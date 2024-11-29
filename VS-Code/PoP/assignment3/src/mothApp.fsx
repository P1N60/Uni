open System
open Asteroids.Vectors
open Asteroids.RandomGenerator
open Asteroids.Asteroids
open Canvas

exception GameOver
type Color = Canvas.color
type Vec = Asteroids.Vectors.Vec
type Object = Object<PrimitiveTree> // kind, tree, position, orientation, heading, speed, acceleration, collisionRadius, age
type State = State<Object> // spaceship, bullets, asteroids

let deltaT = 0.4 // Time step
let canvasWidth, canvasHeight = 1024.0, 512.0
let canvasInterval = 100.0*deltaT |> int |> Some
let numberAsteroids = 1
// *Radius are the collision circle radii, and graphics should be similar
let asteroidRadius = 64.0
let asteroidSmallestRadius = 16.0
let bulletRadius = 4.0
let bulletMaxAge = 15.0
let spaceShipRadius = 14.0

let asteroidShape (r:float) = filledEllipse Color.white r r // Graphics change shape during game
let makeRandomAsteroid _ =
    (Asteroid, asteroidShape asteroidRadius, asteroidRadius)
    |||> makeObject 
    |> setPosition (GetRandomPosition 0.0 canvasWidth 0.0 (canvasHeight - 100.0)) 
    |> setHeading (GetRandomRange 0.0 (2.0*Math.PI))  
    |> setSpeed (GetRandomRange 1.0 5.0)
let asteroids =  List.init numberAsteroids makeRandomAsteroid |> Set.ofList
let bulletShape = filledEllipse Color.red bulletRadius bulletRadius
let makeBullet (p:Vec) (h:float) : Object = 
    (Bullet, bulletShape, bulletRadius)
    |||> makeObject 
    |> setSpeed 20.0 
    |> setPosition p 
    |> setHeading h
let bullets = Set.empty<Object> // Initially there are no bullets
let spaceShipShape = piecewiseAffine Color.blue 3.0 [(-spaceShipRadius, spaceShipRadius); (spaceShipRadius, 0.0); (-spaceShipRadius, -spaceShipRadius)]
let spaceShip =  // There is only ever one spaceship
    (SpaceShip, spaceShipShape, spaceShipRadius)
    |||> makeObject 
    |> setPosition (canvasWidth/2.0,canvasHeight/2.0)
    |> Set.singleton
let initialState = Set.unionMany [spaceShip;bullets;asteroids]

let render (state : State) : Picture =
    let transformObject (o:Object): Canvas.PrimitiveTree =
        let x,y = position o
        let r = radius o
        let a = orientation o
        o
        |> shape
        |> Canvas.translate x y
        |> Canvas.rotate 0.0 0.0 a

    state
    |> Set.toList
    |> List.fold (fun state elm -> onto (transformObject elm) state) emptyTree
    |> make

let update (state : State) (e : Event) : State option =
    let (shipOption,rst) = partitionShip state
    if not (asteroidsExist rst) then
        printfn "Well done"
        raise GameOver
    match shipOption with
        | None ->
            printfn "Programming error: Ship dissapeared"
            raise GameOver
        | Some ship when not (isAlive ship) ->
            printfn "Ship crashed"
            raise GameOver
        | Some ship ->
            match e with
                | LeftArrow -> Set.add (Asteroids.Asteroids.rotate (-5.0*Math.PI/180.0) ship) rst
                | RightArrow -> Set.add (Asteroids.Asteroids.rotate (5.0*Math.PI/180.0) ship) rst
                | UpArrow -> Set.add (accelerate 1.0 ship) rst
                | Key ' ' ->
                    let d = 0.1 + bulletRadius + radius ship
                    let o = orientation ship
                    let v = (d*cos o, d*sin o)
                    let p = ship |> position |> add v
                    let newBullet = makeBullet p o
                    Set.add newBullet state
                | Key 'q' | Key 'Q' ->
                    printfn "Goodbye"
                    raise GameOver
                | TimerTick ->
                    let collide (obj: Object<'T>): Object<'T> list =
                        let shard dh obj =
                            let p = position obj
                            let newH = dh + heading obj
                            let r = radius obj
                            let newR = r/sqrt 2.0
                            let d = 1.1*(r+newR)
                            let newP = add p (d*cos newH,d*sin newH)
                            obj |> setPosition newP |> setRadius newR |> setHeading newH
                        match kind obj with
                            SpaceShip -> [setRadius 0.0 obj]
                            | Bullet -> []
                            | Asteroid -> [shard (-Math.PI/8.0) obj; shard (Math.PI/8.0) obj]
                    let preNextState =
                        state 
                        |> Set.filter (fun o -> kind o <> Bullet || age o < bulletMaxAge) // Remove old bullets
                        |> move deltaT (0.0,canvasWidth-1.0) (0.0,canvasHeight-1.0) // advance simulater 
                    let (collidedPairsLst, notCollided) = detectCollisions preNextState
                    let (bulletBulletPairsLst,otherPairsLst) = // Bullets-bullets do not collide
                        List.partition (fun (a,b) -> (Bullet=kind a) && (Bullet=kind b)) collidedPairsLst
                    let bullets = 
                        List.collect (fun (a,b) -> [a;b]) bulletBulletPairsLst |> Set.ofList
                    let afterCollision = 
                        otherPairsLst
                        |> List.collect (fun (a,b) -> [a;b])
                        |> List.collect collide 
                        |> List.filter (fun o -> (Asteroid <> kind o) || (asteroidSmallestRadius < radius o)) // remove small asteroids
                        |> List.map (fun a -> // update drawing function
                            if Asteroid = kind a then setShape (a |> radius |> asteroidShape) a
                            else a)
                        |> Set.ofList
                    Set.union afterCollision (Set.union bullets notCollided)
                | _ -> state
            |> Some 

[<EntryPoint>]
let main (args : string[]) : int =
    try 
        interact "Asteroid Game" (int canvasWidth) (int canvasHeight) canvasInterval render update initialState
        0
    with 
        | GameOver -> printfn "Game over."; 0
        | exn -> eprintf "Unexpected error:\n%A" exn; 1

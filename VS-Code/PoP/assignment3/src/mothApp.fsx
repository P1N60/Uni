#load "asteroids/asteroids.fs"
open Asteroids.Asteroids
open Asteroids.Vectors
open Asteroids.RandomGenerator

#r "nuget:DIKU.Canvas"
open Canvas
open Color

let w = 1400
let h = w / 2

type Moth(startPos: Vec, startHeading: float) =
    let mutable currentPos = startPos
    let mutable heading = startHeading
    let mothSpeed = 5.0

    new () = Moth (GetRandomPosition 0.0 (float w) 0.0 (float h), GetRandomRange 0.0 (2.0 * System.Double.Pi))

    member this.nextPos(lightOn: bool, lightPos: Vec option) = 
        let targetHeading =
            match lightOn, lightPos with
            | true, Some lp -> ang (sub lp currentPos) // Point toward the light
            | _ -> heading + GetRandomRange -0.174 0.174 // Random jitter (-10 to 10 degrees in radians)

        heading <- targetHeading

        let velocity = (mothSpeed * cos heading, mothSpeed * sin heading)

        let mutable (x,y) = currentPos
        currentPos <- add (cyclic 0.0 w x, cyclic 0.0 h y) velocity

    // Made this in week 10 thursday worksheet (with animation)
    member this.draw() =
        let radius = 10.0
        let pointPolar (x1, x2) (r, t) =
            (x1 + r * cos t, x2 + r * sin t)
        let coords = 
            [0.0 .. 0.1 .. 2.0 * System.Double.Pi + 0.1] 
            |> List.map (fun x -> pointPolar currentPos (radius, x))
        piecewiseAffine white 6.0 coords

    member this.pos = currentPos

type Light() = 
    member this.pos = (float w / 2.0, float h / 2.0)
    member this.drawLight() = 
        let radius = 50.0
        let pointPolar (x1, x2) (r, t) =
            (x1 + r * cos t, x2 + r * sin t)
        let coords = 
            [0.0 .. 0.1 .. 2.0 * System.Double.Pi + 0.1 + 0.2] // I don't know why the circle does not get filled all the way from 0.0 .. 2.0 
            |> List.map (fun x -> pointPolar this.pos (radius, x))
        piecewiseAffine yellow 100.0 coords

let moths = [for e in 1..5 do Moth ()]

let centerLight = Light()

let drawAllMoths (mothList: Moth list) =
    mothList
    |> List.map (fun m -> m.draw())
    |> List.reduce (fun acc tree -> onto acc tree)

let reactAllMoths (mothList: Moth list) (lightOn: bool) =
    let lightPos = if lightOn then Some centerLight.pos else None
    mothList |> List.iter (fun m -> m.nextPos(lightOn, lightPos))

let react (state: Moth list * bool) (ev: Event) : (Moth list * bool) option =
    let (mothList, lightOn) = state
    match ev with
    | Key ' ' -> Some (mothList, not lightOn)
    | TimerTick -> 
        reactAllMoths mothList lightOn
        Some (mothList, lightOn)
    | _ -> Some state

let animation (state: Moth list * bool) = 
    let (mothList, lightOn) = state
    let mothsDrawing = drawAllMoths mothList
    if lightOn then 
        make (onto (centerLight.drawLight()) mothsDrawing)
    else 
        make mothsDrawing

// animating 60 frames pr. second
interact "Moth Simulation" w h (Some (1000 / 60)) animation react (moths, false)
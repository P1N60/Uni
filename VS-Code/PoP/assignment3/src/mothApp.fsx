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
    let mutable _heading = startHeading
    let mutable _pos = startPos

    new() = Moth (GetRandomPosition 0.0 (float w) 0.0 (float h), GetRandomRange 0.0 (2.0 * System.Double.Pi))

     // get and set was taken from the week 11 tuesday "powerBankClamp.fsx" file in order to mutate this.heading and this.pos
    member this.heading
        with get() = _heading 
        and set(c) = _heading <- c

    member this.pos
        with get() = _pos
        and set(c) = _pos <- c

    member this.draw() =
        let radius = 10.0
        let pointPolar (x1, x2) (r, t) =
            (x1 + r * cos t, x2 + r * sin t)
        let coords = 
            [0.0 .. 0.1 .. 2.0 * System.Double.Pi + 0.1] 
            |> List.map (fun x -> pointPolar this.pos (radius, x))
        piecewiseAffine white 6.0 coords

type Light() = 
    member this.pos = (float w / 2.0, float h / 2.0)
    member this.drawLight() = 
        let radius = 50.0
        let pointPolar (x1, x2) (r, t) =
            (x1 + r * cos t, x2 + r * sin t)
        let coords = 
            [0.0 .. 0.1 .. 2.0 * System.Double.Pi + 0.1 + 0.2]
            |> List.map (fun x -> pointPolar this.pos (radius, x))
        piecewiseAffine yellow 100.0 coords

// make 5 moth objects
let moths = [for e in 1..5 do Moth ()]

// make the light object
let centerLight = Light()

let moveMoth (moth: Moth) (lightOn: bool) (lightPos: Vec option) =
    // multiplied move distance factor
    let mothSpeed = 5.0

    // calculated heading randomization
    let targetHeading =
        match lightOn, lightPos with
        | true, Some lp -> ang (sub lp moth.pos)
        | _ -> moth.heading + GetRandomRange -0.174 0.174 // random heading of -10 to 10 degrees in radians
    moth.heading <- targetHeading

    let velocity = (mothSpeed * cos moth.heading, mothSpeed * sin moth.heading)

    // new position with cyclic bounderies calculated
    let mutable (x, y) = moth.pos
    moth.pos <- add (cyclic 0.0 w x, cyclic 0.0 h y) velocity

// combines primitiveTrees of all moths
let drawAllMoths (mothList: Moth list) =
    mothList
    |> List.fold (fun acc m -> onto acc (m.draw())) emptyTree

// run step event for all objects
let reactAllMoths (mothList: Moth list) (lightOn: bool) =
    let lightPos = 
        if lightOn then 
            Some centerLight.pos
        else 
            None
    mothList |> List.iter (fun m -> moveMoth m lightOn lightPos)

// react all ovjects
let react (state: Moth list * bool) (ev: Event) : (Moth list * bool) option =
    let (mothList, lightOn) = state
    match ev with
    | Key ' ' -> Some (mothList, not lightOn)
    | TimerTick -> 
        reactAllMoths mothList lightOn
        Some (mothList, lightOn)
    | _ -> Some state

// make the picture of all combined primitiveTrees
let animation (state: Moth list * bool) = 
    let (mothList, lightOn) = state
    let mothsDrawing = drawAllMoths mothList
    if lightOn then 
        make (onto (centerLight.drawLight()) mothsDrawing)
    else 
        make mothsDrawing

// animating 60 frames pr. second
interact "Moth Simulation" w h (Some (1000 / 60)) animation react (moths, false)
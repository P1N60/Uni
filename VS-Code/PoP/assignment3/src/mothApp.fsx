#load "asteroids/asteroids.fs"
open Asteroids
open RandomGenerator
open Vectors

#r "nuget:DIKU.Canvas"
open Canvas
open Color

let w = 1400
let h = w / 2

type Moth(startPos: float * float) =
    
    let mothSpeed = 4.0
    let mutable currentPos = startPos // Renamed to avoid conflict
    
    member this.nextPos() = 
        let mutable (x, y) = currentPos
        if (x + mothSpeed > w) then
            x <- 0.0
        else
            x <- x + mothSpeed
        if (y + mothSpeed > h) then
            y <- 0.0
        else
            y <- y + mothSpeed
        currentPos <- (x, y)
    
    member this.draw() =
        let radius = 7.0
        let pointPolar (x1, x2) (r, t) =
            (x1 + r * cos t, x2 + r * sin t)
        let coords = 
            [0.0 .. 0.1 .. 2.0 * System.Double.Pi + 0.1] 
            |> List.map (fun x -> pointPolar currentPos (radius, x))
        piecewiseAffine white 4.0 coords

    member this.pos = currentPos // Expose current position
    
// Initialize multiple moths
let moths = 
    [ for _ in 1..5 -> 
        Moth (GetRandomRange 0.0 (float w), GetRandomRange 0.0 (float h)) ]

// Combine multiple PrimitiveTrees into one using `onto`
let drawAllMoths (mothList: Moth list) =
    mothList
    |> List.map (fun m -> m.draw())
    |> List.reduce (fun acc tree -> onto acc tree) // Combine all trees with `onto`

let reactAllMoths (mothList: Moth list) =
    mothList |> List.iter (fun m -> m.nextPos())

let react (mothList: Moth list) (ev: Event) : Moth list option =
    match ev with
    | TimerTick -> 
        reactAllMoths mothList
        Some mothList
    | _ -> Some mothList

let animation (mothList: Moth list) = 
    make (drawAllMoths mothList)

// Run the simulation
interact "Moth Simulation" w h (Some (1000 / 60)) animation react moths

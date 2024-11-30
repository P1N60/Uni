#r "nuget:DIKU.Canvas"

open Canvas
open Color

type Vec = float * float
type hdng = float

let windowWidth : int = 1400
let windowHeight : int = windowWidth / 2

type Moth ((pos: Vec), hdng: hdng) =
    let mutable currentPos = pos
    let mutable currentHdng = hdng

    member this.update(lightPos: Vec option) =
        // Move the moth in the direction of its heading
        let stepSize = 10.0
        let dx, dy = (cos currentHdng, sin currentHdng)
        currentPos <- vecAdd currentPos (vecScale stepSize (dx, dy))
        
        // Wrap around if out of bounds (cyclic domain)
        let wrap (value: float) (maxValue: float) =
            if (value < 0.0) then 
                maxValue + value
            elif (value > maxValue) then 
                value - maxValue
            else 
                value

        currentPos <- (wrap (fst currentPos) (float windowWidth), wrap (snd currentPos) (float windowHeight))
        
        // Update heading
        match lightPos with
        | Some light -> // Light is on, move toward the light
            let toLight = vecNormalize (vecSub light currentPos)
            currentHdng <- atan2 (snd toLight) (fst toLight)
        | None -> // Light is off, random heading change
            let randomChange = (random.NextDouble() * 20.0 - 10.0) * System.Math.PI / 180.0
            currentHdng <- currentHdng + randomChange

    member this.pos() = currentPos
    member this.heading() = currentHdng
    member this.drawCircle() : PrimitiveTree = 
        let radius : float = 6.5
        
        let pointPolar (x1,x2) (r,t) =
                (x1+r*cos t, x2+r*sin t)
        let coords = 
            [0.0..0.1..2.0*System.Double.Pi + 0.1] 
            |> List.map (fun x -> pointPolar (this.pos()) (radius,x)) 
        piecewiseAffine white 1.0 coords

        let react (j: Hand) (ev: Event) : Hand option = 
            match ev with
            | Event.TimerTick -> 
                j.inc()
                Some (j)
            | _ -> None

let moth1 = Moth ((150.0, 500.0), 1.2)
let moth2 = Moth ((300.0, 650.0), 0.3)
let moth3 = Moth((400.0, 600.0), 1.4)
let moth4 = Moth((1100.0, 400.0), 0.5)
let moth5 = Moth((650.0, 100.0), 1.6)

let mothList : Moth list = 
    [moth1; moth2; moth3; moth4; moth5]

let animation (j: Moth) : Picture = 
    let mutable tree : PrimitiveTree =
        tree <- mothList[0]
        let mutable i = 1
        while i < List.length mothList do 
            tree <- onto (tree (mothList[i].drawCircle()))
            i <- i + 1


interact "Moths Simulation" windowWidth windowHeight None animation react
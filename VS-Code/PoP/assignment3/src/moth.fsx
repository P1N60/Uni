#r "nuget:DIKU.Canvas"
open Canvas
open Color

type Moth(startPos: float * float) =
    let w = 1400
    let h = w / 2
    let mothSpeed = 4.0
    let mutable pos = startPos
    
    member this.nextPos() =
        let mutable (x,y) = pos
        if (x + mothSpeed > w) then
            x <- 0
        else
            x <- x + mothSpeed
        if (y + mothSpeed > h) then
            y <- 0
        else
            y <- y + mothSpeed
        pos <- (x,y)
    
    member this.drawTime(initialState) =
        let radius = 7.0

        let drawHand j = 
            let pointPolar (x1,x2) (r,t) =
                (x1+r*cos t, x2+r*sin t)
            let coords = [0.0..0.1..2.0*System.Double.Pi + 0.1] |> List.map (fun x -> pointPolar pos (radius,x)) 
            piecewiseAffine white 4.0 coords

        let react (j: Moth) (ev: Event) : Moth option = 
            match ev with
            | Event.TimerTick -> 
                j.nextPos()
                Some (j)
            | _ -> None

        let animation (j: Moth) = 
            let seconds = pos
            make (drawHand seconds)

        // the simulation updates 60 times pr. second.
        interact "Moth Simulation:" w h (Some (1000/60)) animation react initialState
    
let Moth1 = Moth (55.0, 100.0)

Moth1.drawTime(Moth1)
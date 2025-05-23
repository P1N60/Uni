#r "nuget:DIKU.Canvas"
open Canvas
open Color

// 1.
type Hand(initialValue: int) =
    let mutable _hand = initialValue

    member this.inc() =
        if (_hand = 59) then
            _hand <- 0
        else
            _hand <- _hand + 1

    member this.getSeconds() = 
        float _hand
    
    // 2.
    member this.drawTime(initialState) =
        let w = 1200 // base length of triangle, and smalles triangle to draw
        let h = w / 2
        let center = ((float w/2.0), (float h/2.0))
        let radius = float h/2.0
        let vec = (float w/2.0, 0.0)

        let drawHand j = 
            piecewiseAffine yellow 10.0 [center; vec] |> rotate (float w/2.0) (float h/2.0) (2.0*System.Double.Pi/(60.0/j))
            
        let drawCircle j = 
            let pointPolar (x1,x2) (r,t) =
                (x1+r*cos t, x2+r*sin t)
            let coords = [0.0..0.1..2.0*System.Double.Pi + 0.1] |> List.map (fun x -> pointPolar center (radius,x)) 
            piecewiseAffine yellow 1.0 coords
            
        let react (j: Hand) (ev: Event) : Hand option = 
            match ev with
            | Event.TimerTick -> 
                j.inc()
                Some (j)
            | _ -> None

        let animation (j: Hand) = 
            let seconds = j.getSeconds()
            make (onto (drawCircle()) (drawHand seconds))

        //render "Time:" w h (make (onto drawHand drawCircle))
        interact "Time:" w h (Some 1000) animation react initialState
    
let Hand1 = Hand 55

Hand1.drawTime(Hand1)
#r "nuget:DIKU.Canvas"

open Canvas
open Color

type Vec = float * float
type hdng = float

let windowWidth : int = 1200
let windowHeight : int = windowWidth / 2

type Moth ((pos: Vec), hdng: hdng) =
    member this.pos() = pos
    member this.heading() = hdng
    member this.draw() = 
        let radius : float = 5.0
        
        let drawCircle : PrimitiveTree = 
            let pointPolar (x1,x2) (r,t) =
                (x1+r*cos t, x2+r*sin t)
            let coords = 
                [0.0..0.1..2.0*System.Double.Pi + 0.1] 
                |> List.map (fun x -> pointPolar this.pos (radius,x)) 
            piecewiseAffine white 1.0 coords
        render "Moths Simulation" windowWidth windowHeight (make drawCircle)


let moth1 = Moth((3.0, 4.0), System.Math.PI / 2.0)
let moth2 = Moth((0.0, 0.0), 0.0)



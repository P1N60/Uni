#r "nuget:DIKU.Canvas"
open Canvas
open Color
open System

let width = 400
let radius = 100.0
let center = (200.0,200.0)

let point (x1,x2) =
    let polar (r,t) = 
        (x1+r*cos t,x2+r*sin t)
    polar

let helper angle = point center (radius,angle)
let coords = List.map helper [0.0..0.1..2.0*Math.PI]
let tree = piecewiseAffine yellow 1.0 coords
let draw = make tree

render "Circle" width width draw

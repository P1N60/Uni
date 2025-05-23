#r "nuget:DIKU.Canvas"
open Canvas
open Color

let w = 512 // base length of triangle, and smalles triangle to draw
let h = w / 2

let draw = 
    let length = float (w / 2)
    let height = float (h / 2)
    let tree = filledPolygon red [0.0,0.0; length,0.0; length,height; 0.0,height;]
    make tree

render "Rectangle" w h draw
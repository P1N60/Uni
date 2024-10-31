// 2.b
module Vec2D

type V = float * float

let add ((x1, y1): V) ((x2, y2): V): V =
    ((x1 + x2), y1 + y2)

let neg ((x, y): V): V = 
    (-x, -y)

let scale (k: float) ((x, y): V): V = 
    (k * x, k * y)

let zero: V = 
    (0.0, 0.0)
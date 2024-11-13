// 2.a
module Vec2D

type V = float * float

val add: V -> V -> V          // +  
val neg: V -> V               // unary -
val scale: float -> V -> V    // *, scalar multiplication 
val zero: V                   // 0
(*
add = (x1 + x2, y1 + y2)
neg = (-x, -y)
scale = (k * x, k * y)
zero = (0, 0)
*)

// System.Double.NaN som float violater specificationen for scale
// System.Double.PositiveInfinity som float violater specificationen for scale
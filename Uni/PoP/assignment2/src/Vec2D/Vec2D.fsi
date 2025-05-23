// 2.a
module Vec2D

type V = float * float

val add: V -> V -> V          // +  
val neg: V -> V               // unary -
val scale: float -> V -> V    // *, scalar multiplication 
val zero: V                   // 0
(*
add = (x1 + x2, y1 + y2) This operation creates a vector space, since we get an area between the 2 vectors when we do the operation.
neg = (-x, -y) This does not create, since we are just returning the negative vector of the given vector.
scale = (k * x, k * y) No vector space is created, since we are only scaling a single vector.
zero = (0, 0) This function does not create a vector space, since we only have one empty vector.
*)

// System.Double.NaN as float, violates the specification for scale.
// System.Double.PositiveInfinity as float, violates the specification for scale.

(*
A vector space is the area/field created between 2 vectors when a binary operation that follows the 8 axioms is done on the vectors.
Such spaces naturally require that the vectors are not empty, else the area that is created, would also be empty.
*)
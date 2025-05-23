module Number

type Number = I of int | F of float

let add (v: Number) (w: Number) =
   match (v, w) with
     (I i, I j) -> I (i + j)       // integer addition
   | (I i, F f) -> F (float i + f) // float addition
   | (F f, I i) -> F (f + float i) // float addition
   | (F f, F g) -> F (f + g)       // float addition


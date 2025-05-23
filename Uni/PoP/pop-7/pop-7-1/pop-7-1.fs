module Number

type Number = I of int | F of float

let add (v : Number, w : Number) = 
    match (v, w) with
    | (I v, I w) -> I (v + w)
    | (I v, F w) -> F (float v + w)
    | (F v, I w) -> F (v + float w)
    | (F v, F w) -> F (v + w)

let multiply (v : Number, w : Number) = 
    match (v, w) with
    | (I v, I w) -> I (v * w)
    | (I v, F w) -> F (float v * w)
    | (F v, I w) -> F (v * float w)
    | (F v, F w) -> F (v * w)
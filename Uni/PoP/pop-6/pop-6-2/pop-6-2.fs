// This must match the signature file
module customTypes 

type Custom = I of int

let add (x: Custom, y: Custom) =
    match x, y with
    | (I x, I y) -> I (x + y)
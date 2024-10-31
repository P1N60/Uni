#load "Vec2D.fs"
open Vec2D

// 2.c
let isDistributive (c: float) (v: V) (w: V): bool =
    // k * (x + y) = (k * x) + (k * y)
    if (scale c (add v w) = add (scale c v) (scale c w)) then
        true
    else
        false

// 2.d
let test (c: float) (v: V) (w: V) = 
    match isDistributive c v w with
    | true -> Ok (c, v, w)
    | _ -> Error (c, v, w)

// 2.e
printfn "%A" (test 2.0 (1.0, 1.0) (2.0, 2.0))
printfn "%A" (test 0.0 (-1.0, 1.0) (0.0, 2.0))
printfn "%A" (test System.Double.NaN (1.0, 1.0) (2.0, 2.0))
printfn "%A" (test System.Double.PositiveInfinity (1.0, 0.0) (0.0, 1.0))
(* prints:
Ok (2.0, (1.0, 1.0), (2.0, 2.0))
Ok (0.0, (-1.0, 1.0), (0.0, 2.0))
Error (nan, (1.0, 1.0), (2.0, 2.0))
Error (infinity, (1.0, 0.0), (0.0, 1.0))
*)
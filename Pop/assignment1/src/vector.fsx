let lengthVector (a: float, b: float) : float = 
    sqrt (a ** 2 + b ** 2)
printfn "Length of vector: %f" (lengthVector (1.0, 1.0)) //prints: Length of vector: 1.414214
printfn "Length of vector: %f" (lengthVector (2.0, 1.0)) //prints: Length of vector: 2.236068

let addVector (a: float, b: float) (c: float, d: float) : float * float= 
    (a + c), (b + d)
printfn "Added vector: %A" (addVector (1.0, 2.0) (1.0, 2.0)) //prints: Added vector: (2.0, 4.0)
printfn "Added vector: %A" (addVector (4.0, 3.0) (-1.0, -2.0)) //prints: Added vector: (3.0, 1.0)

let extVector (factor: float) (a:float, b:float) : float * float = 
    (factor * a, factor * b)
printfn "Extended vector: %A" (extVector 2.0 (2.0, 1.0)) //prints: Extended vector: (4.0, 2.0)
printfn "Extended vector: %A" (extVector -1.0 (2.0, 1.0)) //prints: Extended vector: (-2.0, -1.0)
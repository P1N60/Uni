let (x: int) = 3

let rec factorial (x: int) : int = 
    match x with
    | 1 -> x
    | _ -> x * factorial (x - 1)
printfn "Factorial = %d" (factorial x)

let rec fibonacci (x: int) = 
    let l = []
    match x with
    | 0 -> l
    | _ -> l

printfn "fibonacci = %A" (fibonacci x)
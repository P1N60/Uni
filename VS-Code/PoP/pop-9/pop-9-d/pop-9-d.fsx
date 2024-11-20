type 'a option = Some of 'a | None
let floatDiv (x: float) (y: float) : float option = 
    match y with 
    | 0.0 -> None 
    | _ -> Some (x / y)

printfn "%A" (floatDiv 2.0 2.0)
printfn "%A" (floatDiv 1.0 0.0)

let test x y = 
    match floatDiv x y with
    | None -> Error (floatDiv x y)
    | _ -> Ok (floatDiv x y)

printfn "%A" (test 2.0 2.0)
printfn "%A" (test 1.0 0.0)

type Result<'a,'b> = Ok of 'a | Error of 'b
let floatDiv' (x: float) (y: float) : Result<float,string> = 
    match y with
    | 0.0 -> Error "Division by 0.0"
    | _ -> Ok (x / y)

printfn "%A" (floatDiv' 2.0 2.0)
printfn "%A" (floatDiv' 1.0 0.0)

// Results in Error for some reason
exception ZeroDiv of float
let floatDiv'' (x: float) (y: float) : float =
    match y with
    | 0.0 -> raise (ZeroDiv y)
    | _ -> x / y

printfn "%A" (floatDiv'' 2.0 2.0)
printfn "%A" (floatDiv'' 1.0 0.0)
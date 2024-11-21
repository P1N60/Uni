// Error values and exceptions
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

exception ZeroDiv of float
let floatDiv'' (x: float) (y: float) : float =
    match y with
    | 0.0 -> raise (ZeroDiv y)
    | _ -> x / y

printfn "%A" (floatDiv'' 2.0 2.0)
// Results in Error, which is intended
// printfn "%A" (floatDiv'' 1.0 0.0)

// Standard I/O
printfn "%s" "Standard I/O:"

open System
let convertBack () =
    let F = (float (Console.ReadLine())) * 1.8
    Console.WriteLine (string F)

// 3. File I/O
open System.IO
let cp (file1: string) (file2: string) : unit =
    File.WriteAllText(file2, File.ReadAllText(file1))

cp "f1.txt" "f2.txt"

let cpUp (file1: string) (file2: string) : unit =
    let s = File.ReadAllText(file1)
    File.WriteAllText(file2, s.ToUpper())

cpUp "f1.txt" "f2.txt"
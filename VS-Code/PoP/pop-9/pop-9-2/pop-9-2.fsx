// 1. Error values and exceptions


// 2. Standard I/O
open System

(*
[<EntryPoint>]
let printArgs (args: string array) = 
    do Console.WriteLine "Type some arguments"
    let n = Array.length args
    match n with
    | 0 -> Console.WriteLine "No argument received."
    | 1 -> Console.WriteLine "1 argument received."
    | _ -> Console.Write n; Console.WriteLine " arguments received."
    let mutable i = 1
    for a in args do
        Console.Write i 
        Console.Write ": "
        Console.WriteLine a
        i <- i + 1
    0// <--- this is here for some reason
*)

// 3. File I/O
open System.IO

let cat (f1: string) (f2: string) (f3: string) : unit =
    let files = [f1; f2; f3]
    for file in files[0..(List.length files) - 2] do
        File.AppendAllText(f3, File.ReadAllText(file))
        
cat "f1.txt" "f2.txt" "f3.txt"


open System.IO
open System

Console.Write "lol"

let test = File.CreateText "test.txt"

let e = Console.ReadLine
printfn "%A" e

test.Close
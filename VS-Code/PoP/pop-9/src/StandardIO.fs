module StandardIO

open System // System is module and can be opened
            // System.Console is a class; it cannot be opened.

let fahrenheit (c: float) : unit =
  if c < -273.15 then failwith "input too small"
  else printfn "Fahrenheit: %f" (9.0 / 5.0 * c + 32.0)

// Interactively convert Celsius to Fahrenheit on terminal
let convert () = 
    do Console.Write "Temperature in degrees Celcius: "
    let s = Console.ReadLine()
    do try fahrenheit (float s) with 
         Failure s -> Console.Error.WriteLine s
       | _ -> Console.Error.WriteLine "Expecting number"

// [<EntryPoint>]
let main (args: string array) : int =
    for a in args do printfn "%s" a
    0                                // status code "ok"

// Summing numbers with repeated input prompting of summands
let sumIO () = 
    let rec loop (a: float) : float =
        match Console.ReadLine() with "" -> a
                                    | s -> loop (a + float s)
    do Console.WriteLine "Enter numbers (end with empty line):"
    try printfn "Sum: %f" (loop 0.0) 
    with _ -> Console.Error.WriteLine "Expecting numbers"
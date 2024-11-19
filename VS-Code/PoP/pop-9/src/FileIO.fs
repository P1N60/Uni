module FileIO

open System.IO // module containing classes File, StreamReader, StreamWriter, FileStream etc.

// [<EntryPoint>]
// possible entry point since function has type string array -> int
let main (args: string array): int =
  let rec loop n (r: StreamReader) =
    if r.EndOfStream 
    then n
    else ignore (r.ReadLine())
         loop (n+1) r
  try 
    if Array.length args > 0 
    then do printfn "Number of lines: %d" 
                    (loop 0 (File.OpenText (args[0])))
         0  // exit code: success
    else do eprintfn "Expects a file name as argument" 
         1  // exit code: failure
  with ex -> do eprintfn "%s" ex.Message;
             1 // exit code: failure

// Recursive specification of fib -- extremely inefficient!
let rec fib n = 
    if n <= 2 
    then 1 
    else fib (n-1) + fib (n-2)
// Output Fibonacci numbers i to n on stdout
let rec loop n i (w: StreamWriter) =
        if i > n 
        then w.Close() // close stream 
        else w.WriteLine (string (fib i))
             loop n (i+1) w

// Store first Fibonacci numbers in out.txt
let main' (args: string array): int =
    try
        loop 40 1 (File.CreateText "out.txt")
        0
    with
        ex -> eprintf "%s" ex.Message
              1


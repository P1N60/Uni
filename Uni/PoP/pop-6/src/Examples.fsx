open DisjointUnion

// Using generic stacks
open Stack

printfn "empty = %A" empty
printfn "pop (push 3 (push 2 (push 1 empty))) = %A" 
        (pop (push 3 (push 2 (push 1 empty))))
printfn "pop (push (String \"blib\") 
             (push (Int 500) 
             (push (String \"blob\") empty))) = %A"
        (pop (push (String "blib") 
             (push (Int 500) 
             (push (String "blob") empty))))

// Evaluation of instruction lists in reverse Polish notation, using stacks
open Instruction

printfn "eval [Value 0 ; Value 5 ; Divide ; Value 8 ; Value 19 ; Minus] = %A"
        (eval [Value 0 ; Value 5 ; Divide ; Value 8 ; Value 19 ; Minus])
        
try printfn "eval [Value 5 ; Value 0 ; Divide] empty = %A"      
        (eval [Value 5 ; Value 0 ; Divide] empty) 
with :?System.DivideByZeroException -> printfn "Division by zero"


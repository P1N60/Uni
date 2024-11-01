#load "Sort.fs"
open Sort

// 3.d
printfn "%A sorted = %A" [9] (isortRec [9])
printfn "%A sorted = %A" [] (isortRec [])
printfn "%A sorted = %A" [-1; -3] (isortRec [-1; -3])
printfn "%A sorted = %A" [7; 1; 13; 0; -1] (isortRec [7; 1; 13; 0; -1])
(* prints:
[9] sorted = [9]
[] sorted = []
[-1; -3] sorted = [-3; -1]
[7; 1; 13; 0; -1] sorted = [-1; 0; 1; 7; 13]
*)

printfn "%A sorted = %A" [9] (isortIter [9])
printfn "%A sorted = %A" [] (isortIter [])
printfn "%A sorted = %A" [-1; -3] (isortIter [-1; -3])
printfn "%A sorted = %A" [7; 1; 13; 0; -1] (isortIter [7; 1; 13; 0; -1])
(* prints:
[9] sorted = [9]
[] sorted = []
[-1; -3] sorted = [-3; -1]
[7; 1; 13; 0; -1] sorted = [-1; 0; 1; 7; 13]
*)
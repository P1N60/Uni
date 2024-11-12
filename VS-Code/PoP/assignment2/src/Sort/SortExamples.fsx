#load "Sort.fs"
open Sort

// 3.d
printfn "%A sorted with isortRec = %A" [9] (isortRec [9])
printfn "%A sorted with isortRec = %A" [] (isortRec [])
printfn "%A sorted with isortRec = %A" [-1; -3] (isortRec [-1; -3])
printfn "%A sorted with isortRec = %A" [7; 1; 13; 0; -1] (isortRec [7; 1; 13; 0; -1])
(* prints:
[9] sorted with isortRec = [9]
[] sorted with isortRec = []
[-1; -3] sorted with isortRec = [-3; -1]
[7; 1; 13; 0; -1] sorted with isortRec = [-1; 0; 1; 7; 13]
*)

printfn "%A sorted with isortIter = %A" [9] (isortIter [9])
printfn "%A sorted with isortIter = %A" [] (isortIter [])
printfn "%A sorted with isortIter = %A" [-1; -3] (isortIter [-1; -3])
printfn "%A sorted with isortIter = %A" [7; 1; 13; 0; -1] (isortIter [7; 1; 13; 0; -1])
(* prints:
[9] sorted with isortIter = [9]
[] sorted with isortIter = []
[-1; -3] sorted with isortIter = [-3; -1]
[7; 1; 13; 0; -1] sorted with isortIter = [-1; 0; 1; 7; 13]
*)

// 3.e
printfn "%A sorted with isortImp = %A" [|9|] (isortImp [|9|])
printfn "%A sorted with isortImp = %A" [||] (isortImp [||])
printfn "%A sorted with isortImp = %A" [|-1; -3|] (isortImp [|-1; -3|])
printfn "%A sorted with isortImp = %A" [|7; 1; 13; 0; -1|] (isortImp [|7; 1; 13; 0; -1|])
(* prints:
[|9|] sorted with isortImp = [|9|]
[||] sorted with isortImp = [||]
[|-1; -3|] sorted with isortImp = [|-3; -1|]
[|7; 1; 13; 0; -1|] sorted with isortImp = [|-1; 0; 1; 7; 13|]
*)
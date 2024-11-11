#load "pop-8-1.fs"
#load "rootedTree.fs"
open ConsList

//printfn "%A" (length (Cons (false, Cons (true, Nil))))

open rootedTree

let (tree: Tree<int>) = Fork (Leaf 1, Fork (Fork (Leaf 1, Leaf 1), Leaf 20))

printfn "%A" (size tree)
printfn "%A" (prod tree)
printfn "%A" (traverse tree)
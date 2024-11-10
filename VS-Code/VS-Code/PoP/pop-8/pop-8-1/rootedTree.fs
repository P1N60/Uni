module rootedTree

type Tree<'a> = Leaf of 'a | Fork of Tree<'a> * Tree<'a>

let rec size (t: Tree<'a>) =
    match t with
    | Leaf _ -> 1
    | Fork (t1, t2) -> size t1 + size t2

let rec prod (t: Tree<int>) =
    match t with
    | Leaf v -> v
    | Fork (t1, t2) -> prod t1 * prod t2

(*
let traverse (t: Tree<'a>): 'a list =
    fold ((fun x -> [x]), fun (xs, ys) -> xs @ xy) t
*)

let rec traverse t xs =
    match t with
    | Leaf v -> v :: xs
    | Fork (t1, t2) -> traverse t1 (traverse t2 xs)

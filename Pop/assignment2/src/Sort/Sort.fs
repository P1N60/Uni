module Sort

// 3.a
let rec headInsert (h: int) (t: int list): int list =
    match t with
    | [] -> [h]
    | head :: tail when h <= head ->
        h :: t
    | head :: tail ->
        head :: (headInsert h tail)

let rec isortRec (l: int list): int list =
    match List.length l with
    | 0 | 1 -> l
    | _ -> headInsert l.Head (isortRec l.Tail)

// 3.b

module Sort

// 3.a
let rec headInsert (h: int) (t: int list): int list =
    match t with
    | [] -> [h]
    | head :: tail when (h <= head) -> h :: t
    | head :: tail -> head :: (headInsert h tail)

let rec isortRec (l: int list): int list =
    match List.length l with
    | 0 | 1 -> l
    | _ -> headInsert l.Head (isortRec l.Tail)

// 3.b
let isortRec' (l: int list) =
    match List.length l with
    | 0 | 1 -> l
    | _ -> List.foldBack headInsert l []

// 3.c
let rec isortIter' (xs: int list) (ys: int list): int list =
    match ys with
    | [] -> xs
    | h :: t -> isortIter' (headInsert h xs) t

let isortIter (ys: int list): int list = 
    isortIter' [] ys

// 3.e 
let isortImp (A: int array): int array =
    let n = Array.length A
    let mutable e = 0
    for i = 0 to n - 1 do
        for j = n - 1 downto i + 1 do
            if A[j] < A[j - 1] then 
                e <- A[j]
                A[j] <- A[j - 1]
                A[j - 1] <- e
    A
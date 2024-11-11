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
    let mutable i = 0
    while i <= Array.length A do
        let mutable j = i
        while A[i - j] > A[i] do
            j <- j + 1
        A[i - j] <- A[i]
        i <- i + 1
    A

    
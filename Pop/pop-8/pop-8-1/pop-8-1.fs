module ConsList

type ConsList<'a> = Nil | Cons of 'a * ConsList<'a>

let rec length (xs: ConsList<'a>) = 
    match xs with
    | Nil -> 0
    | Cons (_, xs) -> 1 + length xs

let rec sum (xs: ConsList<int>) =
    match xs with
    | Nil -> 0
    | Cons (x, xs) -> x + length xs
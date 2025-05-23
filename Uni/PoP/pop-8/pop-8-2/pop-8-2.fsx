type ConsList<'a> = Nil | Cons of 'a * ConsList<'a>

// * a)
let rec toList (cl: ConsList<'a>): 'a list = 
    match cl with
    | Nil -> []
    | Cons (e, nl) -> e :: toList nl

printfn "%A" (toList (Cons(true, Cons(false, Nil))))

// * b)
let genConsList (n: int): ConsList<int> = 
    let mutable i = n
    match n with
    | 0 -> Nil
    | _ ->
        let mutable cl = Cons (i, Nil)
        while i - 1 > 0 do
            i <- i - 1
            cl <- Cons (i, cl)
        cl

printfn "%A" (genConsList 5)


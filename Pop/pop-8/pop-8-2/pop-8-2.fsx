type ConsList<'a> = Nil | Cons of 'a * ConsList<'a>

let rec toList (cl: ConsList<'a>): list = 
    match cl with
    | Nil -> ()
    | Cons (e, nl) -> [e] @ toList nl
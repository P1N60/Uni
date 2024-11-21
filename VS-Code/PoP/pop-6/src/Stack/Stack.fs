module Stack

type Stack<'a> =  'a list 

exception PopError

let empty : Stack<'a> = []

let push (elmt : 'a) (stack : Stack<'a>) = elmt :: stack
let isEmpty (stack : Stack<'a>) = stack.IsEmpty 
let pop (stack : Stack<'a>) = 
    match stack with
    | [] -> raise PopError
    | elmt :: rest -> (elmt, rest)
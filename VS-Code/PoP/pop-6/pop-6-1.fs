module test

type 'a option = Some of 'a | None
type 'a result = Ok of 'a | Error of string

let valOf (oval: int option) (defaultVal: int): int =
    match oval with
    |   Some v -> v
    |   None -> defaultVal

type IntStack = int list

let empty : IntStack = []

let push elmt (stack : IntStack) = elmt :: stack
let isEmpty (stack : IntStack) = 
    match stack with
    | [] -> true
    | _ -> false
let pop (stack : IntStack): (int * IntStack) option = 
    match stack with
    | [] -> None
    | elmt :: rest -> Some (elmt, rest)
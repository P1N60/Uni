module Exception

// Integer division, return None when dividing by zero
let mydiv (a: int) (b: int): int option =
    if b = 0
    then None
    else Some (a / b)

let bind (f: 'a -> 'b option): 'a option -> 'b option =
    fun x -> match x with None -> None
                        | Some y -> f y

let ex1 = Option.bind (mydiv 8) (mydiv 5 0)

open Result  // Standard F# module containing type Result<'a,'b>
             // and function bind


// Integer division, return Error message when dividing by zero
let mydiv' (a: int) (b: int): Result<int,string> =
    if b = 0
    then Error "Division by zero"
    else Ok (a / b)

let ex2 = Result.bind (mydiv' 8) (mydiv' 5 0)

// Integer division, raise exception when dividing by zero
let mydiv'' (a: int) (b: int): int = a / b

// Commented out since raising unhandled exception stops evaluation
// let ex3 = mydiv'' 8 (mydiv'' 5 0)

// extend exn with "| MyError" 
exception MyError 
// extend exn with "| MyArgExn of int"         
exception MyArgExn of int  

let e1 : exn = MyError
let e2 : exn = MyArgExn 5

let isMyError = (e1 = e2)    // $\leadsto$ false
let isMyArgExn =
    match e2 with MyArgExn _ -> "yes" 
                | _ -> "no"

// Commented out since raising unhandled exception stops evaluation
// let ex4 = "hello" + raise (MyArgExn 42) + "world"

exception MyExnArg of int
let f () = raise (MyExnArg 5)
let y = try f () with MyExnArg x -> x

// Integer division, returns maximum 32-bit integer when dividing by zero
let mydiv''' a b : int =
  try mydiv'' a b  // raises built-in .Net exception if b is zero
  with :? System.DivideByZeroException -> System.Int32.MaxValue

let ex5 = mydiv''' 5 0
let ex6 = mydiv''' 8 (mydiv''' 5 0)

exception Failure of string // built-in F# exception

// raises Failure, built-in F# function
let failwith (message: string) : 'a = raise (Failure message)
// raises System.ArgumentException, built-in F# function
let invalidArg (message: string) (paramName: string): 'a = 
    raise (System.ArgumentException (message, paramName))

// convert Celcius to Fahrenheit, raise exception for invalid input
let toFahrenheit c =
    if c < -273.15 
    then invalidArg "not a temp" "c" 
    else 9.0 / 5.0 * float(c) + 32.0

// handle system exception using 'as' and object access notation
let tryToFahrenheit () =
    try toFahrenheit -274.0 ; ""  // output type is string
    with :? System.ArgumentException as ex -> ex.ParamName + " " + ex.Message
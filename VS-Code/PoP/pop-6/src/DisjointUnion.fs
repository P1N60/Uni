module DisjointUnion

// Lists with different element types
type intlist = int list
type stringlist = string list
type intlistlist = intlist list

// 'a option is type of all elements in 'a, tagged by constructor Some, plus extra element None
type 'a option = Some of 'a | None // built into F#

// Options with different element types
type intoption = int option
type stringoption = string option
type stringoptionoption = stringoption option

// Disjoint union of integers, floating-point numbers and strings
// Example values: Int 5, Float 4.5, String "blob"
type Value = Int of int | Float of float | String of string

// Disjoint union of integers and strings; 
// recommended usage: Ok v for 'expected' result, Error s for error with associated error message
type IntResult = IOk of int | IError of string 

// Disjoint union of 'a (any type) and strings; recommended usage as above
type 'a result = Ok of 'a | Error of string

// Examples of functions whose input is from a disjoint union
let valOf (oval: int option) (defaultVal: int): int =
    match oval with
      Some v -> v 
    | None -> defaultVal

// return string representation of input value
let show (v: Value) = 
    match v with
      Int i -> string i  
    | Float f -> string f
    | String s -> s

// Deliberate practice exercises, Week 6, Part 1.

// Given integer v, returns Some v if v is positive and None otherwise with the following type signature:
let f1 (v: int): int option =
   if v > 0
   then Some v
   else (* v <= 0 *) None

// Given integer v, returns Some(v) if v is even and None otherwise.
let f2 (v: int): int option =
   if v % 2 = 0
   then Some v 
   else None

// Given string s, returns Some(s) if s is longer than 5 characters and None otherwise.
let f3 (s: string): string option =
   Some s // correct type, but wrong implementation; fix it!

// ...

// Given integer len and boolean bval, returns an array of length len whose elements are initialized to boolean value b if bval = Some(b); it returns an empty array (array of length 0) if v = None.
let f6 (len: int) (bval: bool option): bool array =
    [| true; false |] // correct type, but wrong implementation; fix it!
module HOF

// Function abstraction and application
let r = (fun x -> x + 1) 15

// Bindings of names to values, including function values
let x = 18
let g = fun y -> x + y 
let k = 14
let addk l = k + l                    // let addk = fun l -> k + l
let double m = 2 * m                  // let double = fun m -> 2 * m
let (<<) g f = fun x -> g (f x)       // let (<<) = fun g f x -> g (f x)
let h = double << addk

// Recursive functions defined by structural recursion on lists
let rec length xs = 
      match xs with
         [] -> 0
       | x :: xs' -> 1 + length xs'
let rec prod xs = 
      match xs with
         [] -> 1
       | x :: xs' -> x * prod xs'

// Parameterized skeleton function for structural recursion on lists
let listhom e g =  // parameters e and g 
    let rec f xs = // skeleton function 
      match xs with
        [] -> e   
      | x :: xs' -> g x (f xs') 
    f

// Function defined using listhom

// let length' = listhom 0 (fun x r -> 1 + r) -- type error in F#
// Eta-expanded version of length': Apply to parameter xs on both sides
let length' xs = listhom 0 (fun x r -> 1 + r) xs
let prod' xs = listhom 1 (fun x r -> x * r) xs

let map f xs = listhom [] (fun x r -> f x :: r) xs
let map' f xs = List.foldBack (fun x r -> f x :: r) xs []
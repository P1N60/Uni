let rec printList l =
    match l with
    | [] -> ()
    | head::tail -> printfn "%A" head; printList tail //Tail recursion
printList [1; 2; 3; 4]
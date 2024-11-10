//The function should have an integer for a month of the user's choosing, and output the number of days in the month of the input.
let day_labeler month = 
    match month with
    | 1 | 3 | 5 | 7 | 8 | 10 | 12 -> "31"
    | 2 -> "28"
    | 4 | 6 | 9 | 11 -> "30"
    | _ -> "Not a valid month"

//printfn "%s" (day_labeler 1)

let l = [1; 2; 3; 4]
let nl = 
    l |> List.map (fun n -> n + 1)

l |>  List.iter (fun l -> printf "%A" l)
printfn ""
nl |> List.iter (fun nl -> printf "%A" nl)
printfn ""
printf "%A" (l |> List.filter (fun l -> (l % 2) = 0))
printfn ""
printf "%A" (l |> List.filter (fun l -> (l % 2) = 1))
printfn ""
printfn "%A" (l |> List.map (fun l -> l: float))
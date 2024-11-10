let fizzBuzz (l: int list) = 
    l |> List.map (fun e -> 
        match e with
        | _ when ((e % 3 = 0) || (e % 4 = 0)) -> printfn "%d = FizzBuzz" e
        | _ when (e % 3 = 0) -> printfn "%d = Buzz" e
        | _ when (e % 4 = 0) -> printfn "%d = Fizz" e
        | _ -> printfn "%d = %d" e e)

fizzBuzz [1..15]
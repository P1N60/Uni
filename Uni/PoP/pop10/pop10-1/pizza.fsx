type Topping = 
    | Tomato 
    | Cheese of float 
    | Pepperoni of int

type Pizza(toppings: Topping list) =
    let mutable _toppings = toppings

    let isVegetarian topping =
        match topping with
        | Pepperoni _ -> false
        | _ -> true

    let addExtra topping =
        match topping with
        | Tomato -> Tomato
        | Cheese g -> Cheese (g + 20.0)
        | Pepperoni p -> Pepperoni (p + 2)

    member this.Toppings = _toppings
    member this.IsVegetarian() = List.forall isVegetarian _toppings
    member this.ExtraAll() = _toppings <- List.map addExtra _toppings
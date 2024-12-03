type dog (n: string, w: int, h: int) =
    member this.name = n
    member this.weight = w
    member whatever.height = h
    
let kennel = [dog ("HASSAN", 50, 62); dog ("Jens", 30, 40)]

List.iter (fun (d: dog) -> printfn "%s (%d, %d)" d.name d.weight d.height) kennel
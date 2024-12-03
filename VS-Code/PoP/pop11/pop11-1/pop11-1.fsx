(*
type dog (n: string, w: int, h: int) =
    member this.name = n
    member this.weight = w
    member whatever.height = h
    
let kennel = [dog ("HASSAN", 50, 62); dog ("Jens", 30, 40)]

List.iter (fun (d: dog) -> printfn "%s (%d, %d)" d.name d.weight d.height) kennel
*)

type mAh = int

type powerBank (maxCapacity: mAh) =
    let mutable currentCapacity : mAh = maxCapacity - 3000

    member this.getPower =
        printfn "%d mAh/ %d mAh" currentCapacity maxCapacity

let powerBank1 = powerBank 5000
let powerBank2 = powerBank 10000
let powerBank3 = powerBank 3000

powerBank1.getPower
powerBank2.getPower
powerBank3.getPower

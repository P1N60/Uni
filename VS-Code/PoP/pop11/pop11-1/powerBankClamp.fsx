type powerBank(capacity:int) = 
    let mutable _currentCapacity = capacity
    member val maxCapacity = capacity with get
    member this.currentCapacity
        with get() = _currentCapacity
        and set(c) = _currentCapacity <- max 0 (min c this.maxCapacity)

let p = powerBank(5000)
printfn "%A, %A, %A" p p.maxCapacity p.currentCapacity
p.currentCapacity <- 3000
printfn "%A, %A, %A" p p.maxCapacity p.currentCapacity

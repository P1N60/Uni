type cm = int

let volume (length: cm) (height: cm) (width: cm) = length*height*width

//printfn "the volume is %d" (volume 10 20 30)

type qnum = int * int

let qplus (x: qnum) (y: qnum) = 
    let (a, b) = x
    let (c, d) = y
    ((a * d) + (b * c)), (b * d)

let qmult (x: qnum) (y: qnum) =
    let (a, b) = x
    let (c, d) = y
    (a * c) + (a * d) + (b * c) + (b * d)

let t = qplus (1, 2) (-1, 2)
let t2 = qmult (1, 2) (-1, 2)

//printfn "1/2 + (-1/2) = %d/%d" (fst t) (snd t)

let (deposit: float) = 300000.0

let interest_rate (deposit: float): float = 
    if (deposit = 0.0) then 0.0
    elif (deposit <= 10000.0) then 1.0
    elif (deposit <= 50000.0) then 2.0
    else deposit * 0.00001

//printfn "Interest rate = %f" (interest_rate deposit)
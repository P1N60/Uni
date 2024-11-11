let mutable x = 4.0
x <- x + 5.0
//printfn "%f" x

let array1 : string array = Array.zeroCreate 10
array1[4] <- "Hello World!"
//printfn "%A" array1

let array2 : int array = Array.zeroCreate 4
array2[0] <- 1
//printfn "%A" array2

let array3 : float array = Array.init 100 (fun x -> x)
//printfn "%A" array3

//for i = 0 to 4 do printfn "%A" (i + 1)

let array4 : string array = Array.zeroCreate 10
//for e in array4 do printfn "%A" e

let array5 : int array = Array.zeroCreate 4
//for e in array5 do printfn "%d" e

let bubblesort (A: int array) =
    let n = Array.length A
    let mutable e = 0
    for i = 0 to n - 1 do
        for j = n - 1 downto i + 1 do
            if A[j] < A[j - 1] then 
                e <- A[j]
                A[j] <- A[j - 1]
                A[j - 1] <- e
    A
printfn "%A" (bubblesort [|9865; 40; 3; 66; 7|])
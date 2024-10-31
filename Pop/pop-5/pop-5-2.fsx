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
let binarySearch (target: int) (A: int array) : bool = 
    let mutable (j: int) = (Array.length A)/2
    if Array.length A <= 0 then 
        false
    else
        let mutable (i: int) = A[j]
        while i <> target && j - 1 >= 0 && j + 1 <= Array.length A - 1 do
            if (i < target) then
                j <- j + 1
            else
                j <- j - 1
            i <- A[j]
        if (i = target) then
            true
        else
            false
printfn "%b" (binarySearch 20 (bubblesort [|1; 4; 3; 7; 10; 11; 170; 19; 20|]))
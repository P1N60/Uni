#load "HOF.fs"
open HOF

printfn "r = %A" r
printfn "x = %A" x
printfn "g = %A" (fun y -> x + y)
printfn "k = %A" 14
printfn "addk = %A" (fun l -> k + l)
printfn "double = %A" (fun m -> 2 * m) 
printfn "(<<) = %A" (fun g f x -> g (f x)) 
printfn "h = %A" (double << addk)

printfn "g 19 = %A" (g 19)
printfn "addk 37 = %A" (addk 37)
printfn "double 15 = %A" (double 15)
printfn "double << addk = %A" (double << addk)
printfn "(double << addk) 39 = %A" ((double << addk) 39)

printfn "length [1..87] = %A" (length [1..87])
printfn "prod [4..9] = %A" (prod [4..9])
printfn "length' [1..87] = %A" (length' [1..87])
printfn "prod' [4..9] = %A" (prod' [4..9])

printfn "map double [3..17] = %A" (map double [3..17])
printfn "map' double [3..17] = %A" (map' double [3..17])

#load "NumberTest.fs"
open NumberTest

printfn "testNeutralResults () = %A" (testNeutralResults ())
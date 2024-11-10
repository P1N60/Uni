module NumberTest
open Number
type Result<'a> = Ok of 'a | Error of 'a 
// test P x: classifies x as to whether it satisfies property P or not 
let test P = fun x -> if P x then Ok x else Error x
// property to be tested: neutrality of add
// Note: special case for equality on NaN required
let isNeutral = fun x -> 
                  match (x, add x (I 0)) with
                    (F y, F z) -> if System.Double.IsNaN y 
                                  then System.Double.IsNaN z
                                  else z = y
                  | (_, r) -> r = x

// classifies inputs into satisfying/not satisfying the neutrality property
let testNeutral = List.map (test isNeutral)
// test inputs derived by input partititioning of type Number
let testInputs = [
    I -2147483648; I -1; I 0; I 1; I 2377; I 2147483647;
    F System.Double.NegativeInfinity; F 2.2250738585072014e-308; 
    F -1.0; F -System.Double.Epsilon; F 0.0; F System.Double.Epsilon; 
    F 1.0; F 47771354343.98989988; F 1.7976931348623158e+308; 
    F System.Double.PositiveInfinity; F System.Double.NaN ]
// test results 
let testNeutralResults () = testNeutral testInputs 
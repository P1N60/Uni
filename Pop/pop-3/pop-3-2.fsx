// ? Made by rcb933 & kft410
printfn "" // Creates blank space in-between each compiling so it's easy to read
let students = 
    [ 
        ("John", 0)
        ("Alice", 2)
        ("Bob", 4)
        ("Charlie", 2)
        ("David", 1)
        ("Eve", 4)
        ("Frank", 3)
        ("George", 2)
        ("Hannah", 1)
        ("Isaac", 3)
        ("Julia", 2)
        ("Kevin", 0)
        ("Lily", 4)
        ("Michael", 2)
        ("Nina", 1)
        ("Oliver", 3)
        ("Penelope", 2)
        ("Quincy", 4)
        ("Rachel", 1)
        ("Samuel", 0)
        ("Tessa", 0)
        ("Uma", 2)
        ("Victor", 4)
        ("Wendy", 1)
        ("Xavier", 3)
        ("Yvonne", 2)
        ("Zoe", 4)
    ]

let rec sortedStudents score students =
    match students with
    | [] -> []
    | (name, s) :: tail ->
        if s = score then (name, s) :: sortedStudents score tail
        else sortedStudents score tail

let rec filterPrint n = 
    match n with
    | _ when n < 5 -> 
    printfn "%A" (sortedStudents n students) 
    filterPrint (n + 1)
    | _ -> exit 1

filterPrint 0 // start value

(* Output from code, we couldn't get further
[("John", 0); ("Kevin", 0); ("Samuel", 0); ("Tessa", 0)]
[("David", 1); ("Hannah", 1); ("Nina", 1); ("Rachel", 1); ("Wendy", 1)]
[("Alice", 2); ("Charlie", 2); ("George", 2); ("Julia", 2); ("Michael", 2);
 ("Penelope", 2); ("Uma", 2); ("Yvonne", 2)]
[("Frank", 3); ("Isaac", 3); ("Oliver", 3); ("Xavier", 3)]
[("Bob", 4); ("Eve", 4); ("Lily", 4); ("Quincy", 4); ("Victor", 4); ("Zoe", 4)]
*)














// printfn "%A" (List.length test)



(*

[(0, [("John", 0); ("Kevin", 0); ("Samuel", 0); ("Tessa", 0)]);
 (2,
  [("Alice", 2); ("Charlie", 2); ("George", 2); ("Julia", 2); ("Michael", 2);
   ("Penelope", 2); ("Uma", 2); ("Yvonne", 2)]);
 (4,
  [("Bob", 4); ("Eve", 4); ("Lily", 4); ("Quincy", 4); ("Victor", 4); ("Zoe", 4)]);
 (1, [("David", 1); ("Hannah", 1); ("Nina", 1); ("Rachel", 1); ("Wendy", 1)]);
 (3, [("Frank", 3); ("Isaac", 3); ("Oliver", 3); ("Xavier", 3)])]


Studerende med score 0: (0; [("John", 0); ("Kevin", 0); ("Samuel", 0); ("Tessa", 0)])
Studerende med score 1: (1; [("David", 1); ("Hannah", 1); ("Nina", 1); ("Rachel", 1); ("Wendy", 1)])
Studerende med score 2: (2; [("Alice", 2); ("Charlie", 2); ("George", 2); ("Julia", 2); ("Michael", 2); ("Penelope", 2); ("Uma", 2); ("Yvonne", 2)])
Studerende med score 3: (3; [("Frank", 3); ("Isaac", 3); ("Oliver", 3); ("Xavier", 3)])
Studerende med score 4: (4; [("Bob", 4); ("Eve", 4); ("Lily", 4); ("Quincy", 4); ("Victor", 4); ("Zoe", 4)])

check length of list




Studerende med score 0: [("John", 0); ("Kevin", 0); ("Samuel", 0); ("Tessa", 0)]
Studerende med score 2: [("Alice", 2); ("Charlie", 2); ("George", 2); ("Julia", 2); ("Michael", 2);
 ("Penelope", 2); ("Uma", 2); ("Yvonne", 2)]
Studerende med score 4: [("Bob", 4); ("Eve", 4); ("Lily", 4); ("Quincy", 4); ("Victor", 4); ("Zoe", 4)]
Studerende med score 1: [("David", 1); ("Hannah", 1); ("Nina", 1); ("Rachel", 1); ("Wendy", 1)]
Studerende med score 3: [("Frank", 3); ("Isaac", 3); ("Oliver", 3); ("Xavier", 3)]
[(0, [("John", 0); ("Kevin", 0); ("Samuel", 0); ("Tessa", 0)]);
 (2,
  [("Alice", 2); ("Charlie", 2); ("George", 2); ("Julia", 2); ("Michael", 2);
   ("Penelope", 2); ("Uma", 2); ("Yvonne", 2)]);
 (4,
  [("Bob", 4); ("Eve", 4); ("Lily", 4); ("Quincy", 4); ("Victor", 4); ("Zoe", 4)]);
 (1, [("David", 1); ("Hannah", 1); ("Nina", 1); ("Rachel", 1); ("Wendy", 1)]);
 (3, [("Frank", 3); ("Isaac", 3); ("Oliver", 3); ("Xavier", 3)])]
5

*)
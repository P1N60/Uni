//2.a
//Survey structure example 1:
//[410; 4; 2; 1; 3]
//[411; 2; 1; 1; 1]

//Survey structure example 2:
//("kft410", 4, 2, 1, 3)
//("kft411", 2, 1, 1, 1)

//2.b
//Random examples of student answers:
[
    ("kft410", 2, 1, 3, 1)
    ("kfc420", 3, 2, 4, 2)
    ("rgb110", 4, 3, 1, 3)
    ("lgb690", 1, 4, 2, 4)
    ("lwt900", 2, 2, 1, 2)
    ("kmc069", 4, 4, 4, 2)
    ("ops710", 4, 1, 1, 4)
    ("msw910", 4, 4, 4, 2)
]
//Example for input and output for a function that counts student answers for question 3, answer option 1:
//Input should be any list of example student answers, like the one written above.
//Output should be the integer 3, since 3 students answered with option 1 in question 3.
let questionSpicificAnswers (answerOption: int) (question: int) studentAnswers: int = 
    studentAnswers 
    |> List.filter (fun (_, q1, q2, q3, q4) -> 
    match question with
    | 1 -> q1 = answerOption
    | 2 -> q2 = answerOption
    | 3 -> q3 = answerOption
    | _ -> q4 = answerOption)
    |> List.length
printfn "%d" (questionSpicificAnswers 1 3 [
        ("kft410", 2, 1, 3, 1)
        ("kfc420", 3, 2, 4, 2)
        ("rgb110", 4, 3, 1, 3)
        ("lgb690", 1, 4, 2, 4)
        ("lwt900", 2, 2, 1, 2)
        ("kmc069", 4, 4, 4, 2)
        ("ops710", 4, 1, 1, 4)
        ("msw910", 4, 4, 4, 2)
    ])//prints: 3

//2.c
let rec questionPercentageAnswers (answerOption: int) (question: int) studentAnswers = 
    match answerOption with
    | 0 -> ()
    | _ -> printfn "%.2f%% ansered with option %d in question %d" (float (
        studentAnswers 
        |> List.filter (fun (_, q1, q2, q3, q4) ->  
        match question with
        | 1 -> q1 = answerOption
        | 2 -> q2 = answerOption
        | 3 -> q3 = answerOption
        | _ -> q4 = answerOption) 
        |> List.length) / (float (
            studentAnswers 
            |> List.length)) * 100.0) answerOption question; questionPercentageAnswers (answerOption - 1) question studentAnswers
questionPercentageAnswers 4 4 [
        ("kft410", 2, 1, 3, 1)
        ("kfc420", 3, 2, 4, 2)
        ("rgb110", 4, 3, 1, 3)
        ("lgb690", 1, 4, 2, 4)
        ("lwt900", 2, 2, 1, 2)
        ("kmc069", 4, 4, 4, 2)
        ("ops710", 4, 1, 1, 4)
        ("msw910", 4, 4, 4, 2)
    ] //prints the following:
//25.00% ansered with option 4 in question 4
//12.50% ansered with option 3 in question 4
//50.00% ansered with option 2 in question 4
//12.50% ansered with option 1 in question 4

//2.d
let rec matchingStudents (studentIndex: int) studentAnswers = 
    if (studentIndex >= List.length studentAnswers) then 
        ()
    else
        let filteredStudents = 
            studentAnswers 
                |> List.filter (fun (_, q1, q2, q3, q4) -> (q1, q2, q3, q4) = (
                    studentAnswers[studentIndex] 
                    |> fun (_, q1, q2, q3, q4) -> (q1, q2, q3, q4)))
        if List.length filteredStudents = 2 then
            filteredStudents
            |> List.iter (fun (id, _, _, _, _) -> printf "%s " id)
        else
            matchingStudents (studentIndex + 1) studentAnswers
matchingStudents 0 [
        ("kft410", 2, 1, 3, 1)
        ("kfc420", 3, 2, 4, 2)
        ("rgb110", 4, 3, 1, 3)
        ("lgb690", 1, 4, 2, 4)
        ("lwt900", 2, 2, 1, 2)
        ("kmc069", 4, 4, 4, 2)
        ("ops710", 4, 1, 1, 4)
        ("msw910", 4, 4, 4, 2)
    ]
//prints:
//kmc069 msw910
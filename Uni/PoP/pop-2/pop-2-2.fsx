//Laver n-antal af mellemrum (" ") recursivt inden "*"?
let rec spaces n =
    if n <= 0 then ""
    else " " + spaces (n - 1)

//Laver n-antal af "*" efter n-antal af mellemrum?
let rec stars n =
    if n <= 0 then ""
    else "* " + stars (n - 1)

//Laver en list(string) med l-antal af linjer og n-antal af mellemrum?
let rec diamond_top l n =
    if (l = 0) then []
    else 
        (diamond_top (l - 1) n)@((spaces (n - l))+ (stars l)::[])

let rec diamond_bottom l n =
    if (l = 0) then []
    else 
        (diamond_bottom (l - 1) n)@((spaces (l) + stars (n - l))::[])

//Lader os printe en list som l.Head + l.Tail
let rec print_list (l: string list) : unit =
    if (l = []) then printfn ""
    else   
        printfn "%s" l.Head
        print_list l.Tail

//Runs print_list with diamond_top and diamond_top
print_list ((diamond_top 5 5)@(diamond_bottom 5 5))
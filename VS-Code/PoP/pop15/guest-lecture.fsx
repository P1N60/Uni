(**********************************************************************************)
(* Gæsteforelæsning, Programmering og Problemløsning, E2024                       *)
(* Baseret på eksempel fra "Functional Programming Using F#" af Hansen og Rischel *)
(* Ken Friis Larsen <kflarsen@di.ku.dk>                                           *)
(**********************************************************************************)

(*
Når et landkort skal farvelægges, skal farverne på forskellige lande
vælges således at nabo-lande får forskellige farver.

Du får givet en *nabo-relation* som en liste af nabo-par.
For eksempel så er følgende liste:

[("da", "se"); ("no", "da"); ("se", "no"); ("de", "da")]

en definition af nabo-relationen for fire lande da, de, no og se,
hvor da er nabo til alle de tre andre lande og se og no er naboer.

Vores program skal returnere en *farvning* af landende, så ingen
naboer har den samme farve.
*)

type Country = string
type NeighbourRelation = (Country * Country) list
type Colour = Country list
type Colouring = Colour list

let simple : NeighbourRelation = [("da", "se"); ("no", "da"); ("se", "no"); ("de", "da")]

let involved =
    [   // Outer ring connections among themselves + ocean
        ("a", "b")
        ("a", "d")
        ("a", "ocean")
        ("b", "c")
        ("b", "ocean")
        ("c", "d")
        ("c", "ocean")
        ("d", "ocean")

        // Each outer region touches two inner regions
        ("a", "e")
        ("a", "f")
        ("b", "f")
        ("b", "g")
        ("c", "g")
        ("c", "h")
        ("d", "e")
        ("d", "h")

        // Inner ring connections among themselves + lake
        ("e", "f")
        ("e", "h")
        ("e", "lake")
        ("f", "g")
        ("f", "lake")
        ("g", "h")
        ("g", "lake")
        ("h", "lake")
    ]

(*

  Forslag til funktioner/problemer at starte med
      * Kan to lande have den samme farve
      * NeighbourRelation -> Country list
      * Hvordan udvider man en farve med et land
*)

// val isNieghbour: NeighbourRelation -> Country -> Country -> bool
let isNieghbour nr c1 c2 =
    List.exists (fun p -> p = (c1, c2) || p = (c2,c1)) nr


(* canExtendColour: NeighbourRelation -> Country -> Colour -> bool

    Example:
      canExtendColour simple "da" ["de"] ===> false
*)
let canExtendColour nr country colour =
    List.forall (fun c -> not (isNieghbour nr c country)) colour


(*
 giveColour : NR -> Country -> Colouring -> Colouring

 giveColour simple "da" [["de","se"]; ["no"]] ===> [["de","se"]; ["no"]; ["da"]]
*)

let rec giveColour nr country colouring =
    match colouring with
        | [] -> [[country]]
        | col :: rest ->
            if canExtendColour nr country col then (country :: col) :: rest
            else col :: giveColour nr country rest

let countries (nr : NeighbourRelation) : Country list =
    nr
    |> List.collect (fun (c1, c2) -> [c1; c2])
    |> List.distinct

(*
    Forslag til typer:
        colourContries: (string * string) list -> rgb list
        colourContries: (string * string) list -> (string * rgb) list)

val colourContries: NeighbourRelation -> Colouring
*)

let colourContries (nr: NeighbourRelation) : Colouring =
    let cs = countries nr
    List.fold (fun acc c -> giveColour nr c acc) [] cs



// Et par eksempler på brug

let simpleColouring = colourContries simple
let involvedColouring = colourContries involved


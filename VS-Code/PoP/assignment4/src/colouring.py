# Ved ikke om dette er rigtigt defineret
type Country = str
type NeighbourRelation = list[(Country * Country)]
type Colour = list[Country]
type Colouring = list[Colour]

def simple():
    [("da", "se"), ("no", "da"), ("se", "no"), ("de", "da")]

def involved():
    [   # Outer ring connections among themselves + ocean
        ("a", "b")
        ("a", "d")
        ("a", "ocean")
        ("b", "c")
        ("b", "ocean")
        ("c", "d")
        ("c", "ocean")
        ("d", "ocean")

        # Each outer region touches two inner regions
        ("a", "e")
        ("a", "f")
        ("b", "f")
        ("b", "g")
        ("c", "g")
        ("c", "h")
        ("d", "e")
        ("d", "h")

        # Inner ring connections among themselves + lake
        ("e", "f")
        ("e", "h")
        ("e", "lake")
        ("f", "g")
        ("f", "lake")
        ("g", "h")
        ("g", "lake")
        ("h", "lake")
    ]

# val isNieghbour: NeighbourRelation -> Country -> Country -> bool
def isNieghbour(nr, c1, c2):
    List.exists (fun p -> p = (c1, c2) || p = (c2,c1)) nr


# canExtendColour: NeighbourRelation -> Country -> Colour -> bool
#    Example:
#      canExtendColour simple "da" ["de"] ===> false
def canExtendColour(nr, country, colour):
    List.forall (fun c -> not (isNieghbour nr c country)) colour

# giveColour : NR -> Country -> Colouring -> Colouring

# giveColour simple "da" [["de","se"]; ["no"]] ===> [["de","se"]; ["no"]; ["da"]]
def giveColour(nr, country, colouring):
    match colouring with
        | [] -> [[country]]
        | col :: rest ->
            if canExtendColour nr country col then (country :: col) :: rest
            else col :: giveColour nr country rest

def countries(nr):
    nr
    |> List.collect (fun (c1, c2) -> [c1; c2])
    |> List.distinct

#    Forslag til typer:
#        colourContries: (string * string) list -> rgb list
#        colourContries: (string * string) list -> (string * rgb) list)
# val colourContries: NeighbourRelation -> Colouring
def colourContries(nr):
    cs = countries(nr)
    List.fold (fun acc c -> giveColour nr c acc) [] cs



# Et par eksempler på brug

def simpleColouring():
    colourContries(simple)
def involvedColouring():
    colourContries(involved)


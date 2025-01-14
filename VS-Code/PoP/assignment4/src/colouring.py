# Not sure if this is correct
Country = str
NeighbourRelation = list[tuple[Country, Country]]
Colour = list[Country]
Colouring = list[Colour]

def simple():
    return[("da", "se"), ("no", "da"), ("se", "no"), ("de", "da")]

def involved():
    # Outer ring connections among themselves + ocean
    return[   
        ("a", "b"),
        ("a", "d"),
        ("a", "ocean"),
        ("b", "c"),
        ("b", "ocean"),
        ("c", "d"),
        ("c", "ocean"),
        ("d", "ocean"),

        # Each outer region touches two inner regions
        ("a", "e"),
        ("a", "f"),
        ("b", "f"),
        ("b", "g"),
        ("c", "g"),
        ("c", "h"),
        ("d", "e"),
        ("d", "h"),

        # Inner ring connections among themselves + lake
        ("e", "f"),
        ("e", "h"),
        ("e", "lake"),
        ("f", "g"),
        ("f", "lake"),
        ("g", "h"),
        ("g", "lake"),
        ("h", "lake")
    ]

# val isNieghbour: NeighbourRelation -> Country -> Country -> bool
def isNeighbour(nr: NeighbourRelation, country1: Country, country2: Country) -> bool:
    """Checks whether the given countries are a part of a NeighbourRelation"""

    return any(pair == (country1, country2) or pair == (country2, country1) for pair in nr)

# canExtendColour: NeighbourRelation -> Country -> Colour -> bool
#    Example:
#      canExtendColour simple "da" ["de"] ===> false
def canExtendColour(nr: NeighbourRelation, country1: Country, colour: Colour) -> bool:
    """  """

    return all(not isNeighbour(nr, country1, country2) for country2 in colour)

# giveColour : NR -> Country -> Colouring -> Colouring

# giveColour simple "da" [["de","se"]; ["no"]] ===> [["de","se"]; ["no"]; ["da"]]
def giveColour(nr: NeighbourRelation, country: Country, colouring: Colouring) -> Colouring:
    """  """

    if not colouring:
        return [[country]]
    
    head, *rest = colouring
    if canExtendColour(nr, country, head):
        return [[country] + head] + rest
    else:
        return [head] + giveColour(nr, country, rest)

#    Forslag til typer:
#        colourContries: (string * string) list -> rgb list
#        colourContries: (string * string) list -> (string * rgb) list)
# val colourContries: NeighbourRelation -> Colouring
def countries(nr: NeighbourRelation) -> Colour:
    """  """

    return ({c for pair in nr for c in pair})

def colourCountries(nr: NeighbourRelation) -> Colouring:
    """  """

    cs = countries(nr)
    colouring = []
    for c in cs:
        colouring = giveColour(nr, c, colouring)
    return colouring

# Et par eksempler på brug
print(colourCountries(simple()))
print(colourCountries(involved()))

class NeighbourRelation:
    def __init__(self, country1: Country, country2: Country, rest=None):
        self.pair = (country1, country2)
        self.rest = rest

    def __repr__(self):
        return f"{self.pair}, {self.rest}"
    
nr = NeighbourRelation("de", "da", NeighbourRelation("da", "se", NeighbourRelation("se", "no")))
print(nr)
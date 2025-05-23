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
    """
    Checks if two countries are neighbors in the given neighbor relation.
    
    Inputs:
        nr: NeighbourRelation: list of tuples representing neighboring countries.
        country1: Country: first country to check.
        country2: Country: second country to check.
    
    Outputs: 
        bool: True if the countries are neighbors, False otherwise.
    """
    return any(pair == (country1, country2) or pair == (country2, country1) for pair in nr)

# canExtendColour: NeighbourRelation -> Country -> Colour -> bool
#    Example:
#      canExtendColour simple "da" ["de"] ===> false
def canExtendColour(nr: NeighbourRelation, country1: Country, colour: Colour) -> bool:
    """
    Checks if a country can be added to an existing color group without violating the constraint that neighboring countries cannot share the same color.
    
    Inputs:
        nr: NeighbourRelation: list of tuples representing neighboring countries.
        country1: Country: country to potentially add to the color group.
        colour: Colour: list of countries already assigned this color.
    
    Outputs: 
        bool: True if the country can be added to the color group, False otherwise.
    """
    return all(not isNeighbour(nr, country1, country2) for country2 in colour)

# giveColour : NR -> Country -> Colouring -> Colouring

# giveColour simple "da" [["de","se"]; ["no"]] ===> [["de","se"]; ["no"]; ["da"]]
def giveColour(nr: NeighbourRelation, country: Country, colouring: Colouring) -> Colouring:
    """
    Assigns a country to an appropriate color group in the existing coloring, creating a new color group if necessary.
    
    Inputs:
        nr: NeighbourRelation: list of tuples representing neighboring countries.
        country: Country: country to be assigned a color.
        colouring: Colouring: existing list of color groups (each group is a list of countries).
    
    Outputs: 
        Colouring: updated list of color groups including the new country.
    """
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
    """
    Extracts all unique countries from a neighbor relation.
    
    Inputs:
        nr: NeighbourRelation: list of tuples representing neighboring countries
    
    Outputs: 
        Colour: set of all countries mentioned in the neighbor relation.
    """
    return ({c for pair in nr for c in pair})

def colourCountries(nr: NeighbourRelation) -> Colouring:
    """
    Creates a valid coloring for all countries in the neighbor relation, ensuring that no neighboring countries share the same color.
    
    Inputs:
        nr: NeighbourRelation: list of tuples representing neighboring countries.
    
    Outputs: 
        Colouring: list of color groups, where each group is a list of countries that can safely share the same color.
    """
    cs = countries(nr)
    colouring = []
    for c in cs:
        colouring = giveColour(nr, c, colouring)
    return colouring

# A few examples
#print(colourCountries(simple()))
#print(colourCountries(involved()))

# Resursive datatype
class Country:
    """
    Represents a country with a name and a list of neighboring countries.
    """
    def __init__(self, countryName: str):
        """
        Starts with a Country with the given name and an empty list of neighbors.

        Inputs:
            str: countryName with the name of the country.
        """
        self.countryName = countryName
        self.neighbours = []
    
    def addNeighbour(self, neighbour):
        """
        Adds a neighbor Country to this country's list of neighbors.

        Inputs:
            Country: the Country object to be added as a neighbor.
        """
        if neighbour not in self.neighbours:
            self.neighbours.append(neighbour)
            neighbour.addNeighbour(self)
    
    def __repr__(self) -> str:
        """
        Returns a string of the Country.
        
        Outputs:
            str: with "CountryName: [Neighbour1, Neighbour2, ...]".
        """
        return f"{self.countryName}: {[neighbour.countryName for neighbour in self.neighbours]}"
    
de = Country("de")
da = Country("da")
se = Country("se")
no = Country("no")
    
# Not sure if 'no' and 'da' should be neighbours
de.addNeighbour(da)
da.addNeighbour(se)
se.addNeighbour(no)
    
print(de)
print(da)
print(se)
print(no)
def lineReader(path):
    """
    Reads every line of a txt-file, and stores each row as a list.
    
    Inputs:
        path to file.

    Outputs:
        list[str]: with each row in the txt-file as a string.
    """
    with open(path, 'r') as file:
        lines = file.readlines()
    return [line.strip() for line in lines]

def rowsToColumns(rows):
    """
    Converts list of letters in rows to list of letters in columns.
    
    Inputs:
        list[str]: of rows of letters.

    Outputs:
        list[str]: of columns of letters.
    """
    result = []
    i = 0
    for row in rows:
        result.append("")
    while i < len(rows):
        for row in rows:
            result[i] += row[i]
        i += 1
    return result

def rowsToDiagonals(rows):
    """
    Converts list of letters in rows to list of letters in diagonals.
    
    Inputs:
        list[str]: with rows of letters.
    
    Outputs:
        list[str]: with diagonals of letters.
    """
    # Diagonal from right to left
    result = []
    j = 0
    for row in rows:
        result.append("")
        i = 0
        while i < len(row):
            if j == 0 and i < len(row)-1:
                result.append("")
            result[j+i] += row[i]
            i += 1
        j += 1
    j = 2*len(rows)-1
    # Diagonal from left to right
    for row in rows:
        result.append("")
        i = 0
        while i < len(row):
            if j == 2*len(row)-1 and i < len(row)-1:
                result.append("")
            result[j+i] += row[len(row)-i-1]
            i += 1
        j += 1
    return result

def dikuCounter(rows):
    """
    Counts the amount of "DIKU" forwards, backwards, vertically, horizontally and diagonally.

    Inputs:
        list[str]: with letters.
    
    Outputs:
        int: with the amount of "DIKU" present.
    """
    dikuCount = 0
    for row in rows:
        # In rows as normal and backwards
        dikuCount += row.count("DIKU") + row.count("UKID")

    columns = rowsToColumns(rows)
    for column in columns:
        # In columns as normal and backwards
        dikuCount += column.count("DIKU") + column.count("UKID")

    diagonals = rowsToDiagonals(rows)
    for diagonal in diagonals:
        # In diagonals as normal and backwards
        dikuCount += diagonal.count("DIKU") + diagonal.count("UKID")
    return dikuCount

print(dikuCounter(lineReader("../data/diku.txt")))

# Test cases
#print(dikuCounter([]))
#print(dikuCounter(
#    [
#        "DDKUD",
#        "IIKUD",
#        "IDKUD",
#        "IDKUD",
#        "IDKUD"
#    ]))
#print(dikuCounter([" "," "," ",]))
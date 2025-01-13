def lineReader(path):
    "Reads every line of a txt-file, and stores each row as a list"

    with open(path, 'r') as file:
        lines = file.readlines()
    return [line.strip() for line in lines]

rows = lineReader("../data/diku.txt")

def rowsToColumns():
    "Converts list of letters in rows to list of letters in columns"

    result = []
    i = 0
    for row in rows:
        result.append("")
    while i < len(rows):
        for row in rows:
            result[i] += row[i]
        i += 1
    return result

columns = rowsToColumns()

def rowsToDiagonals():
    "Converts list of letters in rows to list of letters in diagonals"

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

diagonals = rowsToDiagonals()

# Count all points
dikuCount = 0
for row in rows:
    # In rows as normal and backwards
    dikuCount += row.count("DIKU") + row.count("UKID")

for column in columns:
    # In columns as normal and backwards
    dikuCount += column.count("DIKU") + column.count("UKID")

for diagonal in diagonals:
    # In diagonals as normal and backwards
    dikuCount += diagonal.count("DIKU") + diagonal.count("UKID")

print(dikuCount)
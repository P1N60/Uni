def lineReader(path):
    "Reads every line of a txt-file, and stores each row as a list"

    with open(path, 'r') as file:
        lines = file.readlines()
    return [line.strip() for line in lines]

rows = lineReader("../data/diku.txt")

def rowsToColumns():
    result = []
    i = 0
    while i < len(rows):
        for row in rows:
            if i == 0:
                result.append("")
            result[i] += f"{row[i]}"
        i += 1
    return result

columns = rowsToColumns()
print(columns)

dikuCount = 0
for row in rows:
    dikuCount += row.count("DIKU") + row.count("UKID")

for column in columns:
    dikuCount += column.count("DIKU") + column.count("UKID")

print(dikuCount)
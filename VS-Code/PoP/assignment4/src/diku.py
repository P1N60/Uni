def lineReader(path):
    "Reads every line of a txt-file, and stores each row as a list"

    with open(path, 'r') as file:
        lines = file.readlines()
    return [line.strip() for line in lines]

rows = lineReader("../data/diku.txt")
print(rows)
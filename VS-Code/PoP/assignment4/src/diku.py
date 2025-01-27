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

print(f"DIKU amount: {dikuCounter(lineReader("../data/diku.txt"))}")

# Testing
def testFun(testCase):
    try:
        return dikuCounter(testCase)
    except:
        return Exception

# Test cases
print("Test Cases:")
print(testFun(lineReader("../data/dikuTest1.txt"))) # Test Case 1: Horizontal forward
print(testFun(lineReader("../data/dikuTest2.txt"))) # Test Case 2: Vertical forward
print(testFun(lineReader("../data/dikuTest3.txt"))) # Test Case 3: Horizontal backward
print(testFun(lineReader("../data/dikuTest4.txt"))) # Test Case 4: Vertical backward
print(testFun(lineReader("../data/dikuTest5.txt"))) # Test Case 5: Sample input from assignment 
print(testFun(lineReader("../data/dikuTest6.txt"))) # Test Case 6: Row and column
print(testFun(lineReader("../data/dikuTest7.txt"))) # Test Case 7: Overlapping in row
print(testFun(lineReader("../data/dikuTest8.txt"))) # Test Case 8: Row and Backward in another row
print(testFun(lineReader("../data/dikuTest9.txt"))) # Test Case 9: No occurrences
print(testFun(lineReader("../data/dikuTest10.txt"))) # Test Case 10: Empty grid
print(testFun([])) # Test Case 11: Empty list
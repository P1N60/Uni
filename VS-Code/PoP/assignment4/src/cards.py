def lineReader(path):
    """Reads every line of a txt-file, and stores each row as a list"""

    with open(path, 'r') as file:
        lines = file.readlines()
    return [line.strip() for line in lines]

cardRows = lineReader("../data/cards.txt")

class Card:
    def __init__(self, card):
        self.card = card
    
    def cardRemover(self):
        """Removes the word 'Card' and the card number from a card row"""

        result = self.card
        i = 0
        while i <= 9:
            # I don't know if this counts as tail recursion, but that was my idea
            head, *tail = result
            result = tail
            i += 1
        return result

    def cardNumbers(self):
        """Returns a list with the numbers that are being matched with the winning numbers of the card"""

        numbers = self.cardRemover()
        i = 0
        # Adds numbers with multiple digits to the same element of the list
        while numbers[i+1] != "|":
            if numbers[i] != " " and numbers[i+1] != " ":
                numbers[i] = numbers[i]+numbers[i+1]
                del numbers[i+1]
            i += 1
        # Replaces all winning numbers and the "|" element with empty spaces
        i += 1
        while i < len(numbers):
            numbers[i] = " "
            i += 1
        # Return the non-empty elements
        return [number for number in numbers if number != " "]
    
    def winningNumbers(self):
        """Returns a list with the winning numbers of the card"""

        numbers = self.cardRemover()
        i = 0
        # Get the index of the "|"
        while numbers[i] != "|":
            numbers[i] = " "
            i += 1
        # Replace the "|" with an empty space
        numbers[i] = " "
        # Add numbers of multiple digits to the same element
        while i < len(numbers)-1:
            if numbers[i] != " " and numbers[i+1] != " ":
                numbers[i] = numbers[i]+numbers[i+1]
                numbers[i+1] = " "
            i += 1
        # Return all non-empty elements
        return [number for number in numbers if number != " "]
    
    def cardPoints(self):
        """Counts the amount of card numbers that match the winning numbers"""

        points = 0
        for number in self.cardNumbers():
            for winningNum in self.winningNumbers():
                if number == winningNum:
                    if points == 0:
                        points = 1
                    else:
                        points = points * 2
        return points
    
    def cardStats(self):
        """Gives information about a given card by running the members of Card"""

        print(self.card)
        print(f"Card numbers: {self.cardNumbers()}")
        print(f"Winning numbers: {self.winningNumbers()}")
        print(f"Points: {self.cardPoints()}")

cardNumber = 1

for card in cardRows:
    print(f"Card {cardNumber}: {Card(card).cardPoints()} points")
    cardNumber += 1
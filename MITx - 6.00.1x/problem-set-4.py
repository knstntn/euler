SCRABBLE_LETTER_VALUES = {
    'a': 1, 'b': 3, 'c': 3, 'd': 2, 'e': 1, 'f': 4, 'g': 2, 'h': 4, 'i': 1, 'j': 8, 'k': 5, 'l': 1, 'm': 3, 'n': 1, 'o': 1, 'p': 3, 'q': 10, 'r': 1, 's': 1, 't': 1, 'u': 1, 'v': 4, 'w': 4, 'x': 8, 'y': 4, 'z': 10
}

def getWordScore(word, n):
    """
    Returns the score for a word. Assumes the word is a valid word.

    The score for a word is the sum of the points for letters in the
    word, multiplied by the length of the word, PLUS 50 points if all n
    letters are used on the first turn.

    Letters are scored as in Scrabble; A is worth 1, B is worth 3, C is
    worth 3, D is worth 2, E is worth 1, and so on (see SCRABBLE_LETTER_VALUES)

    word: string (lowercase letters)
    n: integer (HAND_SIZE; i.e., hand size required for additional points)
    returns: int >= 0
    """
    # TO DO ... <-- Remove this comment when you code this function
    res = 0
    for x in word:
        res = res + SCRABBLE_LETTER_VALUES[x]
    
    res = res*len(word)
    if len(word) == n:
        res = res + 50

    return res


def updateHand(hand, word):
    """
    Assumes that 'hand' has all the letters in word.
    In other words, this assumes that however many times
    a letter appears in 'word', 'hand' has at least as
    many of that letter in it. 

    Updates the hand: uses up the letters in the given word
    and returns the new hand, without those letters in it.

    Has no side effects: does not modify hand.

    word: string
    hand: dictionary (string -> int)    
    returns: dictionary (string -> int)
    """
    res = hand.copy()
    for x in word:
        res[x] = res[x] - 1
    return res

def isValidWord(word, hand, wordList):
    """
    Returns True if word is in the wordList and is entirely
    composed of letters in the hand. Otherwise, returns False.

    Does not mutate hand or wordList.
   
    word: string
    hand: dictionary (string -> int)
    wordList: list of lowercase strings
    """
    if word not in wordList:
        return False
    
    copy = hand.copy()
    for x in word:
        if x not in copy:
            return False
        
        copy[x] = copy[x] - 1
        if copy[x] < 0:
            return False

    return True

def calculateHandlen(hand):
    """ 
    Returns the length (number of letters) in the current hand.
    
    hand: dictionary (string int)
    returns: integer
    """
    res = 0
    for k, v in hand.items():
        res = res + v
    return res

def playHand(hand, wordList, n):
    """
    Allows the user to play the given hand, as follows:

    * The hand is displayed.
    * The user may input a word or a single period (the string ".") 
      to indicate they're done playing
    * Invalid words are rejected, and a message is displayed asking
      the user to choose another word until they enter a valid word or "."
    * When a valid word is entered, it uses up letters from the hand.
    * After every valid word: the score for that word is displayed,
      the remaining letters in the hand are displayed, and the user
      is asked to input another word.
    * The sum of the word scores is displayed when the hand finishes.
    * The hand finishes when there are no more unused letters or the user
      inputs a "."

      hand: dictionary (string -> int)
      wordList: list of lowercase strings
      n: integer (HAND_SIZE; i.e., hand size required for additional points)
      
    """
    total = 0
    while True:
        if calculateHandlen(hand) == 0:
            print("Run out of letters. Total score: " + str(total) + " points.")
            break

        s = ''
        for key in hand:
            s = s + ' ' + key

        print("Current Hand: " + s)
        
        word = input("Enter word, or a \".\" to indicate that you are finished")
        if word == '.':
            print("Goodbye! Total score: " + str(total) + " points. ")
            break

        if not isValidWord(word, hand, wordList):
            print("Invalid word, please try again.")
            continue
            
        score = getWordScore(word, n)
        total = total + score

        print("\"" + word + "\" earned " + str(score) + " points. Total: " + str(total) + " points ")
        
        hand = updateHand(hand, word)

def playGamex(wordList):
    """
    Allow the user to play an arbitrary number of hands.
 
    1) Asks the user to input 'n' or 'r' or 'e'.
      * If the user inputs 'n', let the user play a new (random) hand.
      * If the user inputs 'r', let the user play the last hand again.
      * If the user inputs 'e', exit the game.
      * If the user inputs anything else, tell them their input was invalid.
 
    2) When done playing the hand, repeat from step 1
    """
    hand = None
    while True:
        entered = input("Enter n to deal a new hand, r to replay the last hand, or e to end game: ")
        if entered == 'n':
            hand = dealHand(HAND_SIZE)
            playHand(hand, wordList, HAND_SIZE)
        elif entered == 'r':
            if hand == None:
                print("You have not played a hand yet. Please play a new hand first!")
            else:
                playHand(hand, wordList, HAND_SIZE)
        elif entered == 'e':
            break
        else:
            print("Invalid command.")
def playGame(wordList):
    """
    Allow the user to play an arbitrary number of hands.
 
    1) Asks the user to input 'n' or 'r' or 'e'.
        * If the user inputs 'e', immediately exit the game.
        * If the user inputs anything that's not 'n', 'r', or 'e', keep asking them again.

    2) Asks the user to input a 'u' or a 'c'.
        * If the user inputs anything that's not 'c' or 'u', keep asking them again.

    3) Switch functionality based on the above choices:
        * If the user inputted 'n', play a new (random) hand.
        * Else, if the user inputted 'r', play the last hand again.
          But if no hand was played, output "You have not played a hand yet. 
          Please play a new hand first!"
        
        * If the user inputted 'u', let the user play the game
          with the selected hand, using playHand.
        * If the user inputted 'c', let the computer play the 
          game with the selected hand, using compPlayHand.

    4) After the computer or user has played the hand, repeat from step 1

    wordList: list (string)
    """
    hand = None
    while True:
        entered = input("Enter n to deal a new hand, r to replay the last hand, or e to end game: ")
        if entered == 'e':
            break

        if not (entered == 'n') and not (entered == 'r'):
            print("Invalid command.")
            continue

        if entered == 'r' and hand is None:
            print("You have not played a hand yet. Please play a new hand first!")
            continue

        if entered == 'n':
            hand = dealHand(HAND_SIZE)
        
        while True:
            x = input("Enter u to have yourself play, c to have the computer play: ")
            if x == 'u':
                playHand(hand, wordList, HAND_SIZE)
                break
            elif x == 'c':
                compPlayHand(hand, wordList, HAND_SIZE)
                break
            else:
                print("Invalid command.")
import string

def isWordGuessed(secretWord, lettersGuessed):
    '''
    secretWord: string, the word the user is guessing
    lettersGuessed: list, what letters have been guessed so far
    returns: boolean, True if all the letters of secretWord are in lettersGuessed;
      False otherwise
    '''
    for x in lettersGuessed:
        secretWord = secretWord.replace(x, '')
    return len(secretWord) == 0
            

def getGuessedWord(secretWord, lettersGuessed):

    '''
    secretWord: string, the word the user is guessing
    lettersGuessed: list, what letters have been guessed so far
    returns: string, comprised of letters and underscores that represents
      what letters in secretWord have been guessed so far.
    '''
    result = ''
    for x in secretWord:
        if x in lettersGuessed:
            result += x
        else:
            result += '_ '

    return result

def getAvailableLetters(lettersGuessed):
    
    '''
    lettersGuessed: list, what letters have been guessed so far
    returns: string, comprised of letters that represents what letters have not
      yet been guessed.
    '''
    res = ''
    for x in string.ascii_lowercase:
        if x not in lettersGuessed:
            res += x
    return res

def hangman(secretWord):
    '''
    secretWord: string, the secret word to guess.

    Starts up an interactive game of Hangman.

    * At the start of the game, let the user know how many 
      letters the secretWord contains.

    * Ask the user to supply one guess (i.e. letter) per round.

    * The user should receive feedback immediately after each guess 
      about whether their guess appears in the computers word.

    * After each round, you should also display to the user the 
      partially guessed word so far, as well as letters that the 
      user has not yet guessed.

    Follows the other limitations detailed in the problem write-up.
    '''
    print('Welcome to the game, Hangman!')
    print('I am thinking of a word that is', len(secretWord), 'letters long.')
    count = 8
    lettersGuessed = []
    while count > 0:
        print('------------')
        if isWordGuessed(secretWord, lettersGuessed):
            print('Congratulations, you won!')
            return

        print("You have", count, "guesses left.")
        print("Available Letters:", getAvailableLetters(lettersGuessed))

        letter = input('Please guess a letter: ')
        if letter in lettersGuessed:
            print("Oops! You've already guessed that letter:", getGuessedWord(secretWord, lettersGuessed))
        elif letter in secretWord:
            lettersGuessed.append(letter)
            print("Good guess:", getGuessedWord(secretWord, lettersGuessed))
        else:
            count -= 1
            lettersGuessed.append(letter)
            print("Oops! That letter is not in my word:", getGuessedWord(secretWord, lettersGuessed))
    
    print("-----------")
    print("Sorry, you ran out of guesses. The word was " + secretWord + ".")
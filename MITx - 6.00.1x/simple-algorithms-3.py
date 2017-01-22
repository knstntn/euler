print("Please think of a number between 0 and 100!")

min = 0
max = 100

while True:
    guess = int((min + max)/2)
    print("Is your secret number " + str(guess) + "?")
    
    x = input("Enter 'h' to indicate the guess is too high. Enter 'l' to indicate the guess is too low. Enter 'c' to indicate I guessed correctly.")
    if x == 'h':
        max = guess
    elif x == 'l':
        min = guess
    elif x == 'c':
        print("Game over. Your secret number was:", guess)
        break
    else:
        print("Sorry, I did not understand your input.")
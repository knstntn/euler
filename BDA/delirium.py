import random


class Word(object):
    counter = 0
    descendants = {}

    def __init__(self, counter, descendants):
        self.counter = counter
        self.descendants = descendants


def get_random_word(d):
    keys = list(d.keys())
    index = random.randint(0, len(keys) - 1)
    return keys[index]


def get_next_word(word):
    if len(word.descendants) == 0:
        return None

    rand = random.randint(1, 99)
    prob = 0

    for key, value in word.descendants.items():
        prob += (value / word.counter) * 100

        if rand <= prob:
            return key

    return None


def generate():
    # text = input("Enter text: ")
    text = "Только такая цель позволяет человеку прожить свою жизнь с достоинством и получить настоящую радость. Да, радость! Подумайте: если человек ставит себе задачей увеличивать в жизни добро, приносить людям счастье, какие неудачи могут его постигнуть? Не тому помочь? Но много ли людей не нуждаются в помощи?"
    # k = int(input("Enter k: "))
    k = 7
    # stop = int(input("Enter length to stop: "))
    stop = 1000

    words = {}

    for x in range(0, len(text)):
        key = text[x:x + k]
        next_key = text[x + k:x + k + k]

        word = words.setdefault(key, Word(0, {}))
        word.counter += 1

        word.descendants.setdefault(next_key, 0)
        word.descendants[next_key] += 1

    next_key = get_random_word(words)

    while stop > 0:
        yield next_key

        word = words[next_key]
        next_key = get_next_word(word) or get_random_word(words)
        stop -= len(next_key)


if __name__ == '__main__':
    for text in generate():
        print(text, end='')

    print()

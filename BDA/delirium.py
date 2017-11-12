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
    text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Etiam dolor nunc, pharetra quis nisi ut, tempor posuere ex. Proin vulputate convallis mauris, eu vestibulum neque porttitor sit amet. Integer non vestibulum mauris. Suspendisse vel massa lacinia felis tempor finibus non eu tellus. Quisque accumsan eu lorem a feugiat. Quisque velit lacus, egestas eget magna tempus, venenatis sodales ligula. Donec facilisis, nunc vitae scelerisque semper, tortor neque mollis lorem, non bibendum dolor dolor in ante. In hac habitasse platea dictumst. Proin semper nisl vitae odio vulputate, nec maximus tellus convallis. Fusce porttitor ullamcorper sollicitudin. Integer at tortor ut erat faucibus pulvinar."
    # k = int(input("Enter k: "))
    k = 3
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

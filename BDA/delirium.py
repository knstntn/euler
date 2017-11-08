import random


class Word(object):
    counter = 0
    children = {}

    def __init__(self, counter, children):
        self.counter = counter
        self.children = children

    def next_key(self):
        if len(self.children) == 0:
            return None

        rand = random.randint(1, 99)
        prob = 0

        for key, value in self.children.items():
            prob += (value / self.counter) * 100

            if rand <= prob:
                return key

        return None


def get_random_key(d):
    keys = list(d.keys())
    index = random.randint(0, len(keys) - 1)
    return keys[index]


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
        next = text[x + k:x + k + k]

        value = words.setdefault(key, Word(0, {}))
        value.counter += 1
        value.children.setdefault(next, 0)
        value.children[next] += 1

    next_key = get_random_key(words)

    while stop > 0:
        yield next_key

        word = words[next_key]
        next_key = word.next_key() or get_random_key(words)
        stop -= len(next_key)


if __name__ == '__main__':
    for text in generate():
        print(text, end='')

    print()

DICT_SIZE = 256


def compress(data):
    dictionary = {chr(i): i for i in range(DICT_SIZE)}

    buf = ""
    for c in data:
        word = buf + c
        if word in dictionary:
            buf = word
        else:
            yield dictionary[buf]

            dictionary[word] = len(dictionary)
            buf = c

    if buf:
        yield dictionary[buf]


def decompress(compressed):
    dictionary = {i: chr(i) for i in range(DICT_SIZE)}

    w = chr(compressed.pop(0))
    result = w
    for k in compressed:
        if k in dictionary:
            entry = dictionary[k]
        elif k == len(dictionary):
            entry = w + w[0]
        result += entry
        dictionary[len(dictionary)] = w + entry[0]
        w = entry
    return result


if __name__ == '__main__':
    test = "abbccccdddddffttt0000000000"

    compressed = list(compress(test))
    decompressed = decompress(compressed)
    print(decompressed == test)

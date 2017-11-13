import heapq
from collections import defaultdict


def get_frequencies(code):
    frequencies = defaultdict(int)
    for symbol in code:
        frequencies[symbol] += 1
    return frequencies


def get_code(code):
    frequencies = get_frequencies(code)
    heap = [[weight, [symbol, '']] for symbol, weight in frequencies.items()]
    heapq.heapify(heap)

    while len(heap) > 1:
        left = heapq.heappop(heap)
        right = heapq.heappop(heap)

        for l in left[1:]:
            l[1] = '0' + l[1]
        for r in right[1:]:
            r[1] = '1' + r[1]

        heapq.heappush(heap, [left[0] + right[0]] + left[1:] + right[1:])

    a = heapq.heappop(heap)[1:]
    return {a[i][0]: a[i][1] for i in range(0, len(a))}


def encode(text, code):
    res = ''
    for symbol in text:
        res += code[symbol]
    return res


def decode(text, code):
    block = ''
    res = ''
    inverted_code = {v: k for k, v in code.items()}

    for symbol in text:
        block += symbol

        if block in inverted_code:
            res += inverted_code[block]
            block = ''
    return res


if __name__ == '__main__':
    alphabet = "abbccccdddddffttt0000000000"
    test = 'abcdabcdcdabdba'

    code = get_code(alphabet)
    encoded = encode(test, code)
    decoded = decode(encoded, code)

    print(code, encoded, decoded, test == decoded)

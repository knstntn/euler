def genPrimes():
    yield 2
    x = 3
    while True:
        if isPrime(x):
            yield x

        x += 2

def isPrime(num):
    if num % 2 == 0:
        return False

    max = num**0.5
    val = 3
    while val <= max:
        if num%val == 0:
            return False
        
        val += 2

    return True
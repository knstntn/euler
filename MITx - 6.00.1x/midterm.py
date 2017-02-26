def closest_power(base, num):
    '''
    base: base of the exponential, integer > 1
    num: number you want to be closest to, integer > 0
    Find the integer exponent such that base**exponent is closest to num.
    Note that the base**exponent may be either greater or smaller than num.
    In case of a tie, return the smaller value.
    Returns the exponent.
    '''
    # Your code here
    
    if base > num:
        return 0

    exp = 1
    diff = 0
    while True:
        res = base**exp
        
        if res == num:
            return exp
        elif res < num:
            diff = num - res
            pass
        else:
            d = res - num
            if d < diff:
                return exp
            else: 
                return exp - 1
        
        exp = exp + 1

def dotProduct(listA, listB):
    

    
    '''
    listA: a list of numbers
    listB: a list of numbers of the same length as listA
    '''
    res = 0
    for i in range(len(listA)):
        res = res + listA[i]*listB[i]
    return res

def deep_reverse(L):
    """ assumes L is a list of lists whose elements are ints
    Mutates L such that it reverses its elements and also 
    reverses the order of the int elements in every element of L. 
    It does not return anything.
    """
    for x in L:
        x.reverse()

    L.reverse()

def dict_interdiff(d1, d2):
    '''
    d1, d2: dicts whose keys and values are integers
    Returns a tuple of dictionaries according to the instructions above
    '''
    intersect = {}
    diff = {}

    keys1 = set(d1.keys())
    keys2 = set(d2.keys())

    intersection_keys = keys1 & keys2
    for x in sorted(intersection_keys):
        intersect[x] = f(d1[x], d2[x])

    diff_keys = (keys1 - keys2).union(keys2 - keys1)
    for x in sorted(diff_keys):
        if x in d1:
            diff[x] = d1[x]
        else:
            diff[x] = d2[x]
    
    return (intersect, diff)




def applyF_filterG(L, f, g):
    """
    Assumes L is a list of integers
    Assume functions f and g are defined for you. 
    f takes in an integer, applies a function, returns another integer 
    g takes in an integer, applies a Boolean function, 
        returns either True or False
    Mutates L such that, for each element i originally in L, L contains  
        i if g(f(i)) returns True, and no other elements
    Returns the largest element in the mutated L or -1 if the list is empty
    """
    clone = L[:]
    for index in range(len(clone) - 1, -1, -1):
        x = clone[index]
        if not g(f(x)):
            del L[index]

    if len(L) == 0:
        return -1
    
    return max(L)


def flatten(aList):
    ''' 
    aList: a list 
    Returns a copy of aList, which is a flattened version of aList 
    '''
    res = []
    for x in aList:
        if isinstance(x, list):
            for y in flatten(x):
                res.append(y)
        else:
            res.append(x)
    return res

print(flatten([[1,'a',['cat'],2],[[[3]],'dog'],4,5]))
  
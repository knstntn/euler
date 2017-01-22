def isIn(char, aStr):
    '''
    char: a single character
    aStr: an alphabetized string

    returns: True if char is in aStr; False otherwise
    '''
    length = len(aStr)
    if length == 0: return False
    if length == 1: return char == aStr
    
    mid = length//2
    
    if char < aStr[mid]: return isIn(char, aStr[:mid])
    elif char > aStr[mid]: return isIn(char, aStr[mid+1:])
    else: return True
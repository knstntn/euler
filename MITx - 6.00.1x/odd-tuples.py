def oddTuples(aTup):
    '''
    aTup: a tuple
    
    returns: tuple, every other element of aTup. 
    '''
    res = ()
    for x in range(1, len(aTup), 2):
        res += aTup[x: x +1]
    return res

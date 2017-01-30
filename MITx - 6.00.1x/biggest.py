def biggest(aDict):
    '''
    aDict: A dictionary, where all the values are lists.

    returns: The key with the largest number of values associated with it
    '''
    lengths = map(len, aDict.values())
    maxim = max(lengths)
    for x in aDict:
        if len(aDict[x]) == maxim:
            return x
        
    return ''


animals = {'a': ['aardvark'], 'b': ['baboon'], 'c': ['coati']}

animals['d'] = ['donkey']
animals['d'].append('dog')
animals['d'].append('dingo')

print(biggest(animals))
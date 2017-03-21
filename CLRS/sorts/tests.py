from insertion import InsertionSort
from selection import SelectionSort
from merge import MergeSort
from builtin import BuiltInSort
import time
import random

sorts = [InsertionSort(), SelectionSort(), MergeSort(), BuiltInSort()]
arr = [int(1000*random.random()) for i in xrange(8*1024)]

for i in range(len(sorts)):
    start = time.time()

    sort = sorts[i]
    sort.asc(arr)

    end = time.time()
    print(sort.name, end - start)

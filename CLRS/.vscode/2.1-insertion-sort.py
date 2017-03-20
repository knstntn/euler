class InsertionSort(object):
    def __init__(self):
        pass

    def sort(self, a, compare):
        if len(a) == 0:
            return []

        for i in range(1, len(a), 1):
            value = a[i]

            j = i - 1
            while(j >= 0 and compare(a[j], value)):
                a[j + 1] = a[j]
                j -= 1

            a[j + 1] = value

        return a

    def asc(self, a):
        return self.sort(a, lambda left, right: left > right)

    def desc(self, a):
        return self.sort(a, lambda left, right: left < right)


sort = InsertionSort()
print(sort.asc([55, 44, 22, 99, 78]))
print(sort.desc([5, 44, 22, 99, 78]))

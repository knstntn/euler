class SelectionSort(object):
    def __init__(self):
        self.name = 'SelectionSort'
        pass

    def sort(self, a, find):
        if len(a) == 0:
            return []
        for i in range(len(a)):
            j = find(a, i)
            tmp = a[i]
            a[i] = a[j]
            a[j] = tmp
        return a

    def asc(self, a):
        return self.sort(a, lambda arr, start: min(enumerate(a, start), key=lambda p: p[1])[0])

    def desc(self, a):
        return self.sort(a, lambda arr, start: max(enumerate(a, start), key=lambda p: p[1])[0])

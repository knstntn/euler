class MergeSort(object):
    def __init__(self):
        self.name = 'MergeSort'
        pass

    def asc(self, a):
        return self.sort(a, lambda left, right: left <= right)

    def desc(self, a):
        return self.sort(a, lambda left, right: left >= right)

    def sort(self, a, compare):
        if len(a) > 2:
            middle = int(len(a)) / 2
            l = self.sort(a[: middle], compare)
            r = self.sort(a[middle:], compare)
            return self.merge(l, r, compare)
        return a

    def merge(self, left, right, compare):
        i = 0
        j = 0

        merged = []

        while i < len(left) and j < len(right):
            if compare(left[i], right[j]):
                merged.append(left[i])
                i += 1
            else:
                merged.append(right[j])
                j += 1

        while i < len(left):
            merged.append(left[i])
            i += 1

        while j < len(right):
            merged.append(right[j])
            j += 1

        return merged

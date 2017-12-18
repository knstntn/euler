class BerlekampMasseyPolynomTerm:
    def __init__(self, power):
        self.power = power
        self.coefficient = 1

    def copy(self):
        return BerlekampMasseyPolynomTerm(self.power)


class BerlekampMasseyPolynom:
    def __init__(self, terms):
        self.terms = sorted(terms, key=lambda x: x.power, reverse=True)

    def __add__(self, other):
        m = max(self.degree(), other.degree())
        terms = []
        while m >= 0:
            left = self.coef_by_degree(m)
            right = other.coef_by_degree(m)
            if (left + right) % 2 == 1:
                terms.append(BerlekampMasseyPolynomTerm(m))
            m -= 1
        return BerlekampMasseyPolynom(terms)

    def __mul__(self, other):
        res = BerlekampMasseyPolynom([])
        for t in self.terms:
            for x in other.terms:
                res = res + BerlekampMasseyPolynom([
                    BerlekampMasseyPolynomTerm(t.power + x.power)
                ])
        return res

    def __str__(self):
        return ' + '.join(['x**{0}'.format(x.power) if x.power != 0 else '1' for x in self.terms])

    def copy(self):
        return BerlekampMasseyPolynom([t.copy() for t in self.terms])

    def degree(self):
        if len(self.terms) == 0:
            return -1

        return self.terms[0].power

    def coef_by_degree(self, degree):
        for t in self.terms:
            if t.power == degree:
                return t.coefficient
        return 0


class BerlekampMassey:
    def __discrepancy(self, inp, n, polynom):
        degree = polynom.degree()
        offset = 0
        res = 0
        while degree >= offset:
            res ^= (int(inp[n - offset]) *
                    polynom.coef_by_degree(degree - offset))
            offset += 1
        return res

    def generate_polynoms(self, inp):
        # dummy value for no n
        polynoms = [BerlekampMasseyPolynom([BerlekampMasseyPolynomTerm(0)])]
        m = None
        for i in range(len(inp)):
            n = i + 1
            d = self.__discrepancy(inp, i, polynoms[i])

            if d == 0:
                polynoms.append(polynoms[i].copy())
                continue

            if m is None:
                polynoms.append(BerlekampMasseyPolynom([
                    BerlekampMasseyPolynomTerm(n),
                    BerlekampMasseyPolynomTerm(0)
                ]))
                m = n
                continue

            before_m_changed = polynoms[m - 1]
            previous = polynoms[i]

            a = m - before_m_changed.degree()
            b = n - previous.degree()

            multiplier = BerlekampMasseyPolynom([
                BerlekampMasseyPolynomTerm(abs(a - b))
            ])

            if a >= b:
                new_polynom = previous + before_m_changed * multiplier
            else:
                new_polynom = previous * multiplier + before_m_changed

            if new_polynom.degree() > previous.degree():
                m = n

            polynoms.append(new_polynom)

        return polynoms


if __name__ == '__main__':
    inp = '1010'
    inp = '101011110'
    inp = '1010111100010011010'
    # inp = '00001'
    for (i, p) in enumerate(BerlekampMassey().generate_polynoms(inp)):
        print("n:", i, ' polynom:', p)

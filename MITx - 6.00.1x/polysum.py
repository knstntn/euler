from math import pi, tan

def polysum(n, s):
    '''
     n is the number of sides of a polygon, a positive int
     s is length of each side, a positive int

    A regular polygon has 'n' number of sides. Each side has length 's'.

    * The area of regular polygon is: (0.25*n*s^2)/tan(pi/n)
    * The perimeter of a polygon is: length of the boundary of the polygon

    Returns the sum of the area and square of the perimeter of the regular polygon, rounded to 4 decimal places.
    '''
    area = 0.25*n*s*s/tan(pi/n)
    perimeter = n*s
    result = area + perimeter*perimeter
    return round(result, 4)

"""
This module contains simple kmeans implementation
"""

import random
import numpy as np
from sklearn import cluster, datasets


class KMeans:
    """Contains code for K-Means clustering"""

    def __init__(self, k):
        """K-Means clustering
        Parameters
        ----------
        k : int
            The number of clusters to form as well as the number of
            centroids to generate.
        """
        self.k = k

    def fit(self, X):
        """
        Computes k-means clustering.
        """
        old_centers = []
        new_centers = list(self.get_random_centers(X))
        while not np.array_equal(new_centers, old_centers):
            old_centers = new_centers
            clusters = self.generate_clusters(X, new_centers)
            new_centers = self.reevaluate_centers(clusters)

        return(new_centers, clusters, self.generate_labels(clusters, X))

    def get_random_centers(self, X):
        """ 
        Returns k random centers from X
        """
        length = len(X)
        k = self.k
        while k > 0:
            index = random.randint(0, length - 1)
            yield X[index]
            k -= 1

    def distance(self, x, y):
        """
        Returns distance between two vectors. 
        In this particular implementation used euclidian distance
        """
        return np.linalg.norm(x - y)

    def generate_clusters(self, X, centers):
        """
        Generates new clusters from input array and precalculated centers
        """
        clusters = {}

        for x in X:
            # using index for hashing because arrays or ndarrays are not hashable
            distances = [(index, self.distance(x, value))
                         for (index, value) in enumerate(centers)]
            center_for_x = min(distances, key=lambda t: t[1])[0]

            clusters.setdefault(center_for_x, [])
            clusters[center_for_x].append(x)

        return clusters

    def reevaluate_centers(self, clusters):
        """
        Recalculates centers based on new clusters formation
        """
        new_centers = []
        for k in clusters.keys():
            new_centers.append(np.mean(clusters[k], axis=0))
        return new_centers

    def generate_labels(self, clusters, X):
        """
        Generates labels for all data points in X using calculated clusters
        """
        labels = []
        tmp = [(v, key) for (key, value) in clusters.items() for v in value]
        for x in X:
            for y in tmp:
                if np.array_equal(x, y[0]):
                    labels.append(y[1])
                    break
        return labels


if __name__ == '__main__':
    iris = datasets.load_iris()

    X = iris.data
    k = 3

    my_kmeans = KMeans(k)
    result = my_kmeans.fit(X)

    sk_kmeans = cluster.KMeans(n_clusters=k)
    sk_result = sk_kmeans.fit(X)

    print('sklearn results: ', sk_result.cluster_centers_)
    print('---------------')
    print('my kmeans results: ', result[0])

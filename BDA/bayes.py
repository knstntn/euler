from collections import defaultdict
from functools import reduce
from math import log

import numpy as np
from scipy.io import arff
from sklearn.model_selection import train_test_split
from sklearn.naive_bayes import GaussianNB


class NaiveBayes():
    """Naive implementation of naive bayes classifier"""

    class NaiveBayesClass():
        """Class description for naive bayes"""

        def __init__(self, counter, features_counter, features):
            self.counter = counter
            self.features_counter = features_counter
            self.features = features

        def __str__(self):
            return 'nbc: {} {}'.format(self.counter, self.features)

    def __init__(self):
        self.__classes = None

    def fit(self, X, y):
        """Fit classifier according to X, y"""

        assert(len(X) == len(y))

        # Counting classes and features
        classes = {}
        classes_counter = 0
        for (i, row) in enumerate(X):
            name = y[i]

            classes.setdefault(name, NaiveBayes.NaiveBayesClass(0, 0, {}))
            classes[name].counter += 1

            classes_counter += 1

            for (_, feature) in enumerate(row):
                classes[name].features_counter += 1

                classes[name].features.setdefault(feature, 0)
                classes[name].features[feature] += 1

        # Normalizing ie counting probabilities
        for name in classes:
            cl = classes[name]
            cl.counter /= classes_counter

            for f in cl.features:
                cl.features[f] /= cl.features_counter

        self.__classes = classes

    def predict(self, X):
        """Perform classification on an array of test vectors X."""

        def calculate_log_prob_for_class(class_name, features):
            """Returns log prob for tested class"""
            cl = self.__classes[class_name]
            res = log(cl.counter)
            for f in features:
                default = 1 / len(cl.features)
                res += log(cl.features.get(f, default))
            return res

        result = []
        for (i, row) in enumerate(X):
            max = (None, None)
            for class_name in self.__classes:
                prob = calculate_log_prob_for_class(class_name, row)
                if max[1] is None or max[1] < prob:
                    max = (class_name, prob)
            result.append(max[0])
        return result


if __name__ == '__main__':
    def split_training_and_target_data(array):
        training, target = [], []

        for i in range(len(array)):
            training_row = []

            for j in range(len(array[i])):
                if j == len(array[i]) - 1:
                    target.append(array[i][j])
                else:
                    training_row.append(array[i][j])

            training.append(training_row)
        return (training, target)

    def get_golf_data():
        with open("./data/weather.nominal.arff", 'r') as f:
            data, meta = arff.loadarff(f)
            return data

    def get_soybean_data():
        def filter_soybean_data(data):
            for (_, row) in enumerate(data):
                has_empty = False
                for (_, value) in enumerate(row):
                    if value.decode('UTF-8') == '?':
                        has_empty = True
                        break

                if not has_empty:
                    yield row

        with open("./data/soybean.arff", 'r') as f:
            data, meta = arff.loadarff(f)
            return np.array(list(filter_soybean_data(data)))

    def test(data):
        TRAIN_SIZE = 0.75
        train_set, test_set = train_test_split(
            data,
            random_state=1,
            train_size=TRAIN_SIZE
        )
        (train_data, train_target) = split_training_and_target_data(train_set)
        (test_data, test_target) = split_training_and_target_data(test_set)

        classifier = NaiveBayes()
        classifier.fit(train_data, train_target)
        prediction = classifier.predict(test_data)

        # sk_bayes = GaussianNB()
        # sk_bayes.fit(train_data, train_target)
        # sk_prediction = sk_bayes.predict(test_data)

        print(prediction)
        print('---------')
        print(test_target)

    test(get_golf_data())
    # test(get_soybean_data())

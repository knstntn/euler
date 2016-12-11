using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace CCI
{
    public static class NullifyMatrix
    {
        public static int[][] Do(int[][] matrix)
        {
            var list = new List<Tuple<int, int>>();
            for (var row = 0; row < matrix.Length; row++)
            {
                for (var col = 0; col < matrix[row].Length; col++)
                {
                    if (matrix[row][col] == 0)
                    {
                        list.Add(Tuple.Create(row, col));
                    }
                }
            }

            foreach (var x in list)
            {
                for (var col = 0; col < matrix[x.Item1].Length; col++)
                {
                    matrix[x.Item1][col] = 0;
                }

                for (var row = 0; row < matrix.Length; row++)
                {
                    matrix[row][x.Item2] = 0;
                }
            }

            return matrix;
        }

        [TestFixture]
        public class NullifyMatrixTests
        {
            [Test]
            public void Test()
            {
                int[][] a =
                {
                    new[] {1, 2, 3, 0, 4},
                    new[] {1, 2, 3, 4, 5},
                    new[] {1, 2, 3, 4, 5}
                };
                int[][] c =
                {
                    new[] {0, 0, 0, 0, 0},
                    new[] {1, 2, 3, 0, 5},
                    new[] {1, 2, 3, 0, 5}
                };

                var b = Do(a);

                CollectionAssert.AreEqual(a, b);
                CollectionAssert.AreEqual(a, c);
            }
        }
    }
}
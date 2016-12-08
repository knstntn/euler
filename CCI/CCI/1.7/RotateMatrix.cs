using NUnit.Framework;

namespace CCI
{
    public static class RotateMatrix
    {
        public static int[,] RotateClockwise(int[,] matrix, int n)
        {
            for (var row = 0; row < n; row++)
            {
                for (var col = row + 1; col < n; col++)
                {
                    var tmp = matrix[row, col];

                    matrix[row, col] = matrix[col, row];
                    matrix[col, row] = tmp;
                }
            }

            return matrix;
        }

        [TestFixture]
        public class RotateMatrixTests
        {
            [Test]
            public void Test()
            {
                var a = new[,]
                {
                    {1, 2, 3},
                    {1, 2, 3},
                    {1, 2, 3}
                };
                var c = new[,]
                {
                    {1, 1, 1},
                    {2, 2, 2},
                    {3, 3, 3}
                };

                var b = RotateClockwise(a, 3);

                CollectionAssert.AreEqual(a, b);
                CollectionAssert.AreEqual(a, c);
            }
        }
    }
}
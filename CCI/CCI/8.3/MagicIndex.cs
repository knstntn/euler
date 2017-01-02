using NUnit.Framework;

namespace CCI
{
    public class MagicIndex
    {
        public static int Find(int[] array)
        {
            for (var i = 0; i < array.Length; i++)
            {
                if (i == array[i])
                    return i;
            }

            return -1;
        }

        public static int FindRec(int[] array)
        {
            if (array.Length == 0)
            {
                return -1;
            }

            return FindRec(array, 0, array.Length);
        }

        private static int FindRec(int[] a, int from, int to)
        {
            if (to < from)
                return -1;

            var mid = (from + to)/2;
            if (a[mid] == mid)
            {
                return mid;
            }
            if (a[mid] > mid)
            {
                return FindRec(a, from, mid - 1);
            }
            return FindRec(a, mid + 1, to);
        }

        [TestFixture]
        public class MagicIndexTests
        {
            [Test]
            public void Test()
            {
                Assert.AreEqual(1, Find(new[] {-1, 1, 3}));
                Assert.AreEqual(-1, Find(new[] {3, 4, 5}));
            }

            [Test]
            public void Test2()
            {
                Assert.AreEqual(1, FindRec(new[] {-1, 1, 3}));
                Assert.AreEqual(-1, FindRec(new[] {3, 4, 5}));
            }
        }
    }
}
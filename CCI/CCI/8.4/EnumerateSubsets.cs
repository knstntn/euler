using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace CCI
{
    public class EnumerateSubsets
    {
        public static IEnumerable<int[]> Enumerate(int[] a)
        {
            if (a == null || a.Length == 0)
            {
                yield return new int[0];
                yield break;
            }

            var head = a[0];
            var tail = a.Skip(1).ToArray();

            foreach (var res in Enumerate(tail))
            {
                yield return res;
                yield return new[] {head}.Concat(res).ToArray();
            }
        }


        [TestFixture]
        public class EnumerateSubsetsTests
        {
            [Test]
            public void Test()
            {
                CollectionAssert.AreEqual(new[]
                {
                    new int[0],
                    new[] {0}
                }, Enumerate(new[] {0}));
            }

            [Test]
            public void Test2()
            {
                CollectionAssert.AreEqual(new[]
                {
                    new int[0],
                    new[] {0},
                    new[] {1},
                    new[] {0, 1}
                }, Enumerate(new[] {0, 1}));
            }

            [Test]
            public void Test3()
            {
                CollectionAssert.AreEqual(new[]
                {
                    new int[0],
                    new[] {0},
                    new[] {1},
                    new[] {0, 1},
                    new[] {2},
                    new[] {0, 2},
                    new[] {1, 2},
                    new[] {0, 1, 2}
                }, Enumerate(new[] {0, 1, 2}));
            }
        }
    }
}
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace CCI
{
    public class BracketsPermutations
    {
        public static IEnumerable<string> Find(int n)
        {
            return FindImpl(n).Distinct();
        }

        private static IEnumerable<string> FindImpl(int n)
        {
            if (n == 0)
            {
                yield return null;
                yield break;
            }

            if (n == 1)
            {
                yield return "()";
                yield break;
            }

            foreach (var str in FindImpl(n - 1))
            {
                yield return $"(){str}";
                yield return $"({str})";
                yield return $"{str}()";
            }
        }

        [TestFixture]
        public class BracketsPermutationsTests
        {
            [Test]
            public void Test()
            {
                CollectionAssert.AreEqual(new[] {"()"}, Find(1));
                CollectionAssert.AreEqual(new[] {"()()", "(())"}, Find(2));
                CollectionAssert.AreEqual(new[] {"()()()", "(()())", "()(())", "((()))", "(())()"}, Find(3));
            }
        }
    }
}
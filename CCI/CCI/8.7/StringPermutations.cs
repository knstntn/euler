using System.Collections.Generic;
using NUnit.Framework;

namespace CCI
{
    public class StringPermutations
    {
        public static IEnumerable<string> Find(string s)
        {
            if (string.IsNullOrWhiteSpace(s))
            {
                yield return "";
                yield break;
            }

            if (s.Length == 1)
            {
                yield return s;
                yield break;
            }

            var head = s[0];
            var tail = s.Substring(1);
            foreach (var str in Find(tail))
            {
                for (var i = 0; i <= str.Length; i++)
                {
                    yield return str.Substring(0, i) + head + str.Substring(i);
                }
            }
        }

        [TestFixture]
        public class StringPermutationsTests
        {
            [Test]
            public void Test.1()
            {
                CollectionAssert.AreEqual(new[] {"ab", "ba"}, Find("ab"));
                CollectionAssert.AreEqual(new[] {"abc", "bac", "bca", "acb", "cab", "cba"}, Find("abc"));
            }
        }
    }
}
using System.Linq;
using NUnit.Framework;

namespace CCI
{
    public static class PalindromePermutation
    {
        public static bool Check(string s)
        {
            if (string.IsNullOrWhiteSpace(s))
            {
                return false;
            }

            var d = s.ToLowerInvariant().ToLookup(x => x).ToDictionary(x => x.Key, x => x.Count());
            var odd = false;
            foreach (var pair in d)
            {
                // we do not need meaningless characters
                if (!char.IsLetterOrDigit(pair.Key))
                {
                    continue;
                }

                if ((pair.Value%2) == 1)
                {
                    if (odd)
                    {
                        return false;
                    }

                    odd = true;
                }
            }

            return true;
        }

        [TestFixture]
        public class PalindromePermutationTests
        {
            [Test]
            public void Test()
            {
                Assert.IsTrue(PalindromePermutation.Check("Tact coa"));
                Assert.IsFalse(PalindromePermutation.Check("Tactt coa"));
            }
        }
    }
}
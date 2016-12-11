using NUnit.Framework;

namespace CCI
{
    public static class StringChecker
    {
        public static bool Check(string s1, string s2)
        {
            return IsSubstring(s1 + s1, s2);
        }

        private static bool IsSubstring(string s1, string s2)
        {
            return s1.Contains(s2);
        }

        [TestFixture]
        public class StringCheckerTests
        {
            [Test]
            public void Test()
            {
                Assert.IsTrue(Check("erbottlewat", "waterbottle"));
            }
        }
    }
}
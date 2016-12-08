using System.Text;
using NUnit.Framework;

namespace CCI
{
    public static class SqueezeString
    {
        public static string Do(string s)
        {
            if (string.IsNullOrWhiteSpace(s))
            {
                return s;
            }

            var count = 1;
            var builder = new StringBuilder();
            builder.Append(s[0]);

            for (var i = 1; i < s.Length; i++)
            {
                if (s[i - 1] == s[i])
                {
                    count++;
                    continue;
                }

                builder.Append(count);
                builder.Append(s[i]);
                count = 1;
            }
            builder.Append(count);

            return builder.Length >= s.Length ? s : builder.ToString();
        }

        [TestFixture]
        public class SqueezeStringTests
        {
            [Test]
            public void Test()
            {
                Assert.AreEqual("a2b1c5a3", Do("aabcccccaaa"));
                Assert.AreEqual("abc", Do("abc"));
                Assert.AreEqual("a3b3c3", Do("aaabbbccc"));
                Assert.AreEqual("aabbcc", Do("aabbcc"));
            }
        }
    }
}
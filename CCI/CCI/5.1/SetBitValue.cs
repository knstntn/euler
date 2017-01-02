using NUnit.Framework;

namespace CCI
{
    public class SetBitValue
    {
        public static int Set(int n, int m, int i, int j)
        {
            var left = (~0) << (j + 1);
            var right = ((1 << i) - i);
            var mask = left | right;
            return (n & mask) | (m << i);
        }

        [TestFixture]
        public class SetBitValueTests
        {
            [Test]
            public void Test()
            {
                var n = 0x10000000;
                var m = 0x10011;
                var expected = 0x11001100;

                Assert.AreEqual(expected, Set(n, m, 2, 6));
            }
        }
    }
}
using NUnit.Framework;

namespace CCI
{
    public class Multiplication
    {
        public static int Do(int a, int b)
        {
            if (a == 0 || b == 0)
            {
                return 0;
            }

            if (b == 1)
            {
                return a;
            }

            return a + Do(a, b - 1);
        }

        [TestFixture]
        public class MultiplicationTests
        {
            [Test]
            public void Test()
            {
                Assert.AreEqual(8, Do(2, 4));
                Assert.AreEqual(3, Do(3, 1));
                Assert.AreEqual(9, Do(3, 3));
            }
        }
    }
}
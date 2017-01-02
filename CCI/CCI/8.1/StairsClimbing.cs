using NUnit.Framework;

namespace CCI
{
    public class StairsClimbing
    {
        public static int Calculate(int n)
        {
            if (n < 0) return 0;
            if (n == 0) return 1;

            return Calculate(n - 3) +
                   Calculate(n - 2) +
                   Calculate(n - 1);
        }

        [TestFixture]
        public class StairsClimbingTests
        {
            [Test]
            public void Test()
            {
                Assert.AreEqual(1, Calculate(1));
                Assert.AreEqual(2, Calculate(2));
                Assert.AreEqual(4, Calculate(3));
                Assert.AreEqual(7, Calculate(4));
            }
        }

    }
}
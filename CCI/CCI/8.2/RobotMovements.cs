using NUnit.Framework;

namespace CCI
{
    public class RobotMovements
    {
        public static string FindPath(int r, int c, bool[][] blocked)
        {
            return FindPath(r, c, blocked, "");
        }

        private static string FindPath(int r, int c, bool[][] blocked, string path)
        {
            if (r == 0 && c == 0)
                return path;

            string p = null;

            if (r > 0 && !blocked[r - 1][c])
                p = FindPath(r - 1, c, blocked, "d" + path);

            if (string.IsNullOrWhiteSpace(p) && c > 0 && !blocked[r][c - 1])
                p = FindPath(r, c - 1, blocked, "r" + path);

            return p;
        }

        [TestFixture]
        public class StairsClimbingTests
        {
            [Test]
            public void Test1()
            {
                Assert.AreEqual("rd", FindPath(1, 1, new[]
                {
                    new[] {false, false},
                    new[] {false, false}
                }));
            }

            [Test]
            public void Test2()
            {
                Assert.AreEqual("rrrddd", FindPath(3, 3, new[]
                {
                    new[] {false, false, false, false},
                    new[] {false, false, false, false},
                    new[] {false, false, false, false},
                    new[] {false, false, false, false}
                }));
            }

            [Test]
            public void Test3()
            {
                Assert.AreEqual("dddrrr", FindPath(3, 3, new[]
                {
                    new[] {false, true, false, false},
                    new[] {false, true, false, false},
                    new[] {false, true, true, false},
                    new[] {false, false, false, false}
                }));
            }

            [Test]
            public void Test4()
            {
                Assert.AreEqual(null, FindPath(3, 3, new[]
                {
                    new[] {false, true, false, false},
                    new[] {false, true, false, false},
                    new[] {false, true, true, false},
                    new[] {true, false, false, false}
                }));
            }
        }
    }
}
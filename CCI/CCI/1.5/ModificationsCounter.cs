using System;
using NUnit.Framework;

namespace CCI
{
    public static class ModificationsCounter
    {
        public static bool Check(string left, string right)
        {
            if (left == right)
            {
                return true;
            }

            if (left == null || right == null)
            {
                return false;
            }

            if (CanAdd(left, right))
            {
                return true;
            }

            if (CanReplace(left, right))
            {
                return true;
            }

            return false;
        }

        private static bool CanAdd(string left, string right)
        {
            if (left.Length == right.Length)
            {
                return false;
            }

            if (Math.Abs(left.Length - right.Length) > 1)
            {
                return false;
            }

            var max = left;
            var min = right;
            if (max.Length < min.Length)
            {
                max = right;
                min = left;
            }

            var offset = 0;
            for (var i = 0; i < min.Length; i++)
            {
                if (min[i] != max[i + offset])
                {
                    offset++;

                    if (i + offset >= max.Length || min[i] != max[i + offset])
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        private static bool CanReplace(string left, string right)
        {
            if (left.Length != right.Length)
            {
                return false;
            }

            var canChange = true;
            for (var i = 0; i < left.Length; i++)
            {
                if (left[i] != right[i])
                {
                    if (!canChange)
                    {
                        return false;
                    }

                    canChange = false;
                }
            }
            return true;
        }

        [TestFixture]
        public class ModificationsCounterTests
        {
            [Test]
            public void Test()
            {
                Assert.IsTrue(Check("pale", "ple"));
                Assert.IsTrue(Check("pales", "pale"));
                Assert.IsTrue(Check("bale", "pale"));
                Assert.IsFalse(Check("bake", "pale"));
            }
        }
    }
}
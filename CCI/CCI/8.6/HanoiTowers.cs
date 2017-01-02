using System.Collections.Generic;
using NUnit.Framework;

namespace CCI
{
    public class HanoiTowers
    {
        public static void Move(Stack<int> left, Stack<int> middle, Stack<int> right)
        {
            if (left.Count == 1)
            {
                right.Push(left.Pop());
            }
            else
            {
                while (left.Count > 1)
                {
                    middle.Push(left.Pop());
                }

                right.Push(left.Pop());

                while (middle.Count > 0)
                {
                    right.Push(middle.Pop());
                }
            }
        }

        [TestFixture]
        public class HanoiTowersTests
        {
            [Test]
            public void Test1()
            {
                var s1 = new Stack<int>();
                var s2 = new Stack<int>();
                var s3 = new Stack<int>();

                s1.Push(1);

                CollectionAssert.AreEqual(new[] {1}, s1);
                Move(s1, s2, s3);
                CollectionAssert.AreEqual(new[] {1}, s3);
            }

            [Test]
            public void Test2()
            {
                var s1 = new Stack<int>();
                var s2 = new Stack<int>();
                var s3 = new Stack<int>();

                s1.Push(2);
                s1.Push(1);

                CollectionAssert.AreEqual(new[] {1, 2}, s1);
                Move(s1, s2, s3);
                CollectionAssert.AreEqual(new[] {1, 2}, s3);
            }

            [Test]
            public void Test3()
            {
                var s1 = new Stack<int>();
                var s2 = new Stack<int>();
                var s3 = new Stack<int>();

                s1.Push(5);
                s1.Push(4);
                s1.Push(3);
                s1.Push(2);
                s1.Push(1);

                CollectionAssert.AreEqual(new[] {1, 2, 3, 4, 5}, s1);
                Move(s1, s2, s3);
                CollectionAssert.AreEqual(new[] {1, 2, 3, 4, 5}, s3);
            }
        }
    }
}
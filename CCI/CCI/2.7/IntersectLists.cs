using System.Collections.Generic;
using NUnit.Framework;

namespace CCI
{
    public class IntersectLists
    {
        public static Node<int> Check1(Node<int> n1, Node<int> n2)
        {
            var iter1 = n1;
            while (iter1 != null)
            {
                var iter2 = n2;
                while (iter2 != null)
                {
                    if (iter1 == iter2)
                    {
                        return iter1;
                    }

                    iter2 = iter2.Next;
                }

                iter1 = iter1.Next;
            }

            return null;
        }

        public static Node<int> Check2(Node<int> n1, Node<int> n2)
        {
            var visited = new HashSet<Node<int>>();
            var iter1 = n1;
            while (iter1 != null)
            {
                visited.Add(iter1);
                iter1 = iter1.Next;
            }

            var iter2 = n2;
            while (iter2 != null)
            {
                if (visited.Contains(iter2))
                {
                    return iter2;
                }

                iter2 = iter2.Next;
            }

            return null;
        }

        [TestFixture]
        public class IntersectListsTests
        {
            [Test]
            public void Check1Test()
            {
                var common = new Node<int>(3, new Node<int>(2, new Node<int>(5)));
                var n1 = new Node<int>(1, new Node<int>(2, common));
                var n2 = new Node<int>(1, new Node<int>(2, new Node<int>(3, common)));
                Assert.AreEqual(common, Check1(n1, n2));
            }

            [Test]
            public void Check2Test()
            {
                var common = new Node<int>(3, new Node<int>(2, new Node<int>(5)));
                var n1 = new Node<int>(1, new Node<int>(2, common));
                var n2 = new Node<int>(1, new Node<int>(2, new Node<int>(3, common)));
                Assert.AreEqual(common, Check2(n1, n2));
            }
        }
    }
}
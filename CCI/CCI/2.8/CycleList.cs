using System.Collections.Generic;
using NUnit.Framework;

namespace CCI
{
    public class CycleList
    {
        public static Node<int> Find1(Node<int> n)
        {
            var visited = new HashSet<Node<int>>();

            while (n != null)
            {
                if (visited.Contains(n))
                {
                    return n;
                }

                visited.Add(n);
                n = n.Next;
            }

            return null;
        }

        public static Node<int> Find2(Node<int> n)
        {
            var slow = n;
            var fast = n.Next;

            while (slow != null && fast?.Next != null)
            {
                if (slow == fast)
                {
                    // WRONG: incorrect collision point
                    return slow.Next;
                }

                slow = slow.Next;
                fast = fast.Next.Next;
            }

            return null;
        }


        [TestFixture]
        public class CycleListTests
        {
            [Test]
            public void Find1Test()
            {
                var common = new Node<int>(3);
                common.Next = new Node<int>(2, common);

                var n = new Node<int>(1, new Node<int>(2, common));
                Assert.AreEqual(common, Find1(n));
            }

            [Test]
            public void Find2Test()
            {
                var common = new Node<int>(3);
                common.Next = new Node<int>(4, common);

                var n = new Node<int>(1, new Node<int>(2, common));
                var found = Find2(n);
                Assert.AreEqual(common.Data, found.Data);
            }
        }
    }
}
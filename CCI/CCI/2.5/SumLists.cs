using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace CCI
{
    public class SumLists
    {
        public static Node<int> Sum1(Node<int> n1, Node<int> n2)
        {
            var root = new Node<int>();
            Node<int> res = null;

            var prev = 0;
            while (n1 != null || n2 != null)
            {
                var data = (n1?.Data ?? 0) + (n2?.Data ?? 0) + prev;

                if (res == null)
                {
                    res = root;
                }
                else
                {
                    res.Next = new Node<int>();
                    res = res.Next;
                }

                res.Data = data%10;

                prev = data/10;

                n1 = n1?.Next;
                n2 = n2?.Next;
            }

            if (prev != 0)
            {
                res.Data = prev;
            }

            return root;
        }

        // WRONG: did not consider that lists could have different length
        public static Node<int> Sum2(Node<int> n1, Node<int> n2)
        {
            var root = new Node<int>();
            Node<int> res = null;

            while (n1 != null || n2 != null)
            {
                var next = ((n1?.Next?.Data ?? 0) + (n2?.Next?.Data ?? 0))/10;
                var data = (n1?.Data ?? 0) + (n2?.Data ?? 0) + next;

                if (res == null)
                {
                    if (data/10 > 0)
                    {
                        root.Data = data/10;
                        root.Next = new Node<int>();
                        res = root.Next;
                    }
                    else
                    {
                        res = root;
                    }
                }
                else
                {
                    res.Next = new Node<int>();
                    res = res.Next;
                }

                res.Data = data%10;

                n1 = n1?.Next;
                n2 = n2?.Next;
            }

            return root;
        }

        [TestFixture]
        public class SumListsTests
        {
            [Test]
            public void Sum1Test()
            {
                var n1 = new Node<int>(7, new Node<int>(1, new Node<int>(6)));
                var n2 = new Node<int>(5, new Node<int>(9, new Node<int>(2)));

                var updated = Sum1(n1, n2).Select(x => x.Data).ToList();
                CollectionAssert.AreEqual(new List<int> {2, 1, 9}, updated);
            }

            [Test]
            public void Sum2Test()
            {
                var n1 = new Node<int>(6, new Node<int>(1, new Node<int>(7)));
                var n2 = new Node<int>(2, new Node<int>(9, new Node<int>(5)));

                var updated = Sum2(n1, n2).Select(x => x.Data).ToList();
                CollectionAssert.AreEqual(new List<int> { 9, 1, 2 }, updated);
            }
        }
    }
}
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace CCI
{
    public static class SortList
    {
        public static Node<int> Do(Node<int> node, int value)
        {
            Node<int> before = null;
            Node<int> after = null;

            Node<int> iter1 = null;
            Node<int> iter2 = null;

            while (node != null)
            {
                if (node.Data < value)
                {
                    if (before == null)
                    {
                        before = new Node<int> {Data = node.Data};
                        iter2 = before;
                    }
                    else
                    {
                        var n = new Node<int> {Data = node.Data};
                        iter2.Next = n;
                        iter2 = n;
                    }
                }
                else
                {
                    if (after == null)
                    {
                        after = new Node<int> {Data = node.Data};
                        iter1 = after;
                    }
                    else
                    {
                        var n = new Node<int> {Data = node.Data};
                        iter1.Next = n;
                        iter1 = n;
                    }
                }

                node = node.Next;
            }

            if (iter2 != null)
            {
                iter2.Next = after;
            }

            return before ?? after;
        }

        [TestFixture]
        public class SortListTests
        {
            [Test]
            public void Test1()
            {
                var root = new Node<int>
                {
                    Data = 1,
                    Next = new Node<int>
                    {
                        Data = 2,
                        Next = new Node<int>
                        {
                            Data = 3,
                            Next = new Node<int>
                            {
                                Data = 2,
                                Next = new Node<int>
                                {
                                    Data = 4
                                }
                            }
                        }
                    }
                };
                var updated = Do(root, 3).AsEnumerable().Select(x => x.Data).ToList();
                CollectionAssert.AreEqual(new List<int> {1, 2, 2, 3, 4}, updated);
            }
        }
    }
}
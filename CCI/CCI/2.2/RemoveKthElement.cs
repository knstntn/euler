using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace CCI
{
    public class RemoveKthElement
    {
        public static Node<int> Do(Node<int> root, int k)
        {
            var length = root.Count();
            var n = length - 1 - k;

            var tmp = root;
            Node<int> prev = null;
            while (n-- > 0)
            {
                prev = tmp;
                tmp = tmp.Next;
            }

            if (prev != null)
            {
                prev.Next = tmp.Next;
                return root;
            }

            // if prev is null tmp is root
            return tmp.Next;
        }

        [TestFixture]
        public class RemoveKthElementTests
        {
            [SetUp]
            public void Setup()
            {
                _root = new Node<int>
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
            }

            private Node<int> _root;

            [Test]
            public void Test1()
            {
                var updated = Do(_root, 3).Select(x => x.Data).ToList();
                CollectionAssert.AreEqual(new List<int> {1, 3, 2, 4}, updated);
            }

            [Test]
            public void Test2()
            {
                var updated = Do(_root, 4).Select(x => x.Data).ToList();
                CollectionAssert.AreEqual(new List<int> {2, 3, 2, 4}, updated);
            }

            [Test]
            public void Test3()
            {
                var updated = Do(_root, 0).Select(x => x.Data).ToList();
                CollectionAssert.AreEqual(new List<int> {1, 2, 3, 2}, updated);
            }
        }
    }
}
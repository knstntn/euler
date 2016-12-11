using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace CCI
{
    public static class LinkedListDuplicates
    {
        public static Node<int> RemoveDuplicates(Node<int> root)
        {
            var visited = new HashSet<object>();

            Node<int> prev = null;
            var tmp = root;
            while (tmp != null)
            {
                if (!visited.Contains(tmp.Data))
                {
                    visited.Add(tmp.Data);
                }
                else
                {
                    if (prev != null)
                    {
                        prev.Next = tmp.Next;
                    }
                }

                prev = tmp;
                tmp = tmp.Next;
            }

            return root;
        }

        [TestFixture]
        public class LinkedListDuplicatesTests
        {
            [Test]
            public void Test()
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
                var updated = RemoveDuplicates(root).Select(x => x.Data).ToList();
                CollectionAssert.AreEqual(new List<int> {1, 2, 3, 4}, updated);
            }
        }
    }
}
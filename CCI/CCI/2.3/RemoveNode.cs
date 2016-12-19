using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace CCI
{
    public static class RemoveNode
    {
        // PARTIALLY WRONG: I just wanted to remove next element
        public static void Do(Node<int> node)
        {
            if (node == null || node.Next == null)
            {
                return;
            }

            node.Data = node.Next.Data;
            node.Next = node.Next.Next;
        }

        [TestFixture]
        public class RemoveNodeTests
        {
            [Test]
            public void Test()
            {
                var node = new Node<int>
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
                };
                var root = new Node<int>
                {
                    Data = 1,
                    Next = new Node<int>
                    {
                        Data = 2,
                        Next = node
                    }
                };

                Do(node);

                var updated = root.AsEnumerable().Select(x => x.Data).ToList();
                CollectionAssert.AreEqual(new List<int> {1, 2, 2, 4}, updated);
            }
        }
    }
}
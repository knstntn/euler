using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace CCI
{
    public class TreeToList
    {
        public static IEnumerable<Node<int>> Convert(TreeNode tree)
        {
            var queue = new Queue<Tuple<TreeNode, int>>();
            queue.Enqueue(Tuple.Create(tree, 0));

            var prevLevel = 0;
            Node<int> root = null;
            Node<int> current = null;
            var res = new List<Node<int>>();
            while (queue.Count > 0)
            {
                var node = queue.Dequeue();
                if (prevLevel != node.Item2)
                {
                    res.Add(root);

                    root = null;
                    current = null;

                    prevLevel = node.Item2;
                }

                if (current == null)
                {
                    root = new Node<int>();
                    current = root;
                }
                else
                {
                    current.Next = new Node<int>();
                    current = current.Next;
                }

                current.Data = node.Item1.Value;

                if (node.Item1.Left != null)
                {
                    queue.Enqueue(Tuple.Create(node.Item1.Left, node.Item2 + 1));
                }

                if (node.Item1.Right != null)
                {
                    queue.Enqueue(Tuple.Create(node.Item1.Right, node.Item2 + 1));
                }
            }

            if (root != null)
            {
                res.Add(root);
            }

            return res;
        }

        public class TreeNode
        {
            public int Value { get; set; }
            public TreeNode Left { get; set; }
            public TreeNode Right { get; set; }
        }

        [TestFixture]
        public class TreeToListTests
        {
            [Test]
            public void Test()
            {
                var tree = new TreeNode
                {
                    Value = 1,
                    Left = new TreeNode
                    {
                        Value = 2,
                        Left = new TreeNode {Value = 4},
                        Right = new TreeNode {Value = 5}
                    },
                    Right = new TreeNode
                    {
                        Value = 3,
                        Left = new TreeNode {Value = 6},
                        Right = new TreeNode {Value = 7}
                    }
                };
                var nodes = Convert(tree).ToArray();

                Assert.AreEqual(3, nodes.Length);
                CollectionAssert.AreEqual(new[] {1}, nodes[0].AsEnumerable().Select(x => x.Data).ToArray());
                CollectionAssert.AreEqual(new[] {2, 3}, nodes[1].AsEnumerable().Select(x => x.Data).ToArray());
                CollectionAssert.AreEqual(new[] {4, 5, 6, 7}, nodes[2].AsEnumerable().Select(x => x.Data).ToArray());
            }
        }
    }
}
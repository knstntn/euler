using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace CCI
{
    public class TreeIsBST
    {
        public static bool IsBinarySearchTree1(TreeNode node)
        {
            var list = new List<int>();
            Traverse(list, node);

            for (var i = 1; i < list.Count; i++)
            {
                if (list[i] - list[i - 1] <= 0)
                {
                    return false;
                }
            }

            return true;
        }

        public static bool IsBinarySearchTree2(TreeNode node)
        {
           return CheckBST(node, Int32.MinValue, Int32.MaxValue);
        }

        private static bool CheckBST(TreeNode node, int left, int right)
        {
            if (node == null)
                return true;

            if (node.Value < left || node.Value > right)
            {
                return false;
            }

            return CheckBST(node.Left, left, node.Value - 1) && CheckBST(node.Right, node.Value + 1, right);
        }

        private static void Traverse(List<int> list, TreeNode node)
        {
            if (node == null)
            {
                return;
            }

            Traverse(list, node.Left);
            list.Add(node.Value);
            Traverse(list, node.Right);
        }

        public class TreeNode
        {
            public int Value { get; set; }
            public TreeNode Left { get; set; }
            public TreeNode Right { get; set; }
        }

        [TestFixture]
        public class TreeIsBSTTests
        {
            [Test]
            public void Test1()
            {
                Assert.IsTrue(IsBinarySearchTree1(new TreeNode
                {
                    Value = 2,
                    Left = new TreeNode {Value = 1},
                    Right = new TreeNode {Value = 3}
                }));

                Assert.IsFalse(IsBinarySearchTree1(new TreeNode
                {
                    Value = 2,
                    Left = new TreeNode {Value = 3},
                    Right = new TreeNode {Value = 1}
                }));
            }

            [Test]
            public void Test2()
            {
                Assert.IsTrue(IsBinarySearchTree2(new TreeNode
                {
                    Value = 2,
                    Left = new TreeNode { Value = 1 },
                    Right = new TreeNode { Value = 3 }
                }));

                Assert.IsFalse(IsBinarySearchTree2(new TreeNode
                {
                    Value = 2,
                    Left = new TreeNode { Value = 3 },
                    Right = new TreeNode { Value = 1 }
                }));
            }

        }
    }
}
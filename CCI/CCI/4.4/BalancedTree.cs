using System;
using NUnit.Framework;

namespace CCI
{
    public class BalancedTree
    {
        public static bool Check(TreeNode node)
        {
            if (node == null)
            {
                return true;
            }

            var diff = Math.Abs((node.Left?.Height ?? 0) - (node.Right?.Height ?? 0));
            if (diff > 1)
            {
                return false;
            }

            return Check(node.Left) && Check(node.Right);
        }

        public class TreeNode
        {
            public int Height { get; set; }
            public int Value { get; set; }
            public TreeNode Left { get; set; }
            public TreeNode Right { get; set; }
        }

        [TestFixture]
        public class BalancedTreeTests
        {
            [Test]
            public void Test()
            {
                var tree = new TreeNode
                {
                    Value = 1,
                    Height = 2,
                    Left = new TreeNode
                    {
                        Value = 2,
                        Height = 1,
                        Left = new TreeNode
                        {
                            Value = 4,
                            Height = 0
                        },
                        Right = new TreeNode
                        {
                            Value = 5,
                            Height = 0
                        }
                    },
                    Right = new TreeNode
                    {
                        Value = 3,
                        Height = 1,
                        Left = new TreeNode {Value = 6, Height = 0},
                        Right = new TreeNode {Value = 7, Height = 0}
                    }
                };
                Assert.IsTrue(Check(tree));

                var t2 = new TreeNode
                {
                    Height = tree.Height + 1,
                    Value = -1,
                    Left = tree
                };
                Assert.IsFalse(Check(t2));
            }
        }
    }
}
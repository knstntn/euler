using NUnit.Framework;

namespace CCI
{
    public class FindNext
    {
        public static TreeNode Find(TreeNode node)
        {
            if (node == null)
            {
                return null;
            }

            if (node.Right == null)
            {
                if (node.Parent == null)
                {
                    return null;
                }

                if (node.Parent.Left == node)
                {
                    return node.Parent;
                }

                if (node.Parent.Right == node)
                {
                    return node.Parent.Parent;
                }
            }

            return FindMostLeft(node.Right);
        }

        private static TreeNode FindMostLeft(TreeNode node)
        {
            while (node.Left != null)
            {
                node = node.Left;
            }

            return node;
        }

        public class TreeNode
        {
            public int Value { get; set; }
            public TreeNode Parent { get; set; }
            public TreeNode Left { get; set; }
            public TreeNode Right { get; set; }
        }

        [TestFixture]
        public class FindNextTests
        {
            [Test]
            public void Test()
            {
                Assert.IsNull(Find(new TreeNode()));
                var root = new TreeNode();
                var expected = new TreeNode
                {
                    Left = root,
                    Right = new TreeNode()
                };
                root.Parent = expected;
                Assert.AreEqual(expected, Find(root));
            }
        }
    }
}
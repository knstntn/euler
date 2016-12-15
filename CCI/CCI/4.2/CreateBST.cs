using System.Linq;
using NUnit.Framework;

namespace CCI
{
    public class CreateBST
    {
        public static TreeNode Build(int[] array)
        {
            if (array.Length == 0)
            {
                return null;
            }

            if (array.Length == 1)
            {
                return new TreeNode {Value = array[0]};
            }

            var mid = array.Length/2;
            return new TreeNode
            {
                Value = array[mid],
                Left = Build(array.Where(x => x < array[mid]).ToArray()),
                Right = Build(array.Where(x => x > array[mid]).ToArray())
            };
        }

        public class TreeNode
        {
            public int Value { get; set; }
            public TreeNode Left { get; set; }
            public TreeNode Right { get; set; }
        }

        [TestFixture]
        public class CreateBSTTests
        {
            [Test]
            public void Test()
            {
                var a = new[] {1, 2, 3, 4, 5, 6, 7, 8};
                var root = Build(a);
                Assert.AreEqual(5, root.Value);
                Assert.AreEqual(3, root.Left.Value);
                Assert.AreEqual(2, root.Left.Left.Value);
                Assert.AreEqual(4, root.Left.Right.Value);
                Assert.AreEqual(1, root.Left.Left.Left.Value);
                Assert.IsNull(root.Left.Left.Right);
                Assert.AreEqual(7, root.Right.Value);
                Assert.AreEqual(6, root.Right.Left.Value);
                Assert.AreEqual(8, root.Right.Right.Value);
            }
        }

    }
}
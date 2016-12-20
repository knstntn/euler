using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace CCI
{
    public class TreePermutations
    {
        public static IEnumerable<List<int>> ListArrays(TreeNode root)
        {
            if (root == null)
            {
                return new List<List<int>> {new List<int>()};
            }

            var left = ListArrays(root.Left);
            var right = ListArrays(root.Right);

            return Weave(root.Value, left, right).ToArray();
        }

        private static IEnumerable<List<int>> Weave(int prefix, IEnumerable<List<int>> left, IEnumerable<List<int>> right)
        {
            var result = new List<List<int>>();

            foreach (var l in left)
            {
                foreach (var r in right)
                {
                    var weaved = Weave(new List<int> {prefix}, l, r).ToArray();
                    result.AddRange(weaved);
                }
            }

            return result;
        }

        private static IEnumerable<List<int>> Weave(List<int> prefix, List<int> left, List<int> right)
        {
            if (left.Count == 0 || right.Count == 0)
            {
                return new[] {prefix.Concat(left).Concat(right).ToList()};
            }

            var result = new List<List<int>>();

            var headLeft = left[0];
            prefix.Add(headLeft);
            left.RemoveAt(0);
            result.AddRange(Weave(prefix, left, right).ToList());
            prefix.RemoveAt(prefix.Count - 1);
            left.Insert(0, headLeft);

            var headRight = right[0];
            prefix.Add(headRight);
            right.RemoveAt(0);
            result.AddRange(Weave(prefix, left, right).ToList());
            prefix.RemoveAt(prefix.Count - 1);
            right.Insert(0, headRight);

            return result;
        }

        public class TreeNode
        {
            public int Value { get; set; }
            public TreeNode Left { get; set; }
            public TreeNode Right { get; set; }
        }

        [TestFixture]
        public class TreePermutationsTests
        {
            [Test]
            public void Test()
            {
                var node = new TreeNode
                {
                    Value = 3,
                    Left = new TreeNode
                    {
                        Value = 2,
                        Left = new TreeNode { Value = 1 },
                    },
                    Right = new TreeNode {Value = 4}
                };
                var res = ListArrays(node).ToArray();
                Assert.AreEqual(3, res.Length);
                CollectionAssert.AreEqual(new[] {3, 2, 1, 4}, res[0]);
                CollectionAssert.AreEqual(new[] {3, 2, 4, 1}, res[1]);
                CollectionAssert.AreEqual(new[] {3, 4, 2, 1}, res[2]);
            }
        }
    }
}
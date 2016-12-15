using NUnit.Framework;

namespace CCI
{
    public class GraphPathSearch
    {
        public static bool Find(GraphNode from, GraphNode to)
        {
            if (from == to)
            {
                return true;
            }

            if (from.Children == null)
            {
                return false;
            }

            foreach (var child in from.Children)
            {
                if (Find(child, to))
                {
                    return true;
                }
            }

            return false;
        }

        [TestFixture]
        public class GraphPathSearchTests
        {
            [Test]
            public void Test()
            {
                var to = new GraphNode();
                var from = new GraphNode
                {
                    Children = new[]
                    {
                        new GraphNode(),
                        new GraphNode(),
                        new GraphNode
                        {
                            Children = new[]
                            {
                                new GraphNode(),
                                to,
                                new GraphNode()
                            }
                        }
                    }
                };
                var from2 = new GraphNode
                {
                    Children = new[]
                    {
                        new GraphNode(),
                        new GraphNode(),
                        new GraphNode
                        {
                            Children = new[]
                            {
                                new GraphNode(),
                                new GraphNode()
                            }
                        }
                    }
                };
                Assert.IsTrue(Find(from, to));
                Assert.IsFalse(Find(from2, to));
            }
        }
    }
}
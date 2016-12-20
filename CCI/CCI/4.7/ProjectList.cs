using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace CCI
{
    public class ProjectList
    {
        private static readonly Queue<Vertex> sorted = new Queue<Vertex>();

        // there cannot be cycles
        public static IEnumerable<string> Schedule(string[] projects, IEnumerable<Tuple<string, string>> dependencies)
        {
            var g = new Vertex[projects.Length];
            for (var i = 0; i < projects.Length; i++)
            {
                g[i] = new Vertex(projects[i]);
            }

            foreach (var dep in dependencies)
            {
                var v = g.Single(x => x.Value == dep.Item1);
                var w = g.Single(x => x.Value == dep.Item2);

                v.Children.Add(w);
            }

            dfs(g);

            while (sorted.Count > 0)
            {
                var v = sorted.Dequeue();
                yield return v.Value;
            }
        }

        private static void dfs(Vertex[] g)
        {
            foreach (var v in g)
            {
                if (v.Visited)
                {
                    continue;
                }
                dfs(v);
            }
        }

        private static void dfs(Vertex v)
        {
            v.Visited = true;

            foreach (var vertex in v.Children)
            {
                if (!vertex.Visited)
                {
                    dfs(vertex);
                }
            }

            sorted.Enqueue(v);
        }

        private class Vertex
        {
            public Vertex(string value)
            {
                Value = value;
                Visited = false;
                Children = new List<Vertex>();
            }

            public string Value { get; }
            public bool Visited { get; set; }
            public IList<Vertex> Children { get; }
        }

        [TestFixture]
        public class ProjectListTests
        {
            [Test]
            public void Test()
            {
                var projects = new[] {"a", "b", "c", "d", "e", "f"};
                var deps = new[]
                {
                    Tuple.Create(projects[3], projects[0]),
                    Tuple.Create(projects[1], projects[5]),
                    Tuple.Create(projects[3], projects[1]),
                    Tuple.Create(projects[0], projects[5]),
                    Tuple.Create(projects[2], projects[3])
                };
                var res = Schedule(projects, deps).ToList();
                CollectionAssert.AreEqual(new[] {"f", "a", "b", "d", "c", "e"}, res);
            }
        }
    }
}
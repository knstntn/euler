using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Heaps
{
    public class Dijkstra
    {
        private readonly Graph _graph;

        public Dijkstra(IEnumerable<int> vertices, IEnumerable<Tuple<int, int, int>> edges)
        {
            _graph = new Graph();
            foreach (var vertex in vertices)
            {
                _graph.Vertices.Add(new Vertex(vertex));
            }

            foreach (var edge in edges)
            {
                var from = _graph.Vertices.First(x => x.Value == edge.Item1);
                var to = _graph.Vertices.First(x => x.Value == edge.Item2);

                from.Adjacent.Add(new Edge {To = to, Weght = edge.Item3});
            }
        }

        public int Distance(int v, int w)
        {
            var from = _graph.Vertices.First(x => x.Value == v);
            var to = _graph.Vertices.First(x => x.Value == w);

            var paths = Paths(from);
            if (paths.ContainsKey(to))
            {
                return paths[to];
            }

            return -1;
        }

        private IDictionary<Vertex, int> Paths(Vertex from)
        {
            var distances = new Dictionary<Vertex, int>();
            var pq = new BinaryHeap<Tuple<Vertex, int>>((a, b) => a.Item2.CompareTo(b.Item2) < 0);

            foreach (var vertex in _graph.Vertices)
            {
                distances[vertex] = int.MaxValue;
            }

            distances[from] = 0;
            pq.Push(Tuple.Create(from, 0));

            while (pq.Length() > 0)
            {
                var tuple = pq.Pop();
                foreach (var edge in tuple.Item1.Adjacent)
                {
                    if (distances[edge.To] > distances[tuple.Item1] + edge.Weght)
                    {
                        distances[edge.To] = distances[tuple.Item1] + edge.Weght;

                        if (pq.Contains(t => t.Item1 == edge.To))
                        {
                            pq.Replace(t => t.Item1 == edge.To, Tuple.Create(edge.To, distances[edge.To]));
                        }
                        else
                        {
                            pq.Push(Tuple.Create(edge.To, distances[edge.To]));
                        }
                    }
                }
            }

            return distances;
        }

        public class Vertex
        {
            public Vertex(int value)
            {
                Value = value;
                Adjacent = new List<Edge>();
            }

            public int Value { get; }
            public IList<Edge> Adjacent { get; }
        }

        public class Edge
        {
            public int Weght { get; set; }
            public Vertex To { get; set; }
        }

        public class Graph
        {
            public Graph()
            {
                Vertices = new List<Vertex>();
            }

            public IList<Vertex> Vertices { get; set; }
        }

        [TestFixture]
        public class DijkstraTests
        {
            [Test]
            public void Test()
            {
                var vertices = new[] {1, 2, 3, 4};
                var edges = new[]
                {
                    Tuple.Create(1, 2, 1),
                    Tuple.Create(1, 3, 5),
                    Tuple.Create(1, 4, 2),
                    Tuple.Create(2, 4, 2),
                    Tuple.Create(4, 3, 1),
                };

                var d = new Dijkstra(vertices, edges);
                Assert.AreEqual(1, d.Distance(1, 2));
                Assert.AreEqual(2, d.Distance(1, 4));
                Assert.AreEqual(3, d.Distance(1, 3));
            }
        }
    }
}
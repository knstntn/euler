using System.Collections.Generic;
using System.Linq;

namespace Trie
{
    /// <summary> Represents trie structure </summary>
    public sealed class Trie
    {
        /// <summary> End of chain indicator for trie </summary>
        private const char End = '*';

        /// <summary> Contains character nodes </summary>
        private readonly IDictionary<char, Node> _nodes = new Dictionary<char, Node>();

        /// <summary> Adds string to the trie </summary>
        /// <param name="s">Value to add to trie</param>
        public void Add(string s)
        {
            Add(_nodes, s, 0);
        }

        /// <summary> Returns amount of words starting with fiven prefix </summary>
        /// <param name="prefix">Prefix to look for</param>
        /// <returns>Amount of words</returns>
        public int Count(string prefix)
        {
            var node = Find(_nodes, prefix, 0);
            if (node == null)
            {
                return 0;
            }

            return node.Count;
        }

        /// <summary> Returns list of strings which starts with given prefix </summary>
        /// <param name="prefix">Prefix to look for</param>
        /// <returns>Collection of strings</returns>
        public IEnumerable<string> Find(string prefix)
        {
            var node = Find(_nodes, prefix, 0);
            if (node == null)
            {
                return Enumerable.Empty<string>();
            }

            return Strings(node);
        }

        /// <summary> Adds string to given nodes collection </summary>
        /// <param name="nodes">Collection of nodes</param>
        /// <param name="s">String to add</param>
        /// <param name="index">Current character index in string</param>
        private static bool Add(IDictionary<char, Node> nodes, string s, int index)
        {
            if (s.Length == index)
            {
                if (!nodes.ContainsKey(End))
                {
                    var node = new Node(s, 0);
                    nodes.Add(End, node);
                    return true;
                }
                return false;
            }

            var letter = s[index];
            if (!nodes.ContainsKey(letter))
            {
                var node = new Node(string.Empty, 0);
                nodes.Add(letter, node);
            }

            var found = nodes[letter];
            var res = Add(found.Children, s, index + 1);
            if (res)
            {
                found.Count += 1;
            }
            return res;
        }

        /// <summary> Finds node which starts with given prefix </summary>
        /// <param name="nodes">Collection of nodes</param>
        /// <param name="prefix">Prefix to find</param>
        /// <param name="index">Current character index in prefix</param>
        /// <returns>Found node</returns>
        private static Node Find(IDictionary<char, Node> nodes, string prefix, int index)
        {
            var letter = prefix[index];
            if (nodes.ContainsKey(letter))
            {
                if (prefix.Length == index + 1)
                {
                    return nodes[letter];
                }

                return Find(nodes[letter].Children, prefix, index + 1);
            }

            return null;
        }

        /// <summary> Finds all strings starting from given node </summary>
        /// <param name="node">Search root</param>
        /// <returns>Collection of strings</returns>
        private static IEnumerable<string> Strings(Node node)
        {
            foreach (var child in node.Children)
            {
                if (child.Key == End)
                {
                    yield return child.Value.String;
                }
                else
                {
                    foreach (var str in Strings(child.Value))
                    {
                        yield return str;
                    }
                }
            }
        }

        /// <summary> Single trie node </summary>
        private sealed class Node
        {
            /// <summary> Ctor </summary>
            /// <param name="s">Contains string which is stored in trie</param>
            /// <param name="count">Amount of words starting with current string</param>
            public Node(string s, int count)
            {
                String = s;
                Count = count;
                Children = new Dictionary<char, Node>();
            }

            /// <summary> Returns string which user placed in trie  </summary>
            public string String { get; }

            /// <summary> Returns amount of words starting with current string (including itself) </summary>
            public int Count { get; set; }

            /// <summary> Gets list of chidren </summary>
            public IDictionary<char, Node> Children { get; }
        }
    }
}
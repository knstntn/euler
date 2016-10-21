using System;
using System.IO;
using System.Linq;
using System.Reflection;
using NUnit.Framework;

namespace Trie
{
    [TestFixture]
    internal sealed class TrieTests
    {
        [Test]
        public void Simple()
        {
            var trie = new Trie();

            trie.Add("1");
            trie.Add("1");
            trie.Add("12");
            trie.Add("123");
            trie.Add("1234");

            var values = trie.Find("1").ToArray();
            Assert.AreEqual(4, values.Length);
            Assert.AreEqual("1", values[0]);
            Assert.AreEqual("12", values[1]);
            Assert.AreEqual("123", values[2]);
            Assert.AreEqual("1234", values[3]);

            var count = trie.Count("1");

            Assert.AreEqual(values.Length, count);
        }

        [Test]
        public void Test0()
        {
            var trie = new Trie();

            trie.Add("hack");
            trie.Add("hackerrank");

            var values = trie.Find("hack").ToArray();
            Assert.AreEqual(2, values.Length);
            Assert.AreEqual("hack", values[0]);
            Assert.AreEqual("hackerrank", values[1]);

            values = trie.Find("hak").ToArray();
            Assert.AreEqual(0, values.Length);
        }

        [Test]
        public void Test2()
        {
            FileTest("test2");
        }

        private static void FileTest(string name)
        {
            var input = ReadFromResource("Trie.TestCases." + name + ".txt").Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            var res = ReadFromResource("Trie.TestCases." + name + ".res.txt").Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);

            var pairs = input.Skip(1).Select(x => x.Split(' ')).Select(x => Tuple.Create(x[0], x[1])).ToArray();
            var trie = new Trie();
            for (var i = 0; i < pairs.Length; i++)
            {
                var pair = pairs[i];

                if (pair.Item1 == "add")
                {
                    trie.Add(pair.Item2);
                }
                else if (pair.Item1 == "find")
                {
                    var cnt = trie.Find(pair.Item2).Count();
                    var cnt2 = trie.Count(pair.Item2);
                    Assert.AreEqual(res[i], cnt.ToString());
                    Assert.AreEqual(res[i], cnt2.ToString());
                }
            }
        }

        private static string ReadFromResource(string name)
        {
            var assembly = Assembly.GetExecutingAssembly();
            using (var stream = assembly.GetManifestResourceStream(name))
            using (var reader = new StreamReader(stream))
            {
                return reader.ReadToEnd();
            }
        }
    }
}
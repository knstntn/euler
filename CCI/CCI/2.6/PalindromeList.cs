using System.Collections.Generic;
using NUnit.Framework;

namespace CCI
{
    public class PalindromeList
    {
        public static bool Check(Node<int> root)
        {
            Node<int> reversed = null;

            var tmp = root;
            while (tmp != null)
            {
                var n = reversed;

                reversed = new Node<int>();
                reversed.Data = tmp.Data;
                reversed.Next = n;

                tmp = tmp.Next;
            }

            var i1 = root;
            var i2 = reversed;

            while (i1 != null && i2 != null)
            {
                if (i1.Data != i2.Data)
                {
                    return false;
                }

                i1 = i2.Next;
                i2 = i2.Next;
            }

            return true;
        }

        [TestFixture]
        public class PalindromeListTests
        {
            [Test]
            public void Test()
            {
                Assert.IsFalse(Check(new Node<int>(1, new Node<int>(2, new Node<int>(3, new Node<int>(2, new Node<int>(5)))))));
                Assert.IsTrue(Check(new Node<int>(1, new Node<int>(2, new Node<int>(3, new Node<int>(2, new Node<int>(1)))))));
            }
        }

    }
}
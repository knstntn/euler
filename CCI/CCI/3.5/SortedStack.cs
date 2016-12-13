using System.Collections.Generic;
using NUnit.Framework;

namespace CCI
{
    public class SortedStack
    {
        public static Stack<int> Sort(Stack<int> stack)
        {
            var tmp = new Stack<int>();
            while (stack.Count > 0)
            {
                var top = stack.Pop();
                if (tmp.Count > 0)
                {
                    while (tmp.Count > 0 && tmp.Peek() > top)
                    {
                        stack.Push(tmp.Pop());
                    }
                    tmp.Push(top);
                }
                else
                {
                    tmp.Push(top);
                }
            }

            while (tmp.Count > 0)
            {
                stack.Push(tmp.Pop());
            }

            return stack;
        }

        [TestFixture]
        public class SortedStackTests
        {
            [Test]
            public void Test()
            {
                var st = new Stack<int>();
                st.Push(1);
                st.Push(2);
                st.Push(3);

                Assert.AreEqual(3, st.Peek());

                Sort(st);

                Assert.AreEqual(1, st.Pop());
                Assert.AreEqual(2, st.Pop());
                Assert.AreEqual(3, st.Pop());
            }
        }

    }
}
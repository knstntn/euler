using System;
using NUnit.Framework;

namespace CCI
{
    public class StackWithMin
    {
        private StackNode _top;

        public int Min()
        {
            if (_top == null)
            {
                throw new Exception();
            }

            return _top.Min;
        }

        public int Pop()
        {
            if (_top != null)
            {
                var d = _top.Data;
                _top = _top.Next;

                return d;
            }

            throw new Exception();
        }

        public void Push(int n)
        {
            _top = new StackNode
            {
                Data = n,
                Next = _top,
                Min = _top != null && _top.Min < n ? _top.Min : n
            };
        }

        private class StackNode
        {
            public int Data { get; set; }
            public int Min { get; set; }
            public StackNode Next { get; set; }
        }

        [TestFixture]
        public class StackWithMinTests
        {
            [Test]
            public void Test()
            {
                var st = new StackWithMin();
                st.Push(3);
                st.Push(2);
                st.Push(1);

                Assert.AreEqual(1, st.Min());
                st.Pop();
                Assert.AreEqual(2, st.Min());
                st.Pop();
                Assert.AreEqual(3, st.Min());
                st.Push(4);
                Assert.AreEqual(3, st.Min());
            }
        }
    }
}
using System.Collections.Generic;
using NUnit.Framework;

namespace CCI
{
    public class MyQueue
    {
        private Stack<object> newest = new Stack<object>();
        private Stack<object> oldest = new Stack<object>();

        public void Enqueue(object o)
        {
            newest.Push(o);
        }

        public object Dequeue()
        {
            Repopulate();
            return oldest.Pop();
        }

        private void Repopulate()
        {
            while (newest.Count > 0)
            {
                oldest.Push(newest.Pop());
            }
        }

        [TestFixture]
        public class MyQueueTests
        {
            [Test]
            public void Test()
            {
                var st = new MyQueue();
                st.Enqueue(1);
                st.Enqueue(2);
                st.Enqueue(3);

                Assert.AreEqual(1, st.Dequeue());
                Assert.AreEqual(2, st.Dequeue());
                Assert.AreEqual(3, st.Dequeue());
            }
        }

    }
}
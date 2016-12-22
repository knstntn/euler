using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Heaps
{
    public abstract class BinaryHeap
    {
        private readonly Func<int, int, bool> _compare;
        // placing dummy value as a first one to make index calculation easier
        // ref. Sedgewick
        private readonly List<int> _data = new List<int> {int.MinValue};

        protected BinaryHeap(Func<int, int, bool> compare)
        {
            _compare = compare;
        }

        public int Peek()
        {
            if (Length() == 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            return _data[1];
        }

        public int Pop()
        {
            if (Length() == 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            var top = _data[1];
            if (Length() == 1)
            {
                _data.RemoveAt(1);
                return top;
            }

            _data[1] = _data[_data.Count - 1];
            _data.RemoveAt(_data.Count - 1);

            Sink(1);

            return top;
        }

        public void Push(int i)
        {
            _data.Add(i);
            Bubble(_data.Count - 1);
        }

        public int Length()
        {
            return _data.Count - 1;
        }

        private void Bubble(int index)
        {
            while (index/2 > 0)
            {
                var j = index/2;
                var parent = _data[j];

                if (_compare(_data[index], parent))
                {
                    Swap(index, j);
                    index = j;
                }
                else
                {
                    break;
                }
            }
        }

        private void Sink(int index)
        {
            while (2*index <= Length())
            {
                var j = 2*index;

                if (j < Length() && _compare(_data[j + 1], _data[j]))
                {
                    j++;
                }

                if (!_compare(_data[j], _data[index]))
                    break;

                Swap(j, index);
                index = j;
            }
        }

        private void Swap(int i, int j)
        {
            var tmp = _data[j];
            _data[j] = _data[i];
            _data[i] = tmp;
        }
    }

    public sealed class MinBinaryHeap : BinaryHeap
    {
        public MinBinaryHeap() : base((left, right) => left <= right)
        {
        }
    }

    public sealed class MaxBinaryHeap : BinaryHeap
    {
        public MaxBinaryHeap() : base((left, right) => left >= right)
        {
        }
    }

    [TestFixture]
    public class BinaryHeapTests
    {
        [Test]
        public void MinBinaryHeapTest()
        {
            var heap = new MinBinaryHeap();

            heap.Push(12);
            heap.Push(2445);
            heap.Push(1);
            heap.Push(4123);
            heap.Push(41);
            heap.Push(4);
            heap.Push(48);
            heap.Push(90);
            heap.Push(0);

            Assert.AreEqual(9, heap.Length());

            Assert.AreEqual(0, heap.Pop());
            Assert.AreEqual(1, heap.Pop());
            Assert.AreEqual(4, heap.Pop());
            Assert.AreEqual(12, heap.Pop());
            Assert.AreEqual(41, heap.Pop());
            Assert.AreEqual(48, heap.Pop());
            Assert.AreEqual(90, heap.Pop());
            Assert.AreEqual(2445, heap.Pop());
            Assert.AreEqual(4123, heap.Pop());
        }

        [Test]
        public void MaxBinaryHeapTest()
        {
            var heap = new MaxBinaryHeap();

            heap.Push(12);
            heap.Push(2445);
            heap.Push(1);
            heap.Push(4123);
            heap.Push(41);
            heap.Push(4);
            heap.Push(48);
            heap.Push(90);
            heap.Push(0);

            Assert.AreEqual(9, heap.Length());

            Assert.AreEqual(4123, heap.Pop());
            Assert.AreEqual(2445, heap.Pop());
            Assert.AreEqual(90, heap.Pop());
            Assert.AreEqual(48, heap.Pop());
            Assert.AreEqual(41, heap.Pop());
            Assert.AreEqual(12, heap.Pop());
            Assert.AreEqual(4, heap.Pop());
            Assert.AreEqual(1, heap.Pop());
            Assert.AreEqual(0, heap.Pop());
        }

    }
}
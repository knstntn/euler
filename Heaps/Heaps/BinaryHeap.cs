using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Heaps
{
    public class BinaryHeap<T>
    {
        private readonly Func<T, T, bool> _compare;
        // placing dummy value as a first one to make index calculation easier
        // ref. Sedgewick
        private readonly List<T> _data = new List<T> {default(T)};

        public BinaryHeap(Func<T, T, bool> compare)
        {
            _compare = compare;
        }

        public int Length()
        {
            return _data.Count - 1;
        }

        public T Peek()
        {
            if (Length() == 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            return _data[1];
        }

        public T Pop()
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

        public void Push(T i)
        {
            _data.Add(i);
            Bubble(_data.Count - 1);
        }

        public void Replace(Func<T, bool> func, T value)
        {
            var elem = _data.Skip(1).First(func);
            var index = _data.IndexOf(elem);

            _data[index] = value;
            if (_compare(elem, value))
            {
                Sink(index);
            }
            else
            {
                Bubble(index);
            }
        }

        public bool Contains(Func<T, bool> func)
        {
            return _data.Skip(1).Any(func);
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

    public sealed class MinBinaryHeap : BinaryHeap<int>
    {
        public MinBinaryHeap() : base((left, right) => left <= right)
        {
        }
    }

    public sealed class MaxBinaryHeap : BinaryHeap<int>
    {
        public MaxBinaryHeap() : base((left, right) => left >= right)
        {
        }
    }

    [TestFixture]
    public class BinaryHeapTests
    {
        private readonly int[] _numbers = {12, 2445, 1, 4123, 41, 4, 48, 90, 0};

        [Test]
        public void MaxBinaryHeapTest()
        {
            var heap = new MaxBinaryHeap();
            foreach (var number in _numbers)
            {
                heap.Push(number);
            }

            Assert.AreEqual(_numbers.Length, heap.Length());

            foreach (var number in _numbers.OrderByDescending(x => x))
            {
                Assert.AreEqual(number, heap.Pop());
            }
        }

        [Test]
        public void MinBinaryHeapTest1()
        {
            var heap = new MinBinaryHeap();
            foreach (var number in _numbers)
            {
                heap.Push(number);
            }

            Assert.AreEqual(_numbers.Length, heap.Length());

            foreach (var number in _numbers.OrderBy(x => x))
            {
                Assert.AreEqual(number, heap.Pop());
            }
        }

        [Test]
        public void MinBinaryHeapTest2()
        {
            var heap = new MinBinaryHeap();
            foreach (var number in _numbers)
            {
                heap.Push(number);
            }

            Assert.AreEqual(_numbers.Length, heap.Length());
            Assert.AreEqual(0, heap.Peek());

            heap.Replace(x => x == 0, 5000);
            Assert.AreEqual(_numbers.Length, heap.Length());
            Assert.AreEqual(1, heap.Peek());

            heap.Replace(x => x == 5000, -1);
            Assert.AreEqual(_numbers.Length, heap.Length());
            Assert.AreEqual(-1, heap.Peek());
        }
    }
}
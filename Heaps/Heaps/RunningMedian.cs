using System;
using System.Collections.Generic;

namespace Heaps
{
    public sealed class RunningMedian
    {
        private readonly MaxBinaryHeap _max;
        private readonly MinBinaryHeap _min;

        public RunningMedian()
        {
            _min = new MinBinaryHeap();
            _max = new MaxBinaryHeap();
        }

        public void Print(IEnumerable<int> values)
        {
            foreach (var value in values)
            {
                if (_max.Length() == 0)
                {
                    _max.Push(value);
                }
                else
                {
                    if (value < _max.Peek())
                    {
                        _max.Push(value);
                    }
                    else
                    {
                        _min.Push(value);
                    }

                    while (Math.Abs(_max.Length() - _min.Length()) > 1)
                    {
                        var longerHeap = _max.Length() > _min.Length() ? _max : (BinaryHeap<int>) _min;
                        var shorter = _max.Length() > _min.Length() ? _min : (BinaryHeap<int>) _max;
                        shorter.Push(longerHeap.Pop());
                    }
                }

                Print();
            }
        }

        private void Print()
        {
            var lv = _min.Length() > 0 ? _min.Peek() : 0;
            var gv = _max.Length() > 0 ? _max.Peek() : 0;

            var val = _min.Length() == _max.Length()
                ? (lv + gv)/2d
                : (_max.Length() > _min.Length() ? gv : lv);

            Console.WriteLine("{0:F1}", val);
        }
    }
}
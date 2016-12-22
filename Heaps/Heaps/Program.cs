using System;

namespace Heaps
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            // solving running median using two heaps
            BinaryHeap min = new MinBinaryHeap();
            BinaryHeap max = new MaxBinaryHeap();

            var input = "";
            while ((input = Console.ReadLine()) != "exit")
            {
                var val = int.Parse(input);

                if (max.Length() == 0)
                {
                    max.Push(val);
                }
                else
                {
                    if (val < max.Peek())
                    {
                        max.Push(val);
                    }
                    else
                    {
                        min.Push(val);
                    }

                    while (Math.Abs(max.Length() - min.Length()) > 1)
                    {
                        var longerHeap = max.Length() > min.Length() ? max : min;
                        var shorter = max.Length() > min.Length() ? min : max;
                        shorter.Push(longerHeap.Pop());
                    }
                }

                Print(min, max);
            }
        }

        private static void Print(BinaryHeap lower, BinaryHeap higher)
        {
            var lv = lower.Length() > 0 ? lower.Peek() : 0;
            var gv = higher.Length() > 0 ? higher.Peek() : 0;

            var val = lower.Length() == higher.Length()
                ? (lv + gv)/2d
                : (higher.Length() > lower.Length() ? gv : lv);

            Console.WriteLine("{0:F1}", val);
        }
    }
}
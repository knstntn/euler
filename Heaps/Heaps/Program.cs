using System;
using System.Collections.Generic;

namespace Heaps
{
    internal class Program
    {
        private static void Main()
        {
            var rm = new RunningMedian();
            rm.Print(RunningMedianArraySource());
            Console.ReadLine();
        }

        private static IEnumerable<int> RunningMedianArraySource()
        {
            return new[] {12, 4, 5, 3, 4, 8, 7};
        }

        private static IEnumerable<int> RunningMedianConsoleSource()
        {
            var input = "";
            while ((input = Console.ReadLine()) != "exit")
            {
                yield return int.Parse(input);
            }
        }
    }
}
using System;
using System.Linq;

namespace Euler
{
    internal class Program
    {
        private static void Main()
        {
            const int max = 2000000;

            var sieve = Enumerable.Range(2, max - 2).ToDictionary(x => x, x => true);
            var next = sieve.First();

            while (Math.Pow(next.Key, 2) < max)
            {
                var remove = sieve.Where(x => x.Value
                                              && Math.Pow(next.Key, 2) <= x.Key
                                              && (x.Key%next.Key) == 0).Select(x => x.Key).ToArray();
                foreach (var key in remove)
                {
                    sieve.Remove(key);
                }

                next = sieve.First(x => x.Key > next.Key);
            }
            var sum = sieve.Sum(x => (long)x.Key);

            Console.Out.WriteLine(sum);
            Console.In.ReadLine();
        }
    }
}
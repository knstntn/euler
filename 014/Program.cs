using System;
using System.Collections.Generic;

namespace Euler
{
    internal class Program
    {
        private static void Main()
        {
            var memo = new Dictionary<long, int> {{1L, 1}};

            var num = 2L;

            var maxPath = 1;
            var maxNum = num;
            var limit = 1000000;

            while (num < limit)
            {
                var path = Collatz(memo, num);
                if (path > maxPath)
                {
                    maxPath = path;
                    maxNum = num;
                }
                maxPath = Math.Max(path, maxPath);

                num++;
            }

            Console.Out.WriteLine(maxPath);
            Console.Out.WriteLine(maxNum);
            Console.In.ReadLine();
        }

        private static int Collatz(IDictionary<long, int> memo, long n)
        {
            if (memo.ContainsKey(n))
            {
                return memo[n];
            }

            var next = n%2 == 0 ? Even(n) : Odd(n);
            var path = Collatz(memo, next);

            memo[n] = path + 1;

            return memo[n];
        }

        private static long Even(long n)
        {
            return n/2;
        }

        private static long Odd(long n)
        {
            return 3*n + 1;
        }
    }
}
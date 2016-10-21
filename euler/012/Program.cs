using System;
using System.Collections.Generic;
using System.Linq;

namespace Euler
{
    internal class Program
    {
        private static void Main()
        {
            var memo1 = new Dictionary<int, long>();
            var memo2 = new Dictionary<long, IEnumerable<long>>();
            var index = 1;

            while (true)
            {
                var sum = Sum(memo1, index);
                var div = GetDividers(memo2, sum).Distinct(EqualityComparer<long>.Default).ToList();
                
                Extend(div, sum);

                div.Sort(Comparer<long>.Default);

                memo2[sum] = div;

                if (div.Count >= 500)
                {
                    Console.Out.WriteLine(sum);
                    break;
                }
                index++;
            }
            Console.In.ReadLine();
        }

        private static long Sum(IDictionary<int, long> memo, int n)
        {
            if (n < 1)
            {
                return 0L;
            }

            if (memo.ContainsKey(n))
            {
                return memo[n];
            }

            memo[n] = Sum(memo, n - 1) + n;

            return memo[n];
        }

        private static IEnumerable<long> GetDividers(IDictionary<long, IEnumerable<long>> memo, long n)
        {
            if (n <= 1)
            {
                return new[] {1L};
            }

            if (memo.ContainsKey(n))
            {
                return memo[n];
            }

            if (n%2 == 0)
            {
                return GetDividers(memo, n/2).Concat(new[] {2, n});
            }

            var div = 3L;
            var limit = n/2 + 1;

            while (div <= n)
            {
                if (n%div == 0)
                {
                    return GetDividers(memo, n/div).Concat(new[] {div}).ToArray();
                }
                div += 2;
            }

            return new[] {1L, n};
        }

        private static void Extend(IList<long> list, long n)
        {
            while (true)
            {
                var update = new List<long>();

                for (var i = 0; i < list.Count; i++)
                {
                    for (var j = i; j < list.Count; j++)
                    {
                        var prod = list[i]*list[j];

                        if (n%prod == 0 && !list.Contains(prod) && !update.Contains(prod))
                        {
                            update.Add(prod);
                        }
                    }
                }

                foreach (var val in update)
                {
                    list.Add(val);
                }

                if (update.Count == 0)
                {
                    break;
                }
            }
        }
    }
}
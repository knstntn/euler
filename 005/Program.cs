using System;
using System.Collections.Generic;
using System.Linq;

namespace Euler
{
    internal class Program
    {
        private static void Main()
        {
            var max = 20;
            var factors = new List<int>();
            
            for (var i = max; i >= 1; i--)
            {
                var list = new List<int>();
                var tmp = i;
                var div = 2;
                while (tmp > 1)
                {
                    if ((tmp % div) == 0)
                    {
                        list.Add(div);
                        tmp = tmp / div;
                    }
                    else
                    {
                        div = div + 1;
                    }
                }

                foreach (var factor in factors)
                {
                    var index = list.IndexOf(factor);
                    if (index != -1)
                    {
                        list.RemoveAt(index);
                    }
                }

                factors = factors.Concat(list).ToList();
            }

            var x = factors.Aggregate(1, (res, fact) => res * fact);
            Console.Out.WriteLine(string.Join(",", factors));
            Console.Out.WriteLine(x);
            Console.In.ReadLine();
        }
    }
}
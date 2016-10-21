using System;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Numerics;

namespace Euler
{
    internal class Program
    {
        private static void Main()
        {
            var p = 1000;

            var res = Math.Pow(2, p);
            var res2 = Pow(2, p).ToString().Select(x => (int) char.GetNumericValue(x)).Sum();

            Console.Out.WriteLine(res);
            Console.Out.WriteLine(res2);
            Console.In.ReadLine();
        }

        private static BigInteger Pow(BigInteger n, int p)
        {
            if (p == 0)
            {
                return 1;
            }
            if (p == 1)
            {
                return n;
            }

            if (p%2 == 0)
            {
                return Pow(n*n, p/2);
            }
            var p1 = (int) Math.Floor(p/2d);

            Contract.Assert(2*p1 + 1 == p);

            return Pow(n*n, p1)*n;
        }
    }
}
using System;
using System.Linq;
using System.Numerics;

namespace Euler
{
    internal class Program
    {

        private static void Main()
        {
            var num = 100;

            var res2 = Fact(num).ToString().Select(x => (int)char.GetNumericValue(x)).Sum();

            Console.Out.WriteLine(res2);
            Console.In.ReadLine();
        }

        private static BigInteger Fact(int n)
        {
            var res = BigInteger.One;
            while (n > 1)
            {
                res *= n;

                n--;
            }
            return res;
        }
    }
}
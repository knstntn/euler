using System;

namespace Euler
{
    internal class Program
    {
        private static void Main()
        {
            var index = 1;
            var num = 2;

            while (index < 10001)
            {
                num++;
                if (IsPrime(num))
                {
                    index += 1;
                }
            }

            Console.Out.WriteLine(num);
            Console.In.ReadLine();
        }

        private static bool IsPrime(long n)
        {
            if ((n%2) == 0)
            {
                return false;
            }
            var sqrt = Math.Sqrt(n);
            for (long i = 3; i <= sqrt; i++)
            {
                if ((n%i) == 0)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
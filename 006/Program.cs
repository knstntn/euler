using System;

namespace Euler
{
    internal class Program
    {
        private static void Main()
        {
            const int max = 100;
            var sum = 0;

            for (var i = 1; i <= max; i++)
            {
                for (var j = 1; j <= max; j++)
                {
                    if (i == j) continue;

                    sum += i*j;
                }
            }

            Console.Out.WriteLine(sum);
            Console.In.ReadLine();
        }
    }
}
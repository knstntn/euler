using System;
using System.Linq;

namespace Euler
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var max = 0;

            for (var i = 999; i >= 100; i--)
            {
                for (var j = 999; j >= 100; j--)
                {
                    var tmp = i*j;
                    if (tmp < max)
                    {
                        break;
                    }

                    var str = tmp.ToString();
                    var reversed = new string(str.Reverse().ToArray());
                    if (str == reversed)
                    {
                        max = Math.Max(max, tmp);
                    }
                }
            }

            Console.Out.WriteLine(max);
            Console.In.ReadLine();
        }
    }
}
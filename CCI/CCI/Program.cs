using System;
using System.Linq;

namespace CCI
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            /* Enter your code here. Read input from STDIN. Print output to STDOUT */
            var search = Console.ReadLine().Split(' ');
            var m = int.Parse(Console.ReadLine());
            var hotels = Enumerable.Range(0, m).Select(_ => new {
                Id = Console.ReadLine(),
                Review = Console.ReadLine().Split(' ')
            }).ToLookup(x => x.Id);

            var res = hotels.ToDictionary(x => x.Key, x => x.SelectMany(y => y.Review).Intersect(search).Count())
                .OrderByDescending(x => x.Value)
                .ToArray();
//                .Select(x => x.Key);

            Console.WriteLine(string.Join(", ", res));
        }
    }
}
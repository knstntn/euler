using System;
using System.IO;
using System.Linq;

namespace Euler
{
    internal class Program
    {
        private static void Main()
        {
            var alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".Select((x, i) => Tuple.Create(x, i + 1)).ToDictionary(x => x.Item1, x => x.Item2);

            var result = File.ReadAllText("p022_names.txt")
                .Split(new[] {","}, StringSplitOptions.RemoveEmptyEntries).Select(x => x.Trim('"').Trim())
                .OrderBy(x => x)
                .Select((s, i) => (i + 1)*s.Aggregate(0L, (sum, x) => sum + alphabet[x]))
                .Sum();

            Console.Out.WriteLine(result);
            Console.In.ReadLine();
        }
    }
}
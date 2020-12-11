using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace day6
{
    class Program
    {
        static void Main(string[] args)
        {
            #region part1
            //var input = File.ReadAllLines("input.txt").Select(_ => _ == "" ? ";" : _).Aggregate((a, b) => a + b).Split(';').Select(_ => _.GroupBy(__ => __).Count()).Sum();
            //Console.WriteLine(input);
            #endregion
            List<string> l = new List<string>();
            var input = File.ReadAllLines("input.txt");

            var query1 = input
              .Select(_ => _ == "" ? ";" : _)
              .Aggregate((a, b) => a + "/" + b)
              .Split(';')
              .Select(_ => _.Split('/', StringSplitOptions.RemoveEmptyEntries).Select(__ => __)
              .GroupBy(_ => _).Select(c => c.Count())
              .Sum())
              .ToArray();


          var query2 =input
                .Select(_ => _ == "" ? ";" : _)
                .Aggregate((a, b) => a + "/" + b)
                .Split(';')
                .Select(_ => _.Split('/', StringSplitOptions.RemoveEmptyEntries)
                .Select(__ => __)
                .Aggregate((a, b) => a + b))
                .Select((_,k) => _.GroupBy(__ => __)
                .Select(c => new { Char = c.Key, Count = c.Count(),IsSame = c.Count() == query1[k] })
                .Where(_ => _.IsSame))
                .Select(_=>_.Count())
                .Sum();

            Console.WriteLine(query2);

        }

    }
}


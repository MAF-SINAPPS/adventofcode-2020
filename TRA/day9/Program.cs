using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace day9
{
    class Program
    {
        static int l = 25;
        static double error;
        static void Main(string[] args)
        {
            var input = File.ReadAllLines("input.txt");
            var arr = input.Select(_ => double.Parse(_)).ToArray();
            error = Error(arr);
            var maxIndex = Array.FindIndex(arr, _ => _ == error);
            var r = arr.Take(maxIndex);
         Console.WriteLine(   bruteForce(r, maxIndex));

        }

        static double Process(double[] input, int length)
        {
            var allsum = from a in input
                         from b in input
                         select a + b;

            var toCheck = input.Last();
            if (!allsum.Contains(toCheck))
                return toCheck;

            return double.MinValue;
        }

        static double Error(double[] arr)
        {
            for (int i = 0; arr.Skip(i).Count() > l + 1; i++)
            {
                var p = Process(arr.Skip(i).Take(l + 1).ToArray(), l);
                if (double.MinValue != p)
                {
                    return p;
                }
            }
            return double.MinValue;
        }

        static double bruteForce(IEnumerable<double> r, int maxindex)
        {
            int i = 0;

            while (true)
            {

                for (int j = 1; j <= maxindex; j++)
                {
                    var tmp = r.Skip(i).Take(j);
                    if (tmp.Sum() == error || tmp.Count() == 0)
                    {
                        return tmp.Max() + tmp.Min();
                    }

                 //   Console.WriteLine(tmp.Sum());
                }
                i++;
            }
        }
    }
}

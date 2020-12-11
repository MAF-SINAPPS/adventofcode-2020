using System;
using System.IO;
using System.Linq;

namespace day10
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = File.ReadAllLines("input.txt");
            var array = input.Select(_ => int.Parse(_)).ToArray().OrderBy(_ => _);

            int maxJoltage = 0;
            int maxDiff = 3;
            int c1 = 0, c2 = 0, c3 = 0;
            foreach (var jolt in array)
            {
                if (jolt == maxJoltage + 1)
                {
                    c1++;
                    maxJoltage = jolt;
                    continue;
                }
                if (jolt == maxJoltage + 2)
                {
                    c2++;
                    maxJoltage = jolt;
                    continue;
                }
                if (jolt == maxJoltage + 3)
                {
                    c3++;
                    maxJoltage = jolt;
                    continue;
                }

            }
            c3++;
            

            Console.WriteLine(c1 * c3);
        }
    }
}

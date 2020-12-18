using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace day10
{
    class Program
    {
        static int count = 0;
        static int maxJoltage = 0;
        static IEnumerable<int> array;
        static void Main(string[] args)
        {
            var input = File.ReadAllLines("input.txt");
            array = input.Select(_ => int.Parse(_)).ToArray().OrderBy(_ => _);


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

            maxJoltage += 3;

            FindNext(0);
        }

        static void FindNext(int joltage)
        {
            int current = joltage;
            Console.Write($"{current},");

            for (int margin = 1; margin <= 3; margin++)
            {
                current += margin;
                if (current >= maxJoltage)
                {                    
                    count++;
                    Console.WriteLine(current);
                  //  FindNext(0);
                    break;
                }
                if (array.Contains(current))
                    FindNext(current);
            }
        }

    }

}



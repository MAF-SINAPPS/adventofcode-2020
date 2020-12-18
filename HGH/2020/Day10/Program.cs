using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode
{
    class Program
    {
        private static IEnumerable<int[]> CombinationsRosettaWoRecursion(int m, int n)
        {
            int[] result = new int[m];
            Stack<int> stack = new Stack<int>(m);
            stack.Push(0);
            while (stack.Count > 0)
            {
                int index = stack.Count - 1;
                int value = stack.Pop();
                while (value < n)
                {
                    result[index++] = value++;
                    stack.Push(value);
                    if (index != m) continue;
                    //yield return (int[])result.Clone(); // thanks to @xanatos
                    yield return result;
                    break;
                }
            }
        }
        private static IEnumerable<IList<int>> GetCombinations(int[] array, int m)
        {
            var result = new List<int>();
            bool isEmpty = result.Count() == 0;
            if (m > array.Length/2 && m<=array.Length)
            {
                foreach (int[] j in CombinationsRosettaWoRecursion(m, array.Length))
                {
                    for (int i = 0; i < m && (result.Any() ? result?.Last() > (array[j[i]] - 4) : array[j[i]]<4 ); i++)
                    {
                        result.Add(array[j[i]]);
                    }
                    yield return (IList<int>)result.Distinct().OrderBy(o=>o).ToList();
                }
            }
        }

        private static IEnumerable<IEnumerable<int>> GetPermutationsWithRept(IEnumerable<int> list, int length)
        {
            if (length == 1) return list.Select(t => new int[] { t });
            return GetPermutationsWithRept(list, length - 1)
                .SelectMany(t => list.Where(o => t.Last()> (o-4)),
                    (t1, t2) => t1.Concat(new int[] { t2 }));
        }
        static void Main(string[] args)
        {
            var lines = File.ReadAllLines("Input10.txt")
            .Select(_ => Convert.ToInt32(_)).OrderBy(o => o).ToList();
            //------------------Day 10 Part 1 -------------------
            int Jolt1 = 0;
            int Jolt3 = 1;
            int maxAdapter = lines.Max();
            for (int i = 0; i <= maxAdapter; i++)
            {
                var isExistDiff3 = lines.Any(_ => _ == (i + 3));
                Jolt1 += lines.Count(_ => _ == (i + 1));
                if (lines.Any(_ => _ == (i + 2)))
                {
                    Jolt1++; i++;
                    if (isExistDiff3)
                    {
                        Jolt1++; i++;
                    }
                }
                else
                {
                    if (isExistDiff3)
                    {
                        Jolt3++; i++; i++;
                    }
                }
            }
            Console.WriteLine("Jolt 1 : " + Jolt1);
            Console.WriteLine("Jolt 3 : " + Jolt3);
            Console.WriteLine("Result : " + Jolt1 * Jolt3);
            //------------------Day 10 Part 2 -------------------
            Console.ReadLine();
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;

namespace day5
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = File.ReadAllLines("input.txt");
            var highest = 0;
            var list = new List<int>();
            foreach (var word in input)
            {
                int low = 0;
                int high = 127;
                int row = 0, col = 0;
                for (int i = 0; i < word.Length; i++)
                {
                    if (i == 7)
                    {
                        row = low;
                        low = 0;
                        high = 7;
                    }
                    var k = Dichotomy(word[i], low, high);
                    low = k.Item1;
                    high = k.Item2;
                }
                if (word[9] == 'L')
                    col = low;
                else
                    col = high;
                if (highest < (row * 8 + col))
                    highest = (row * 8 + col);
                //   Console.WriteLine($"{row},{col} => {highest}");
                list.Add(row * 8 + col);
            }
            list.Sort();

            for (int i = 0; i < list.Count; i++)
            {
                Console.WriteLine($"{ i},{list[i]} , {list[i] - i}");//repérer visuellement le changement d'index et bingo!!!!
            }
            Console.WriteLine(highest);
        }

        static (int, int) Dichotomy(char c, int low, int high)
        {
            var div2 = (low + high) / 2;
            var mod2 = (low + high) % 2;
            if (c == 'F' || c == 'L')
                return (low, div2);
            else
                return (div2 + mod2, high);
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = new List<int> { 5, 1, 9, 18, 13, 8, 0 };
            var initLength = numbers.Count();
            for (int i = initLength; i < 2020; i++)
            {
                int lastNbr = numbers.Last();
                int count = numbers.Count(_ => _ == lastNbr);
                if (count > 1)
                {
                    int indexOfLastElement = i - 1;
                    numbers.RemoveAt(indexOfLastElement);
                    int index1 = numbers.LastIndexOf(lastNbr);
                    numbers.Add(lastNbr);
                    numbers.Add(indexOfLastElement - index1);
                }
                else
                {
                    numbers.Add(0);
                }
            }
            Console.WriteLine("-----------------------------");
            Console.WriteLine("        Result : "+ numbers.Last());
            Console.WriteLine("-----------------------------");
            Console.ReadLine();
        }
    }
}

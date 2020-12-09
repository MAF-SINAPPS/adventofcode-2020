using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode
{
    class Program
    {
        
        private static bool IsExist(double nbr, double[] last5Numbers)
        {
            foreach (var item in last5Numbers)
            {
                for (int i = 1; i < last5Numbers.Length; i++)
                {
                    if (nbr == item + last5Numbers[i])
                        return true;
                }
            }
            return false;
        }
        static void Main(string[] args)
        {
            //------------------Day 9-------------------
            var lines = File.ReadAllLines("Input/Input9.txt")
            .Select(_ => Convert.ToDouble(_)).ToArray();
            double result = -1;
            for(int i= 25; i < lines.Length; i++)
            {
                if (!IsExist(lines[i], lines.Skip(i - 25).Take(25).ToArray()))
                {
                    result = lines[i];
                    break;
                }
            }
            Console.WriteLine(result);

            Console.ReadLine();
        }
    }
}

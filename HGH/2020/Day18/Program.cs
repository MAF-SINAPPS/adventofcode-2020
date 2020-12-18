using ExtensionMethods;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace ExtensionMethods
{
    public static class ExtensionChar
    {
        public static bool IsNumber(this char str)
        {
            string pattern = "[0-9]";
            var match = new Regex(pattern).Match(str.ToString());
            return match.Success;
        }
    }
}

namespace AdventOfCode
{
    class Program
    {
        public static double Simplify(String input)
        {
            var result = input;
            while(result.Contains('('))
            {
                var indexofFirstB = result.IndexOf(')');
                int i = 0;
                for (i = indexofFirstB; i >= 0 && !result[i].Equals('('); i--)
                {

                }
                var str = result.Substring(i+1, indexofFirstB - i-1);
                result = result.Replace("(" + str + ")", Calcul(str).ToString());
            }
            return Calcul(result);
        }

        public static double Calcul(string input)
        {
            string result = input;
            while (result.Contains("+") || result.Contains("*"))
            {
                string firstParam = "";
                string secondeParam = "";
                char operation = '*';
                int indexOfFirstOpe = result.IndexOf(operation);
                int indexOfFirstPlus = result.IndexOf('+');
                if(indexOfFirstOpe<=0)
                {
                    indexOfFirstOpe = indexOfFirstPlus;
                    operation = '+';
                }else if (indexOfFirstPlus < indexOfFirstOpe && indexOfFirstPlus>0)
                {
                    indexOfFirstOpe = indexOfFirstPlus;
                    operation = '+';
                }
                for (int i = indexOfFirstOpe - 1; i >= 0 && result[i].IsNumber(); i--)
                    firstParam += result[i];
                for (int i = indexOfFirstOpe + 1; i < result.Length && result[i].IsNumber(); i++)
                    secondeParam += result[i];
                if (firstParam.Length > 1)
                    firstParam = new string(firstParam.Reverse().ToArray());
                var value = Convert.ToDouble(firstParam);
                if (operation.Equals('+'))
                    value += Convert.ToDouble(secondeParam);
                else
                    value *= Convert.ToDouble(secondeParam);

                result = result.Replace(firstParam + operation.ToString() + secondeParam, (value).ToString());
            }
            return Convert.ToDouble(result);
        }

        static void Main(string[] args)
        {
            //-----------------Day 18 Part 1 -------------------
            var lines = File.ReadAllLines("Input18.txt")
                .ToArray();
            double count = 0;
            int i = 0;
            foreach (var line in lines)
            {
                i++;
                var newLine = line.Trim().Replace(" ", "");
                var res = Simplify(newLine);
                Console.WriteLine($"Iteration : {i} : {count} + {res}");
                count += res;

            }
            Console.WriteLine("-----------------------------");
            Console.WriteLine("        Result : " + count);
            Console.WriteLine("-----------------------------");
            Console.ReadLine();
        }
    }
}

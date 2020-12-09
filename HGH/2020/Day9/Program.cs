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
            for (int j = 0; j < last5Numbers.Length-1; j++)
            {
                for (int i = j+1; i < last5Numbers.Length; i++)
                {
                    if (nbr == last5Numbers[j] + last5Numbers[i])
                        return true;
                }
            }
            return false;
        }

        private static double GetSumOfSmallestAndLargest(double nbr, double[] last5Numbers)
        {
            List<double> listNbr = new List<double>();
            double sum = 0;
            for (int j = 0; j < last5Numbers.Length - 1 && sum!=nbr; j++)
            {
                sum = last5Numbers[j];
                listNbr.RemoveAll(_=> _>=0);
                listNbr.Add(last5Numbers[j]);
                for (int i = j + 1; i < last5Numbers.Length && sum<=nbr; i++)
                {
                    sum += last5Numbers[i];
                    listNbr.Add(last5Numbers[i]);
                    if (nbr == sum)
                        break;
                }
            }
            return listNbr.Max() + listNbr.Min();
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
                    //Start Part 2
                    result = GetSumOfSmallestAndLargest(lines[i], lines.Take(i).ToArray());
                    //End Part 2
                    break;
                }
            }
            Console.WriteLine(result);
            Console.ReadLine();
        }
    }
}

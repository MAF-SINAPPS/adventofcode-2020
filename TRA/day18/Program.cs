using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace day18
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = File.ReadAllLines("input.txt");
            long sum = 0;
            List<(string, long)> l = new List<(string, long)>();
            foreach (string item in input)
            {
                var expression = item;
                expression = String.Concat(expression.Where(c => !Char.IsWhiteSpace(c)));//trim
                string pattern = @"\([0-9*+-]*\)";// @"(\(\d+[*-+]\d+\))";
                Regex processBracket = new Regex(pattern);
                MatchCollection matches = processBracket.Matches(expression);
                while (matches.Any())
                {
                    var localExpression = matches[0].ToString();Console.WriteLine(expression);
                    expression = expression.Replace(localExpression, Process(localExpression).ToString());


                    matches = processBracket.Matches(expression);
                }
                Console.WriteLine(expression);
                l.Add((item, Process(expression)));
                sum += Process(expression);
            }
        }

        static long Process(string input)
        {

            var op = new char[] { '*', '-', '+' };

            input = String.Concat(input.Where(c => char.IsDigit(c) || op.Contains(c)));//remove ()
            string pattern = @"(\d+)([\+\-\*])(\d+)";
            Regex processBracket = new Regex(pattern);
            MatchCollection matches = processBracket.Matches(input);
            while (matches.Any())
            {
                var localExpression = matches[0].ToString();
                input = input.Replace(localExpression, NewMethod(localExpression).ToString());
                matches = processBracket.Matches(input);
            }


            return long.Parse(input);
        }

        private static long NewMethod(string tmp)
        {
            if (tmp.Contains("*"))
                return long.Parse(tmp.Split('*')[0]) * long.Parse(tmp.Split('*')[1]);
            if (tmp.Contains("-"))
                return long.Parse(tmp.Split('-')[0]) - long.Parse(tmp.Split('-')[1]);
            if (tmp.Contains("+"))
                return long.Parse(tmp.Split('+')[0]) + long.Parse(tmp.Split('+')[1]);

            return 0;
        }
    }
}

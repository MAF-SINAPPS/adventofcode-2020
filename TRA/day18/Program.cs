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
                string pattern = @"\([0-9\*\+]*\)";// @"(\(\d+[*-+]\d+\))";
                Regex processBracket = new Regex(pattern);
                MatchCollection matches = processBracket.Matches(expression);
                while (matches.Any())
                {
                    var localExpression = matches[0].ToString();
                    expression = processBracket.Replace(expression, Process(localExpression).ToString(), 1);

                    matches = processBracket.Matches(expression);
                }

                l.Add((item, Process(expression)));
                sum += Process(expression);
            }

            Console.WriteLine(sum);
        }

        static long Process(string input)
        {

            var op = new char[] { '*', '-', '+' };

            input = String.Concat(input.Where(c => char.IsDigit(c) || op.Contains(c)));//remove ()
            string[] patterns = { @"(\d+)([\+])(\d+)", @"(\d+)([\*])(\d+)" };
            foreach (var pattern in patterns)
            {
                Regex processBracket = new Regex(pattern);
                MatchCollection matches = processBracket.Matches(input);
                while (matches.Any())
                {
                    var localExpression = matches[0].ToString();
                    input = processBracket.Replace(input, NewMethod(localExpression).ToString(), 1);
                    matches = processBracket.Matches(input);
                }
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

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace day16
{
    class Program
    {
        static List<int> yourTicket = new List<int>();
        static List<int> nearbyTicket = new List<int>();
        static Dictionary<string, IEnumerable<int>> firstpart = new Dictionary<string, IEnumerable<int>>();
        static void Main(string[] args)
        {
            var input = File.ReadAllLines("input.txt");
            var str = string.Join(Environment.NewLine, input);

            Regex regex = new Regex(@"(?<key>\w+): (?<r1>\d+)-(?<r11>\d+) or (?<r2>\d+)-(?<r22>\d+)");
            var coll = regex.Matches(str);
            foreach (Match item in coll)
            {
                var r1 = Enumerable.Range(int.Parse(item.Groups["r1"].Value), int.Parse(item.Groups["r11"].Value));
                var r2 = Enumerable.Range(int.Parse(item.Groups["r2"].Value), int.Parse(item.Groups["r22"].Value));
                firstpart.Add(item.Groups["key"].Value, r1.Concat(r2));
            }


            Regex regex = new Regex(@"(?<key>\w+): (?<r1>\d+)-(?<r11>\d+) or (?<r2>\d+)-(?<r22>\d+)");
            var coll = regex.Matches(str);
            foreach (Match item in coll)
            {
                var r1 = Enumerable.Range(int.Parse(item.Groups["r1"].Value), int.Parse(item.Groups["r11"].Value));
                var r2 = Enumerable.Range(int.Parse(item.Groups["r2"].Value), int.Parse(item.Groups["r22"].Value));
                firstpart.Add(item.Groups["key"].Value, r1.Concat(r2));
            }
        }
    }
}

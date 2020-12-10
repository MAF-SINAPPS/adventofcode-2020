using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace day7
{
    class Program
    {
        #region part1
        static Dictionary<string, Dictionary<string, int>> dico = new Dictionary<string, Dictionary<string, int>>();
        #endregion
        static HashSet<string> h = new HashSet<string>();
        static int sommetotale = 0;
        static void Main(string[] args)
        {
            var input = File.ReadAllLines("input.txt");
            #region part1
            foreach (var item in input)
            {
                Tokenizer(item);
            }

            recursive("shiny gold bag", 1);//1  bag

            //foreach (var hh in h)
            //{
            //    Console.WriteLine(hh);
            //}

            Console.WriteLine($"somme = {sommetotale}");
            #endregion
        }

        private static void recursive(string input, int previousValue)
        {
            #region part1
            input = input.Trim();
            //// var res = dico.Where(x => x.Value.Any(_ => _.Contains(input.LastIndexOf('s') == input.Length - 1 ? input.Substring(0, input.LastIndexOf('s') - 1) : input))).Select(k => k.Key);
            // foreach (var kp in res)
            // {

            //     recursive(kp);
            //     if (!h.Contains(kp))
            //         h.Add(kp);
            // }
            #endregion

            //s += dico[input].Select(x => x.Value).Sum();
            var localcount = 0;
            foreach (var item in dico[input])
            {

                localcount += item.Value;
                Console.WriteLine($" parent = {input} => {item.Value} {item.Key} =>  NextrecursiveParam = {previousValue * item.Value}");
                recursive(item.Key, item.Value * previousValue);
            }
            sommetotale += (localcount * previousValue);
            Console.WriteLine($"sommetotale+= {localcount} * {previousValue} => sommetotale = {sommetotale}");

        }

        static void Tokenizer(string input)
        {
            #region part1
            var tokens = input.Split("contain");
            var t2 = tokens[1].Split(",");

            var r = new Regex(@"((?<count>[0-9])(?<grouped>[a-z ]+bag))");
            var matched = r.Matches(tokens[1]);
            // if (dico.ContainsKey(tokens[0]))
            string key = tokens[0].Replace(" bags", " bag").Trim();
            dico.Add(key, new Dictionary<string, int>());
            foreach (Match _ in matched)
            {
                dico[key].Add(_.Groups["grouped"].Value, int.Parse(_.Groups["count"].Value));
            }
            #endregion
        }




    }
}

using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Day7
{
    class Program
    {
        static void Main(string[] args)
        {
            var definitionRegex = new Regex(@"^(?<colorBag>.+) bags contain (?<listBags>.+)\.$");
            var containsRegex = new Regex(@"^(?<quantity>\d+) (?<colorBag>.+) bags?$");
            var inputs = File.ReadAllLines("input.txt");
            var bags = new Dictionary<string, (int quantity,string color)[]>();
            foreach(var input in inputs){
                var match = definitionRegex.Match(input);
                var colorBag = match.Groups["colorBag"].Value;
                var listBags = match.Groups["listBags"].Value.Split(", ").Select(_ => {
                    var matchContain = containsRegex.Match(_);
                    if(matchContain.Success){
                        return (int.Parse(matchContain.Groups["quantity"].Value), matchContain.Groups["colorBag"].Value);
                    }
                    return (0,"");
                }).ToArray();
                bags[colorBag] = listBags;                
            }
            // var count = 0;
            // var alreadyCountBag = new HashSet<string>();
            // var bagsToSearch = new HashSet<string>(){"shiny gold"};
            // for(int i =0; i<bags.Count(); i++){
            //     foreach(var bagToSearch in bagsToSearch.ToList()){
            //         bagsToSearch.Remove(bagToSearch);
            //         alreadyCountBag.Add(bagToSearch);
            //         foreach(var bag in bags){
            //             if(bag.Value.Any(_=>_.color == bagToSearch)){
            //                 if(!alreadyCountBag.Contains(bag.Key) && !bagsToSearch.Contains(bag.Key)){
            //                     bagsToSearch.Add(bag.Key);
            //                     count ++;
            //                 }
            //             }
            //         }
            //     }
            // }
            
            Console.WriteLine($"{CountBags("shiny gold",bags) - 1}");
        }

        static private int CountBags(string color, Dictionary<string, (int quantity,string color)[]> bags){
            if(!bags.ContainsKey(color))
                return 0;
            if(!bags[color].Any()){
                return 1;
            }
            return 1 + bags[color].Select(_=>_.quantity*CountBags(_.color,bags)).Sum();
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace day4
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = File.ReadAllLines("input.txt");
            string currentPasseport = "";
            var valid = 0;

            //List<Func<string, bool>> rules = new List<Func<string, bool>>();
            //rules.Add(_ => new Regex(@"\bbyr:(19[2-9][0-9]|200[0-2])\b").Match(_).Success);//1920-2002
            //rules.Add(_ => new Regex(@"\biyr:(201[0-9]|2020)\b").Match(_).Success);//2010-2020
            //rules.Add(_ => new Regex(@"\beyr:(202[0-9]|2030)\b").Match(_).Success);//2020-2030
            //rules.Add(_ => new Regex(@"\bhgt:((1[5-8][0-9]|19[0-3])cm)\b|^((59|6[0-9]|7[0-6])in)\b").Match(_).Success);//150-193cm ou 59-76in
            //rules.Add(_ => new Regex(@"\bhcl:#(([0-9]|[a-f]){6})\b").Match(_).Success);
            //rules.Add(_ => new Regex(@"\becl:(amb|blu|brn|gry|grn|hzl|oth)\b").Match(_).Success);
            //rules.Add(_ => new Regex(@"\bpid:([0-9]{9})\b").Match(_).Success);


            Dictionary<string, Func<string, bool>> rules = new Dictionary<string, Func<string, bool>>();
            rules.Add("byr", _ => new Regex(@"^(19[2-9][0-9]|200[0-2])$").Match(_).Success);//1920-2002
            rules.Add("iyr", _ => new Regex(@"^(201[0-9]|2020)$").Match(_).Success);//2010-2020
            rules.Add("eyr", _ => new Regex(@"^(202[0-9]|2030)$").Match(_).Success);//2020-2030
            rules.Add("hgt", _ => new Regex(@"^((1[5-8][0-9]|19[0-3])cm)$|^((59|6[0-9]|7[0-6])in)$").Match(_).Success);//150-193cm ou 59-76in
            rules.Add("hcl", _ => new Regex(@"^#(([0-9]|[a-f]){6})$").Match(_).Success);//#1f3b2a
            rules.Add("ecl", _ => new Regex(@"^(amb|blu|brn|gry|grn|hzl|oth)$").Match(_).Success);//one of
            rules.Add("pid", _ => new Regex(@"^([0-9]{9})$").Match(_).Success);//000000000

            var e = input.ToList();
            e.Add("");

            foreach (var line in e)
            {

                if (line.Trim().Length > 0)
                {
                    currentPasseport += (currentPasseport == "" ? "" : " ") + line.Trim();
                }
                else
                {
                    var result  = rules.Select(_ => _(currentPasseport));
                    //foreach (var rule in rules)
                    //    rule(currentPasseport);

                    //if (currentPasseport.Contains("byr:") &&
                    // currentPasseport.Contains("iyr:") &&
                    // currentPasseport.Contains("eyr:") &&
                    // currentPasseport.Contains("hgt:") &&
                    // currentPasseport.Contains("hcl:") &&
                    // currentPasseport.Contains("ecl:") &&
                    // currentPasseport.Contains("pid:"))
                    //{
                    //    //valid++;
                    //    var tokens = Tokenizer(currentPasseport);
                    //    var success = true;
                    //    var fields = new string[] { "iyr", "byr", "eyr", "hgt", "hcl", "ecl", "pid" };

                    //    foreach (var key in fields)
                    //    {
                    //        success &= match[key](tokens[key]);

                    //    }
                    //    if (success)
                    //    {
                    //        valid++;
                    //        //Console.WriteLine(currentPasseport);
                    //    }

                    //}
                    if (result.All(_ => _))
                    {
                        valid++;
                    }
                    currentPasseport = "";
                }
            }

            Console.WriteLine(valid);

        }

        static List<string> Tokenizer(string item)
        {
            var splitted = item.Split(' ');
            List<string> dic = new List<string>();
            foreach (var s in splitted)
            {
                dic.Add(s/*.Split(':')[0], s.Split(':')[1]*/);
            }

            return dic;
        }
    }
}

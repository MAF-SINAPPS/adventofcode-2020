using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace Day2
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = File.ReadAllLines("input.txt");            
            var count=0;
            Regex expression = new Regex(@"(?<min>\d+)-(?<max>\d+) (?<char>\w): (?<password>\w+)");
            #region Part 1
            // var values = input.Select(i=>{                
            //     var match = expression.Match(i);
            //     return new {
            //         Min = int.Parse(match.Groups["min"].Value),
            //         Max = int.Parse(match.Groups["max"].Value),
            //         Char = match.Groups["char"].Value,
            //         Password = match.Groups["password"].Value,
            //     };
            // });
            // foreach(var o in values){
            //     var nbChar = o.Password.Count(p=>p.ToString()==o.Char);
            //     if(nbChar >= o.Min && nbChar <= o.Max)
            //         count++;
            // }
            #endregion
            #region Part 2
            var values = input.Select(i=>{                
                var match = expression.Match(i);
                return new {
                    Position1 = int.Parse(match.Groups["min"].Value),
                    Position2 = int.Parse(match.Groups["max"].Value),
                    Char = match.Groups["char"].Value,
                    Password = match.Groups["password"].Value,
                };
            });
            foreach(var o in values){
                if(o.Password[o.Position1-1].ToString() == o.Char ^ o.Password[o.Position2-1].ToString() == o.Char)
                    count++;
            }
            #endregion 
            Console.WriteLine($"Nombre de mot de passe correct : {count}");
        }
    }
}

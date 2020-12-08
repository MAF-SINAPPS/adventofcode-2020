using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Day4
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputs = File.ReadAllText("input.txt").Split("\r\n\r\n").Select(l=>l.Replace("\r\n", " "));
            var requiredFields = new Policy[]{
                new BirthYearPolicy(),
                new IssueYearPolicy(),
                new ExpirationYearPolicy(),
                new HeightPolicy(),
                new HairColorPolicy(),
                new EyeColorPolicy(),
                new PassportIdPolicy(),
            };
            var count = 0;
            foreach(var input in inputs){
                var isValid = true;

                var fields = input.Split(' ').Select(_=>{
                    var split = _.Split(':');
                    return (split[0],split[1]);
                }).ToArray<(string Field, string Value)>();

                foreach(var required in requiredFields){
                    var value = fields.FirstOrDefault(f=>f.Field == required.Field).Value;
                    if(String.IsNullOrEmpty(value)){                        
                        isValid = false;
                        break;                        
                    }
                    isValid = isValid && required.Validate(value);
                }
                if(isValid)
                    count++;
            }
            Console.WriteLine($"valid inputs : {count}");
        }
    }

    abstract class Policy
    {
        public string Field { get; protected set; }
        public abstract bool Validate(string value);
    }

    class BirthYearPolicy : Policy
    {
        public BirthYearPolicy(){
            Field = "byr";
        }
        const int Min = 1920;
        const int Max = 2002;
        public override bool Validate(string value)
        {
            return int.TryParse(value,out var year) && year >= Min && year <= Max;
        }
    }

    class IssueYearPolicy : Policy
    {
        public IssueYearPolicy(){
            Field = "iyr";
        }
        const int Min = 2010;
        const int Max = 2020;
        public override bool Validate(string value)
        {
            if(int.TryParse(value,out var year) && year >= Min && year <= Max){
                return true;
            }
            return false;
        }
    }

    class ExpirationYearPolicy : Policy
    {
        public ExpirationYearPolicy(){
            Field = "eyr";
        }
        const int Min = 2020;
        const int Max = 2030;
        public override bool Validate(string value)
        {
            return int.TryParse(value,out var year) && year >= Min && year <= Max;
        }
    }

    class HeightPolicy : Policy
    {
        public HeightPolicy(){
            Field = "hgt";
        }
        Regex expression = new Regex(@"^(?<height>\d{2,3})(?<unit>in|cm)$");
        const int MinCm = 150;
        const int MaxCm = 193;
        const int MinIn = 59;
        const int MaxIn = 76;
        public override bool Validate(string value)
        {
            var match = expression.Match(value);
            if(!match.Success){
                return false;
            }
            var unit = match.Groups["unit"].Value;
            var height = int.Parse(match.Groups["height"].Value);
            
            return (unit=="cm" && height >= MinCm && height <= MaxCm) || (unit=="in" && height >= MinIn && height <= MaxIn);
        }
    }

    class HairColorPolicy : Policy
    {
        public HairColorPolicy(){
            Field = "hcl";
        }        
        Regex expression = new Regex(@"^#[0-9a-f]{6}$");
        public override bool Validate(string value)
        {
            return expression.IsMatch(value);
        }
    }

    class EyeColorPolicy : Policy
    {
        public EyeColorPolicy(){
            Field = "ecl";
        }        
        Regex expression = new Regex(@"^(amb|blu|brn|gry|grn|hzl|oth)$");
        public override bool Validate(string value)
        {
            return expression.IsMatch(value);
        }
    }
    
    class PassportIdPolicy : Policy
    {
        public PassportIdPolicy(){
            Field = "pid";
        }        
        Regex expression = new Regex(@"^\d{9}$");
        public override bool Validate(string value)
        {
            return expression.IsMatch(value);
        }
    }
}

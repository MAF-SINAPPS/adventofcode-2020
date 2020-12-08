using System;
using System.IO;
using System.Linq;

namespace Day6
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputs = File.ReadAllText("input.txt").Split("\r\n\r\n");
            var count = 0;
            foreach(var group in inputs){
                var questions = new int[26];
                foreach(var letter in group){
                    if(letter >= 'a' && letter <= 'z'){
                        questions[letter-97] += 1; 
                    }
                }
                var groupLength = group.Split("\r\n").Length;
                count += questions.Where(_=>_ == groupLength).Count();
            }
            Console.WriteLine($"{count}");
        }
    }
}

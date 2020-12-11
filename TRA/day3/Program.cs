using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace day3
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = File.ReadAllLines("input.txt");
            Tuple<int, int>[] tuples = { /*Tuple.Create(1, 1),*/ Tuple.Create(1, 3)/*, Tuple.Create(1, 5), Tuple.Create(1, 7), Tuple.Create(2, 1) */};
            long multtrees = 1;
            foreach (var tup in tuples)
            {
                var down = tup.Item1;
                var _____ = tup.Item2;
                var Y = 0;
                var X = 0;
                var trees = 0;
                while ((Y + down) < input.Length)
                {
                    var s = input[Y + down];
                    while (s.Length <= X + right)
                        s += s;
                    if (s[X + right] == '#')
                        trees++;

                    Y += down;
                    X += right;
                }
                multtrees *= trees;
            }


            Console.WriteLine("Trees = " + multtrees);


        }

        static List<string> CreateMap(string[] input, int patternRepeat)
        {
            List<string> ret2d = new List<string>();
            foreach (var s in input)
            {
                string ccnt = s;
                for (int i = 1; i <= patternRepeat; i++)
                {
                    ccnt = String.Concat(s, ccnt);
                }
                ret2d.Add(ccnt);
            }

            return ret2d;
        }
    }
}


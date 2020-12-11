using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace day11
{
    class Program
    {
        static string[] map;
        static void Main(string[] args)
        {
            map = File.ReadAllLines("input.txt");
            var changed = true;
            int count = 0;
           

            while (changed)
            {
                changed = false;
                List<(int, int)> qdiese = new List<(int, int)>();
                List<(int, int)> qL = new List<(int, int)>();
                for (var line = 0; line < map.Length; line++)
                    for (var x = 0; x < map[line].Length; x++)
                    {
                        if (map[line][x] == 'L' && !Adjacent(x, line).Contains('#'))
                        {
                            //var arr = map[line].ToCharArray();
                            //arr[x] = '#';
                            //map[line] = new String(arr);
                            qdiese.Add((line, x));
                            changed = true;
                        }
                     

                        if (map[line][x] == '#' && Adjacent(x, line).Where( _ => _ == '#').Count() >= 4)
                        {
                            //var arr = map[line].ToCharArray();
                            //arr[x] = 'L';
                            //map[line] = new String(arr);
                            qL.Add((line, x));
                            changed = true;
                        }                     

                    }

               foreach(var item in qdiese)
                {
                    var arr = map[item.Item1].ToCharArray();
                    arr[item.Item2] = '#';
                    map[item.Item1] = new String(arr);
                }

                foreach (var item in qL)
                {
                    var arr = map[item.Item1].ToCharArray();
                    arr[item.Item2] = 'L';
                    map[item.Item1] = new String(arr);
                }

                count++;
            }

            var c = map.SelectMany(x => x).Where(_ => _ == '#').Count();
            Console.WriteLine(c);
        }

        static char[] Adjacent(int x, int line)
        {
            var adj = new List<char>();
            if (x > 0)
                adj.Add(map[line][x - 1]);
            if (map[line].Length > (x + 1))
                adj.Add(map[line][x + 1]);
            if (line > 0)
                adj.Add(map[line - 1][x]);
            if ((line + 1) < map.Length)
                adj.Add(map[line + 1][x]);
            if (line > 0 && x > 0)
                adj.Add(map[line - 1][x - 1]);
            if (line > 0 && map[line].Length > (x + 1))
                adj.Add(map[line - 1][x + 1]);
            if ((line + 1) < map.Length && x > 0)
                adj.Add(map[line + 1][x - 1]);
            if ((line + 1) < map.Length && map[line].Length > (x + 1))
                adj.Add(map[line + 1][x + 1]);

            return adj.ToArray();
        }
    }
}

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

            //var kk = Adjacent(3, 4).Where(_ => _ == '#').Count();
            //  var kk = Adjacent(3, 3).Where(_ => _ == '#').Count();
            var kk = Adjacent(1, 1).Where(_ => _ == '#').Count();
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
                            qdiese.Add((line, x));
                            changed = true;
                        }


                        if (map[line][x] == '#' && Adjacent(x, line).Where(_ => _ == '#').Count() >= 5)
                        {
                            qL.Add((line, x));
                            changed = true;
                        }

                    }

                foreach (var item in qdiese)
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

            var c = map.SelectMany(x => x).Count();
            Console.WriteLine(c);
        }

        static char[] Adjacent(int x, int line)
        {
            var adj = new List<char>();



            //for (int i = 1; (x + i) < map[line].Length; i++)
            //    if (map[line][x + i] != '.')
            //    {
            //        adj.Add(map[line][x + i]);
            //        break;
            //    }


            //for (int i = 1; (x - i) >= 0; i++)
            //    if (map[line][x - i] != '.')
            //    {
            //        adj.Add(map[line][x - i]);
            //        break;
            //    }



            //for (int i = 1; (line + i) < map.Length; i++)
            //    if (map[line + i][x] != '.')
            //    {
            //        adj.Add(map[line + i][x]);
            //        break;
            //    }


            //for (int i = 1; (line - i) >= 0; i++)
            //    if (map[line - i][x] != '.')
            //    {
            //        adj.Add(map[line - i][x]);
            //        break;
            //    }



            for (int i = 1; ((line + i) < map.Length) && (x + i) < map[line].Length; i++)
            {
                if (map[line + i][x + i] != '.')
                {
                    adj.Add(map[line + i][x + i]); break;
                }
            }


            for (int i = 1; ((line + i) < map.Length) && (x - i) >= 0; i++)
            {
                if (map[line + i][x - i] != '.')
                {
                    adj.Add(map[line + i][x - i]);
                    break;
                }
            }

            for (int i = 1; (line - i) >= 0 && (x + i) < map[line].Length; i++)
            {
                if (map[line - i][x + i] != '.')
                {
                    adj.Add(map[line - i][x + i]);
                    break;
                }
            }

            for (int i = 1; (line - i) > 0 && (x - i) >= 0; i++)
            {
                if (map[line - i][x - i] != '.')
                {
                    adj.Add(map[line - i][x - i]);
                    break;
                }
            }

            return adj.ToArray();
        }
    }
}

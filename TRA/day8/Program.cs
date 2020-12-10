using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace day8
{
    class Program
    {
         
        static int accumulator = 0;
        static void Main(string[] args)
        {
            var input = File.ReadAllLines("input.txt");
            //int i = 0;
            //int previ = 0;
            //while (i < input.Length)
            //{
            //    var splitted = input[i].Split(" ");
            //    var instr = splitted[0];
            //    if (dico.ContainsKey(i))
            //    {
            //        i = previ+1;
            //        continue;
            //    }
            //    dico.Add(i, true);
            //    if (instr == "acc")
            //    {
            //        accumulator += int.Parse(splitted[1]);
            //    }
            //    else
            //    if ("jmp" == instr)
            //    {
            //        previ = i;
            //        i += int.Parse(splitted[1]);
            //        continue;
            //    }
            //    i++;
            //}
            //Console.WriteLine(accumulator);

            //var input = File.ReadAllLines("input.txt");
            var eeee = input.Select((s, i) => new { i, s }).Where(_ => _.s.Contains("jmp"));
            string[] oooo = new string[input.Length];
            Array.Copy(input, oooo, input.Length);
            foreach (var ii in eeee)
            {
                if (!runprogram(oooo))
                {
                    Array.Copy(input, oooo, input.Length);
                    oooo[ii.i] = oooo[ii.i].Replace("jmp", "nop");
                    if (runprogram(oooo))
                        break;
                }
                else
                    break;
               
            }
            Console.WriteLine(accumulator);
        }

        static bool runprogram(string[] files)
        {
            int i = 0;
            var dico = new Dictionary<int, bool>();
            while (i < files.Length)
            {
                var splitted = files[i].Split(" ");
                var instr = splitted[0];

                if (dico.ContainsKey(i))
                {
                    accumulator = 0;
                    return false;
                }
                    dico.Add(i, true);
             
                if (instr == "acc")
                {
                    accumulator += int.Parse(splitted[1]);
                }
                else
                      if ("jmp" == instr)
                {
                    i += int.Parse(splitted[1]);
                    continue;
                }
                i++;
            }
            return true;
        }

    }




}

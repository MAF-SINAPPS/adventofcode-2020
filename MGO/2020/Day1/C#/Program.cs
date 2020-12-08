using System;
using System.IO;
using System.Linq;

namespace Day1
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = File.ReadAllLines("input.txt");
            var values = input.Select(i=>int.Parse(i)).ToArray();

            for(int i = 0; i < values.Length - 3; i++){
                for(int j = i+1; j < values.Length - 2; j++){
                    if(values[i] + values[j] == 2020){
                        Console.WriteLine($"x={values[i]},y={values[j]}, x*y={ values[i]*values[j]}");
                    }
                    for(int k = j+1; k < values.Length - 1; k++){
                        if(values[i] + values[j] + values[k] == 2020){
                            Console.WriteLine($"x={values[i]},y={values[j]},z={values[k]}, x*y*z={ values[i]*values[j]*values[k]}");
                        }
                    }
                }
            }            
        }
    }
}

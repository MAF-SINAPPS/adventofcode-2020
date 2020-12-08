using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace Day3
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = File.ReadAllLines("input.txt");
            #region Part 1
            // var count = 0;
            // for(int i=1; i<input.Length; i++){
            //     var lineLength = input[i].Length;
            //     if(input[i][(i*3)%lineLength] == '#')
            //         count++;
            // }

            // Console.WriteLine($"Nombre d'arbre rencontrés : {count}");
            #endregion
            #region Part 2
            //Clé: tuple (x,y) pour la pente, Valeur : compteur
            var slopes = new Dictionary<(int x, int y),int>{
                {(1,1),0},
                {(1,3),0},
                {(1,5),0},
                {(1,7),0},
                {(2,1),0}
            };

            for(int i=1; i<input.Length; i++){
                foreach(var slope in slopes.Keys.ToList()){
                    if(i%slope.x == 0 && input[i][(i*slope.y/slope.x)%input[i].Length] == '#')
                        slopes[slope]++;
                }               
            }

            Console.WriteLine($"Nombre d'arbre rencontrés :");
            foreach(var slope in slopes){
                Console.WriteLine($"({slope.Key.x}, {slope.Key.y}) : {slope.Value}");
            }
            Console.WriteLine($"Nombre d'arbre rencontrés : {slopes.Values.Aggregate(1, (acc, val) => acc * val)}");
            #endregion
        }
    }
}

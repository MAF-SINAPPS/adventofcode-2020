using System;
using System.IO;
using System.Linq;

namespace Day8
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputs = File.ReadAllLines("input.txt").Select(_=>{
                var split = _.Split(" ");
                return (split[0], int.Parse(split[1]));
            }).ToArray<(string instruction, int value)>();
            
            for(int i = 0; i<inputs.Length; i++){
                var clonedInputs = ((string instruction, int value)[])inputs.Clone();
                if(inputs[i].instruction == "nop" || inputs[i].instruction == "jmp")
                    clonedInputs[i].instruction = inputs[i].instruction == "nop" ? "jmp" : "nop";
                else continue;
                var accumulator = 0;
                var instructionRun = new bool[inputs.Length];
                var stopLoop = false;
                var instructionPointer = 0;
                while(!stopLoop && instructionPointer < inputs.Length){
                    if(instructionRun[instructionPointer] == true){
                        stopLoop = true;
                        break;
                    }
                    var instruction = clonedInputs[instructionPointer].instruction;
                    var value = clonedInputs[instructionPointer].value;                
                    instructionRun[instructionPointer] = true;
                    switch(instruction){
                        case "nop": instructionPointer ++;
                                    break;
                        case "acc": instructionPointer ++;
                                    accumulator += value;
                                    break;
                        case "jmp": instructionPointer += value;
                                    break;
                    }
                }
                if(!stopLoop){
                    Console.WriteLine($"{accumulator}");
                    break;
                }
            }
        }
    }
}

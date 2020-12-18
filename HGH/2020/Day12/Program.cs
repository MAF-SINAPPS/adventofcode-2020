using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode
{
    class Program
    {
        private static int configSeats = 5;
        private static List<char> refDirections = new List<char> {'N', 'E', 'S', 'W'};
        private static (char, int, char) MoveDirection(string line, char directionInit)
        {
            char direction = line[0];
            int units = Convert.ToInt32(line.Substring(1, line.Length-1));
            switch(direction)
            {
                case 'L':
                    directionInit = GetDirection(units, false, directionInit);
                    return (directionInit, 0, directionInit);
                case 'R':
                    directionInit = GetDirection(units, true, directionInit);
                    return (directionInit, 0, directionInit);
                case 'F':
                    //directionInit = GetDirection(units, true);
                    return (directionInit, units, directionInit);
                default:
                    //directionInit = 
                    return (direction, units, directionInit);
            }
        }
        
        private static char GetDirection(int units, bool isRight, char directionInit)
        {
            int index = units / 90;
            int indexInit = refDirections.FindIndex(a => a.Equals(directionInit));
            int indexToMove;
            if (isRight)
            {
                indexToMove = indexInit + index;
                indexToMove = indexToMove > 3 ? indexToMove - 4 : indexToMove;
            }else
            {
                indexToMove = indexInit - index;
                indexToMove = indexToMove < 0 ? indexToMove + 4 : indexToMove;
            }
            return refDirections[indexToMove];
        }

        private static (int, char[], int[]) MoveDirectionPart2(string line, char[] directionInitKey, int[] directionInitUnits)
        {
            char direction = line[0];
            int units = Convert.ToInt32(line.Substring(1, line.Length - 1));
            List<char> listKeys = new List<char>(directionInitKey);
            List<int> listUnits = new List<int>(directionInitUnits);
            switch (direction)
            {
                case 'L':
                    directionInitKey = GetDirectionPart2(units, false, directionInitKey);
                    return (0, directionInitKey, directionInitUnits);
                case 'R':
                    directionInitKey = GetDirectionPart2(units, true, directionInitKey);
                    return (0, directionInitKey, directionInitUnits);
                case 'N':
                    if (directionInitKey.Contains('N'))
                        directionInitUnits[listKeys.FindIndex(_ => _.Equals('N'))] += units;
                    if (directionInitKey.Contains('S'))
                        directionInitUnits[listKeys.FindIndex(_ => _.Equals('S'))] -= units;
                    return (0, directionInitKey, directionInitUnits);
                case 'E':
                    if (directionInitKey.Contains('E'))
                        directionInitUnits[listKeys.FindIndex(_ => _.Equals('E'))] += units;
                    if (directionInitKey.Contains('W'))
                        directionInitUnits[listKeys.FindIndex(_ => _.Equals('W'))] -= units;
                    return (0, directionInitKey, directionInitUnits);
                case 'S':
                    if (directionInitKey.Contains('S'))
                        directionInitUnits[listKeys.FindIndex(_ => _.Equals('S'))] += units;
                    if (directionInitKey.Contains('N'))
                        directionInitUnits[listKeys.FindIndex(_ => _.Equals('N'))] -= units;
                    return (0, directionInitKey, directionInitUnits);
                case 'W':
                    if (directionInitKey.Contains('W'))
                        directionInitUnits[listKeys.FindIndex(_ => _.Equals('W'))] += units;
                    if (directionInitKey.Contains('E'))
                        directionInitUnits[listKeys.FindIndex(_ => _.Equals('E'))] -= units;
                    return (0, directionInitKey, directionInitUnits);
                case 'F':
                    //directionInit = GetDirection(units, true);
                    return (units, directionInitKey, directionInitUnits);
                default:
                    return (units, directionInitKey, directionInitUnits);
            }
        }


        private static char[] GetDirectionPart2(int units, bool isRight, char[] directionInitKey)
        {
            int index = units / 90;
            int indexInit1 = refDirections.FindIndex(a => a.Equals(directionInitKey[0]));
            int indexInit2 = refDirections.FindIndex(a => a.Equals(directionInitKey[1]));
            int indexToMove1;
            int indexToMove2;
            if (isRight)
            {
                indexToMove1 = indexInit1 + index;
                indexToMove1 = indexToMove1 > 3 ? indexToMove1 - 4 : indexToMove1;

                indexToMove2 = indexInit2 + index;
                indexToMove2 = indexToMove2 > 3 ? indexToMove2 - 4 : indexToMove2;
            }
            else
            {
                indexToMove1 = indexInit1 - index;
                indexToMove1 = indexToMove1 < 0 ? indexToMove1 + 4 : indexToMove1;

                indexToMove2 = indexInit2 - index;
                indexToMove2 = indexToMove2 < 0 ? indexToMove2 + 4 : indexToMove2;
            }
            directionInitKey[0] = refDirections[indexToMove1];
            directionInitKey[1] = refDirections[indexToMove2];
            return directionInitKey;
        }


        static void Main(string[] args)
        {
            var lines = File.ReadAllLines("Input12.txt")
                .ToArray();
            int countNorth = 0;
            int countSouth = 0;
            int countEast = 0;
            int countWest = 0;
            //------------------Day 12 Part 1 -------------------
            //char directionInit = 'E';
            //foreach (var line in lines)
            //{
            //    var result = MoveDirection(line, directionInit);
            //    directionInit = result.Item3;
            //    switch(result.Item1)
            //    {
            //        case 'N':
            //            countNorth += result.Item2;
            //            break;
            //        case 'E':
            //            countEast += result.Item2;
            //            break;
            //        case 'S':
            //            countSouth += result.Item2;
            //            break;
            //        case 'W':
            //            countWest += result.Item2;
            //            break;
            //    }
            //}
            //------------------Day 12 Part 2 -------------------
            var wayPointDirections = new char[2] { 'N','E' };
            var wayPointUnits = new int[2] { 1, 10};
            foreach (var line in lines)
            {
                var result = MoveDirectionPart2(line, wayPointDirections, wayPointUnits);
                wayPointDirections = result.Item2;
                wayPointUnits = result.Item3;
                switch (result.Item2[0])
                {
                    case 'N':
                        countNorth += result.Item3[0] * result.Item1;
                        break;
                    case 'E':
                        countEast += result.Item3[0] * result.Item1;
                        break;
                    case 'S':
                        countSouth += result.Item3[0] * result.Item1;
                        break;
                    case 'W':
                        countWest += result.Item3[0] * result.Item1;
                        break;
                }
                switch (result.Item2[1])
                {
                    case 'N':
                        countNorth += result.Item3[1] * result.Item1;
                        break;
                    case 'E':
                        countEast += result.Item3[1] * result.Item1;
                        break;
                    case 'S':
                        countSouth += result.Item3[1] * result.Item1;
                        break;
                    case 'W':
                        countWest += result.Item3[1] * result.Item1;
                        break;
                }
            }
            int count = Math.Abs(countNorth - countSouth) + Math.Abs(countWest-countEast);
            Console.WriteLine("-----------------------------");
            Console.WriteLine("        Result : "+count);
            Console.WriteLine("-----------------------------");
            Console.ReadLine();
        }
    }
}

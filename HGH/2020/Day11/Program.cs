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
        private static char GetChar(char[][] input, int i, int j)
        {
            var virtuelTable = GetDiagonaleChar(input, i, j);
            if (input[i][j].Equals('L'))
            {
                if (virtuelTable[0, 0].Equals('#')
                    || virtuelTable[0, 1].Equals('#')
                    || virtuelTable[0, 2].Equals('#')
                    || virtuelTable[1, 0].Equals('#')
                    || virtuelTable[1, 2].Equals('#')
                    || virtuelTable[2, 0].Equals('#')
                    || virtuelTable[2, 1].Equals('#')
                    || virtuelTable[2, 2].Equals('#')
                    )
                    return 'L';
                return '#';
            }

            if (input[i][j].Equals('#'))
            {
                var countOccupedSeats = 0;
                if (virtuelTable[0,0].Equals('#'))
                    countOccupedSeats++;
                if (virtuelTable[0,1].Equals('#'))
                    countOccupedSeats++;
                if (virtuelTable[0,2].Equals('#'))
                    countOccupedSeats++;
                if (virtuelTable[1,0].Equals('#'))
                    countOccupedSeats++;
                if (virtuelTable[1,2].Equals('#'))
                    countOccupedSeats++;
                if (virtuelTable[2,0].Equals('#'))
                    countOccupedSeats++;
                if (virtuelTable[2,1].Equals('#'))
                    countOccupedSeats++;
                if (virtuelTable[2,2].Equals('#'))
                    countOccupedSeats++;
                if (countOccupedSeats >= configSeats)
                    return 'L';
                return '#';
            }

            //if (input[i][j].Equals('.'))
                return '.';
            //return input[i][j];
        }
        private static bool AreEquals(char[,] a, char[,] b, int lengthRows, int lengthColumns)
        {
            for (int i = 0; i < lengthRows; i++)
            {
                for (int j = 0; j < lengthColumns; j++)
                {
                    if (a[i, j] != b[i, j])
                        return false;
                }
            }
            return true;
        }
        private static char[,] GetDiagonaleChar(char[][] input, int indI, int indJ)
        {
            char[,] result = new char[3, 3];
            int rows = input.GetLength(0);
            int columns = input[0].GetLength(0);
            for(int lineIndex = 0; lineIndex<3;lineIndex++)
            {
                result[lineIndex, 0] = '.';
                result[lineIndex, 1] = '.';
                result[lineIndex, 2] = '.';
            }
            result[1, 1] = input[indI][indJ];
            int countRows = 1;
            int countColumns = 1;
            while ((indI - countRows) >= 0
                || (indI + countRows) <rows
                || (indJ - countColumns) >=0
                || (indJ + countColumns) <columns
                )
            {
                if((indI - countRows) >=0 
                    && (indJ - countColumns) >=0 
                    && !input[indI - countRows][indJ - countColumns].Equals('.') 
                    && result[0, 0].Equals('.'))
                    result[0, 0] = input[indI - countRows][indJ - countColumns];

                if((indI - countRows) >=0 
                    && result[0, 1].Equals('.')
                    && !input[indI - countRows][indJ].Equals('.'))
                    result[0, 1] = input[indI - countRows][indJ];
                
                if((indI - countRows) >=0 
                    && (indJ + countColumns) <columns 
                    && result[0, 2].Equals('.')
                    && !input[indI - countRows][indJ + countColumns].Equals('.'))
                    result[0, 2] = input[indI - countRows][indJ + countColumns];
                
                if((indJ - countColumns) >=0 
                    && result[1, 0].Equals('.')
                    && !input[indI][indJ - countColumns].Equals('.'))
                    result[1, 0] = input[indI][indJ - countColumns];
                
                if((indJ + countColumns) <columns 
                    && result[1, 2].Equals('.')
                    && !input[indI][indJ + countColumns].Equals('.'))
                    result[1, 2] = input[indI][indJ + countColumns];
                
                if((indI + countRows) < rows 
                    && (indJ - countColumns) >=0 
                    && result[2, 0].Equals('.')
                    && !input[indI + countRows][indJ - countColumns].Equals('.'))
                    result[2, 0] = input[indI + countRows][indJ - countColumns];
                
                if((indI + countRows) < rows 
                    && result[2, 1].Equals('.')
                    && !input[indI + countRows][indJ].Equals('.'))
                    result[2, 1] = input[indI + countRows][indJ];
                
                if((indI + countRows) < rows 
                    && (indJ + countColumns) <columns 
                    && result[2, 2].Equals('.')
                    && !input[indI + countRows][indJ + countColumns].Equals('.'))
                    result[2, 2] = input[indI + countRows][indJ + countColumns];
                
                countRows++;
                countColumns++;
            }
            return result;
        }
        static void Main(string[] args)
        {
            //------------------Day 11 Part 2 -------------------
            var inputTable = File.ReadAllLines("Input11.txt")
                .Select(_=>_.ToCharArray()).ToArray();
            var lengthRows = inputTable.GetLength(0);
            var lengthColumns = inputTable[0].GetLength(0);
            var newTable = new char[lengthRows, lengthColumns];
            var lines = inputTable;
            var lastTable = new char[lengthRows, lengthColumns];
            var stop = false;
            var count = 0;
            for (int i = 0; i < lengthRows; i++)
            {
                for (int j = 0; j < lengthColumns; j++)
                {
                    newTable[i,j] = inputTable[i][j];
                }
            }
            while (!stop)
            {
                for (int i = 0; i < lengthRows; i++)
                {
                    for (int j = 0; j < lengthColumns; j++)
                    {
                        lines[i][j] = newTable[i, j];
                    }
                }
                for (int i = 0; i < lengthRows; i++)
                {
                    for (int j = 0; j < lengthColumns; j++)
                    {
                        newTable[i, j] = GetChar(lines, i, j);
                    }
                }
                stop = AreEquals(newTable, lastTable, lengthRows, lengthColumns);
                for (int i = 0; i < lengthRows; i++)
                {
                    for (int j = 0; j < lengthColumns; j++)
                    {
                        lastTable[i, j] = newTable[i, j];
                    }
                }
            }
            for (int i = 0; i < lengthRows; i++)
            {
                for (int j = 0; j < lengthColumns; j++)
                {
                    if (newTable[i, j].Equals('#'))
                        count++;
                }
            }
            Console.WriteLine("-----------------------------");
            Console.WriteLine("        Result : "+count);
            Console.WriteLine("-----------------------------");
            Console.ReadLine();
        }
    }
}

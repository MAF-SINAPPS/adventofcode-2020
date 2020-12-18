using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode
{
    class Program
    {
        private static char[,,] GetNextIteration3Dim(char[,,] a, int dim)
        {
            int dims = dim;
            char[,,] result = new char[dims, dims, dims];
            for (int x = 0; x < dims; x++)
            {
                for (int y = 0; y < dims; y++)
                {
                    for (int z = 0; z < dims; z++)
                    {
                        result[x, y, z] = '.';
                    }
                }
            }
            for (int x = 0; x < dims; x++)
            {
                for (int y = 0; y < dims; y++)
                {
                    for (int z = 0; z < dims; z++)
                    {
                        var count = CountNeighborsCube3Dim(a, x, y, z);
                        if (a[x, y, z].Equals('#') && (count == 3 || count == 4))
                            result[x, y, z] = '#';
                        else if (a[x, y, z].Equals('.') && count == 3)
                            result[x, y, z] = '#';
                    }
                }
            }
            return result;
        }
        private static char[,,,] GetNextIteration4Dim(char[,,,] a, int dim)
        {
            int dims = dim;
            char[,,,] result = new char[dims, dims, dims, dims];
            for (int x = 0; x < dims; x++)
            {
                for (int y = 0; y < dims; y++)
                {
                    for (int z = 0; z < dims; z++)
                    {
                        for (int w = 0; w < dims; w++)
                        {
                            result[x, y, z, w] = '.';
                        }
                    }
                }
            }
            for (int x = 0; x < dims; x++)
            {
                for (int y = 0; y < dims; y++)
                {
                    for (int z = 0; z < dims; z++)
                    {
                        for (int w = 0; w < dims; w++)
                        {
                            var count = CountNeighborsCube4Dim(a, x, y, z, w);
                            if (a[x, y, z, w].Equals('#') && (count == 3 || count == 4))
                                result[x, y, z, w] = '#';
                            else if (a[x, y, z, w].Equals('.') && count == 3)
                                result[x, y, z, w] = '#';
                        }
                    }
                }
            }
            return result;
        }
        private static int CountNeighborsCube3Dim(char[,,] input, int indX, int indY, int indZ)
        {
            int rows = input.GetLength(0);
            int countActif = 0;
            for (int xIndex = -1; xIndex < 2; xIndex++)
            {
                int nX = indX + xIndex;
                if(nX >= 0 && nX < rows)
                {
                    for (int yIndex = -1; yIndex < 2; yIndex++)
                    {
                        int nY = indY + yIndex;
                        if (nY >= 0 && nY < rows)
                        {
                            for (int zIndex = -1; zIndex < 2; zIndex++)
                            {
                                int nZ = indZ + zIndex;
                                if (nZ >= 0 && nZ < rows)
                                {
                                    if (input[nX, nY, nZ].Equals('#'))
                                        countActif++;
                                }
                            }
                        }
                    }
                }
                
            }
            return countActif;
        }
        private static int CountNeighborsCube4Dim(char[,,,] input, int indX, int indY, int indZ, int indW)
        {
            int rows = input.GetLength(0);
            int countActif = 0;
            for (int xIndex = -1; xIndex < 2; xIndex++)
            {
                int nX = indX + xIndex;
                if (nX >= 0 && nX < rows)
                {
                    for (int yIndex = -1; yIndex < 2; yIndex++)
                    {
                        int nY = indY + yIndex;
                        if (nY >= 0 && nY < rows)
                        {
                            for (int zIndex = -1; zIndex < 2; zIndex++)
                            {
                                int nZ = indZ + zIndex;
                                if (nZ >= 0 && nZ < rows)
                                {
                                    for (int wIndex = -1; wIndex < 2; wIndex++)
                                    {
                                        int nW = indW + wIndex;
                                        if (nW >= 0 && nW < rows)
                                        {
                                            if (input[nX, nY, nZ, nW].Equals('#'))
                                                countActif++;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }

            }
            return countActif;
        }
        static void Main(string[] args)
        {
            ////------------------Day 17 Part 1 -------------------
            //var inputTable = File.ReadAllLines("Input17.txt")
            //    .Select(_ => _.ToCharArray()).ToArray();
            //var lengthRows = inputTable.GetLength(0);
            //int dims = lengthRows * 8+1;
            //int startIndex = dims/2 -1;
            //int endIndex = startIndex + lengthRows-1;
            //char[,,] result = new char[dims, dims, dims];
            //for (int x = 0; x < dims; x++)
            //{
            //    for (int y = 0; y < dims; y++)
            //    {
            //        for (int z = 0; z < dims; z++)
            //        {
            //            result[x, y, z] = '.';

            //        }
            //    }
            //}
            //for (int x = startIndex; x <= endIndex; x++)
            //{
            //    for (int y = startIndex; y <= endIndex; y++)
            //    {
            //        result[x, y, dims / 2] = inputTable[x- startIndex][y- startIndex];
            //    }
            //}
            //for (int i = 0; i < 6; i++)
            //{
            //    result = GetNextIteration3Dim(result, dims);
            //}
            //int count = 0;
            //for (int x = 0; x < dims; x++)
            //{
            //    for (int y = 0; y < dims; y++)
            //    {
            //        for (int z = 0; z < dims; z++)
            //        {
            //            if (result[x, y, z].Equals('#'))
            //                count++;
            //        }
            //    }
            //}
            //------------------End Day 17 Part 1 -------------------

            //------------------Start Day 17 Part 2 -------------------
            var inputTable = File.ReadAllLines("Input17.txt")
                .Select(_ => _.ToCharArray()).ToArray();
            var lengthRows = inputTable.GetLength(0);
            int dims = lengthRows * 8 + 1;
            int startIndex = dims / 2 - 1;
            int endIndex = startIndex + lengthRows - 1;
            char[,,,] result = new char[dims, dims, dims, dims];
            for (int x = 0; x < dims; x++)
            {
                for (int y = 0; y < dims; y++)
                {
                    for (int z = 0; z < dims; z++)
                    {
                        for (int w = 0; w < dims; w++)
                        {
                            result[x, y, z, w] = '.';
                        }
                    }
                }
            }
            for (int x = startIndex; x <= endIndex; x++)
            {
                for (int y = startIndex; y <= endIndex; y++)
                {
                    result[x, y, dims / 2, dims/2] = inputTable[x - startIndex][y - startIndex];
                }
            }
            for (int i = 0; i < 6; i++)
            {
                result = GetNextIteration4Dim(result, dims);
            }
            int count = 0;
            for (int x = 0; x < dims; x++)
            {
                for (int y = 0; y < dims; y++)
                {
                    for (int z = 0; z < dims; z++)
                    {
                        for (int w = 0; w < dims; w++)
                        {
                            if (result[x, y, z, w].Equals('#'))
                                count++;
                        }
                    }
                }
            }
            //------------------End Day 17 Part 2 -------------------
            Console.WriteLine("-----------------------------");
            Console.WriteLine("        Result : " + count);
            Console.WriteLine("-----------------------------");
            Console.ReadLine();
        }
    }
}

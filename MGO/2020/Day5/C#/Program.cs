using System;
using System.IO;
using System.Linq;

namespace Day5
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputs = File.ReadAllLines("input.txt");
            var minSeatId = int.MaxValue;
            var maxSeatId = 0;
            var seatIds = new bool[1024];
            foreach(var input in inputs){
                var seatId = CalculateSeatId(input);
                seatIds[seatId]=true;
                if(seatId>maxSeatId)
                    maxSeatId = seatId;
                if(seatId < minSeatId)
                    minSeatId = seatId;

            }
            var mySeatId = Array.FindIndex(seatIds,minSeatId,maxSeatId - minSeatId,_=>_==false);
            Console.WriteLine($"{mySeatId}");
        }

        private static int CalculateSeatId(string seatString)
        {
            var minRange = 0;
            var maxRange = 127; 
            for (int i = 0; i < 7; i++)
            {
                var midRange = (minRange + maxRange) / 2;
                if (seatString[i] == 'F')
                    maxRange = midRange;
                else
                    minRange = midRange + 1;
            }
            var row = minRange;
            minRange = 0;
            maxRange = 7;
            for (int i = 7; i < 10; i++)
            {
                var midRange = (minRange + maxRange) / 2;
                if (seatString[i] == 'L')
                    maxRange = midRange;
                else
                    minRange = midRange + 1;
            }
            var column = minRange;
            return 8*row + column;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.TruckTour
{
    class Program
    {
        static int numberOfPumps;
        static Queue<int[]> pumpData;

        static void Main(string[] args)
        {
            numberOfPumps = int.Parse(Console.ReadLine());
            pumpData = new Queue<int[]>();

            for (int i = 0; i < numberOfPumps; i++)
                pumpData.Enqueue(Console.ReadLine()
                    .Split(' ')
                    .Select(a => int.Parse(a))
                    .ToArray());

            for (int j = 0; j < numberOfPumps; j++)
            {
                if (IsAnswer())
                {
                    Console.WriteLine(j);
                    break;
                }
                int[] startPump = pumpData.Dequeue();
                pumpData.Enqueue(startPump);
            }
        }

        static bool IsAnswer()
        {
            int currFuel = 0;
            bool isAnswer = true;

            for (int i = 0; i < numberOfPumps; i++)
            {
                int[] currPump = pumpData.Dequeue();
                currFuel += currPump[0] - currPump[1];

                if (currFuel < 0)
                    isAnswer = false;

                pumpData.Enqueue(currPump);
            }

            if (isAnswer)
                return true;
            else
                return false;
        }       
    }
}

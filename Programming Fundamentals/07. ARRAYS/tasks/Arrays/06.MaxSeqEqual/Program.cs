using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.MaxSeqEqual
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            int currLength = 0;
            int bestLength = 0;
            int bestElement = 0;

            for (int i = 0; i < arr.Length-1; i++)
            {
                if (arr[i] == arr[i + 1])
                {
                    currLength++;
                }
                else
                {
                    currLength = 0;
                }

                if (currLength > bestLength)
                {
                    bestLength = currLength;
                    bestElement = arr[i];
                }
            }

            for (int j = 0; j <= bestLength; j++)
            {
                Console.Write(bestElement + " ");
            }
        }
    }
}

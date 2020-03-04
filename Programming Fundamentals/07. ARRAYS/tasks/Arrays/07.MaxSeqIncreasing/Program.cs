using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.MaxSeqIncreasing
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            int maxstart = 0;
            int max = 1;
            int start = 0;
            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i] > arr[i - 1])
                {
                    if (i - start + 1 > max)
                    {
                        max = i - start + 1;
                        maxstart = start;
                    }
                }
                else
                {
                    start = i;
                }
            }

            for (int i = 0; i < max; i++)
            {
                Console.Write(arr[maxstart + i] + " ");
            }
        }
    }
}

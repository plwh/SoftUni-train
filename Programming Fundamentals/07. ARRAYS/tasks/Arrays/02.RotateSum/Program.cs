using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.RotateSum
{
    class Program
    {
        static void Main(string[] args)
        {
            int [] arr = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int[] rotatedArr = new int[arr.Length];
            int[] sum = new int[arr.Length];

            int k = int.Parse(Console.ReadLine());

            for (int i = 0; i < k; i++)
            {
                // rotating array
                for (int j = 0, l = arr.Length - 1; j < arr.Length; j++)
                {
                    if (j == 0)
                    {
                        rotatedArr[j] = arr[l];
                    }
                    else
                    {
                        rotatedArr[j] = arr[j-1];
                    }
                }

                //summing rotated array elements
                for (int m = 0; m < rotatedArr.Length; m++)
                {
                    sum[m] = sum[m] + rotatedArr[m];
                }

                // creating a copy of array
                arr = (int []) rotatedArr.Clone();
            }

            foreach (int i in sum) Console.Write(i + " ");
        }
    }
}

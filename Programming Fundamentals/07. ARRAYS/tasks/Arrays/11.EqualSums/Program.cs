using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11.EqualSums
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            
            int leftSum = 0;
            int rightSum = 0;
            int index = -1;

            for (int i = 0; i < arr.Length; i++)
            {
                
                //calc left sum
                for (int j = i; j > 0; j--)
                {
                    leftSum += arr[j - 1];      
                }

                //calc right sum
                for (int k = i; k < arr.Length-1; k++)
                {
                    rightSum += arr[k + 1];
                }
                
                
                //check if sums are equal
                if (leftSum == rightSum) index = i;

                // change sums value to the default one
                leftSum = 0;
                rightSum = 0;
            }

            Console.WriteLine((index != -1) ? index.ToString() : "no");
        }
    }
}

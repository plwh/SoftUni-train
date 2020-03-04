using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.LargestCommonEnd
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] arr1 = Console.ReadLine().Split(' ');
            string[] arr2 = Console.ReadLine().Split(' ');

            int shorterLength = (arr1.Length > arr2.Length) ? arr2.Length : arr1.Length;

            int currEqual = 0;
            int maxEqual = 0;

            //scan from left to right
            for (int i = 0; i < shorterLength; i++)
            {
                if (arr1[i] == arr2[i]) currEqual++;

                if (currEqual > maxEqual) maxEqual = currEqual;
            }

            currEqual = 0;

            //scan from right to left
            for (int j = 1; j <= shorterLength; j++)
            {
                if (arr1[arr1.Length - j] == arr2[arr2.Length - j]) currEqual++;

                if (currEqual > maxEqual) maxEqual = currEqual;
            }

            Console.WriteLine(maxEqual);
        }
    }
}

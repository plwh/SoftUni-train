using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12.CharacterMultiplier
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split();

            var str1 = input[0];
            var str2 = input[1];
            var maxLength = Math.Max(str1.Length, str2.Length);
            var sum = 0;

            for (int i = 0; i < maxLength; i++)
            {
                if (i >= str1.Length)
                {
                    sum += str2[i];
                }
                else if (i >= str2.Length)
                {
                    sum += str1[i];
                }
                else
                {
                    sum += str1[i] * str2[i];
                }
            }
            
            Console.WriteLine(sum);
        }
    }
}

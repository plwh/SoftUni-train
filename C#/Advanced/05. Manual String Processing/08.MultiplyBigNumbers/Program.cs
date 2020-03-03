using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.MultiplyBigNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string num = Console.ReadLine();
            int multiplier = int.Parse(Console.ReadLine());

            num = num.PadLeft(num.Length + 1, '0');
          
            var sum = new int[num.Length];
            int remainder = 0;

            for (int i = sum.Length - 1; i >= 0; i--)
            {
                int total = (num[i] - 48) * multiplier + remainder;
                sum[i] = total % 10;

                if (total > 9)
                {
                    remainder = total.ToString()[0] - 48;
                }
                else
                {
                    remainder = 0;
                }
            }

            var result = string.Join("",sum.SkipWhile(x => x == 0));
            Console.WriteLine(result);
        }
    }
}

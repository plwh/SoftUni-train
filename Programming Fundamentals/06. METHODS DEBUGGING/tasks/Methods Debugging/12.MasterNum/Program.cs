using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12.MasterNum
{
    class Program
    {
        public static bool IsPalindrome(int num)
        {
            string value = num.ToString();
            int min = 0;
            int max = value.Length - 1;

            while (true)
            {
                if (min > max)
                {
                    return true;
                }
                char a = value[min];
                char b = value[max];
                if (char.ToLower(a) != char.ToLower(b))
                {
                    return false;
                }
                min++;
                max--;
            }
        }
        static bool SumOfDigits(int num)
        {
            int sumOfDigits = 0;

            while(num > 0)
            {
                sumOfDigits += num % 10;
                num /= 10;
            }

            if (sumOfDigits % 7 == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        static bool ContainsEvenDigit(int num)
        {
            while (num > 0)
            {
                if ((num % 10) % 2 == 0) return true;
                num /= 10;
            }
            return false;
        }

        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            for (int i = 1; i <= number; i++)
            {
                if (IsPalindrome(i) && SumOfDigits(i) && ContainsEvenDigit(i))
                {
                    Console.WriteLine(i);
                }
            }
        }
    }
}

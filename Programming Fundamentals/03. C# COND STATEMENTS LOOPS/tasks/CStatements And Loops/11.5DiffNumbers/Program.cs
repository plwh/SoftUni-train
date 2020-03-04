using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11._5DiffNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            short a = short.Parse(Console.ReadLine());
            short b = short.Parse(Console.ReadLine());

            StringBuilder result = new StringBuilder();

            for (int i = a; i <= b; i++)
            {
                for (int j = a; j <= b; j++)
                {
                    for (int k = a; k <= b; k++)
                    {
                        for (int l = a; l <= b; l++)
                        {
                            for (int m = a; m <= b; m++)
                            {
                                if (a <= i && i < j && j < k && k < l && l < m && m <= b)
                                {
                                    result.AppendLine(i + " " + j + " " + k + " " + l + " " + m);
                                }
                            }
                        }
                    }
                }
            }

            if (result.Length != 0)
            {
                Console.Write(result);
            }
            else
            {
                Console.WriteLine("No");
            }
        }
    }
}
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.LuckyNumbers
{
    class Program
    {
        static void Main()
        {
            int input = int.Parse(Console.ReadLine());

            for (int i = 1; i <= 9; i++)
            {
                for (int j = 1; j <= 9; j++)
                {
                    for (int k = 1; k <= 9; k++)
                    {
                        for (int l = 1; l <= 9; l++)
                        {
                            if (i + j == k + l)
                            {
                                if (input % (i + j) == 0)
                                {
                                    Console.Write(i + "" + j + "" + k + "" + l + " ");
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
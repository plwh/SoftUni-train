using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.MaximalSum
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(' ');

            int m = int.Parse(input[0]);
            int n = int.Parse(input[1]);

            int[,] matrix = new int[m, n];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                var currRow = Console.ReadLine().Split(' ').Select(a => int.Parse(a)).ToArray();
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = currRow[j];
                }
            }

            PrintMatrix(FindMaximalSumSquare(matrix));
        }
        
        private static int[,] FindMaximalSumSquare(int[,] matrix)
        {
            int[,] result = new int[3,3];

            int currSum = 0;
            int maxSum = 0;

            for (int i = 0; i < matrix.GetLength(0)-2; i++)
            {
               
                for (int j = 0; j < matrix.GetLength(1)-2; j++)
                {
                    currSum = matrix[i, j] + matrix[i, j + 1] + matrix[i, j + 2]
                            + matrix[i + 1, j] + matrix[i + 1, j + 1] + matrix[i + 1, j + 2]
                            + matrix[i + 2, j] + matrix[i + 2, j + 1] + matrix[i + 2, j + 2];

                    if (currSum > maxSum)
                    {
                        maxSum = currSum;
                        result = new int[3, 3] { { matrix[i, j] , matrix[i, j + 1] , matrix[i, j + 2] },
                                                 { matrix[i + 1, j] , matrix[i + 1, j + 1] , matrix[i + 1, j + 2]},
                                                 { matrix[i + 2, j] , matrix[i + 2, j + 1] , matrix[i + 2, j + 2]} };
                    }   
                }          
            }
            Console.WriteLine($"Sum = {maxSum}");   
            return result;
        }

        private static void PrintMatrix(int[,] v)
        {
            for (int i = 0; i < v.GetLength(0); i++)
            {
                for (int j = 0; j < v.GetLength(1); j++)
                {
                    Console.Write(v[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.TargetPractice
{
    class Program
    {
        static void Main(string[] args)
        {
            var dimensions = Console.ReadLine()
                .Split(' ')
                .Select(a => int.Parse(a))
                .ToArray();

            int rows = dimensions[0];
            int cols = dimensions[1];

            string snake = Console.ReadLine().Trim();

            char[,] matrix = new char[rows, cols];

            int count = 0;

            for (int rowIndex = rows - 1; rowIndex >= 0; rowIndex--)
            {
                for (int colIndex = cols - 1; colIndex >= 0; colIndex--)
                {
                    if (count == snake.Length) count = 0;

                    if (rowIndex % 2 == 0)
                    {
                        matrix[rowIndex, colIndex] = snake[count];
                    }
                    else
                    {
                        matrix[rowIndex, Math.Abs(cols - colIndex - 1)] = snake[count];
                    }
                    count++;
                }
            }

            var shotParameters = Console.ReadLine()
               .Split(' ')
               .Select(a => int.Parse(a))
               .ToArray();

            int impactRow = shotParameters[0];
            int impactColumn = shotParameters[1];
            int radius = shotParameters[2];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    double distance = Math.Sqrt(Math.Pow(row - impactRow, 2) + Math.Pow(col - impactColumn, 2));
                    if (distance <= radius)
                    {
                        matrix[row, col] = ' ';
                    }
                }
            }

            for (int c = 0; c < cols; c++)
            {
                for (int i = 0; i < rows; i++)
                {
                    for (int r = rows - 1; r > 0; r--)
                    {
                        if (matrix[r, c] == ' ')
                        {
                            matrix[r, c] = matrix[r - 1, c];
                            matrix[r - 1, c] = ' ';
                        }
                    }
                }
            }

            PrintMatrix(matrix);
        }

        private static void PrintMatrix(char[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}

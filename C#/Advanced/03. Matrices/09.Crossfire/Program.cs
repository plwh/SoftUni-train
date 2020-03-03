using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.Crossfire
{
    class Program
    {
        static void Main(string[] args)
        {
            var matrixDimensions = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int N = matrixDimensions[0];
            int M = matrixDimensions[1];
            var matrix = new int[N][];
            int count = 1;

            for (int i = 0; i < matrix.Length; i++)
            {
                matrix[i] = new int[M];
                for (int j = 0; j < M; j++)
                {
                    matrix[i][j] = count;
                    count++;
                }
            }

            var line = Console.ReadLine();

            while (line != "Nuke it from orbit")
            {
                var input = line.Split(' ').Select(int.Parse).ToArray();

                int startRow = input[0];
                int startCol = input[1];
                int radius = input[2];

                // remove up and down
                for (int i = startRow-radius; i <= startRow + radius; i++)
                {
                    if (IsValidIndex(i, startCol, matrix))
                    {
                        matrix[i][startCol] = -1;
                    }
                }

                // remove left and right
                for (int j = startCol - radius; j <= startCol + radius; j++)
                {
                    if (IsValidIndex(startRow, j, matrix))
                    {
                        matrix[startRow][j] = -1;
                    }
                }

                for (int rowIndex = 0; rowIndex < matrix.Length; rowIndex++)
                {
                    if (matrix[rowIndex].Any(c => c == -1))
                    {
                        matrix[rowIndex] = matrix[rowIndex].Where(n => n > 0).ToArray();
                    }

                    if (matrix[rowIndex].Length < 1)
                    {
                        matrix = matrix.Take(rowIndex).Concat(matrix.Skip(rowIndex + 1)).ToArray();
                        rowIndex--;
                    }
                }

                line = Console.ReadLine();
            }

            foreach (var row in matrix)
            {
                Console.WriteLine(string.Join(" ", row));
            }
        }

        private static bool IsValidIndex(int row, int col, int[][] matrix)
        {
            return row >= 0 && row < matrix.Length && col >= 0 && col < matrix[row].Length;
        }
    }
}

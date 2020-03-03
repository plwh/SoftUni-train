using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.KinghtGame
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var matrix = new char[n, n];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                var line = Console.ReadLine();
                for (int j = 0; j < matrix.GetLength(1); j++)
                { 
                    matrix[i, j] = line[j];
                }
            }

            int currentKnightsInDanger = 0;
            int maxKnightsInDanger = -1;
            int mostDangerousKnightRow = 0;
            int mostDangerousKnightCol = 0;
            int count = 0;

            while (true)
            {
                for (int rowIndex = 0; rowIndex < matrix.GetLength(0); rowIndex++)
                {
                    for (int colIndex = 0; colIndex < matrix.GetLength(1); colIndex++)
                    {
                        if (matrix[rowIndex, colIndex].Equals('K'))
                        {
                            // vertical up and left
                            if (IsValidCell(rowIndex - 2, colIndex - 1, matrix))
                            {
                                if (matrix[rowIndex - 2, colIndex - 1].Equals('K'))
                                {
                                    currentKnightsInDanger++;
                                }
                            }

                            // vertical up and right
                            if (IsValidCell(rowIndex - 2, colIndex + 1, matrix))
                            {
                                if (matrix[rowIndex - 2, colIndex + 1].Equals('K'))
                                {
                                    currentKnightsInDanger++;
                                }
                            }

                            // vertical down and left
                            if (IsValidCell(rowIndex + 2, colIndex -1,matrix))
                            {
                                if (matrix[rowIndex + 2, colIndex - 1].Equals('K'))
                                {
                                    currentKnightsInDanger++;
                                }
                            }

                            // vetical down and right
                            if (IsValidCell(rowIndex + 2, colIndex + 1, matrix))
                            {
                                if (matrix[rowIndex + 2, colIndex + 1].Equals('K'))
                                {
                                    currentKnightsInDanger++;
                                }
                            }

                            // horizontal up and left
                            if (IsValidCell(rowIndex - 1, colIndex - 2, matrix))
                            {
                                if (matrix[rowIndex - 1, colIndex - 2].Equals('K'))
                                {
                                    currentKnightsInDanger++;
                                }
                            }

                            // horizontal up and right
                            if (IsValidCell(rowIndex - 1, colIndex + 2, matrix))
                            {
                                if (matrix[rowIndex - 1, colIndex + 2].Equals('K'))
                                {
                                    currentKnightsInDanger++;
                                }
                            }

                            // horizontal down and left
                            if (IsValidCell(rowIndex + 1, colIndex - 2, matrix))
                            {
                                if (matrix[rowIndex + 1, colIndex - 2].Equals('K'))
                                {
                                    currentKnightsInDanger++;
                                }
                            }

                            // horizontal down and right
                            if (IsValidCell(rowIndex + 1, colIndex + 2, matrix))
                            {
                                if (matrix[rowIndex + 1, colIndex + 2].Equals('K'))
                                {
                                    currentKnightsInDanger++;
                                }
                            }
                        }

                        if (currentKnightsInDanger > maxKnightsInDanger)
                        {
                            maxKnightsInDanger = currentKnightsInDanger;
                            mostDangerousKnightRow = rowIndex;
                            mostDangerousKnightCol = colIndex;
                        }

                        currentKnightsInDanger = 0;
                    }
                }
                if (maxKnightsInDanger != 0)
                {
                    matrix[mostDangerousKnightRow, mostDangerousKnightCol] = '0';
                    count++;
                    maxKnightsInDanger = 0;
                }
                else
                {
                    Console.WriteLine(count);
                    return;
                }
            }
        }

        public static bool IsValidCell(int row, int col, char[,] matrix)
        {
            if (row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(1))
            {
                return true;
            }
            return false;
        }
    }
}

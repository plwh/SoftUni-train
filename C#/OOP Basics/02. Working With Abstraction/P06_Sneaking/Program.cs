using System;
using System.Collections.Generic;
using System.Linq;

namespace P06_Sneaking
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[][] matrix = new char[n][];
            List<int> samCoordinates = new List<int>();

            FillMatrix(matrix, samCoordinates);

            int samRow = samCoordinates[0];
            int samCol = samCoordinates[1];

            string directionSequence = Console.ReadLine();
            int index = 0;

            while (true)
            {
                MoveEnemies(matrix);

                CheckEnemies(matrix);
                
                char direction = directionSequence[index];

                MoveSam(matrix, ref samRow, ref samCol, direction);

                CheckNikoladze(matrix);
                
                index++;
            }
        }

        private static void CheckNikoladze(char[][] matrix)
        {
            for (var line = 0; line < matrix.Length; line++)
            {
                if (matrix[line].Contains('N') && matrix[line].Contains('S'))
                {
                    matrix[line][Array.IndexOf(matrix[line], 'N')] = 'X';
                    Console.WriteLine($"Nikoladze killed!");
                    PrintMatrix(matrix);
                }
            }
        }

        private static void CheckEnemies(char[][] matrix)
        {
            for (int line = 0; line < matrix.Length; line++)
            {
                if (matrix[line].Contains('b') && matrix[line].Contains('S'))
                {
                    if (Array.IndexOf(matrix[line], 'b') < Array.IndexOf(matrix[line], 'S'))
                    {
                        matrix[line][Array.IndexOf(matrix[line], 'S')] = 'X';
                        Console.WriteLine($"Sam died at {line}, {Array.IndexOf(matrix[line], 'X')}");
                        PrintMatrix(matrix);
                    }
                }
                else if (matrix[line].Contains('d') && matrix[line].Contains('S'))
                {
                    if (Array.IndexOf(matrix[line], 'd') > Array.IndexOf(matrix[line], 'S'))
                    {
                        matrix[line][Array.IndexOf(matrix[line], 'S')] = 'X';
                        Console.WriteLine($"Sam died at {line}, {Array.IndexOf(matrix[line], 'X')}");
                        PrintMatrix(matrix);
                    }
                }
            }
        }

        private static void MoveSam(char[][] matrix, ref int samRow, ref int samCol, char direction)
        {
            if (direction != 'W')
            {
                matrix[samRow][samCol] = '.';
                switch (direction)
                {
                    case 'U':
                        samRow--;
                        break;
                    case 'D':
                        samRow++;
                        break;
                    case 'L':
                        samCol--;
                        break;
                    case 'R':
                        samCol++;
                        break;
                }
                matrix[samRow][samCol] = 'S';
            }
        }

        private static void MoveEnemies(char[][] matrix)
        {
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    if (matrix[i][j] == 'b')
                    {
                        if (j == matrix[i].Length - 1)
                        {
                            matrix[i][j] = 'd';
                        }
                        else 
                        {
                            matrix[i][j] = '.';
                            matrix[i][++j] = 'b';
                        }
                    } 
                    else if (matrix[i][j] == 'd')
                    {
                        if (j == 0)
                        {
                            matrix[i][j] = 'b';
                        }
                        else
                        {
                            matrix[i][j] = '.';
                            matrix[i][j - 1] = 'd';
                        }
                    }
                }
            }
        }

        private static void FillMatrix(char[][] matrix, List<int> samCoordinates)
        {
            for (int i = 0; i < matrix.Length; i++)
            {
                string line = Console.ReadLine();

                matrix[i] = new char[line.Length];

                for (int j = 0; j < matrix[i].Length; j++)
                {
                    matrix[i][j] = line[j];

                    if (matrix[i][j] == 'S')
                    {
                        samCoordinates.Add(i);
                        samCoordinates.Add(j);
                    }
                }
            }
        }

        static void PrintMatrix(char[][] matrix)
        {
            foreach (var line in matrix)
            {
                Console.WriteLine(String.Join("", line));
            }
            Environment.Exit(0);
        }
    }
}

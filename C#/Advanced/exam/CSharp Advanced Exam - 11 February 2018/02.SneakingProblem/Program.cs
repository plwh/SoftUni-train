using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.SneakingProblem
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var matrix = new char[n][];
            var samRow = 0;
            var samCol = 0;
            var nikRow = 0;
            var nikCol = 0;

            for (int i = 0; i < n; i++)
            {
                var line = Console.ReadLine();

                matrix[i] = new char[line.Length];

                for (int j = 0; j < matrix[i].Length; j++)
                {
                    matrix[i][j] = line[j];

                    if (matrix[i][j] == 'S')
                    {
                        samRow = i;
                        samCol = j;
                    }
                    else if (matrix[i][j] == 'N')
                    {
                        nikRow = i;
                        nikCol = j;
                    }
                }
            }

            var commands = Console.ReadLine();
            var index = 0;

            while (true)
            {
                // enemy moving logic
                for (int i = 0; i < matrix.Length; i++)
                {
                    for (int j = 0; j < matrix[i].Length; j++)
                    {
                        // check for enemy
                        if (matrix[i][j] == 'b' || matrix[i][j] == 'd')
                        {
                            // right moving enemy
                            if (matrix[i][j] == 'b')
                            {
                                // if enemy is at the end reverse direction
                                if (j == matrix[i].Length - 1)
                                {
                                    matrix[i][j] = 'd';
                                }
                                else // move to right
                                {
                                    matrix[i][j] = '.';
                                    matrix[i][++j] = 'b';
                                }
                            } //left moving enemy
                            else if (matrix[i][j] == 'd')
                            {
                                // if enemy is at the beginning reverse direction
                                if (j == 0)
                                {
                                    matrix[i][j] = 'b';
                                } // move to left
                                else
                                {
                                    matrix[i][j] = '.';
                                    matrix[i][j - 1] = 'd';
                                }
                            }
                            break;
                        }
                    }
                }
                // check if enemy kills sam
                for (var line = 0; line < matrix.Length; line++)
                {
                    if (matrix[line].Contains('b') && matrix[line].Contains('S'))
                    {
                        if (Array.IndexOf(matrix[line], 'b') < Array.IndexOf(matrix[line], 'S'))
                        {
                            matrix[line][Array.IndexOf(matrix[line], 'S')] = 'X';
                            Console.WriteLine($"Sam died at {line}, {Array.IndexOf(matrix[line], 'X')}");
                            PrintMatrix(matrix);
                            return;
                        }
                    }
                    else if (matrix[line].Contains('d') && matrix[line].Contains('S'))
                    {
                        if (Array.IndexOf(matrix[line], 'd') > Array.IndexOf(matrix[line], 'S'))
                        {
                            matrix[line][Array.IndexOf(matrix[line], 'S')] = 'X';
                            Console.WriteLine($"Sam died at {line}, {Array.IndexOf(matrix[line], 'X')}");
                            PrintMatrix(matrix);
                            return;
                        }
                    }
                }

                // sam moving logic
                var direction = commands[index];
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

                // check if sam kills nik
                if (samRow == nikRow)
                {
                    matrix[nikRow][nikCol] = 'X';
                    Console.WriteLine("Nikoladze killed!");
                    PrintMatrix(matrix);
                    return;
                }
                index++;
            }
        }

        static void PrintMatrix(char[][] matrix)
        {
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    Console.Write(matrix[i][j]);
                }
                Console.WriteLine();
            }
        }
    }
}
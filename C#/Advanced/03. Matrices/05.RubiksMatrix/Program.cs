using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.RubiksMatrix
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

            int count = 1;

            int[,] matrix = new int[rows, cols];

            for (int rowIndex = 0; rowIndex < rows; rowIndex++)
            {
                for (int colIndex = 0; colIndex < cols; colIndex++)
                {
                    matrix[rowIndex, colIndex] = count;
                    count++;
                }
            }

            int numOfCommands = int.Parse(Console.ReadLine());

            for (int i = 0; i < numOfCommands; i++)
            {
                var commands = Console.ReadLine()
                .Split(' ');

                int rcIndex = int.Parse(commands[0]);
                string direction = commands[1];
                int moves = int.Parse(commands[2]);

                switch (direction)
                {
                    case "up":
                        MoveCol(matrix, rcIndex, moves);    
                        break;
                    case "down":
                        MoveCol(matrix, rcIndex, rows - moves % rows);
                        break;
                    case "left":
                        MoveRow(matrix, rcIndex, moves);
                        break;
                    case "right":
                        MoveRow(matrix, rcIndex, cols - moves % cols);
                        break;
                }
            }

            var element = 1;
            for (int rowIndex = 0; rowIndex < matrix.GetLength(0); rowIndex++)
            {
                for (int colIndex = 0; colIndex < matrix.GetLength(1); colIndex++)
                {
                    if (matrix[rowIndex, colIndex] == element)
                    {
                        Console.WriteLine("No swap required");
                    }
                    else
                    {
                        for (int r = 0; r < matrix.GetLength(0); r++)
                        {
                            for (int c = 0; c < matrix.GetLength(1); c++)
                            {
                                if (matrix[r, c] == element)
                                {
                                    var currentElement = matrix[rowIndex, colIndex];
                                    matrix[rowIndex, colIndex] = element;
                                    matrix[r, c] = currentElement;
                                    Console.WriteLine($"Swap ({rowIndex}, {colIndex}) with ({r}, {c})");
                                    break;
                                }
                            }
                        }
                    }
                    element++;
                }
            }
        }

        private static void MoveCol(int[,] matrix, int rcIndex, int moves)
        {
            var temp = new int[matrix.GetLength(0)];
            for (int rowIndex = 0; rowIndex < matrix.GetLength(0); rowIndex++)
            {
                temp[rowIndex] = matrix[(rowIndex + moves) % matrix.GetLength(0),rcIndex];
            }

            for (int rowIndex = 0; rowIndex < matrix.GetLength(0); rowIndex++)
            {
                matrix[rowIndex, rcIndex] = temp[rowIndex];
            }
        }

        private static void MoveRow(int[,] matrix, int rcIndex, int moves)
        {
            var temp = new int[matrix.GetLength(1)];
            for (int colIndex = 0; colIndex < matrix.GetLength(1); colIndex++)
            {
                temp[colIndex] = matrix[rcIndex, (colIndex + moves) % matrix.GetLength(1)];
            }

            for (int colIndex = 0; colIndex < matrix.GetLength(1); colIndex++)
            {
                matrix[rcIndex,colIndex] = temp[colIndex];
            }
        }
    }
}

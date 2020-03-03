using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.RadioactiveMutantVampireBunnies
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            int N = input[0];
            int M = input[1];
            var lair = new char[N, M];
            int startRow = 0;
            int startCol = 0;
            bool hasWon = false;
            bool isDead = false;

            for (int i = 0; i < lair.GetLength(0); i++)
            {
                var inputLine = Console.ReadLine();
                for (int j = 0; j < lair.GetLength(1); j++)
                {
                    if (inputLine[j] == 'P')
                    {
                        startRow = i;
                        startCol = j;
                    }

                    lair[i, j] = inputLine[j];
                }
            }

            var moves = Console.ReadLine();
            string playerPosition = "";

            foreach (char i in moves)
            {
                playerPosition = startRow + " " + startCol;
                lair[startRow, startCol] = '.';

                switch (i)
                {
                    case 'U':
                        startRow--;
                        break;
                    case 'D':
                        startRow++;
                        break;
                    case 'L':
                        startCol--;
                        break;
                    case 'R':
                        startCol++;
                        break;
                }

                lair = MultiplyBunnies(lair);

                if (IsPositionOutOfRange(lair,i, startRow,startCol))
                {
                    hasWon = true;
                    break;
                }
                else if (lair[startRow, startCol] == 'B')
                {
                    playerPosition = startRow + " " + startCol;
                    isDead = true;
                    break;
                }
                else
                {
                    lair[startRow, startCol] = 'P';
                }
            }

            PrintMatrix(lair);

            if (hasWon)
            {
                Console.WriteLine($"won: {playerPosition}");
            }
            else if (isDead)
            {
                Console.WriteLine($"dead: {playerPosition}");
            }
        }

        private static bool IsPositionOutOfRange(char[,] lair, char direction, int startRow, int startCol)
        {
            bool result = false;

            switch (direction)
            {
                case 'U':
                    if (startRow < 0)
                        result = true;
                    break;
                case 'D':
                    if (startRow == lair.GetLength(0))
                        result = true;
                    break;
                case 'L':
                    if (startCol < 0)
                        result = true;
                    break;
                case 'R':
                    if (startCol == lair.GetLength(1))
                        result = true;
                    break;
            }
        
            return result;
        }

        private static char[,] MultiplyBunnies(char[,] lair)
        {
            // find current bunnies coordinates
            var bunniesCoordinates = FindBunniesCoordinates(lair);

            foreach (string coordinate in bunniesCoordinates)
            {
                var coordinateData = coordinate.Split(' ').Select(int.Parse).ToArray();
                int bunnyRow = coordinateData[0];
                int bunnyCol = coordinateData[1];

                // check down
                if (bunnyRow + 1 < lair.GetLength(0) && lair[bunnyRow + 1, bunnyCol] == '.')
                {
                    lair[bunnyRow + 1, bunnyCol] = 'B';
                }

                // check up
                if (bunnyRow - 1 >= 0 && lair[bunnyRow - 1, bunnyCol] == '.')
                {
                    lair[bunnyRow - 1, bunnyCol] = 'B';
                }

                // check left
                if (bunnyCol - 1 >= 0 && lair[bunnyRow, bunnyCol - 1] == '.')
                {
                    lair[bunnyRow, bunnyCol - 1] = 'B';
                }

                // check right
                if (bunnyCol + 1 < lair.GetLength(1) && lair[bunnyRow, bunnyCol + 1] == '.')
                {
                    lair[bunnyRow, bunnyCol + 1] = 'B';
                }
            }

            return lair;
        }

        private static void PrintMatrix(char[,] lair)
        {
            for (int i = 0; i < lair.GetLength(0); i++)
            {
                for (int j = 0; j < lair.GetLength(1); j++)
                {
                    Console.Write(lair[i, j]);
                }
                Console.WriteLine();
            }
        }

        private static List<string> FindBunniesCoordinates(char[,] lair)
        {
            var result = new List<string>();
            for (int i = 0; i < lair.GetLength(0); i++)
            {
                for (int j = 0; j < lair.GetLength(1); j++)
                {
                    if (lair[i, j] == 'B')
                    {
                        result.Add(i + " " + j);
                    }
                }
            }
            return result;
        }
    }
}


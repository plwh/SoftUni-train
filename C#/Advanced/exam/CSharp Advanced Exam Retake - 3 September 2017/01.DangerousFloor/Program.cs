using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.DangerousFloor
{
    class Program
    {
        static string[,] board = new string[8, 8];

        static void Main(string[] args)
        {

            for (int i = 0; i < board.GetLength(0); i++)
            {
                var inputLine = Console.ReadLine().Split(',');
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    board[i, j] = inputLine[j];
                }
            }

            var line = Console.ReadLine();
            while (line != "END")
            {
                var input = line.Split('-');

                var pieceType = input[0].Substring(0, 1);

                var currPositionRow = int.Parse(input[0].Substring(1, 1));
                var currPositionCol = int.Parse(input[0].Substring(2, 1));

                var finalPositionRow = int.Parse(input[1].Substring(0, 1));
                var finalPositionCol = int.Parse(input[1].Substring(1, 1));

                
                if (board[currPositionRow, currPositionCol] != pieceType)
                {
                    Console.WriteLine("There is no such a piece!");
                } 
                else if (IsValidMove(pieceType, currPositionRow, currPositionCol, finalPositionRow, finalPositionCol))
                {
                    if (!IsMoveInside(finalPositionRow, finalPositionCol))
                    {
                        Console.WriteLine("Move go out of board!");
                    }
                    else
                    {
                        board[currPositionRow, currPositionCol] = "x";
                        board[finalPositionRow, finalPositionCol] = pieceType;
                    }
                } 
                else
                {
                    Console.WriteLine("Invalid move!");
                }
                line = Console.ReadLine();
            }
        }

        private static bool IsMoveInside(int finalPositionRow, int finalPositionCol)
        {
            if (finalPositionRow >= 0 && finalPositionRow < board.GetLength(0) && finalPositionCol >= 0 && finalPositionCol < board.GetLength(1))
                return true;

            return false;
        }

        private static bool IsValidMove(string pieceType, int currPositionRow, int currPositionCol, int finalPositionRow, int finalPositionCol)
        {
            bool result = false;
            switch (pieceType)
            {
                case "K":
                    if ((finalPositionRow == currPositionRow - 1 && finalPositionCol == currPositionCol) // check up
                        || (finalPositionRow == currPositionRow + 1 && finalPositionCol == currPositionCol) // check down
                        || (finalPositionRow == currPositionRow && finalPositionCol == currPositionCol - 1) // check left
                        || (finalPositionRow == currPositionRow && finalPositionCol == currPositionCol + 1) // check right
                        || (finalPositionRow == currPositionRow - 1 && finalPositionCol == currPositionCol - 1) // check up left diagonal
                        || (finalPositionRow == currPositionRow - 1 && finalPositionCol == currPositionCol + 1) // check up right diagonal
                        || (finalPositionRow == currPositionRow + 1 && finalPositionCol == currPositionCol - 1) // check down left diagonal
                        || (finalPositionRow == currPositionRow + 1 && finalPositionCol == currPositionCol + 1) // check down right diagonal
                        )
                        result = true;
                    break;
                case "R":
                    if ((finalPositionCol == currPositionCol) // check up down
                        || (finalPositionRow == currPositionRow) // check left right
                     )
                        result = true;
                    break;
                case "B":
                    if(Math.Abs(currPositionRow - finalPositionRow) == Math.Abs(currPositionCol - finalPositionCol))
                        result = true;
                    break;
                case "Q":
                    if((finalPositionCol == currPositionCol) || (finalPositionRow == currPositionRow)
                        || Math.Abs(currPositionRow - finalPositionRow) == Math.Abs(currPositionCol - finalPositionCol))
                    result = true;
                    break;
                case "P":
                    if (finalPositionRow == currPositionRow - 1)
                        result = true;
                    break;
            }
            return result;
        }
    }
}

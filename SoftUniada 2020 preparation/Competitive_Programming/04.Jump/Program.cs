using System;
using System.Linq;

namespace ConsoleApp4
{
    class Program
    {
        static void Main(string[] args)
        {
            var indexes = Console.ReadLine().Split(" ").Select(Int32.Parse).ToList();

            int playerCol = 0;
            int playerRow = 0;

            var matrix = new string[indexes[0], indexes[1]];

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                var elements = Console.ReadLine().ToCharArray();

                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (elements[j] == 'S')
                    {
                        playerCol = j;
                        playerRow = i;
                    }

                    matrix[i, j] = elements[j].ToString();
                }
            }

            bool win = false;
            int jumps = 0;
            int attempts = int.Parse(Console.ReadLine());

            for (int k = 0; k < attempts; k++)
            {
                if (playerRow - 1 <= 0)
                {
                    win = true;
                }

                var data = Console.ReadLine().Split(" ").Select(Int32.Parse).ToList();

                int rowToMove = data[0];
                int timesToShift = data[1];

                // extract row

                string[] shiftedElements = new string[matrix.GetLength(1)];
                for (int index = 0, row = rowToMove; index < matrix.GetLength(1); index++)
                {
                    shiftedElements[index] = matrix[row, index];
                }

                // shift row
                for(int i = 0; i< timesToShift; i++)
                RotateArrayRight(shiftedElements, 1);

                // get row back into matrix

                for (int row = rowToMove, col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = shiftedElements[col];
                }

                // player tries to jump up


                if (matrix[playerRow - 1, playerCol] == "-")
                {
                    // succesful jump
                    if (k == 0 || jumps == 0)
                    {
                        matrix[playerRow, playerCol] = "0";
                    }
                    else
                    {
                        matrix[playerRow, playerCol] = "-";
                    }

                    playerRow--;
                    matrix[playerRow, playerCol] = "S";
                    jumps++;
                }
            }

            if (win)
            {
                Console.WriteLine("Win");
            }
            else
            {
                Console.WriteLine("Lose");
            }

            Console.WriteLine("Total Jumps: " + jumps);
            PrintMatrix(matrix);
        }

        private static void RotateArrayRight(string[] array, int count)
        {
            if (count < 0)
                throw new ArgumentOutOfRangeException("count");
            if (count == 0)
                return;

            // If (count == array.Length) there is nothing to do.
            // So we need the remainder (count % array.Length):
            count %= array.Length;

            // Create a temp array to store the tail of the source array
            string[] tmp = new string[count];

            // Copy tail of the source array to the temp array
            Array.Copy(array, array.Length - count, tmp, 0, count);

            // Shift elements right in the source array
            Array.Copy(array, 0, array, count, array.Length - count);

            // Copy saved tail to the head of the source array
            Array.Copy(tmp, array, count);
        }
        public static void PrintMatrix(string[,] arr)
        {
            int rowLength = arr.GetLength(0);
            int colLength = arr.GetLength(1);

            for (int i = 0; i < rowLength; i++)
            {
                for (int j = 0; j < colLength; j++)
                {
                    Console.Write(string.Format("{0}", arr[i, j]));
                }
                Console.WriteLine();
            }
        }
    }
}

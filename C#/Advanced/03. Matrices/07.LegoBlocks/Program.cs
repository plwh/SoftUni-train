using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.LegoBlocks
{
    class Program
    {
        static void Main(string[] args)
        {
            int numberOfRows = int.Parse(Console.ReadLine());
            int[][] firstArr = new int[numberOfRows][];
            int[][] secondArr = new int[numberOfRows][];
            int cells = 0;
            bool fitsPerfectly = true;

            for (int i = 0; i < numberOfRows * 2; i++)
            {
                var inputLine = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(a => int.Parse(a)).ToArray();
                if (i < numberOfRows)
                {
                    firstArr[i] = new int[inputLine.Length];
                    for (int j = 0; j < firstArr[i].Length; j++)
                    {
                        firstArr[i][j] = inputLine[j];
                        cells++;
                    }
                }
                else
                {
                    secondArr[i - numberOfRows] = new int[inputLine.Length];
                    for (int j = secondArr[i - numberOfRows].Length - 1, k = 0; j >= 0; j--, k++)
                    {
                        secondArr[i - numberOfRows][j] = inputLine[k];
                        cells++;
                    }
                }
            }

            int[][] resultArr = new int[numberOfRows][];

            for (int i = 0; i < numberOfRows; i++)
            {
                resultArr[i] = new int[firstArr[i].Length + secondArr[i].Length];

                if (i > 0)
                {
                    if (resultArr[i].Length != resultArr[i - 1].Length)
                    {
                        fitsPerfectly = false;
                        break;
                    }
                }

                for (int j = 0; j < resultArr[i].Length; j++)
                {
                    if (j > firstArr[i].Length - 1)
                    {
                        resultArr[i][j] = secondArr[i][j - firstArr[i].Length];
                    }
                    else
                    {
                        resultArr[i][j] = firstArr[i][j];
                    }
                }  
            }

            if (fitsPerfectly)
            {
                PrintArray(resultArr);
            }
            else
            {
                Console.WriteLine($"The total number of cells is: {cells}");
            }

        }

        private static void PrintArray(int[][] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine("[" + string.Join(", ", array[i].Select(x => x.ToString()).ToArray()) + "]");
            }
        }
    }
}

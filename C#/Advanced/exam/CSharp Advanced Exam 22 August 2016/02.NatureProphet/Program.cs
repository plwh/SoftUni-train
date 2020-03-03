using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.NatureProphet
{
    class Program
    {
        static void Main(string[] args)
        {
            var dimensions = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            var garden = new int[dimensions[0], dimensions[1]];
            var points = new List<string>();
            string inputLine;

            while ((inputLine = Console.ReadLine()) != "Bloom Bloom Plow")
            {
                points.Add(inputLine);
            }

            for (int rowIndex = 0; rowIndex < garden.GetLength(0); rowIndex++)
            {
                for (int colIndex = 0; colIndex < garden.GetLength(1); colIndex++)
                {
                    var currentPlace = rowIndex + " " + colIndex;
                    if (points.Contains(currentPlace))
                    {
                        for (int row = 0; row < garden.GetLength(0); row++)
                        {
                            garden[row, colIndex]++;
                        }

                        for (int col = 0; col < garden.GetLength(1); col++)
                        {
                            if (col != colIndex)
                            {
                                garden[rowIndex, col]++;
                            }
                        }
                    }
                }
            }

            for (int row = 0; row < garden.GetLength(0); row++)
            {
                for (int col = 0; col < garden.GetLength(1); col++)
                {
                    Console.Write(garden[row, col] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}

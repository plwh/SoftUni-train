using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.MaxSeqEqEl
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = File.ReadAllLines("../../input.txt");
            foreach (string line in input)
            {
                File.AppendAllText("../../output.txt", $"Test input: {line} {Environment.NewLine}");
                File.AppendAllText("../../output.txt", $"Test output:{Environment.NewLine}");

                int[] arr = line.Split(' ').Select(int.Parse).ToArray();

                int currLength = 0;
                int bestLength = 0;
                int bestElement = 0;
                string textToAppend = "";

                for (int i = 0; i < arr.Length - 1; i++)
                {
                    if (arr[i] == arr[i + 1])
                    {
                        currLength++;
                    }
                    else
                    {
                        currLength = 0;
                    }

                    if (currLength > bestLength)
                    {
                        bestLength = currLength;
                        bestElement = arr[i];
                    }
                }

                for (int j = 0; j <= bestLength; j++)
                {            
                        textToAppend += bestElement + " ";          
                }

                File.AppendAllText("../../output.txt", $"{textToAppend.TrimEnd()}{Environment.NewLine}");
            }
        }
    }
}

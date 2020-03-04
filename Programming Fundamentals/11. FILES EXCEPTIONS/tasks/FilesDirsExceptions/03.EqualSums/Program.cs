using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.EqualSums
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] input = File.ReadAllLines("../../input.txt");
            List<string> results = new List<string>();

            foreach (string line in input)
            {
                results.Add($"Test input: {line}");
                results.Add("Test output:");
                int[] numbers = line.Split(' ').Select(int.Parse).ToArray();

                int leftSum = 0;
                int rightSum = 0;
                int index = -1;

                for (int i = 0; i < numbers.Length; i++)
                {

                    //calc left sum
                    for (int j = i; j > 0; j--)
                    {
                        leftSum += numbers[j - 1];
                    }

                    //calc right sum
                    for (int k = i; k < numbers.Length - 1; k++)
                    {
                        rightSum += numbers[k + 1];
                    }


                    //check if sums are equal
                    if (leftSum == rightSum) index = i;

                    // change sums value to the default one
                    leftSum = 0;
                    rightSum = 0;
                }

                results.Add((index != -1) ? index.ToString() : "no");
            }
            File.WriteAllLines("../../output.txt", results.ToArray());
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.IndexOfLetters
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
                foreach (char letter in line)
                {
                    int indexOfLetter = (int)letter - 97;
                    string resultToAdd = $"{letter} -> {indexOfLetter}";
                    results.Add(resultToAdd);
                }
            }

            File.WriteAllLines("../../output.txt", results.ToArray());
        }
    }
}

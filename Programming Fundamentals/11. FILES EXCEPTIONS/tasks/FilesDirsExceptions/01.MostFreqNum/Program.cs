using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.MostFreqNum
{
    class Program
    {
        static void Main(string[] args)
        {
            string [] input = File.ReadAllLines("../../input.txt");
            List<string> results = new List<string>();

            foreach (string line in input)
            {
                int [] numbers = line.Split(' ').Select(int.Parse).ToArray();

                int mostFrequentNumber = numbers.GroupBy(v => v)
                                        .OrderByDescending(g => g.Count())
                                        .First()
                                        .Key;

                results.Add(mostFrequentNumber.ToString());
            }

            File.WriteAllLines("../../output.txt", results.ToArray());
        }
    }
}

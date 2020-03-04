using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.AMinerTask
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, long> resources = new Dictionary<string, long>();

            string[] input = File.ReadAllLines("../../input.txt");
            int lineCount = 0;

            foreach (string line in input)
            {
                if (line == "stop") break;

                if (lineCount % 2 == 0)
                {
                    string resource = line;
                    long amount = long.Parse(input[lineCount+1]);

                    if (resources.ContainsKey(resource))
                    {
                        resources[resource] += amount;
                    }
                    else
                    {
                        resources.Add(resource, amount);
                    }
                }
                lineCount++;          
            }
            foreach (var pair in resources)
            {
                File.AppendAllText("../../output.txt",$"{pair.Key} -> {pair.Value}{Environment.NewLine}");
            }
        }
    }
}

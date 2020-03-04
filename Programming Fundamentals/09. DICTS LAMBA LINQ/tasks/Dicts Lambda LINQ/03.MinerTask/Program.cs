using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.MinerTask
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, long> resources = new Dictionary<string, long>();
            
            
            while (true)
            {
                string currLine = Console.ReadLine();

                if (currLine == "stop") break;

                string resource = currLine;
                long amount = long.Parse(Console.ReadLine());

                if (resources.ContainsKey(resource))
                {
                    resources[resource] += amount;
                }
                else
                {
                    resources.Add(resource, amount);
                }
            }

            foreach (var pair in resources)
            {
                Console.WriteLine($"{pair.Key} -> {pair.Value}");
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.AMinerTask
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> resources = new Dictionary<string, int>();

            string line = Console.ReadLine();

            while (line != "stop")
            {
                string resource = line;
                int quantity = int.Parse(Console.ReadLine());

                if (resources.ContainsKey(resource))
                {
                    resources[resource] += quantity;
                }
                else
                {
                    resources[resource] = quantity;
                }

                line = Console.ReadLine();
            }

            foreach (var pairs in resources)
            {
                Console.WriteLine($"{pairs.Key} -> {pairs.Value}");
            }
        }
    }
}

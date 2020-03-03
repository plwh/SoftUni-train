using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10.PopulationCounter
{
    class Program
    {
        static void Main()
        {
            string line = Console.ReadLine();
            Dictionary<string, Dictionary<string, long>> countriesData = new Dictionary<string, Dictionary<string, long>>();

            while (line != "report")
            {
                var input = line.Split('|');

                string town = input[0];
                string country = input[1];
                long popCount = long.Parse(input[2]);

                if (!countriesData.ContainsKey(country))
                {
                    countriesData.Add(country, new Dictionary<string, long> { { town, popCount } });
                }
                else
                {
                    countriesData[country].Add(town, popCount);
                }

                line = Console.ReadLine();
            }
            


            foreach (var country in countriesData.OrderByDescending(x => x.Value.Values.Sum()))
            {
                long totalPopulation = country.Value.Values.Sum();
                
                Console.WriteLine($"{country.Key} (total population: {totalPopulation})");
                
                Console.Write($"=>{string.Join("=>", country.Value.OrderByDescending(x => x.Value).Select(x => $"{x.Key}:{x.Value}\r\n"))}");
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _13.SrabskoUnleashed
{
    class Program
    {
        static void Main(string[] args)
        {
            const string pattern = @"(.*?) @(.*?) (\d+) (\d+)";

            var venuesInfo = new Dictionary<string, Dictionary<string, long>>();

            string input = Console.ReadLine();

            while (input != "End")
            {
                if (!Regex.IsMatch(input, pattern))
                {
                    input = Console.ReadLine();
                    continue;
                }

                var match = Regex.Match(input, pattern);
                string venueName = match.Groups[2].Value;
                string singerName = match.Groups[1].Value;
                int ticketPrice = int.Parse(match.Groups[3].Value);
                int ticketCount = int.Parse(match.Groups[4].Value);
                long overallMoney = (long)ticketCount * ticketPrice;

                if (!venuesInfo.ContainsKey(venueName))
                {
                    venuesInfo.Add(venueName, new Dictionary<string, long>());
                }

                if (!venuesInfo[venueName].ContainsKey(singerName))
                {
                    venuesInfo[venueName].Add(singerName, 0);
                }

                venuesInfo[venueName][singerName] += overallMoney;

                input = Console.ReadLine();
            }

            foreach (var venues in venuesInfo)
            {
                Console.WriteLine($"{venues.Key}");

                foreach (var singers in venues.Value.OrderByDescending(x => x.Value))
                {
                    Console.WriteLine($"# {singers.Key} -> {singers.Value}");
                }
            }
        }
    }
}

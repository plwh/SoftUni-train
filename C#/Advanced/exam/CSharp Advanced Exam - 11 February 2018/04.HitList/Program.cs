using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.HitList
{
    class Program
    {
        static void Main(string[] args)
        {
            var peopleData = new Dictionary<string,Dictionary<string,string>>();
            var targetInfoIndex = int.Parse(Console.ReadLine());
            var inputLine = "";

            while ((inputLine = Console.ReadLine())!= "end transmissions")
            {
                var personData = inputLine.Split(new[] { '=', ';' }, StringSplitOptions.RemoveEmptyEntries);

                var name = personData[0];

                for (int i = 1; i < personData.Length; i++)
                {
                    var infoValue = personData[i].Split(':');
                    var info = infoValue[0];
                    var value = infoValue[1];

                    if (!peopleData.ContainsKey(name))
                    {
                        peopleData[name] = new Dictionary<string, string>();
                    }

                    if (!peopleData[name].ContainsKey(info))
                    {
                        peopleData[name].Add(info, value);
                    }
                    else
                    {
                        peopleData[name][info] = value;
                    }
                }
            }
            
            var targetName = Console.ReadLine().Split()[1];

            Console.WriteLine($"Info on {targetName}:");
            foreach (var pair in peopleData[targetName].OrderBy(a => a.Key))
            {
                Console.WriteLine($"---{pair.Key}: {pair.Value}");
            }

            var keysLengthSum = peopleData[targetName].Select(a => a.Key.Length).Sum();
            var valuesLengthSum = peopleData[targetName].Select(a => a.Value.Length).Sum();
            var infoIndex = keysLengthSum + valuesLengthSum;

            Console.WriteLine($"Info index: {infoIndex} ");
            Console.WriteLine((infoIndex >= targetInfoIndex) ? "Proceed":$"Need {targetInfoIndex - infoIndex} more info.");
        }
    }
}

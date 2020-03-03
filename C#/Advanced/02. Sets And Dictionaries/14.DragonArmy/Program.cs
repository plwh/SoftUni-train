using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14.DragonArmy
{
    class Program
    {
        static void Main(string[] args)
        {
            var allDragons = new Dictionary<string, SortedDictionary<string, int[]>>();
            var numberOfDragons = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfDragons; i++)
            {
                var dragon = Console.ReadLine()
                    .Split(new[] {' '},StringSplitOptions.RemoveEmptyEntries);

                string dragonType = dragon[0];
                string dragonName = dragon[1];
                int dragonDamage = dragon[2].Equals("null") ? 45 : int.Parse(dragon[2]);
                int dragonHealth = dragon[3].Equals("null") ? 250 : int.Parse(dragon[3]);
                int dragonArmor = dragon[4].Equals("null") ? 10 : int.Parse(dragon[4]);

                if (!allDragons.ContainsKey(dragonType))
                {
                    allDragons.Add(dragonType, new SortedDictionary<string, int[]>());
                }

                if (!allDragons[dragonType].ContainsKey(dragonName))
                {
                    allDragons[dragonType].Add(dragonName, new[] { dragonDamage, dragonHealth, dragonArmor });
                }
            }

            PrintDragonsInfo(allDragons);
        }

        private static void PrintDragonsInfo(Dictionary<string, SortedDictionary<string, int[]>> allDragons)
        {
            foreach (var type in allDragons)
            {
                var dragonTypeInfo = new StringBuilder();
                double avgDmg = 0, avgHp = 0, avgArmor = 0;
                foreach (var dragon in type.Value)
                {
                    dragonTypeInfo.AppendLine($"-{dragon.Key} -> damage: {dragon.Value[0]} health: {dragon.Value[1]} armor: {dragon.Value[2]}");

                    avgDmg += dragon.Value[0];
                    avgHp += dragon.Value[1];
                    avgArmor += dragon.Value[2];
                }


                avgDmg /= type.Value.Count;
                avgHp /= type.Value.Count;
                avgArmor /= type.Value.Count;

                Console.WriteLine($"{type.Key}::({avgDmg:F2}/{avgHp:F2}/{avgArmor:F2})");
                Console.Write(dragonTypeInfo.ToString());
            }
        }
    }
}

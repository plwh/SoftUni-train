using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12.LegendaryFarming
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> materials = new Dictionary<string, int>();
            string keyMaterials = "shards fragments motes";

            while (true)
            {
                var input = Console.ReadLine().Split(' ');
                string material = "";

                for (int i = 0; i < input.Length; i += 2)
                {
                    int quantity = int.Parse(input[i]);
                    material = input[i + 1].ToLower();

                    if (!materials.ContainsKey(material))
                    {
                        materials.Add(material, quantity);
                    }
                    else
                    {
                        materials[material] += quantity;
                    }

                    if (IsLegendaryItemObtained(materials[material], keyMaterials.Contains(material)))
                    {
                        materials[material] -= 250;

                        PrintResult(materials, material, keyMaterials);
                        return;
                    }
                }
            }
        }

        private static bool IsLegendaryItemObtained(int materialQuantity, bool isKeyMaterial)
        {
            if (materialQuantity >= 250 && isKeyMaterial)
                return true;

            return false;
        }

        private static void PrintResult(Dictionary<string, int> materials, string winningMaterial, string keyMaterials)
        {
            // print legendary item
            switch (winningMaterial)
            {
                case "shards":
                    Console.WriteLine("Shadowmourne obtained!");
                    break;
                case "fragments":
                    Console.WriteLine("Valanyr obtained!");
                    break;
                case "motes":
                    Console.WriteLine("Dragonwrath obtained!");
                    break;
            }
            // print key materials
            foreach (var items in materials.OrderByDescending(x => x.Value).ThenBy(x => x.Key).Where(y => keyMaterials.Contains(y.Key)))
            {
                Console.WriteLine($"{items.Key}: {items.Value}");
            }
            // print rest of materials
            foreach (var items in materials.OrderBy(x => x.Key).Where(y => !keyMaterials.Contains(y.Key)))
            {
                Console.WriteLine($"{items.Key}: {items.Value}");
            }
        }
    }
}

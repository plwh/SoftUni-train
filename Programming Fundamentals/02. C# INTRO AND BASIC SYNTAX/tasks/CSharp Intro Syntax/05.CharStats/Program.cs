using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.CharStats
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            int currHp = int.Parse(Console.ReadLine());
            int maxHp = int.Parse(Console.ReadLine());
            int currEnergy = int.Parse(Console.ReadLine());
            int maxEnergy = int.Parse(Console.ReadLine());

            Console.WriteLine($"Name: {name}");
            Console.WriteLine("Health: |{0}{1}|", new string('|', currHp),new string('.', maxHp - currHp));
            Console.WriteLine("Energy: |{0}{1}|", new string('|', currEnergy), new string('.', maxEnergy - currEnergy));
        }
    }
}

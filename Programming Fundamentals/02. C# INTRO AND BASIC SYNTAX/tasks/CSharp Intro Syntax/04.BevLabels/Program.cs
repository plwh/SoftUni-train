using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.BevLabels
{
    class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            int volume = int.Parse(Console.ReadLine());
            int energy100ml = int.Parse(Console.ReadLine());
            int sugar100ml = int.Parse(Console.ReadLine());

            double totalEnergy = volume / 100.0 * energy100ml;
            double totalSugar = volume / 100.0 * sugar100ml;

            Console.WriteLine("{0}ml {1}:{2}{3}kcal, {4}g sugars", volume, name,Environment.NewLine, totalEnergy,totalSugar);
        }
    }
}

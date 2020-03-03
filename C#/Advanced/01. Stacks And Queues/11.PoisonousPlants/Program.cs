using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11.PoisonousPlants
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int countOfDays = 0;
            var plants = Console.ReadLine().Split(' ').Select(a => int.Parse(a)).ToList();
            int removedCount = 0;

            while (true)
            {
                removedCount = 0;

                for (int i = plants.Count - 1; i > 0; i--)
                {       
                    if(plants[i] > plants[i-1])
                    {
                        plants.RemoveAt(i);
                        removedCount++;
                    }
                }

                if (removedCount == 0)
                {
                    break;
                }

                countOfDays++;
            }

            Console.WriteLine(countOfDays);
        }
    }
}

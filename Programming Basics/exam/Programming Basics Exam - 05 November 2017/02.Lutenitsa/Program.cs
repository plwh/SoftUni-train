using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Lutenitsa
{
    class Program
    {
        static void Main(string[] args)
        {
            float tomatoes = float.Parse(Console.ReadLine());
            int X = int.Parse(Console.ReadLine());
            int Y = int.Parse(Console.ReadLine());

            float totalProduct = tomatoes / 5;
            float jars = totalProduct / (float)0.535;
            float boxes = jars / Y;

            Console.WriteLine("Total lutenica: {0} kilograms.", Math.Floor(totalProduct));

            if (boxes > X)
            {
                Console.WriteLine("{0} boxes left.", Math.Floor(boxes - X));
                Console.WriteLine("{0} jars left.", Math.Floor(jars - (X * Y)));
            }
            else
            {
                Console.WriteLine("{0} more boxes needed.", Math.Floor(X - boxes));
                Console.WriteLine("{0} more jars needed.", Math.Floor((X * Y) - jars));
            }
        }
    }
}

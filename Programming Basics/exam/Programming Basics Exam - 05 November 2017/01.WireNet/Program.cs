using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.WireNet
{
    class Program
    {
        static void Main(string[] args)
        {
            byte length = byte.Parse(Console.ReadLine());
            byte width = byte.Parse(Console.ReadLine());
            double height = double.Parse(Console.ReadLine());
            double price = double.Parse(Console.ReadLine());
            double weight = double.Parse(Console.ReadLine());

            int webLength = (2 * length) + (2 * width);
            double area = webLength * height;

            Console.WriteLine(webLength);
            Console.WriteLine("{0:F2}", webLength * price);
            Console.WriteLine("{0:F3}", area * weight);
        }
    }
}

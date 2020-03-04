using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12.RectProp
{
    class Program
    {
        static void Main(string[] args)
        {
            double width = double.Parse(Console.ReadLine());
            double height = double.Parse(Console.ReadLine());

            double perimeter = (width + height) * 2;
            double area = width * height;
            double diagonal = Math.Sqrt(width * width + height * height);

            Console.WriteLine("{2}\n{0}\n{1}",area, diagonal,perimeter);
        }
    }
}

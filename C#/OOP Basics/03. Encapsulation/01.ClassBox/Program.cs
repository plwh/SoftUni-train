using System;

namespace _01.ClassBox
{
    class Program
    {
        static void Main(string[] args)
        {
            double length = double.Parse(Console.ReadLine());
            double width = double.Parse(Console.ReadLine());
            double height = double.Parse(Console.ReadLine());

            Box box = new Box(length, width, height);

            Console.WriteLine($@"Surface Area - {box.CalcSurfaceArea():f2}
Lateral Surface Area - {box.CalcLateralSurfaceArea():f2}
Volume - {box.CalcVolume():f2}");
        }
    }
}

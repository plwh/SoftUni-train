using System;

namespace _02.ClassBoxDataValidation
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                double length = double.Parse(Console.ReadLine());
                double width = double.Parse(Console.ReadLine());
                double height = double.Parse(Console.ReadLine());

                Box box = new Box(length, width, height);

                Console.WriteLine($@"Surface Area - {box.CalcSurfaceArea():f2}
Lateral Surface Area - {box.CalcLateralSurfaceArea():f2}
Volume - {box.CalcVolume():f2}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}

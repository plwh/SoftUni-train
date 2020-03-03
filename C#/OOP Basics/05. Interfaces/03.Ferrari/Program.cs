using System;

class Program
{
    static void Main(string[] args)
    {
        string driverName = Console.ReadLine();
        ICar ferrari = new Ferrari(driverName);
        Console.WriteLine(ferrari);
    }
}

using System;

class Program
{
    static void Main()
    {
        string command = Console.ReadLine();

        if (command == "Square")
        {
            int size = int.Parse(Console.ReadLine());
            Shape square = new Square(size);
            square.Draw();
        }
        else if (command == "Rectangle")
        {
            int width = int.Parse(Console.ReadLine());
            int height = int.Parse(Console.ReadLine());
            Shape rectangle = new Rectangle(width, height);
            rectangle.Draw();
        }
    }
}

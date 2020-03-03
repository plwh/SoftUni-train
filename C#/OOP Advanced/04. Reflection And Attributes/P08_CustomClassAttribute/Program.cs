using System;
using System.Linq;

[InfoAttribute("Pesho", 3, "Used for C# OOP Advanced Course - Enumerations and Attributes.", "Pesho", "Svetlio")]
class Program
{
    static void Main(string[] args)
    {
        string input = string.Empty;

        var attribute = (InfoAttribute)typeof(Program).GetCustomAttributes(true).First();

        while ((input = Console.ReadLine()) != "END")
        {
            attribute.PrintInfo(input);
        }
    }
}

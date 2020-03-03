using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.AppliedArithmetics
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Split(new char[] {' '},StringSplitOptions.RemoveEmptyEntries).Select(a => int.Parse(a)).ToList();

            Action<string> applyCommand = inputCommand =>
            {
                switch(inputCommand)
                {
                    case "add":
                        numbers = numbers.Select(n => n + 1).ToList();
                        break;
                    case "multiply":
                        numbers = numbers.Select(n => n * 2).ToList();
                        break;
                    case "subtract":
                        numbers = numbers.Select(n => n - 1).ToList();
                        break;
                    case "print":
                        Console.WriteLine(string.Join(" ", numbers));
                        break;
                }
            };

            string command = Console.ReadLine();

            while (command != "end")
            {
                applyCommand(command);
                command = Console.ReadLine();
            }
        }
    }
}

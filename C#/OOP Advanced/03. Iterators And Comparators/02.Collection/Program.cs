using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.Collection
{
    class Program
    {
        static void Main(string[] args)
        {
            ListyIterator<string> iterator = new ListyIterator<string>();
            string input = "";
            while ((input = Console.ReadLine()) != "END")
            {
                string[] commands = input.Split();

                switch (commands[0])
                {
                    case "Create":
                        if (commands.Length > 1)
                        {
                            List<string> elements = commands.Skip(1).Take(commands.Length - 1).ToList();
                            iterator = new ListyIterator<string>(elements);
                        }
                        break;
                    case "Move":
                        Console.WriteLine(iterator.Move());
                        break;
                    case "HasNext":
                        Console.WriteLine(iterator.HasNext());
                        break;
                    case "Print":
                        try
                        {
                            iterator.Print();
                        }
                        catch (InvalidOperationException e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;
                    case "PrintAll":
                        Console.WriteLine(string.Join(" ", iterator));
                        break;
                }
            }
        }
    }
}

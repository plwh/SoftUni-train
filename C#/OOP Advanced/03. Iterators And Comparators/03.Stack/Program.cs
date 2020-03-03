using System;
using System.Linq;

namespace _03.Stack
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomStack<int> stack = new CustomStack<int>();

            string input = "";
            while ((input = Console.ReadLine()) != "END")
            {
                string[] commands = input.Split(new char[] {' ',','}, StringSplitOptions.RemoveEmptyEntries);

                switch (commands[0])
                {
                    case "Push":
                        int[] elementsToPush = commands.Skip(1).Take(commands.Length - 1).Select(int.Parse).ToArray();
                        for (int i = 0; i < elementsToPush.Length; i++)
                        {
                            stack.Push(elementsToPush[i]);
                        }
                        break;
                    case "Pop":
                        try
                        {
                            stack.Pop();
                        }
                        catch (InvalidOperationException e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;
                }
            }

            for (int i = 0; i < 2; i++)
            {
                foreach (int number in stack)
                    Console.WriteLine(number);
            }
        }
    }
}

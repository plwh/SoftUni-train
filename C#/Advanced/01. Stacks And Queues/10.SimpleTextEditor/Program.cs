using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10.SimpleTextEditor
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string text = String.Empty;
            Stack<string> lastOperations = new Stack<string>();
            
            for (int i = 0; i < n; i++)
            {
                var commands = Console.ReadLine().Split(' ');

                switch (commands[0])
                {
                    case "1":
                        lastOperations.Push(text);
                        text += commands[1];
                        break;
                    case "2":
                        lastOperations.Push(text);
                        text = text.Substring(0, text.Length - int.Parse(commands[1]));
                        break;
                    case "3":
                        Console.WriteLine(text[int.Parse(commands[1])-1]);
                        break;
                    case "4":
                        text = lastOperations.Pop();
                        break;
                }
            }
        }
    }
}

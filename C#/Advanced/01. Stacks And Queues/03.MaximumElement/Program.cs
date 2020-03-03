using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.MaximumElement
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());
            Stack<string> stack = new Stack<string>();

            for (int i = 0; i < N; i++)
            {
                var input = Console.ReadLine().Split(' ').ToList();

                switch (input[0])
                {
                    case "1":
                        stack.Push(input[1]);
                        break;
                    case "2":
                        stack.Pop();
                        break;
                    case "3":
                        Console.WriteLine(stack.Max());
                        break;
                }
            }
        }
    }
}

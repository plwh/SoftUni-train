using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.BasicStackOperations
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(' ').Select(a => int.Parse(a)).ToArray();

            int N = input[0];
            int S = input[1];
            int X = input[2];

            var stackInput = Console.ReadLine().Split(' ');
            Stack<int> stack = new Stack<int>();

            for (int i = 0; i < N; i++)
            {
                stack.Push(int.Parse(stackInput[i]));
            }

            for (int i = 0; i < S; i++)
            {
                stack.Pop();
            }

            if (stack.Count == 0)
            {
                Console.WriteLine(0);
            }
            else if (stack.Contains(X))
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine(stack.Min());
            }
        }
    }
}

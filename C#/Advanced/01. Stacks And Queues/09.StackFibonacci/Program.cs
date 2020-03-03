using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.StackFibonacci
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<ulong> stack = new Stack<ulong>();
            stack.Push(0);
            stack.Push(1);

            int nthNumber = int.Parse(Console.ReadLine());

            for (int i = 0; i < nthNumber; i++)
            {
                ulong first = stack.Pop();
                ulong second = stack.Pop();

                stack.Push(first);
                stack.Push(first + second);
            }

            stack.Pop();
            Console.WriteLine(stack.Peek());
        }
    }
}

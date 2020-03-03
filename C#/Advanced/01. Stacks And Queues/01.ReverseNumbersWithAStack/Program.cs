using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.ReverseNumbersWithAStack
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(' ').Select(a => int.Parse(a));

            Stack<int> stack = new Stack<int>(input);

            while(stack.Count > 0)
            { 
                Console.Write(stack.Pop() + " ");
            }

            Console.WriteLine();
        }
    }
}

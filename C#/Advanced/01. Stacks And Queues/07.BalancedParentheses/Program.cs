using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.BalancedParentheses
{
    class Program
    {
        static void Main(string[] args)
        {
            var parenthesisLine = Console.ReadLine();

            var openParenthesis = new Stack<char>();
            var openingCases = new char[] { '{', '[', '(' };

            for (int i = 0; i < parenthesisLine.Length; i++)
            {
                if (openingCases.Contains(parenthesisLine[i]))
                {
                    openParenthesis.Push(parenthesisLine[i]);
                }
                else
                {
                    if(openParenthesis.Count == 0)
                    {
                        Console.WriteLine("NO");
                        return;
                    }

                    switch (parenthesisLine[i])
                    {
                        case '}':
                            if (openParenthesis.Pop() != '{')
                            {
                                Console.WriteLine("NO");
                                return;
                            }
                            break;
                        case ']':
                            if (openParenthesis.Pop() != '[')
                            {
                                Console.WriteLine("NO");
                                return;
                            }
                            break;
                        case ')':
                            if (openParenthesis.Pop() != '(')
                            {
                                Console.WriteLine("NO");
                                return;
                            }
                            break;
                    }
                }
            }

            Console.WriteLine("YES");
        }
    }
}

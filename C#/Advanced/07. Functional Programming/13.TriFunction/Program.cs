using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13.TriFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());
            var names = Console.ReadLine().Split().ToArray();

            Func<string, int, bool> checker = (name, targetSum) => {
                int sum = 0;
                foreach (char i in name)
                {
                    sum += (int)i;
                }

                if (sum >= targetSum)
                {
                    return true;
                }

                return false;
            };

            Func<string[], int, Func<string, int, bool>, string> firstValidName = (arr, num, func) => arr
              .FirstOrDefault(str => func(str, num));

            var result = firstValidName(names, number, checker);

            Console.WriteLine(result);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.ReverseAndExclude
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(a=> int.Parse(a)).Reverse().ToList();
            var divisor = int.Parse(Console.ReadLine());

            Func<int, bool> checker = n => n % divisor == 0;

            numbers.Where(checker)
                   .ToList()
                   .ForEach(n => numbers.Remove(n));

            Console.WriteLine(String.Join(" ", numbers));
        }
    }
}

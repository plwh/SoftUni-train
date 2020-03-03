using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.StudentsByAge
{
    class Program
    {
        static void Main(string[] args)
        {
            var studentsData = new List<string[]>();

            var line = Console.ReadLine();
            while (line != "END")
            {
                studentsData.Add(line.Split(' '));
                line = Console.ReadLine();
            }

            studentsData
                .Where(a => int.Parse(a[2]) >= 18 && int.Parse(a[2]) <= 24)
                .ToList()
                .ForEach(st => Console.WriteLine($"{st[0]} {st[1]} {st[2]}"));
        }
    }
}

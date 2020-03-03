using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.SortStudents
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
                .OrderBy(a => a[1])
                .ThenByDescending(a => a[0])
                .ToList()
                .ForEach(st => Console.WriteLine($"{st[0]} {st[1]}"));
        }
    }
}

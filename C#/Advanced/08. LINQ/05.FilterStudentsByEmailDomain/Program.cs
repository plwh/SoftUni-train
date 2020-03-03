using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.FilterStudentsByEmailDomain
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
                .Where(a => a[2].EndsWith("@gmail.com"))
                .ToList()
                .ForEach(st => Console.WriteLine($"{st[0]} {st[1]}"));
        }
    }
}

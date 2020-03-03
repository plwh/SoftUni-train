using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.StudentsByFirstLastName
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
                .Where(a  => string.Compare(a[0],a[1]) < 0)
                .ToList()
                .ForEach(name => Console.WriteLine($"{name[0]} {name[1]}"));
        }
    }
}

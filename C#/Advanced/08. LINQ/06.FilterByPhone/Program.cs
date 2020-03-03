using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.FilterByPhone
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
                .Where(a => a[2].StartsWith("02") || a[2].StartsWith("+3592"))
                .ToList()
                .ForEach(a => Console.WriteLine(a[0] + " " + a[1]));
        }
    }
}

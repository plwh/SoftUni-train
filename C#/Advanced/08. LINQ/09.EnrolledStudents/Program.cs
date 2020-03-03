using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.EnrolledStudents
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
                .Where(a => a[0].EndsWith("14") || a[0].EndsWith("15"))
                .Select(a => a.Skip(1))
                .ToList()
                .ForEach(a => Console.WriteLine(String.Join(" ", a)));
        }
    }
}

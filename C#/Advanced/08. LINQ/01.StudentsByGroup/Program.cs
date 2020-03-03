using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.StudentsByGroup
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
                .Where(a => a[2] == "2")
                .OrderBy(a => a[0])
                .ToList()
                .ForEach(a => Console.WriteLine(a[0] + " " +  a[1]));
                    
        }
    }
}

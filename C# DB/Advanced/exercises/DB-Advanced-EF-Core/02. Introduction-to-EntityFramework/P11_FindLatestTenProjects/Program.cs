using P02_DatabaseFirst.Data;
using System;
using System.Globalization;
using System.Linq;

namespace P11_FindLatestTenProjects
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new SoftUniContext())
            {
                var lastTenProjects = context.Projects
                    .OrderByDescending(p => p.StartDate)
                    .OrderBy(p => p.Name)
                    .Take(10);

                foreach (var p in lastTenProjects)
                {
                    Console.WriteLine($"{p.Name}{Environment.NewLine}{p.Description}");
                    Console.WriteLine(p.StartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture));
                }
            }
        }
    }
}

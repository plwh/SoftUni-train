using P02_DatabaseFirst.Data;
using P02_DatabaseFirst.Data.Models;
using System;
using System.Linq;

namespace P14.DeleteProjectById
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new SoftUniContext())
            {
                var project = context.Projects.Find(2);

                var recordsToRemove = context.EmployeesProjects
                    .Where(ep => ep.ProjectId == project.ProjectId)
                    .ToList();

                foreach (var target in recordsToRemove)
                {
                    context.EmployeesProjects.Remove(target);
                }

                context.Projects.Remove(project);
                context.SaveChanges();

                var tenProjects = context.Projects
                    .Take(10)
                    .Select(p => p.Name);

                foreach (var p in tenProjects)
                {
                    Console.WriteLine(p);
                }
            }
        }
    }
}

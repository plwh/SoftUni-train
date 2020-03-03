using P04_WorkForce.Contracts;
using P04_WorkForce.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace P04_WorkForce
{
    class Program
    {
        static void Main(string[] args)
        {
            JobList jobs = new JobList();
            List<IEmployee> employees = new List<IEmployee>();

            string input = "";
            while ((input = Console.ReadLine()) != "End")
            {
                string[] tokens = input.Split();

                switch (tokens[0])
                {
                    case "Job":
                        string jobName = tokens[1];
                        int hoursOfWorkRequired = int.Parse(tokens[2]);
                        string employeeName = tokens[3];

                        IEmployee employee = employees.Where(e => e.Name == employeeName).First();

                        jobs.AddJob(new Job(jobName, hoursOfWorkRequired, employee));
                        break;
                    case "StandardEmployee":
                        employees.Add(new StandardEmployee(tokens[1]));
                        break;
                    case "PartTimeEmployee":
                        employees.Add(new PartTimeEmployee(tokens[1]));
                        break;
                    case "Pass":
                        jobs.ToList().ForEach(j => j.Update());
                        break;
                    case "Status":
                        foreach (Job job in jobs)
                        {
                            Console.WriteLine(job);
                        }
                        break;
                }
            }
        }
    }
}

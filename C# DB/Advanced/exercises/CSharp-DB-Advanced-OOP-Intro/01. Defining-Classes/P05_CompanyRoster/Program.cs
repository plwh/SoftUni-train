using System;
using System.Collections.Generic;
using System.Linq;

namespace P05_CompanyRoster
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<Employee>> departmentsInfo = new Dictionary<string, List<Employee>>();

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] tokens = Console.ReadLine().Split();

                string name = tokens[0];
                double salary = double.Parse(tokens[1]);
                string position = tokens[2];
                string department = tokens[3];

                Employee currEmployee = new Employee(name, salary, position, department, null, null); // create default employee

                if (tokens.Length == 6) // employee has both email and age
                {
                    string email = tokens[4];
                    int age = int.Parse(tokens[5]);

                    currEmployee = new Employee(name, salary, position, department, email, age);
                }
                else if(tokens.Length == 5) // employee has email or age
                {
                    if (int.TryParse(tokens[4], out int age)) // has age
                    {
                        currEmployee = new Employee(name, salary, position, department, null, age);
                    }
                    else // has email
                    {
                        string email = tokens[4]; 
                        currEmployee = new Employee(name, salary, position, department, email, null);
                    }
                }

                if (!departmentsInfo.ContainsKey(department))
                {
                    departmentsInfo[department] = new List<Employee> { currEmployee };
                }
                else
                {
                    departmentsInfo[department].Add(currEmployee);
                }
            }

            double maxSum = 0;
            string targetDepartment = "";

            foreach (var pairs in departmentsInfo)
            {
                double currSum = 0;

                foreach (var emp in pairs.Value)
                {
                    currSum += emp.Salary;
                }

                if (currSum > maxSum)
                {
                    maxSum = currSum;
                    targetDepartment = pairs.Key;
                }
            }
            
            foreach (var department in departmentsInfo.Where(d => d.Key == targetDepartment))
            {
                Console.WriteLine($"Highest Average Salary: {department.Key}");

                foreach (var emp in department.Value.OrderByDescending(e => e.Salary))
                {
                    Console.WriteLine(emp);
                }
            }
        }
    }
}

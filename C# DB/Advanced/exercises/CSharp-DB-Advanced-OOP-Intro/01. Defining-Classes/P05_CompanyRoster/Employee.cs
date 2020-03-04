using System;
using System.Collections.Generic;
using System.Text;

namespace P05_CompanyRoster
{
    public class Employee
    {
        public Employee(string name, double salary, string position, string department, string email, int? age)
        {
            this.Name = name;
            this.Salary = salary;
            this.Position = position;
            this.Department = department;
            this.Email = email;
            this.Age = age;
        }

        public string Name { get; set; }

        public double Salary { get; set; }

        public string Position { get; set; }

        public string Department { get; set; }

        public string Email { get; set; }

        public int? Age { get; set; }

        public override string ToString()
        {
            return string.Format($"{this.Name} {this.Salary:f2} {((this.Email == null) ? "n/a" : this.Email)} " +
                $"{((this.Age == null) ? "-1" : this.Age.ToString())}");
        }
    }
}

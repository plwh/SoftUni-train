using P04_WorkForce.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace P04_WorkForce.Models
{
    public abstract class Employee : IEmployee
    {
        protected Employee(string name, int workHoursPerWeek)
        {
            this.Name = name;
            this.WorkHoursPerWeek = workHoursPerWeek;
        }

        public string Name { get; }

        public int WorkHoursPerWeek { get; }
    }
}

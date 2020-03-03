using P04_WorkForce.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace P04_WorkForce.Models
{
    public class Job : IJob
    {
        public Job(string name, int hoursOfWorkRequired, IEmployee employee)
        {
            this.Name = name;
            this.HoursOfWorkRequired = hoursOfWorkRequired;
            this.Employee = employee;
        }

        public event UpdateEventHandler UpdateEvent;

        public IEmployee Employee { get; }

        public int HoursOfWorkRequired { get; private set; }

        public string Name { get; }

        public void Update()
        {
            this.HoursOfWorkRequired -= this.Employee.WorkHoursPerWeek;

            if (this.HoursOfWorkRequired <= 0)
            {
                Console.WriteLine($"Job {this.Name} done!");
                this.UpdateEvent.Invoke(this);
            }
        }

        public override string ToString()
        {
            return $"Job: {this.Name} Hours Remaining: {this.HoursOfWorkRequired}";
        }
    }
}

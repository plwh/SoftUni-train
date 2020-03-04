using System;
using System.Collections.Generic;
using System.Text;

namespace P03_Mankind
{
    public class Worker : Human
    {
        private double weekSalary;
        private int workHoursPerDay;

        public Worker(string firstName, string lastName, double weekSalary, int workHoursPerDay) 
            : base(firstName, lastName)
        {
            this.WorkHoursPerDay = workHoursPerDay;
            this.WeekSalary = weekSalary;
        }

        public int WorkHoursPerDay
        {
            get { return this.workHoursPerDay; }
            private set
            {
                if(value < 1 || value > 12)
                {
                    throw new ArgumentException($"Expected value mismatch! Argument: {value}");
                }

                this.workHoursPerDay = value;
            }
        }

        public double WeekSalary
        {
            get { return this.weekSalary; }
            private set
            {
                if (value <= 10)
                {
                    throw new ArgumentException($"Expected value mismatch! Argument: {value}");
                }

                this.weekSalary = value;
            }
        }

        public double SalaryPerHour
        {
            get
            {
                return this.WeekSalary / (5 * this.WorkHoursPerDay);
            }
        }

        public override string ToString()
        {
            return base.ToString() + $"Week Salary: {this.WeekSalary:f2}" + Environment.NewLine +
                                     $"Hours per day: {this.WorkHoursPerDay:f2}" + Environment.NewLine +
                                     $"Salary per hour: {this.SalaryPerHour:f2}" + Environment.NewLine; 
        }
    }
}

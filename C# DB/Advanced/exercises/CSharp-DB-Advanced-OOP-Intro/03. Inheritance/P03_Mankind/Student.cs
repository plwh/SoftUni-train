using System;
using System.Collections.Generic;
using System.Text;

namespace P03_Mankind
{
    public class Student : Human
    {
        private string facultyNumber;

        public Student(string firstName, string lastName, string facultyNumber) 
            : base(firstName, lastName)
        {
            this.FacultyNumber = facultyNumber;
        }


        public string FacultyNumber
        {
            get { return facultyNumber; }
            private set
            {
                if (value.Length < 5 || value.Length > 10)
                {
                    throw new ArgumentException("Invalid faculty number!");
                }

                facultyNumber = value;
            }
        }

        public override string ToString()
        {
            return base.ToString() + $"Faculty Number: {this.FacultyNumber}" +
                   Environment.NewLine;
        }
    }
}

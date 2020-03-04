using System;
using System.Collections.Generic;
using System.Text;

namespace P03_Mankind
{
    public class Human
    {
        private string firstName;
        private string lastName;

        public Human(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        public string LastName
        {
            get { return this.lastName; }
            private set
            {
                if (char.IsLower(value[0]))
                {
                    throw new ArgumentException($"Expected upper case letter! Argument: {value}");
                }

                if (value.Length < 3)
                {
                    throw new ArgumentException($"Expected length at least 4 symbols! Argument: {value}");
                }

                this.lastName = value;
            }
        }

        public string FirstName
        {
            get { return this.firstName; }
            private set
            {
                if(char.IsLower(value[0]))
                {
                    throw new ArgumentException($"Expected upper case letter! Argument: {value}");
                }

                if (value.Length < 4)
                {
                    throw new ArgumentException($"Expected length at least 4 symbols! Argument: {value}");
                }

                this.firstName = value;
            }
        }

        public override string ToString()
        {
            return string.Format($"First Name: {this.FirstName}" + Environment.NewLine +
                                 $"Last Name: {this.LastName}" + Environment.NewLine);
        }
    }
}

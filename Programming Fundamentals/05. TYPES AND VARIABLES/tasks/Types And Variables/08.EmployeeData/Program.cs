using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.EmployeeData
{
    class Program
    {
        static void Main(string[] args)
        {
            string firstName = "Amanda";
            string lastName = "Jonson";
            byte age = 27;
            char gender = 'f';
            long personalID = 8306112507;
            int employeeNumber = 27563571;
            Console.WriteLine(@"First name: {0}
Last name: {1}
Age: {2}
Gender: {3}
Personal ID: {4}
Unique Employee number: {5}", firstName, lastName, age, gender, personalID, employeeNumber);
        }
    }
}

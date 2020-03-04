using System;
using System.Collections.Generic;
using System.Text;

namespace P01_StudentDatabase.Generators.Student
{
    public class StudentNameGenerator
    {
        internal static string GenerateName()
        {
            Random rnd = new Random();

            string[] firstNames = { "Petur", "Ivan", "Georgi", "Alexander", "Stefan", "Vladimir", "Svetoslav", "Kaloyan", "Mihail", "Stamat" };
            string[] lastNames = { "Ivanov", "Georgiev", "Stefanov", "Alexandrov", "Petrov", "Stamatkov", };

            string studentName = $"{firstNames[rnd.Next(0, firstNames.Length)]} {lastNames[rnd.Next(0, lastNames.Length)]}";

            return studentName;
        }
    }
}

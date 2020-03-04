using System;
using System.Collections.Generic;
using System.Text;

namespace P01_StudentDatabaseInitializer.Generators.Course
{
    public class CourseNameGenerator
    {
        private static string generatedName;

        public static string GeneratedName
        {
            get { return generatedName; }
        }

        public static string GenerateName()
        {
            Random rnd = new Random();

            string[] prefixes = new string []{"Advanced", "Computational", "Literal", "Empiric", "General", "Professional"};
            string[] disciplines = new string[] { "Mathematics", "Physics", "Chemistry", "Computer Science", "Arts", "Bibliography" };

            generatedName = $"{prefixes[rnd.Next(0, prefixes.Length)]} {disciplines[rnd.Next(0, disciplines.Length)]}";
            return generatedName;
        }
    }
}

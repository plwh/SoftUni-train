using System;
using System.Collections.Generic;
using System.Text;

namespace P01_StudentDatabaseInitializer.Generators.Course
{
    public class DescriptionGenerator
    {
        internal static string GenerateDescription()
        {
            Random rnd = new Random();

            string courseName = CourseNameGenerator.GeneratedName;
            string[] descriptions = new string[] { "is the best option for fast learners", "will teach you the best practices",
                "will give you the most necessary knowledge", "is our fundamental course", "will help build the foundation of your future",
                "will enhance your thought process", "will enhance your skills", "is tailored for your specific needs", "is our express course"};

            return $"The {courseName} course {descriptions[rnd.Next(0, descriptions.Length)]}.";
        }
    }
}

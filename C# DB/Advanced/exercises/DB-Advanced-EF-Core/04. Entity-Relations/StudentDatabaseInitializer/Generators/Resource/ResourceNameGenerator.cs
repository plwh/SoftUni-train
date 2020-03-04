using System;
using System.Collections.Generic;
using System.Text;

namespace P01_StudentDatabaseInitializer.Generators.Resource
{
    public class ResourceNameGenerator
    {
        private static string name;

        public static string GeneratedName
        {
            get { return name; }
        }

        public static string GenerateName()
        {
            Random rnd = new Random();

            string[] namePool = new string[] { "First", "Second", "Third", "Fourth", "Fifth", "Sixth", "Seventh", "Eight", "Ninth" };

            name = $"{namePool[rnd.Next(0, namePool.Length)]} resource";
            
            return name;
        }
    }
}

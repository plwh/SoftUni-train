using System;
using System.Collections.Generic;
using System.Text;

namespace P01_StudentDatabase.Generators.Student
{
    public class PhoneNumberGenerator
    {
        internal static string GenerateNumber()
        {
            Random rnd = new Random();

            string [] prefixes = new string [] { "088", "087", "089" };
            string [] numbers = new string [7];

            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = rnd.Next(0, 9).ToString();
            }

            return $"{prefixes[rnd.Next(0, prefixes.Length)]}{string.Join("", numbers)}";
        }
    }
}

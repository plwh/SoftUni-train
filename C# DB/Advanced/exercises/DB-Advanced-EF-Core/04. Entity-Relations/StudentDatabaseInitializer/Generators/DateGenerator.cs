using System;
using System.Collections.Generic;
using System.Text;

namespace P01_StudentDatabase.Generators
{
    public class DateGenerator
    {
        internal static DateTime GenerateDate(string type)
        {
            Random rnd = new Random();

            int month = rnd.Next(1, 12);
            int day = rnd.Next(1, 31);
            int year = 0;

            switch(type)
            {
                case "birthDate":
                    year = rnd.Next(1990, 2010);
                    break;
                case "registrationDate":
                    year = rnd.Next(2011, 2018);
                    break;
                case "startDate":
                    year = rnd.Next(2011, 2014);
                    break;
                case "endDate":
                    year = rnd.Next(2015, 2018);
                    break;
                default:
                    Console.WriteLine("Invalid type.");
                    break;
            }

            DateTime date = DateTime.Parse($"{year}-{month}-{day}");

            return date;
        }
    }
}

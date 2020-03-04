using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.CountWorkDays
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime startDate = DateTime.ParseExact(Console.ReadLine(), "dd-MM-yyyy", CultureInfo.InvariantCulture);
            DateTime endDate = DateTime.ParseExact(Console.ReadLine(), "dd-MM-yyyy", CultureInfo.InvariantCulture);

            int workingCount = 0;

            foreach (DateTime day in EachDay(startDate, endDate))
            {
                if (!IsHoliday(day) && day.DayOfWeek.ToString() != "Saturday" && day.DayOfWeek.ToString() != "Sunday")
                {
                    workingCount++;
                }
            }

            Console.WriteLine(workingCount);
        }

        public static IEnumerable<DateTime> EachDay(DateTime from, DateTime thru)
        {
            for (var day = from.Date; day.Date <= thru.Date; day = day.AddDays(1))
                yield return day;
        }

        static bool IsHoliday(DateTime date)
        {
            DateTime[] holidays = new DateTime[] {
                DateTime.Parse("01.01"),
                DateTime.Parse("03.03"),
                DateTime.Parse("05.01"),
                DateTime.Parse("05.06"),
                DateTime.Parse("05.24"),
                DateTime.Parse("09.06"),
                DateTime.Parse("09.22"),
                DateTime.Parse("11.01"),
                DateTime.Parse("12.24"),
                DateTime.Parse("12.25"),
                DateTime.Parse("12.26"),
            };

            foreach (var holiday in holidays)
            {
                if (date.Month == holiday.Month && date.Day == holiday.Day)
                    return true;
            }
            return false;
        }
    }
}

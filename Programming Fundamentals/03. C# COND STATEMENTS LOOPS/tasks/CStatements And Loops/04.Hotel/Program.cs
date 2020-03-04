using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Hotel
{
    class Program
    {
        static void Main(string[] args)
        {
            string month = Console.ReadLine();
            int nightCount = int.Parse(Console.ReadLine());
            double studioPrice = 0;
            double doublePrice = 0;
            double suitePrice = 0;

            switch (month)
            {
                case "May":
                case "October":
                    studioPrice += 50;
                    doublePrice += 65;
                    suitePrice += 75;
                    break;
                case "June":
                case "September":
                    studioPrice += 60;
                    doublePrice += 72;
                    suitePrice += 82;
                    break;
                case "July":
                case "August":
                case "December":
                    studioPrice += 68;
                    doublePrice += 77;
                    suitePrice += 89;
                    break;
            }

            if (nightCount > 7 && (month == "May" || month == "October"))
            {
                studioPrice -= 0.05 * studioPrice;
            }
            else if (nightCount > 14 && (month == "June" || month == "September"))
            {
                doublePrice -= 0.10 * doublePrice;
            }
            else if (nightCount > 14 && (month == "July" || month == "August" || month == "December"))
            {
                suitePrice -= 0.15 * suitePrice;
            }

            if (nightCount > 7 && (month == "September" || month == "October"))
            {
                studioPrice *= nightCount - 1;
            }
            else
            {
                studioPrice *= nightCount;
            }

            doublePrice *= nightCount;
            suitePrice *= nightCount;

             
            Console.WriteLine("Studio: {0:F2} lv. \nDouble: {1:F2} lv. \nSuite: {2:F2} lv.",studioPrice,doublePrice,suitePrice);
        }
    }
}

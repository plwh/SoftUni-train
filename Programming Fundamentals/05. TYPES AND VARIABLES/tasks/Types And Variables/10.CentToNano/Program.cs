using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10.CentToNano
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int years = a * 100;
            int days = (int)(years * 365.2422);
            int hours = days * 24;
            int minutes = hours * 60;
            ulong seconds = (ulong)minutes * 60;
            ulong milliseconds = seconds * 1000;
            ulong microseconds = milliseconds * 1000;
            ulong nanoseconds = microseconds * 100;

            Console.Write("{0} centuries = {1} years = {2} days = {3} hours = {4} minutes",a,years,days,hours,minutes);
            Console.Write(" = {0} seconds = {1} milliseconds = {2} microseconds = {3} nanoseconds",seconds,milliseconds,microseconds,nanoseconds.ToString() + '0');

        }
    }
}

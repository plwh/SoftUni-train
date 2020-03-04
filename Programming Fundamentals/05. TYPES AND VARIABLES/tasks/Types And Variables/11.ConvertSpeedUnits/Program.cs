using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11.ConvertSpeedUnits
{
    class Program
    {
        static void Main(string[] args)
        {
            uint distMeter = uint.Parse(Console.ReadLine());
            int hours = int.Parse(Console.ReadLine());
            int minutes = int.Parse(Console.ReadLine());
            int seconds = int.Parse(Console.ReadLine());

            ushort time = (ushort)(hours * 3600 + minutes * 60 + seconds);

            float metersPerSecond = (float)distMeter / time;
            float kilometerPerHour = ((float)distMeter / 1000) / ((float)time / 3600);
            float milesPerHour =  ((float)distMeter / 1609) / ((float)time / 3600);

            Console.WriteLine("{0}\n{1}\n{2}",metersPerSecond,kilometerPerHour,milesPerHour);
        }
    }
}

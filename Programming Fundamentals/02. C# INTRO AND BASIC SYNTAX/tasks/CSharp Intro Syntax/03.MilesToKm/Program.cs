using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.MilesToKm
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("{0:F2}", double.Parse(Console.ReadLine()) * 1.60934);
        }
    }
}

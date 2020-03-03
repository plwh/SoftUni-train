using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.FormattingNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(new char[] { ' ', '\t' });

            int a = int.Parse(input[0]);
            double b = double.Parse(input[1]);
            double c = double.Parse(input[2]);

            string aToBinary = Convert.ToString(a, 2).PadLeft(10,'0');

            if (aToBinary.Length > 10)
                aToBinary = aToBinary.Substring(0, 10);

            Console.WriteLine("|{0,-10:X}|{1}|{2,10:f2}|{3,-10:f3}|",a,aToBinary,b,c);
        }
    }
}

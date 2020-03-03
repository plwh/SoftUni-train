using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.CustomMinFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(new char[] {' ' },StringSplitOptions.RemoveEmptyEntries).Select(a => double.Parse(a)).ToArray();

            Func<double[], double> minChecker = GetMin;

            Console.WriteLine(minChecker(input));
        }

        private static double GetMin(double[] nums)
        {
            double min = nums[0];
            foreach (var i in nums)
            {
                if (i < min) min = i;
            }
            return min;
        }
    }
}

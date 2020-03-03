using System;
using System.Collections.Generic;
using System.Text;

namespace Pr11.Tuple
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split();

            CustomTuple<string, string> tuple1 = new CustomTuple<string, string>(input[0] + " " + input[1], input[2]);
            Console.WriteLine(tuple1);

            input = Console.ReadLine().Split();
            CustomTuple<string, int> tuple2 = new CustomTuple<string, int>( input[0], int.Parse(input[1]));
            Console.WriteLine(tuple2);

            input = Console.ReadLine().Split();
            CustomTuple<int, double> tuple3 = new CustomTuple<int, double>(int.Parse(input[0]),double.Parse(input[1]));
            Console.WriteLine(tuple3);
        }
    }
}

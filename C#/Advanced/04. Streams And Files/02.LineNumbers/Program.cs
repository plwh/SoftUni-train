using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.LineNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"..\..\TextFile1.txt";

            using (var reader = new StreamReader(path))
            {
                using (var writer = new StreamWriter(@"..\..\result.txt"))
                {
                    var readLine = "";
                    int counter = 1;
                    while ((readLine = reader.ReadLine()) != null)
                    {
                        writer.WriteLine($"{counter}.{readLine}");
                        counter++;
                    }
                }
            }
        }
    }
}

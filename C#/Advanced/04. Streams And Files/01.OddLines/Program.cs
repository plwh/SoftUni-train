using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.OddLines
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"..\..\TextFile1.txt";

            StreamReader reader = new StreamReader(path);

            int count = 1;

            using (reader)
            {
                while (true)
                {
                    string line = reader.ReadLine();
                    if (line == null)
                        break;

                    if(count % 2 != 0)
                    Console.WriteLine(line);

                    count++;
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.SlicingFile
{
    class Program
    {
        static void Main(string[] args)
        {
            Slice(@"..\..\sudoku.png", @"..\..\", 3);
            Assemble(new List<string> { @"..\..\part1.png" , @"..\..\part2.png" , @"..\..\part3.png" }, @"..\..\");
        }

        public static void Slice(string sourceFile, string destinationDirectory, int parts)
        {
            var buffer = new byte[4096];
            using (var fileReader = new FileStream(sourceFile, FileMode.Open, FileAccess.Read, FileShare.None))
            {
                var length = fileReader.Length;
                var partSize = (long)Math.Ceiling((double)length / parts);

                for (int i = 1; i <= parts; i++)
                {
                    using (var fileWriter = new FileStream(destinationDirectory + "part" + i + ".png", FileMode.Create))
                    {

                        int number = fileReader.Read(buffer, 0, buffer.Length);
                        
                        while (number != 0 && fileWriter.Length <= partSize)
                        {
                            fileWriter.Write(buffer, 0, number);

                            int bytesToRead = buffer.Length;
                            if (fileWriter.Length + buffer.Length > partSize)
                                bytesToRead = (int)(partSize - fileWriter.Length);

                            number = fileReader.Read(buffer, 0, bytesToRead);

                            Console.WriteLine(fileWriter.Length);

                        }
                        Console.WriteLine("Next");
                    }
                }
            }
        }

        public static void Assemble(List<string> files, string destinationDirectory)
        {
            var buffer = new byte[4096];
            using (var assembled = new FileStream(destinationDirectory + "assembled.png", FileMode.Create))
            {
                for (int i = 0; i < files.Count; i++)
                {
                    using (var reader = new FileStream(files[i], FileMode.Open))
                    {
                        int number = reader.Read(buffer, 0, buffer.Length);
                        while (number != 0)
                        {
                            assembled.Write(buffer, 0, number);
                            number = reader.Read(buffer, 0, buffer.Length);
                        }
                    }
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.CopyBinaryFile
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var source = new FileStream(@"..\..\sudoku.png", FileMode.Open))
            {
                using (var destination =
                  new FileStream(@"..\..\result.png", FileMode.Create))
                {
                    byte[] buffer = new byte[1024];
                    while (true)
                    {
                        int readBytes = source.Read(buffer, 0, buffer.Length);
                        if (readBytes == 0)
                            break;
                        destination.Write(buffer, 0, readBytes);
                    }
                }
            }
        }
    }
}

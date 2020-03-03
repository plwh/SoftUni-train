using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.DirectoryTraversal
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] filePath = Directory.GetFiles(@"C:\Users\PLWH\Desktop\Coding\C# (SoftUni)\C#\Advanced\04. Streams And Files\06.ZippingSlicedFiles");

            List<FileInfo> files = filePath.Select(path => new FileInfo(path)).ToList();

            var sortedFiles = files
                .OrderBy(file => file.Length)
                .GroupBy(file => file.Extension)
                .OrderByDescending(group => group.Count())
                .ThenBy(group => group.Key);

            string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            using(var writer = new StreamWriter(desktop + @"\report.txt"))
            {

                foreach (var group in sortedFiles)
                {
                    writer.WriteLine(group.Key);

                    foreach (var y in group)
                    {
                        writer.WriteLine("--{0} - {1:F3}kb", y.Name, y.Length / 1024.0);
                    }
                }
            }
        }
    }
}

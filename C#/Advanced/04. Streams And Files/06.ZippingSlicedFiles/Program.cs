using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace _06.ZippingSlicedFiles
{
    class Program
    {
        private static List<string> files = new List<string>();
        private static MatchCollection matches;

        static void Main(string[] args)
        {
            string inputFile = @"..\..\sudoku.png";
            string folderPath = @"..\..\";

            Slice(inputFile, folderPath, 3);
            Assemble(files, folderPath);
        }

        public static void Slice(string sourceFile, string destinationDirectory, int parts)
        {
            using (var fileReader = new FileStream(sourceFile, FileMode.Open, FileAccess.Read, FileShare.None))
            {
                long partSize = (long)Math.Ceiling((double)fileReader.Length / parts);

                long fileOffset = 0;

                string currPartPath;
                long sizeRemaining = fileReader.Length;

                string pattern = @"(\w+)(?=\.)\.(?<=\.)(\w+)";
                Regex pairs = new Regex(pattern);
                matches = pairs.Matches(sourceFile);

                for (int i = 1; i <= parts; i++)
                {
                    currPartPath = destinationDirectory + matches[0].Groups[1] + String.Format(@"-{0}", i) + "." + "gz";
                    files.Add(currPartPath);

                    using (var fileWriter = new FileStream(currPartPath, FileMode.Create))
                    {
                        using (var compressionStream = new GZipStream(fileWriter, CompressionMode.Compress, false))
                        {
                            long currentPieceSize = 0;
                            byte[] buffer = new byte[4096];
                            while (currentPieceSize < partSize)
                            {
                                int readBytes = fileReader.Read(buffer, 0, buffer.Length);
                                if (readBytes == 0)
                                {
                                    break;
                                }

                                compressionStream.Write(buffer, 0, readBytes);
                                currentPieceSize += readBytes;
                            }
                        }
                    }

                    sizeRemaining = (int)fileReader.Length - (i * partSize);
                    if (sizeRemaining < partSize)
                    {
                        partSize = sizeRemaining;
                    }
                    fileOffset += partSize;
                }
            }
        }

        private static void Assemble(List<string> files, string destinationDirectory)
        {
            string fileOutputPath = destinationDirectory + "assembled" + "." + matches[0].Groups[2];
            var fsSource = new FileStream(fileOutputPath, FileMode.Create);

            fsSource.Close();
            using (fsSource = new FileStream(fileOutputPath, FileMode.Append))
            {
                foreach (var filePart in files)
                {
                    using (var partSource = new FileStream(filePart, FileMode.Open))
                    {
                        using (var compressionStream = new GZipStream(partSource, CompressionMode.Decompress, false))
                        {
                            Byte[] bytePart = new byte[4096];
                            while (true)
                            {
                                int readBytes = compressionStream.Read(bytePart, 0, bytePart.Length);
                                if (readBytes == 0)
                                {
                                    break;
                                }

                                fsSource.Write(bytePart, 0, readBytes);
                            }
                        }
                    }
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.AnonymousThreat
{
    class Program
    {
        static void Main(string[] args)
        {
            var inputArray = Console.ReadLine().Split(' ').ToList();
            var line = Console.ReadLine();

            while (line != "3:1")
            {
                var commands = line.Split(' ');

                string command = commands[0];

                switch (command)
                {
                    case "merge":
                        int startIndex = int.Parse(commands[1]);
                        int endIndex = int.Parse(commands[2]);

                        inputArray = Merge(inputArray,startIndex,endIndex);
                        break;
                    case "divide":
                        int index = int.Parse(commands[1]);
                        int chunkSizes = int.Parse(commands[2]);

                        inputArray = Divide(inputArray, index, chunkSizes);
                        break;
                        
                }
                line = Console.ReadLine();
            }

            Console.WriteLine(string.Join(" ",inputArray));
        }

        private static int ChangeIndex(int index, int maxLength)
        {
            if (index < 0) index = 0;

            if (index >= maxLength) index = maxLength - 1;

            return index;
        }

        private static List<string> Merge(List<string> inputArray, int startIndex, int endIndex)
        {
            StringBuilder mergedElements = new StringBuilder();
            int count = 0;
           
            startIndex = ChangeIndex(startIndex,inputArray.Count);

            endIndex = ChangeIndex(endIndex, inputArray.Count);

            for (int i = startIndex; i <= endIndex; i++)
            {
                mergedElements.Append(inputArray[i]);
                count++;
            }

            inputArray.RemoveRange(startIndex, count);
            inputArray.Insert(startIndex, mergedElements.ToString());
            
            return inputArray;
        }

        private static List<string> Divide(List<string> inputArray, int index, int chunkSizes)
        {   
            string element = inputArray[index];
            
            int chunkSize = element.Length / chunkSizes;

            List<string> dividedPartitions = new List<string>();

            for (int i = 0; i < chunkSizes; i++)
            {
                if (i == chunkSizes - 1)
                {
                    dividedPartitions.Add(element.Substring(i * chunkSize));
                }
                else
                {
                    dividedPartitions.Add(element.Substring(i * chunkSize, chunkSize));
                }
            }
            inputArray.RemoveAt(index);
            inputArray.InsertRange(index, dividedPartitions);
            
            return inputArray;
        }
    }
}

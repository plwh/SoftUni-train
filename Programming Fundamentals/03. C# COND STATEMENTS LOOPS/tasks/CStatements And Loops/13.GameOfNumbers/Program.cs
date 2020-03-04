using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13.GameOfNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int m = int.Parse(Console.ReadLine());
            int magicNum = int.Parse(Console.ReadLine());
            int combinationCount = 0;
            List<string> magicCombinations = new List<string>();

            for (int i = n; i <= m; i++)
            {
                for (int j = n; j <= m; j++)
                {
                    combinationCount++;
                    if (i + j == magicNum)
                    {
                        magicCombinations.Add(i + " + " + j);
                    }
                }
            }

            if (magicCombinations.Count != 0)
            {
                Console.WriteLine("Number found! {0} = {1}", magicCombinations.Last(), magicNum);
            }
            else
            {
                Console.WriteLine("{0} combinations - neither equals {1}", combinationCount, magicNum);
            }
        }
    }
}

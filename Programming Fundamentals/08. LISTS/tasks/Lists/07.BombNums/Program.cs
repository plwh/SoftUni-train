using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.BombNums
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> sequence = Console.ReadLine().Split(' ').Select(int.Parse).ToList();
            int[] bombAndPower = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            int bomb = bombAndPower[0];
            int power = bombAndPower[1];
            int sum = 0;

            while (sequence.IndexOf(bomb) != -1)
            {
                // find bomb index
                int indexOfBomb = sequence.IndexOf(bomb);

                // remove left neighbors
                for (int i = 1; i <= power; i++)
                {
                    int currIndex = indexOfBomb - i;

                    if (currIndex >= 0)
                    {
                        sequence.RemoveAt(currIndex);
                    }
                    else
                    {
                        break;
                    }
                }

                // find bomb index after removing left neighbors
                indexOfBomb = sequence.IndexOf(bomb);

                // remove right neighbors
                for (int i = 1; i <= power; i++)
                {
                    int currIndex = indexOfBomb + 1;

                    if (currIndex < sequence.Count)
                    {
                        sequence.RemoveAt(currIndex);
                    }
                    else
                    {
                        break;
                    }
                }

                // remove bomb
                sequence.Remove(bomb);
            }

            foreach (int i in sequence) sum += i;
            Console.WriteLine(sum);
        }
    }
}

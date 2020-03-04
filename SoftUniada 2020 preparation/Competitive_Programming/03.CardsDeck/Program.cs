using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            int cardAmount = int.Parse(Console.ReadLine());

            int[] cards = new int[cardAmount];

            for (int i = 0; i < cards.Length; i++)
            {
                cards[i] = i + 1;

            }

            var indexes = Console.ReadLine().Split(new char[0]).Select(Int32.Parse).ToArray();

            for (int i = 0; i < indexes.Length; i++)
            {
                int currIndex = indexes[i];

                List<int> firstPart = new List<int>();
                List<int> secondPart = new List<int>();

                
                for (int j = 0; j < currIndex; j++) 
                {
                    firstPart.Add(cards[j]);
                }

                for (int k = currIndex; k < cards.Length; k++)
                {
                    secondPart.Add(cards[k]);
                }

                int iterator = 0;
                bool isFirst = true;
                int targetElement = 0;

                while (iterator < cards.Length) 
                {
                    if (isFirst && firstPart.Count > 0 )
                    {
                        targetElement = firstPart[0];
                        firstPart.RemoveAt(0);

                        if (secondPart.Count > 0)
                            isFirst = false;
                    }
                    else if (secondPart.Count > 0)
                    {
                        targetElement = secondPart[0];
                        secondPart.RemoveAt(0);


                        if (firstPart.Count > 0)
                            isFirst = true;
                    }

                    cards[iterator] = targetElement;
                    iterator++;
                }
            }

            Console.WriteLine(string.Join(" ", cards));
        }
    }
}

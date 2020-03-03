using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.HandsOfCards
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> playersHands = new Dictionary<string, List<string>>();

            string line = Console.ReadLine();

            while (line != "JOKER")
            {
                var arr = line.Split(':');

                string playerName = arr[0].Trim();

                var input = line.Split(new char[] {' ',',',},StringSplitOptions.RemoveEmptyEntries);

                if(!playersHands.ContainsKey(playerName))
                playersHands.Add(playerName,new List<string>());

                for (int i = 1; i < input.Length; i++)
                {
                    string currCard = input[i];

                    if (!playersHands[playerName].Contains(currCard))
                    {
                        playersHands[playerName].Add(currCard);
                    }
                }
                
                line = Console.ReadLine();
            }

            foreach (var players in playersHands)
            {
                CalculateAndPrintResult(players.Key, players.Value);
            }
        }

        private static void CalculateAndPrintResult(string name, List<string> hands)
        {
            int currSum = 0;
            int result = 0;

            foreach (string card in hands)
            {
                currSum = 0;

                string power = card.Substring(0, card.Length - 1);

                if (int.TryParse(power, out int number))
                {
                    currSum += number;
                }
                else
                {
                    switch (power)
                    {
                        case "J":
                            currSum += 11;
                            break;
                        case "Q":
                            currSum += 12;
                            break;
                        case "K":
                            currSum += 13;
                            break;
                        case "A":
                            currSum += 14;
                            break;
                    }
                }

                switch (card[card.Length - 1])
                {
                    case 'S':
                        currSum *= 4;
                        break;
                    case 'H':
                        currSum *= 3;
                        break;
                    case 'D':
                        currSum *= 2;
                        break;
                    case 'C':
                        currSum *= 1;
                        break;
                }

                result += currSum;
            }

            Console.WriteLine($"{name}: {result}");
        }
    }
}

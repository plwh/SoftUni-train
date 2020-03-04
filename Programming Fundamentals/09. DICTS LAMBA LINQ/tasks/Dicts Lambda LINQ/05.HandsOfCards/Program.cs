using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.HandsOfCards
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> playerHands = new Dictionary<string, List<string>>();
            char[] delimitedChars = new char[] {' ',':',','};
            string input = Console.ReadLine();

            while (input != "JOKER")
            {
                var arr = input.Split(':');
                
                string personName = arr[0].Trim();

                var cards = arr[1].Split(delimitedChars, StringSplitOptions.RemoveEmptyEntries).ToList();

                // add distinct hands
                if (playerHands.ContainsKey(personName))
                {
                    foreach (string card in cards)
                    {
                        if (!playerHands[personName].Contains(card))
                        {
                            playerHands[personName].Add(card);
                        }
                    }
                }
                else
                {
                    playerHands.Add(personName,cards.Select(x => x).Distinct().ToList());
                }

                input = Console.ReadLine();
            }

            foreach (var pair in playerHands)
            {
                int sum = 0;
                for (int i = 0; i< pair.Value.Count; i++)
                {
                    sum += CalcCardValue(pair.Value[i]);
                }
                Console.WriteLine(pair.Key.ToString() + ": " + sum);
            }
        }

        private static int CalcCardValue(string card)
        {
            int cardValue = 0;
            string power = "";
            char type = card[card.Length - 1];
            int multiplier = 0;

            switch (type)
            {
                case 'S':
                    multiplier = 4;
                    break;
                case 'H':
                    multiplier = 3;
                    break;
                case 'D':
                    multiplier = 2;
                    break;
                case 'C':
                    multiplier = 1;
                    break;
            }

            foreach (char i in card)
            {
                int num = 0;

                if (i == type) break;

                if (int.TryParse(i.ToString(), out num))
                {
                    power += i;
                }
                else
                {
                    switch (i)
                    {
                        case 'J': power += 11; break;
                        case 'Q': power += 12; break;
                        case 'K': power += 13; break;
                        case 'A': power += 14; break;
                    }
                }
            }

            cardValue = int.Parse(power) * multiplier;
            
            return cardValue;
        }
    }
}

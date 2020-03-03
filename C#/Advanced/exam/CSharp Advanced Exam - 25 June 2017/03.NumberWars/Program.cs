using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.NumberWars
{
    class Program
    {
        static void Main(string[] args)
        {
            var turns = 0;
            bool IsDraw = false;

            var firstPlayerCards = new Queue<Card>();
            var secondPlayerCards = new Queue<Card>();

            var input1 = Console.ReadLine().Split(' ');
            var input2 = Console.ReadLine().Split(' ');

            foreach (var ca in input1)
            {
                int digit = int.Parse(ca.Substring(0, ca.Length - 1));
                string letter = ca.Substring(ca.Length - 1);
                firstPlayerCards.Enqueue(new Card(digit, letter));
            }

            foreach (var ca in input2)
            {
                int digit = int.Parse(ca.Substring(0, ca.Length - 1));
                string letter = ca.Substring(ca.Length - 1);
                secondPlayerCards.Enqueue(new Card(digit, letter));
            }

            bool outOfCards = false;

            while (turns < 1000000 && firstPlayerCards.Count > 0 && secondPlayerCards.Count > 0)
            {
                if (turns > 10000)
                {
                    turns = 1000000;
                    break;
                }

                List<Card> playedCards = new List<Card>();

                var firstPlayerCard = firstPlayerCards.Dequeue();
                var secondPlayerCard = secondPlayerCards.Dequeue();

                playedCards.Add(firstPlayerCard);
                playedCards.Add(secondPlayerCard);

                if (firstPlayerCard.Digit > secondPlayerCard.Digit)
                {
                    AddPlayedCards(ref firstPlayerCards, playedCards);
                }
                else if (secondPlayerCard.Digit > firstPlayerCard.Digit)
                {
                    AddPlayedCards(ref secondPlayerCards, playedCards);
                }
                else
                {
                    outOfCards = false;
                    var hasWinner = false;

                    if (firstPlayerCards.Count - 3 < 0 || secondPlayerCards.Count - 3 < 0)
                    {
                        hasWinner = true;
                        outOfCards = true;
                        if (firstPlayerCards.Count == secondPlayerCards.Count)
                        {
                            IsDraw = true;
                        }
                        break;
                    }

                    while (hasWinner == false)
                    {
                        if (firstPlayerCards.Count - 3 < 0 || secondPlayerCards.Count - 3 < 0)
                        {
                            hasWinner = true;
                            outOfCards = true;
                            if (firstPlayerCards.Count == secondPlayerCards.Count)
                            {
                                IsDraw = true;
                            }
                            break;
                        }

                        List<Card> p1WithdrawnCards = new List<Card>();
                        List<Card> p2WithdrawnCards = new List<Card>();

                        for (int i = 0; i < 3; i++)
                        {
                            p1WithdrawnCards.Add(firstPlayerCards.Dequeue());
                            p2WithdrawnCards.Add(secondPlayerCards.Dequeue());
                        }

                        int warResult = -1;

                        warResult = GetWarResult(p1WithdrawnCards, p2WithdrawnCards);

                        playedCards.AddRange(p1WithdrawnCards);
                        playedCards.AddRange(p2WithdrawnCards);

                        if (warResult == 1)
                        {
                            hasWinner = true;
                            AddPlayedCards(ref firstPlayerCards, playedCards);
                        }
                        else if (warResult == 2)
                        {
                            hasWinner = true;
                            AddPlayedCards(ref secondPlayerCards, playedCards);
                        }
                    }
                }
                turns++;
                if (outOfCards || IsDraw)
                {
                    break;
                }
            }

            if (IsDraw)
            {
                Console.WriteLine($"Draw after {turns} turns");
            }
            else
            {
                if (firstPlayerCards.Count > secondPlayerCards.Count)
                {
                    Console.WriteLine($"First player wins after {turns} turns");
                }
                else
                {
                    Console.WriteLine($"Second player wins after {turns} turns");
                }
            }
        }

        private static void AddPlayedCards(ref Queue<Card> currPlayerCards, List<Card> playedCards)
        {
            foreach (var card in playedCards.OrderByDescending(x => x.Digit).ThenByDescending(x => x.Name))
            {
                currPlayerCards.Enqueue(card);
            }
        }

        private static int GetWarResult(List<Card> p1WithdrawnCards, List<Card> p2WithdrawnCards)
        {
            string p1Chars = string.Join(string.Empty, p1WithdrawnCards.Select(x => x.Name)).ToLower();
            string p2Chars = string.Join(string.Empty, p2WithdrawnCards.Select(x => x.Name)).ToLower();

            int p1Sum = 0;
            int p2Sum = 0;

            for (int i = 0; i < p1Chars.Length; i++)
            {
                var num = p1Chars[i] - 96;
                p1Sum += num;
            }

            for (int i = 0; i < p2Chars.Length; i++)
            {
                var num = p2Chars[i] - 96;
                p2Sum += num;
            }

            if (p1Sum > p2Sum)
            {
                return 1;
            }
            else if (p2Sum > p1Sum)
            {
                return 2;
            }
            else
            {
                return 0;
            }
        }
    }

    class Card
    {
        public Card(int digit, string name)
        {
            this.Digit = digit;
            this.Name = name;
        }

        public int Digit { get; set; }
        public string Name { get; set; }
    }
}
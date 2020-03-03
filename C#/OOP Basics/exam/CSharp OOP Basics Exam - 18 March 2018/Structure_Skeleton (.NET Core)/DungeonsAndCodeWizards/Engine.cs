﻿namespace DungeonsAndCodeWizards
{
    using System;
    using System.Linq;

    public class Engine
    {
        private readonly DungeonMaster dungeonMaster;

        public Engine()
        {
            this.dungeonMaster = new DungeonMaster();
        }

        public void Run()
        {
            string input = "";
            while (!string.IsNullOrEmpty((input = Console.ReadLine())))
            {
                string[] tokens = input.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                string command = tokens[0];
                string[] args = tokens.Skip(1).ToArray();
                
                try
                {
                    switch (command)
                    {
                        case "JoinParty":
                            Console.WriteLine(this.dungeonMaster.JoinParty(args));
                            break;
                        case "AddItemToPool":
                            Console.WriteLine(this.dungeonMaster.AddItemToPool(args));
                            break;
                        case "PickUpItem":
                            Console.WriteLine(this.dungeonMaster.PickUpItem(args));
                            break;
                        case "UseItem":
                            Console.WriteLine(this.dungeonMaster.UseItem(args));
                            break;
                        case "UseItemOn":
                            Console.WriteLine(this.dungeonMaster.UseItemOn(args));
                            break;
                        case "GiveCharacterItem":
                            Console.WriteLine(this.dungeonMaster.GiveCharacterItem(args));
                            break;
                        case "GetStats":
                            Console.WriteLine(this.dungeonMaster.GetStats());
                            break;
                        case "Attack":
                            Console.WriteLine(this.dungeonMaster.Attack(args));
                            break;
                        case "Heal":
                            Console.WriteLine(this.dungeonMaster.Heal(args));
                            break;
                        case "EndTurn":
                            Console.WriteLine(this.dungeonMaster.EndTurn(args));
                            break;
                        case "IsGameOver":
                            Console.WriteLine(this.dungeonMaster.IsGameOver());
                            break;
                    }

                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine($"Parameter Error: {ae.Message}");
                }
                catch (InvalidOperationException ioe)
                {
                    Console.WriteLine($"Invalid Operation: {ioe.Message}");
                }

                if (this.dungeonMaster.IsGameOver())
                {
                    this.PrintResult();
                    return;
                }
            }

            this.PrintResult();
        }

        private void PrintResult()
        {
            Console.WriteLine($"Final stats:");
            Console.WriteLine(this.dungeonMaster.GetStats());
        }
    }
}

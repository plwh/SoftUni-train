using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.UpgradePhonebook
{
    class Program
    {
        static void Main(string[] args)
        {
            var phonebook = new SortedDictionary<string, string>();

            string[] commands;

            while (true)
            {
                commands = Console.ReadLine().Split(' ').ToArray();

                switch (commands[0])
                {

                    case "A":
                        phonebook[commands[1]] = commands[2];
                        break;
                    case "S":
                        if (phonebook.ContainsKey(commands[1]))
                        {
                            Console.WriteLine(commands[1] + " -> " + phonebook[commands[1]]);
                        }
                        else
                        {
                            Console.WriteLine($"Contact {commands[1]} does not exist.");
                        }
                        break;
                    case "ListAll":
                        foreach (var pairs in phonebook)
                        {
                           Console.WriteLine($"{pairs.Key} -> {pairs.Value}");
                        }
                        break;
                    default:
                        return;
                }
            }
                   
        }
    }
}

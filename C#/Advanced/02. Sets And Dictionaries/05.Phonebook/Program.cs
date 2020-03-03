using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.Phonebook
{
    class Program
    {
        static void Main(string[] args)
        {
            var contacts = new Dictionary<string, string>();

            var line = Console.ReadLine();

            while (line != "search")
            {
                string name = line.Substring(0,line.IndexOf('-'));
                string number = line.Substring(line.IndexOf('-')+1,line.Length-name.Length-1);

                contacts[name] = number;

                line = Console.ReadLine();
            }

            line = Console.ReadLine();

            while (line != "stop")
            {
                if (contacts.ContainsKey(line))
                {
                    Console.WriteLine($"{line} -> {contacts[line]}");
                }
                else
                {
                    Console.WriteLine($"Contact {line} does not exist.");
                }

                line = Console.ReadLine();
            }
        }
    }
}

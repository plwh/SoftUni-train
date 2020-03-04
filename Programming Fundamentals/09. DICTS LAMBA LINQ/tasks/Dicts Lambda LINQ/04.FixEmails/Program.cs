using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.FixEmails
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> emails = new Dictionary<string, string>();


            while (true)
            {
                string currLine = Console.ReadLine();

                if (currLine == "stop") break;

                string personName = currLine;
                string email = Console.ReadLine();

                emails.Add(personName,email);         
            }

           //IMPORTANT
            foreach (var item in emails.Where(kvp => kvp.Value.EndsWith(".us") || kvp.Value.EndsWith(".uk")).ToList())
            {
                emails.Remove(item.Key);
            }

            foreach (var pair in emails) Console.WriteLine($"{pair.Key} -> {pair.Value}");
        }
    }
}

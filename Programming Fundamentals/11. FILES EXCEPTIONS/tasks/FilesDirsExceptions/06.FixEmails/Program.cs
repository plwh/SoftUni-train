using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.FixEmails
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> emails = new Dictionary<string, string>();

            string[] input = File.ReadAllLines("../../input.txt");
            int lineCount = 0;

            foreach (string line in input)
            {
                if (line == "stop") break;

                if (lineCount % 2 == 0)
                {
                    string personName = line;
                    string email = input[lineCount+1];

                    emails.Add(personName, email);
                }
                lineCount++;
            }

            foreach (var item in emails.Where(kvp => kvp.Value.EndsWith(".us") || kvp.Value.EndsWith(".uk")).ToList())
            {
                emails.Remove(item.Key);
            }

            foreach (var pair in emails)
            {
                File.AppendAllText("../../output.txt", $"{pair.Key} -> {pair.Value}{Environment.NewLine}");
            }
        }
    }
}

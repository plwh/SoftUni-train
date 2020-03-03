using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.FixEmails
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> emails= new Dictionary<string, string>();

            string line = Console.ReadLine();

            while (line != "stop")
            {
                string name = line;
                string email = Console.ReadLine();

                emails[name] = email;

                line = Console.ReadLine();
            }

            var emailsNew = emails.Where(pair => !(pair.Value.EndsWith("us") || pair.Value.EndsWith("uk")))
                                  .ToDictionary(pair => pair.Key,
                                                pair => pair.Value);

            foreach (var pairs in emailsNew)
            {
                Console.WriteLine($"{pairs.Key} -> {pairs.Value}");
            }
        }
    }
}

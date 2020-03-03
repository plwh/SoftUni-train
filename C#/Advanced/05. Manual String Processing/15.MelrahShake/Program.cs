using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _15.MelrahShake
{
    class Program
    {
        static void Main(string[] args)
        {
            string textToShake = Console.ReadLine();
            var pattern = Console.ReadLine().ToList();

            while (true)
            {
                string textToReplace = String.Join("", pattern);

                if (textToShake.IndexOf(textToReplace) == -1 || textToShake.LastIndexOf(textToReplace) == -1)
                {
                    Console.WriteLine("No shake.");
                    break;
                }

                textToShake = textToShake.Replace(textToReplace, "");
                Console.WriteLine("Shaked it.");

                pattern.RemoveAt(pattern.Count / 2);
            }

            Console.WriteLine(textToShake);
        }
    }
}

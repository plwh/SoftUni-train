using System;
using System.Linq;

namespace _04.Telephony
{
    class Program
    {
        static void Main(string[] args)
        {
            Smartphone smartPhone = new Smartphone();

            string[] numbers = Console.ReadLine().Split();

            foreach (string number in numbers)
            {
                if (number.Any(a => Char.IsLetter(a)))
                {
                    Console.WriteLine("Invalid number!");
                }
                else
                {
                    smartPhone.CallNumber(number);
                }
            }

            string[] websites = Console.ReadLine().Split();

            foreach (string website in websites)
            {
                if (website.Any(a => Char.IsDigit(a)))
                {
                    Console.WriteLine("Invalid URL!");
                }
                else
                {
                    smartPhone.BrowseWebsite(website);
                }
            }
        }
    }
}

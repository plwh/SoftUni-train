using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Advertisement
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] p = new string[] { "Excellent product.", "Such a great product.", "I always use that product.", "Best product of its category.", "Exceptional product.", "I can’t live without this product." };
            string[] e = new string[] { "Now I feel good.", "I have succeeded with this product.", "Makes miracles. I am happy of the results!", "I cannot believe but now I feel awesome.", "Try it yourself, I am very satisfied.", "I feel great!"};
            string[] a = new string[] { "Diana", "Petya", "Stella", "Elena", "Katya", "Iva", "Annie", "Eva" };
            string[] t = new string[] { "Burgas", "Sofia", "Plovdiv", "Varna", "Ruse" };

            int numberOfMessages = int.Parse(Console.ReadLine());

            Random rand = new Random();

            for (int i = 0; i < numberOfMessages; i++)
            {
                Console.WriteLine($"{p[rand.Next(0,p.Length)]} {e[rand.Next(0,e.Length)]} {a[rand.Next(0,a.Length)]} - {t[rand.Next(0,t.Length)]}");
            }
        }
    }
}

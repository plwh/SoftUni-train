using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace _01.AnonymousDownsite
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int secKey = int.Parse(Console.ReadLine());
            BigInteger secToken = BigInteger.Pow(secKey, n);

            var websites = new List<string>();
            decimal totalLoss = 0;

            for (int i = 0; i < n; i++)
            {
                string[] websiteInfo = Console.ReadLine().Split(' ');
                if (websiteInfo.Length == 3)
                {
                    string websiteName = websiteInfo[0];
                    long siteVisits = long.Parse(websiteInfo[1]);
                    decimal pricePerVisit = decimal.Parse(websiteInfo[2]);

                    decimal currLoss = siteVisits * pricePerVisit;

                    websites.Add(websiteName);
                    totalLoss += currLoss;
                }
            }

            Console.WriteLine(String.Join(Environment.NewLine, websites));
            Console.WriteLine($"Total Loss: {totalLoss:F20}{Environment.NewLine}Security Token: {secToken}");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13.OfficeStuff
{
    class Program
    {
        static void Main(string[] args)
        {
            var companyData = new Dictionary<string,Dictionary<string,List<int>>>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                var line = Console.ReadLine().Split(new char[] { '|', ' ', '-' }, StringSplitOptions.RemoveEmptyEntries).ToArray();

                var companyName = line[0];
                var product = line[2];
                var amount = int.Parse(line[1]);

                if (!companyData.ContainsKey(companyName))
                {
                    companyData.Add(companyName, new Dictionary<string, List<int>>()
                    {
                        {product,new List<int>(){amount}}
                    });
                }
                else if (!companyData[companyName].ContainsKey(product))
                {
                    companyData[companyName].Add(product, new List<int>() { amount });
                }
                else
                {
                    companyData[companyName][product].Add(amount);
                }
            }

            foreach (var company in companyData)
            {
                Console.Write($"{company.Key}: ");
                Console.WriteLine(string.Join(", ", company.Value.Select(x => x.Key + "-" + x.Value.Sum())) + Environment.NewLine);
            }
        }
    }
}

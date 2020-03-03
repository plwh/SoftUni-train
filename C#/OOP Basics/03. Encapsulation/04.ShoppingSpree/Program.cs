using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.ShoppingSpree
{
    class Program
    {
        static List<Person> people = new List<Person>();
        static List<Product> products = new List<Product>();

        static void Main(string[] args)
        {
            try
            {
                ParseData("people");
                ParseData("products");

                string line = "";
                while ((line = Console.ReadLine()) != "END")
                {
                    string [] inputData = line.Split();

                    string personName = inputData[0];
                    string productName = inputData[1];

                    Person person = people.Find(a => a.Name == personName);
                    Product product = products.Find(a => a.Name == productName);

                    if (person.Money >= product.Cost)
                    {
                        person.AddProduct(product);
                        Console.WriteLine($"{person.Name} bought {product.Name}");
                    }
                    else
                    {
                        Console.WriteLine($"{person.Name} can't afford {product.Name}");
                    }
                }

                foreach (Person person in people)
                {
                    if (person.Bag.Count == 0)
                    {
                        Console.WriteLine($"{person.Name} - Nothing bought");

                    }
                    else
                    {
                        Console.WriteLine(person.Name + " - " + string.Join(", ", person.Bag.Select(pr => pr.Name)));
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void ParseData(string target)
        {
            string[] tokensData = Console.ReadLine().Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (string token in tokensData)
            {
                string[] tokenData = token.Split('=');
                string firstParameter = tokenData[0];
                int secondParameter = int.Parse(tokenData[1]);

                if (target == "people")
                {
                    people.Add(new Person(firstParameter, secondParameter));
                }
                else
                {
                    products.Add(new Product(firstParameter, secondParameter));
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;

namespace P03_ShoppingSpree
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();
            List<Product> products = new List<Product>();

            try
            {
                for (int i = 0; i < 2; i++)
                {
                    string[] tokens = Console.ReadLine().Split(new char[] { ';', '=' }, StringSplitOptions.RemoveEmptyEntries);

                    for (int j = 0; j < tokens.Length; j += 2)
                    {
                        string name = tokens[j];

                        if (i % 2 == 0)
                        {
                            int money = int.Parse(tokens[j + 1]);
                            people.Add(new Person(name, money));
                        }
                        else
                        {
                            int price = int.Parse(tokens[j + 1]);
                            products.Add(new Product(name, price));
                        }
                    }
                }

                string input = "";
                while ((input = Console.ReadLine()) != "END")
                {
                    string[] tokens = input.Split();

                    Person person = people.Find(p => p.Name == tokens[0]);
                    Product product = products.Find(p => p.Name == tokens[1]);

                    person.Buy(product);
                }
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }

            foreach (Person person in people)
            {
                Console.WriteLine(person);
            }
        }
    }
}

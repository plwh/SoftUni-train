using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P03_ShoppingSpree
{
    public class Person
    {
        private string name;
        private int money;

        public Person(string name, int money)
        {
            this.Name = name;
            this.Money = money;
            this.Products = new List<Product>();
        }

        public string Name
        {
            get { return this.name; }
            private set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException("Name cannot be empty");

                this.name = value;
            }
        }

        public int Money
        {
            get { return this.money; }
            private set
            {
                if (value < 0)
                    throw new ArgumentException("Money cannot be negative");

                this.money = value;
            }
        }

        public List<Product> Products { get; set; }

        public void Buy(Product product)
        {
            if (this.Money - product.Price < 0)
                throw new ArgumentException($"{this.Name} can't afford {product.Name}");

            this.Products.Add(product);
            this.Money -= product.Price;

            Console.WriteLine($"{this.Name} bought {product.Name}");
        }

        public override string ToString()
        {
            return string.Format($"{this.Name} - " +
                $"{((this.Products.Count == 0) ? "Nothing bought" : string.Join(", ", this.Products.Select(p => p.Name)))}");
        }
    }
}

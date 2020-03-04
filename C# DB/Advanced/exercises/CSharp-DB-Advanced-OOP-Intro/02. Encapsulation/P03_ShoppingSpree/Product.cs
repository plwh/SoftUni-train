using System;
using System.Collections.Generic;
using System.Text;

namespace P03_ShoppingSpree
{
    public class Product
    {
        private string name;
        private int price;

        public Product(string name, int price)
        {
            this.Name = name;
            this.Price = price;
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

        public int Price
        {
            get { return this.price; }
            private set
            {
                if (value <= 0)
                    throw new ArgumentException("Price cannot be zero or negative");

                this.price = value;
            }
        }
    }
}

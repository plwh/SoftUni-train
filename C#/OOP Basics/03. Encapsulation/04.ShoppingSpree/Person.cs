using System;
using System.Collections.Generic;
using System.Text;

public class Person
{
    private string name;
    private int money;
    private List<Product> bag;

    public Person(string name, int money)
    {
        this.Name = name;
        this.Money = money;
        this.Bag = new List<Product>();
    }

    public List<Product> Bag
    {
        get { return bag; }
        set { bag = value; }
    }

    public int Money
    {
        get { return money; }
        private set
        {
            if (value < 0)
            {
                throw new ArgumentException("Money cannot be negative");
            }
            money = value;
        }
    }

    public string Name
    {
        get { return name; }
        private set
        {
            if (value == null || value == " ")
            {
                throw new ArgumentException("Name cannot be empty");
            }
            name = value;
        }
    }

    public IEnumerable<string> Select { get; internal set; }

    public void AddProduct(Product product)
    {
        this.Bag.Add(product);
        this.Money -= product.Cost;
    }
}

using System;
using System.Collections.Generic;
using System.Text;

public class Product
{
    private string name;
    private int cost;

    public Product(string name, int cost)
    {
        this.Name = name;
        this.Cost = cost;
    }

    public int Cost
    {
        get { return cost; }
        private set
        {
            if (value < 0)
            {
                throw new ArgumentException("Money cannot be negative");
            }
            cost = value;
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

}

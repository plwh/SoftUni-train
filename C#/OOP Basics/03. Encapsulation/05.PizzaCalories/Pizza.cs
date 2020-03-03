using System;
using System.Collections.Generic;
using System.Text;

public class Pizza
{
    private string name;
    private List<Topping> toppings;
    private Dough dough;

    public Pizza(string name, Dough dough)
    {
        this.Name = name;
        this.Dough = dough;
        this.Toppings = new List<Topping>();
    }
    public Dough Dough
    {
        get { return dough; }
        set { dough = value; }
    }

    public List<Topping> Toppings
    {
        get { return toppings; }
        set { toppings = value; }
    }

    public string Name
    {
        get { return name; }
        private set
        {
            if (value == string.Empty || value.Length > 15)
            {
                throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
            }
            name = value;
        }
    }
   
    public int NumberOfToppings
    {
        get
        {
            return this.Toppings.Count;
        }
    }

    public double Calories
    {
        get
        {
            double result = 0;
            result += this.Dough.Calories;

            foreach (Topping topping in this.Toppings)
            {
                result += topping.Calories;
            }

            return result;
        }
    }

    public void AddTopping(Topping topping)
    {
        if (this.Toppings.Count == 10)
        {
            throw new ArgumentException("Number of toppings should be in range [0..10].");
        }
        this.Toppings.Add(topping);
    }
}

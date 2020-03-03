using System;
using System.Collections.Generic;
using System.Text;

public class Topping
{
    private string type;
    private int weight;
    private const int BaseCaloriesPerGram = 2;

    public Topping(string type, int weight)
    {
        this.Type = type;
        this.Weight = weight;
    }

    public int Weight
    {
        get { return weight; }
        private set
        {
            if (value < 1 || value > 50)
            {
                throw new ArgumentException($"{this.Type} weight should be in the range [1..50].");
            }
            weight = value;
        }
    }

    public string Type
    {
        get { return type; }
        private set
        {
            if (value.ToLower() != "meat" && value.ToLower() != "veggies" && value.ToLower() != "cheese" && value.ToLower() != "sauce")
            {
                throw new ArgumentException($"Cannot place {value} on top of your pizza.");
            }
            type = value;
        }
    }

    public double Calories
    {
        get
        {
            double result = BaseCaloriesPerGram * Weight;

            switch (this.Type.ToLower())
            {
                case "meat":
                    result *= 1.2;
                    break;
                case "veggies":
                    result *= 0.8;
                    break;
                case "cheese":
                    result *= 1.1;
                    break;
                case "sauce":
                    result *= 0.9;
                    break;
            }

            return result;
        }
    }
}

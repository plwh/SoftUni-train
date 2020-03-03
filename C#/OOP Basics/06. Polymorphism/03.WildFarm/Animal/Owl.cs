using System;
using System.Collections.Generic;
using System.Text;

public class Owl : Bird
{
    public Owl(string name, double weight, double wingSize) 
        : base(name, weight, wingSize)
    {
    }

    public override void Feed(Food food)
    {
        if (food.GetType().Name != "Meat")
        {
            throw new ArgumentException($"{this.GetType().Name} does not eat {food.GetType().Name}!");
        }
        else
        {
            this.FoodEaten += food.Quantity;
            this.Weight += food.Quantity * 0.25;
        }
    }

    public override void MakeSound()
    {
        Console.WriteLine("Hoot Hoot");
    }
}

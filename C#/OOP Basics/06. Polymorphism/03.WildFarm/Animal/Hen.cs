using System;
using System.Collections.Generic;
using System.Text;

public class Hen : Bird
{
    public Hen(string name, double weight, double wingSize) 
        : base(name, weight, wingSize)
    {
    }

    public override void Feed(Food food)
    {
        this.FoodEaten += food.Quantity;
        this.Weight += food.Quantity * 0.35;
    }

    public override void MakeSound()
    {
        Console.WriteLine("Cluck");
    }
}

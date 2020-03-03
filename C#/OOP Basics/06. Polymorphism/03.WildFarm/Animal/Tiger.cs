using System;
using System.Collections.Generic;
using System.Text;

public class Tiger : Feline
{
    public Tiger(string name, double weight, string livingRegion, string breed)
        : base(name, weight, livingRegion, breed)
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
            this.Weight += food.Quantity * 1.00;
        }
    }

    public override void MakeSound()
    {
        Console.WriteLine("ROAR!!!");
    }
}

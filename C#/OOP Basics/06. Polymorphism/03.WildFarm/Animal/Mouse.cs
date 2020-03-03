using System;
using System.Collections.Generic;
using System.Text;

public class Mouse : Mammal
{
    public Mouse(string name, double weight, string livingRegion) 
        : base(name, weight, livingRegion)
    {
    }

    public override void Feed(Food food)
    {
        if (food.GetType().Name != "Vegetable" && food.GetType().Name != "Fruit")
        {
            throw new ArgumentException($"{this.GetType().Name} does not eat {food.GetType().Name}!");
        }
        else
        {
            this.FoodEaten += food.Quantity;
            this.Weight += food.Quantity * 0.10;
        }
    }

    public override void MakeSound()
    {
        Console.WriteLine("Squeak");
    }
}

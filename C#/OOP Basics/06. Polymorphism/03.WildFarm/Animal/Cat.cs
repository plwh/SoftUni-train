using System;
using System.Collections.Generic;
using System.Text;

public class Cat : Feline
{
    public Cat(string name, double weight, string livingRegion, string breed)
        : base(name, weight, livingRegion, breed)
    {
    }

    public override void Feed(Food food)
    {
        if (food.GetType().Name != "Vegetable" && food.GetType().Name != "Meat")
        {
            throw new ArgumentException($"{this.GetType().Name} does not eat {food.GetType().Name}!");
        }
        else
        {
            this.FoodEaten += food.Quantity;
            this.Weight += food.Quantity * 0.30;
        }
    }

    public override void MakeSound()
    {
        Console.WriteLine("Meow");
    }
}

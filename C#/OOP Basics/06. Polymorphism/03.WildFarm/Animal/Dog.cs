using System;
using System.Collections.Generic;
using System.Text;

public class Dog : Mammal
{
    public Dog(string name, double weight, string livingRegion) 
        : base(name, weight, livingRegion)
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
            this.Weight += food.Quantity * 0.40;
        }
    }

    public override void MakeSound()
    {
        Console.WriteLine("Woof!");
    }
}

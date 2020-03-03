using System;
using System.Collections.Generic;
using System.Text;

public abstract class Animal
{
    private string name;
    private double weight;
    private int foodEaten;
    
    public Animal(string name, double weight)
    {
        this.Name = name;
        this.Weight = weight;
        this.FoodEaten = 0;
    }

    public int FoodEaten
    {
        get { return foodEaten; }
        protected set { foodEaten = value; }
    }

    public double Weight
    {
        get { return weight; }
        set { weight = value; }
    }

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public abstract void MakeSound();
    public abstract void Feed(Food food);
}

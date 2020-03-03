using System;
using System.Collections.Generic;
using System.Text;

class Car
{
    private string model;
    private Engine engine;
    private string weight;
    private string color;

    public Car(string model, Engine engine, string weight, string color)
    {
        this.Model = model;
        this.Engine = engine;
        this.Weight = weight;
        this.Color = color;
    }

    public string Color
    {
        get { return color; }
        set { color = value; }
    }

    public string Weight
    {
        get { return weight; }
        set { weight = value; }
    }

    public Engine Engine
    {
        get { return engine; }
        set { engine = value; }
    }

    public string Model
    {
        get { return model; }
        set { model = value; }
    }

    public override string ToString()
    {
        return $@"{this.Model}:
  {this.Engine.Model}:
    Power: {this.Engine.Power}
    Displacement: {this.Engine.Displacement}
    Efficiency: {this.Engine.Efficiency}
  Weight: {this.Weight}
  Color: {this.Color}"; 
    }
}
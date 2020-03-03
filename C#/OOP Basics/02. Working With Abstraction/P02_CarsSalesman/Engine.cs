using System;
using System.Collections.Generic;
using System.Text;

class Engine
{
    private string model;
    private int power;
    private string displacement;
    private string efficiency;

    public Engine(string model, int power, string displacement, string efficiency)
    {
        this.Model = model;
        this.Power = power;
        this.Displacement = displacement;
        this.Efficiency = efficiency;
    }

    public string Efficiency
    {
        get { return efficiency; }
        set { efficiency = value; }
    }

    public string Displacement
    {
        get { return displacement; }
        set { displacement = value; }
    }

    public int Power
    {
        get { return power; }
        set { power = value; }
    }

    public string Model
    {
        get { return model; }
        set { model = value; }
    }
}

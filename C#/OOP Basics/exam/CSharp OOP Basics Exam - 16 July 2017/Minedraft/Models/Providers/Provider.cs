using System;
using System.Collections.Generic;
using System.Text;

public class Provider
{
    private string id;
    private double energyOutput;

    public Provider(string id, double energyOutput)
    {
        this.Id = id;
        this.EnergyOutput = energyOutput;
    }

    public double EnergyOutput
    {
        get { return energyOutput; }
        protected set
        {
            if (value < 0 || value > 10000)
                throw new ArgumentException("Provider is not registered, because of it's EnergyOutput");

            energyOutput = value;
        }
    }

    public string Id
    {
        get { return id; }
        set { id = value; }
    }

    public override string ToString()
    {
        return $@"{this.GetType().Name} Provider - {this.Id}
Energy Output: {this.EnergyOutput}";
    }
}

using System;
using System.Collections.Generic;
using System.Text;

public class Harvester
{
    private string id;
    private double oreOutput;
    private double energyRequirement;

    public Harvester(string id, double oreOutput, double energyRequirement)
    {
        this.Id = id;
        this.OreOutput = oreOutput;
        this.EnergyRequirement = energyRequirement;
    }

    public double EnergyRequirement
    {
        get { return energyRequirement; }
        protected set
        {
            if (value < 0 || value > 20000)
            {
                throw new ArgumentException($"Harvester is not registered, because of it's EnergyRequirement");
            }

            energyRequirement = value;
        }
    }

    public double OreOutput
    {
        get { return oreOutput; }
        protected set
        {
            if (value < 0)
            {
                throw new ArgumentException($"Harvester is not registered, because of it's OreOutput");
            }

            oreOutput = value;
        }
    }

    public string Id
    {
        get { return id; }
        set { id = value; }
    }

    public override string ToString()
    {
        return $@"{this.GetType().Name} Harvester - {this.Id}
Ore Output: {this.OreOutput}
Energy Requirement: {this.EnergyRequirement}";
    }
}

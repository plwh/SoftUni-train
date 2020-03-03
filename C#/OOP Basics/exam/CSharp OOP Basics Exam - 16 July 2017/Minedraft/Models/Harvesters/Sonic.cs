using System;
using System.Collections.Generic;
using System.Text;

public class Sonic : Harvester
{
    private int sonicFactor;

    public Sonic(string id, double oreOutput, double energyRequirement, int sonicFactor)
        : base(id, oreOutput, energyRequirement)
    {
        this.SonicFactor = sonicFactor;
        this.EnergyRequirement /= this.SonicFactor;
    }

    public int SonicFactor
    {
        get { return sonicFactor; }
        set { sonicFactor = value; }
    }
}

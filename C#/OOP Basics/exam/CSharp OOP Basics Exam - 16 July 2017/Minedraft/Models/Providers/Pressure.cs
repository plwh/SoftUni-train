using System;
using System.Collections.Generic;
using System.Text;

public class Pressure : Provider
{
    public Pressure(string id, double energyOutput) 
        : base(id, energyOutput)
    {
        this.EnergyOutput += this.EnergyOutput * 0.5;
    }
}

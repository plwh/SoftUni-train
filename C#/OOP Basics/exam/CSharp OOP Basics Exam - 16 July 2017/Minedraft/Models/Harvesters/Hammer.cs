﻿using System;
using System.Collections.Generic;
using System.Text;

public class Hammer : Harvester
{
    public Hammer(string id, double oreOutput, double energyRequirement) 
        : base(id, oreOutput, energyRequirement)
    {
        this.OreOutput += this.OreOutput * 2;
        this.EnergyRequirement += this.EnergyRequirement;
    }
}

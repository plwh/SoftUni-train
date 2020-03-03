using System;
using System.Collections.Generic;
using System.Text;

public class HarvesterFactory
{
    public Harvester Get(List<string> args)
    {
        string type = args[0];
        string id = args[1];
        double oreOutput = double.Parse(args[2]);
        double energyRequirement = double.Parse(args[3]);

        switch (type)
        {
            case "Sonic":
                return new Sonic(id, oreOutput, energyRequirement, int.Parse(args[4]));
            case "Hammer":
                return new Hammer(id, oreOutput, energyRequirement);
            default:
                throw new Exception("Harvester could not be created.");
        }
    }
}

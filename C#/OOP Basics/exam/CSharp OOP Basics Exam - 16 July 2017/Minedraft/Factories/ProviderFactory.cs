using System;
using System.Collections.Generic;
using System.Text;

public class ProviderFactory
{
    public Provider Get(List<string> args)
    {
        string type = args[0];
        string id = args[1];
        double energyOutput = double.Parse(args[2]);

        switch (type)
        {
            case "Solar":
                return new Solar(id, energyOutput);
            case "Pressure":
                return new Pressure(id, energyOutput);
            default:
                throw new ArgumentException("Provider could not be created.");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class DraftManager
{
    private string workingMode;
    private double totalStoredEnergy;
    private double totalMinedOre;
    private HarvesterFactory harvesterFactory;
    private ProviderFactory providerFactory;
    private List<Harvester> harvesters;
    private List<Provider> providers;

    public DraftManager()
    {
        this.workingMode = "Full";
        this.harvesterFactory = new HarvesterFactory();
        this.providerFactory = new ProviderFactory();
        this.harvesters = new List<Harvester>();
        this.providers = new List<Provider>();
    }

    public string RegisterHarvester(List<string> args)
    {
        try
        {
            this.harvesters.Add(this.harvesterFactory.Get(args));
        }
        catch (Exception ex)
        {
            return ex.Message;
        }

        return $"Successfully registered {args[0]} Harvester - {args[1]}";
    }
    public string RegisterProvider(List<string> args)
    {
        try
        {
            this.providers.Add(this.providerFactory.Get(args));
        }
        catch (Exception ex)
        {
            return ex.Message;
        }

        return $"Successfully registered {args[0]} Provider - {args[1]}";
    }
    public string Day()
    {
        double totalEnergyRequired = 0;
        double summedOreOutput = 0;
        double summedEnergyOutput = this.providers.Select(a => a.EnergyOutput).Sum();
        this.totalStoredEnergy += summedEnergyOutput;

        switch (this.workingMode)
        {
            case "Full":
                totalEnergyRequired = this.harvesters.Sum(h => h.EnergyRequirement);
                if (this.totalStoredEnergy >= totalEnergyRequired)
                {
                    summedOreOutput = this.harvesters.Sum(h => h.OreOutput);
                    this.totalMinedOre += summedOreOutput;
                    this.totalStoredEnergy -= totalEnergyRequired;
                }
                break;

            case "Half":
                totalEnergyRequired = this.harvesters.Sum(h => h.EnergyRequirement) * 0.6;
                if (this.totalStoredEnergy >= totalEnergyRequired)
                {
                    summedOreOutput = this.harvesters.Sum(h => h.OreOutput) * 0.5;
                    this.totalMinedOre += summedOreOutput;
                    this.totalStoredEnergy -= totalEnergyRequired;
                }
                break;

            default:
                break;
        }

        return $@"A day has passed.
Energy Provided: {summedEnergyOutput}
Plumbus Ore Mined: {summedOreOutput}";
    }
    public string Mode(string mode)
    {
        this.workingMode = mode;
        return $"Successfully changed working mode to {mode} Mode";
    }

    public string Check(string id)
    {
        if (this.providers.Any(a => a.Id == id))
        {
            Provider provider = this.providers.Find(a => a.Id == id);
            return provider.ToString();
        }
        else if(this.harvesters.Any(a => a.Id == id))
        {
            Harvester harvester = this.harvesters.Find(a => a.Id == id);
            return harvester.ToString();
        }

        return $"No element found with id - {id}";
    }

    public string ShutDown()
    {
        return $@"System Shutdown
Total Energy Stored: {this.totalStoredEnergy}
Total Mined Plumbus Ore: {this.totalMinedOre}";
    }
}

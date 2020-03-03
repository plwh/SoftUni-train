using System;
using System.Collections.Generic;

public class HarvesterController : IHarvesterController
{
    private string mode;
    private IEnergyRepository energyRepository;
    private IList<IHarvester> harvesters;
    private IHarvesterFactory factory;

    public HarvesterController(IEnergyRepository energyRepository, IHarvesterFactory factory)
    {
        this.mode = Constants.DefaultMode;
        this.harvesters = new List<IHarvester>();

        this.energyRepository = energyRepository;
        this.factory = factory;
    }

    public double OreProduced { get; private set; }

    public IReadOnlyCollection<IEntity> Entities => (IReadOnlyCollection<IEntity>)this.harvesters;

    public string ChangeMode(string mode)
    {
        this.mode = mode;
        List<IHarvester> reminder = new List<IHarvester>();

        foreach (var h in this.harvesters)
        {
            try
            {
                h.Broke();
            }
            catch (Exception)
            {
                reminder.Add(h);
            }
        }

        foreach (var entity in reminder)
        {
            this.harvesters.Remove(entity);
        }

        return string.Format(Constants.ModeChange, mode);
    }

    public string Produce()
    {
        double neededEnergy = 0;
        foreach (var harvester in this.harvesters)
        {
            if (this.mode == "Full")
            {
                neededEnergy += harvester.EnergyRequirement;
            }
            else if (this.mode == "Half")
            {
                neededEnergy += harvester.EnergyRequirement * 50 / 100;
            }
            else if (this.mode == "Energy")
            {
                neededEnergy += harvester.EnergyRequirement * 20 / 100;
            }
        }

        //check if we can mine
        double minedOres = 0;
        if (this.energyRepository.TakeEnergy(neededEnergy))
        {
            foreach (var harvester in this.harvesters)
            {
                minedOres += harvester.Produce();
            }
        }

        //take the mode in mind
        if (this.mode == "Energy")
        {
            minedOres = minedOres * 20 / 100;
        }
        else if (this.mode == "Half")
        {
            minedOres = minedOres * 50 / 100;
        }

        this.OreProduced += minedOres;


       
        return string.Format(Constants.OreOutputToday, minedOres);
    }

    public string Register(IList<string> args)
    {
        IHarvester harvester = this.factory.GenerateHarvester(args);
        this.harvesters.Add(harvester);

        return string.Format(Constants.SuccessfullRegistration, 
            harvester.GetType().Name);

    }
}


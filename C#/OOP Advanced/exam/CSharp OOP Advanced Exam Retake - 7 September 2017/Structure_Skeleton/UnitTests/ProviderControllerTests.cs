using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

[TestFixture]
public class ProviderControllerTests
{
    private EnergyRepository energyRepository;
    private ProviderController providerController;

    [SetUp]
    public void SetUpProviderController()
    {
        this.energyRepository = new EnergyRepository();
        this.providerController = new ProviderController(energyRepository);
    }

    [Test]
    public void ProducesCorrectAmountOfEnergy()
    {
        List<string> provider1 = new List<string>
        {
            "Solar", "1", "100"
        };

        List<string> provider2 = new List<string>
        {
            "Solar", "2", "100"
        };

        this.providerController.Register(provider1);
        this.providerController.Register(provider2);

        for (int i = 0; i < 3; i++)
        {
            this.providerController.Produce();
        }

        Assert.That(this.providerController.TotalEnergyProduced, Is.EqualTo(600));
    }


    [Test]
    public void BrokenProviderIsDeleted()
    {
        List<string> provider1 = new List<string>
        {
            "Pressure", "1", "100"
        };

        this.providerController.Register(provider1);

        for (int i = 0; i < 8; i++)
        {
            this.providerController.Produce();
        }

        FieldInfo fieldType = typeof(ProviderController).GetField("providers", BindingFlags.NonPublic |
            BindingFlags.Instance);

        int count = ((IList<IProvider>)fieldType.GetValue(this.providerController)).Count;
        Assert.That(count, Is.EqualTo(0));
    }
}

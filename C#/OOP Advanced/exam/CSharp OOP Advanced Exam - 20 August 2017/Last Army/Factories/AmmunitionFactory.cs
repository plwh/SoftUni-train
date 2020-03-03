using System;
using System.Linq;
using System.Reflection;

public class AmmunitionFactory : IAmmunitionFactory
{
    public IAmmunition CreateAmmunition(string ammunitionName)
    {
        Type ammunitionType = this.GetAmmunitionType(ammunitionName);
        return (IAmmunition)Activator.CreateInstance(ammunitionType, ammunitionName);
    }

    public Type GetAmmunitionType(string ammunitionName)
    {
        Type[] types = Assembly
            .GetExecutingAssembly()
            .GetTypes();

        return types.FirstOrDefault(t => t.Name == ammunitionName);
    }
}

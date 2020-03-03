using System;
using System.Linq;
using System.Reflection;

public class SoldierFactory : ISoldierFactory
{
    public ISoldier CreateSoldier(string soldierTypeName, string name, int age, double experience, double endurance)
    {
        Type soldierType = this.GetSoldierType(soldierTypeName);
        return (ISoldier)Activator.CreateInstance(soldierType, name, age, experience, endurance);
    }

    public Type GetSoldierType(string soldierTypeName)
    {
        Type[] types = Assembly
            .GetExecutingAssembly()
            .GetTypes();

        return types.FirstOrDefault(t => t.Name == soldierTypeName);
    }
}

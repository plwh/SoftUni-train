using System;
using System.Linq;
using System.Reflection;

public class MissionFactory : IMissionFactory
{
    public IMission CreateMission(string missionName, double neededPoints)
    {
        Type missionType = GetMissionType(missionName);
        return (IMission)Activator.CreateInstance(missionType, neededPoints);
    }

    public Type GetMissionType(string missionName)
    {
        Type[] types = Assembly
            .GetExecutingAssembly()
            .GetTypes();

        return types.FirstOrDefault(t => t.Name == missionName);
    }
}

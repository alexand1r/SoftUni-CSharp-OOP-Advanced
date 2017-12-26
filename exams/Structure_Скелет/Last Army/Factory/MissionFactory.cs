using System;
using System.Linq;
using System.Reflection;

public class MissionFactory
{
    public IMission CreateMission(string name, int score)
    {
        string missionName = name;
        Type missionType = Assembly.GetExecutingAssembly().GetTypes().First(t => t.Name == missionName);
        return (IMission)Activator.CreateInstance(missionType, new object[]{score});
    }
}

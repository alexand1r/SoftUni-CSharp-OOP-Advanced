using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

public class SoldierFactory
{
    public ISoldier CreateSoldier(string type, string name, int age, double expirience, double endurance)
    {
        string soldierName = name;
        Type soldierType = Assembly.GetExecutingAssembly().GetTypes().First(t => t.Name == soldierName);
        return (ISoldier)Activator.CreateInstance(soldierType, new object[] { name, age, expirience, endurance });
    }
}

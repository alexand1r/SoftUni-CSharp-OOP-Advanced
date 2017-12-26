
    using System;
    using System.Linq;
    using System.Reflection;

public class AmmunitionFactory
    {

        public IAmmunition CreateAmmunition(string name)
        {
            string ammunitionName = name;
            Type ammunitionType = Assembly.GetExecutingAssembly().GetTypes().First(t => t.Name == ammunitionName);
            return (IAmmunition)Activator.CreateInstance(ammunitionType, new object[]{ammunitionName});
        
        }

        //public IAmmunition CreateAmmunitions(string name, int number)
        //{
        //    string ammunitionName = name;
        //    Type ammunitionType = Assembly.GetExecutingAssembly().GetTypes().First(t => t.Name == ammunitionName);
        //    return (IAmmunition)Activator.CreateInstance(ammunitionType, new object[] { ammunitionName, number });
        
        //}
    }

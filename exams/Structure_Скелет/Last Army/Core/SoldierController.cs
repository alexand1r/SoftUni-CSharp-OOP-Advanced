using System.Collections.Generic;
using System.Linq;

public class SoldierController
{
    public void SoldierChangesAfterMission(Dictionary<string, List<ISoldier>> army, IMission mission, string rankerType)
    {
        foreach (var soldier in army[rankerType])
        {
            
        }
    }

    public void TeamRegenerate(Dictionary<string, List<Soldier>> army, string rankerType)
    {
        army[rankerType].ForEach(r => r.Regenerate());
    }

    //public bool CheckSoldiersEndurance(IMission mission, Dictionary<string, List<Soldier>> army, string s)
    //{
    //    //if (army[mission.RequiredTeam].Average(e => e.Endurance) < mission.EnduranceRequired)
    //    //{
    //    //    return false;
    //    //}
    //    //return true;
    //}

    public bool DoWeHaveAllNeededWeaponsForTheMission(Dictionary<string, List<IAmmunition>> wareHouse,
        Dictionary<string, List<Soldier>> army, string soldireType, IMission mission)
    {
        //foreach (var weapon in mission.MissionWeapons)
        //{
        //    string weaponName = weapon.Name;

        //    // проверяваме дали изобщо имаме такива оръжия
        //    if (!wareHouse.ContainsKey(weaponName))
        //    {
        //        return false;
        //    }

        //    int weaponIndex = wareHouse[weaponName].FindIndex(w => w.Name.Equals(weaponName));

        //    //проверка дали оръжието което се иска от нас, нищо че го има в склада войника е обучен да го използва
        //    //if (!army[soldireType][0].Weapons.Contains(weaponName))
        //    //{
        //    //    return false;
        //    //}
        //    // проверяваме дали броя оръжия които имаме отговаря на броя на хората в екипа
        //    //if (army[soldireType].Count > wareHouse[weaponName][weaponIndex].Number)
        //    //{
        //    //    return false;
        //    //}
        //}

        return true;
    }

    public bool CanEverySoldierCarryOnTheNeededWeapons(Dictionary<string, List<Soldier>> army, List<Ammunition> missionWeapons, string soldierGroup)
    {
        foreach (var soldier in army[soldierGroup])
        {
            //if (!soldier.CanCarryWeaponsTotalWeight(missionWeapons))
            //{
            //    return false;
            //}
        }
        return true;
    }

   
}

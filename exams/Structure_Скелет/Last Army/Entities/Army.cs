using System.Collections.Generic;

public class Army : IArmy
{
    //public Army(Dictionary<string, List<ISoldier>> soldiers)
    //{
    //    this.soldiers = soldiers;
    //    this.FillDict();
    //}

    public Army() { }

    public Dictionary<string, List<ISoldier>> soldiers { get; set; }
    public IReadOnlyList<ISoldier> Soldiers { get; }

    public void AddSoldier(ISoldier soldier)
    {
        string type = soldier.GetType().Name;
        soldiers[type].Add(soldier);
    }

    public void FillDict()
    {
        soldiers.Add(typeof(Ranker).Name, new List<ISoldier>());
        soldiers.Add(typeof(Corporal).Name, new List<ISoldier>());
        soldiers.Add(typeof(SpecialForce).Name, new List<ISoldier>());
    }

    public void RegenerateTeam(string soldierType)
    {
        throw new System.NotImplementedException();
    }
}


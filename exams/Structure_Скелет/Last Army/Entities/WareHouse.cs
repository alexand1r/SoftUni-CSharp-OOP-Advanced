using System.Collections.Generic;

public class WareHouse : IWareHouse
{
    //public WareHouse(Dictionary<string, List<IAmmunition>> ammonitions)
    //{
    //    this.ammonitions = ammonitions;
    //    this.FillDict();
    //}

    public WareHouse() { }

    public Dictionary<string, List<IAmmunition>> ammonitions { get; set; }
    public string Name { get; private set; }
    public double Weight { get; private set; }
    public void EquipArmy(IArmy army)
    {
        throw new System.NotImplementedException();
    }

    public void FillDict()
    {
        this.ammonitions.Add("AutomaticMachine", new List<IAmmunition>());
        this.ammonitions.Add("Gun", new List<IAmmunition>());
        this.ammonitions.Add("Helmet", new List<IAmmunition>());
        this.ammonitions.Add("Knife", new List<IAmmunition>());
        this.ammonitions.Add("MachineGun", new List<IAmmunition>());
        this.ammonitions.Add("NightVision", new List<IAmmunition>());
        this.ammonitions.Add("RPG", new List<IAmmunition>());
    }
}
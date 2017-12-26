using System;
using System.Collections.Generic;
using System.Text;


public class GameController
{
    private Dictionary<string, List<ISoldier>> army;
    private Dictionary<string, List<IAmmunition>> wareHouse;
    private MissionController missionControllerField;
    private SoldierFactory soldierFactory;
    private AmmunitionFactory ammunitionFactory;

    public GameController()
    {
        this.Army = new Dictionary<string, List<ISoldier>>();
        this.WareHouse = new Dictionary<string, List<IAmmunition>>();
        this.MissionControllerField = new MissionController(new Army(this.Army), new WareHouse(this.WareHouse));
        this.soldierFactory = new SoldierFactory();
        this.ammunitionFactory = new AmmunitionFactory();
    }

    public Dictionary<string, List<ISoldier>> Army
    {
        get { return army; }
        set { army = value; }
    }

    public Dictionary<string, List<IAmmunition>> WareHouse
    {
        get { return wareHouse; }
        set { wareHouse = value; }
    }

    public MissionController MissionControllerField
    {
        get { return missionControllerField; }
        set { missionControllerField = value; }
    }

    public void GiveInputToGameController(string input)
    {
        var data = input.Split();

        if (data[0].Equals("Soldier"))
        {
            string type = string.Empty;
            string name = string.Empty;
            int age = 0;
            double experience = 0d;
            double endurance = 0d;

            if (data.Length == 3)
            {
                type = data[1];
                name = data[2];
            }
            else
            {
                type = data[1];
                name = data[2];
                age = int.Parse(data[3]);
                experience = double.Parse(data[4]);
                endurance = double.Parse(data[5]);
            }
            

            var soldier = this.soldierFactory.CreateSoldier(type, name, age, experience, endurance);

            Dictionary<string, List<IAmmunition>> ammo = this.MissionControllerField.WareHouse.ammonitions;
            if (type == "Ranker")
            {
                if (ammo["Gun"].Count > 1 && ammo["Gun"].Count > 1 && ammo["Gun"].Count > 1)
                {
                    
                }
            }
            //this.MissionControllerField(ranker, type);
             
        }
        else if (data[0].Equals("WearHouse"))
        {
            string name = data[1];
            int number = int.Parse(data[2]);

            AddAmmunitions(this.ammunitionFactory.CreateAmmunition(name));
        }
        else if (data[0].Equals("Mission"))
        {
            string name = data[1];
            int score = int.Parse(data[2]);
            this.MissionControllerField.CreateMission(name, score);
        }
    }

    //public string RequestResult()
    //{
    //    //return Output.GiveOutput(result, army, wearHouse, this.MissionControllerField.MissionQueue.Count);
    //}

    private void AddAmmunitions(IAmmunition ammunition)
    {
        if (!this.WareHouse.ContainsKey(ammunition.Name))
        {
            this.WareHouse[ammunition.Name] = new List<IAmmunition>();
            this.WareHouse[ammunition.Name].Add(ammunition);
        }
        else
        {
            //this.WearHouse[ammunition.Name][0].Number += ammunition.Number;
        }
    }

    private void AddSoldierToArmy(ISoldier soldier, string type)
    {
        if (!this.Army.ContainsKey(type))
        {
            this.Army[type] = new List<ISoldier>();
        }
        this.Army[type].Add(soldier);
    }
}

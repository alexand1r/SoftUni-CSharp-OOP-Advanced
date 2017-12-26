using System.Collections.Generic;
using System.Reflection;
using NUnit.Framework;

[TestFixture]
public class Class1
{
    private MissionController missionController;
    private SoldierFactory soldierFactory;
    private AmmunitionFactory ammunitionFactory;
    private MissionFactory missionFactory;

    [SetUp]
    public void InitInventory()
    {
        this.missionController = new MissionController(new Army(), new WareHouse());
        this.soldierFactory = new SoldierFactory();
        this.ammunitionFactory = new AmmunitionFactory();
        this.missionFactory = new MissionFactory();
    }

    [Test]
    public void CreateMission()
    {
        this.missionController.Missions.Enqueue(this.missionFactory.CreateMission("Easy", 50));
        this.missionController.Missions.Enqueue(this.missionFactory.CreateMission("Medium", 600));
        this.missionController.Missions.Enqueue(this.missionFactory.CreateMission("Hard", 1000));

        Assert.AreEqual(3, this.missionController.Missions.Count);
    }

    [Test]
    public void ExecuteMissionTestResultIfOnHold()
    {
        this.missionController.Missions.Enqueue(this.missionFactory.CreateMission("Easy", 50));
        IMission mission = this.missionController.Missions.Peek();
        
        string result = this.missionController.PerformMission(mission);

        Assert.AreEqual("Mission on hold - Suppression of civil rebellion", result);
    }

    [Test]
    public void ExecuteMissionTestRemainCountOfMissionsWhenOnHold()
    {
        this.missionController.Missions.Enqueue(this.missionFactory.CreateMission("Easy", 50));
        IMission mission = this.missionController.Missions.Peek();

        Assert.AreEqual(1, this.missionController.Missions.Count);
    }

    [Test]
    public void ExecuteMissionTestWhenMissionIsSuccessful()
    {
        this.missionController.Missions.Enqueue(this.missionFactory.CreateMission("Easy", 10));
        IMission mission = this.missionController.Missions.Peek();

        ISoldier soldier = this.soldierFactory.CreateSoldier("Ranker", "Pesho", 10, 20, 30);
        IAmmunition gun = this.ammunitionFactory.CreateAmmunition("Gun");
        IAmmunition automaticMachine = this.ammunitionFactory.CreateAmmunition("AutomaticMachine");
        IAmmunition helmet = this.ammunitionFactory.CreateAmmunition("Helmet");
        soldier.Weapons.Add("Gun", gun);
        soldier.Weapons.Add("AutomaticMachine", automaticMachine);
        soldier.Weapons.Add("Helmet", helmet);
        soldier.ReadyForMission(mission);
        this.missionController.Army.AddSoldier(soldier);

        string result = this.missionController.PerformMission(mission);

        Assert.AreEqual("Mission completed - Suppression of civil rebellion", result);
    }

    //[Test]
    //public void ExecuteMissionTestWhenMissionIsSuccessful2()
    //{
    //    this.missionController.Missions.Enqueue(this.missionFactory.CreateMission("Easy", 10));
    //    IMission mission = this.missionController.Missions.Peek();

    //    ISoldier soldier = this.soldierFactory.CreateSoldier("Ranker", "Pesho", 10, 20, 30);
    //    IAmmunition gun = this.ammunitionFactory.CreateAmmunition("Gun");
    //    IAmmunition automaticMachine = this.ammunitionFactory.CreateAmmunition("AutomaticMachine");
    //    IAmmunition helmet = this.ammunitionFactory.CreateAmmunition("Helmet");
    //    soldier.Weapons.Add("Gun", gun);
    //    soldier.Weapons.Add("AutomaticMachine", automaticMachine);
    //    soldier.Weapons.Add("Helmet", helmet);
    //    soldier.ReadyForMission(mission);
    //    this.missionController.Army.AddSoldier(soldier);

    //    Assert.AreEqual(0, this.missionController.Missions.Count);
    //}

    [Test]
    public void FailMissionsOnHold()
    {
        this.missionController.Missions.Enqueue(this.missionFactory.CreateMission("Easy", 50));
        this.missionController.Missions.Enqueue(this.missionFactory.CreateMission("Medium", 600));
        this.missionController.Missions.Enqueue(this.missionFactory.CreateMission("Hard", 1000));
        this.missionController.FailMissionsOnHold();
        this.missionController.Missions.Dequeue();

        Assert.AreEqual(2, this.missionController.FailedMissionCounter);
    }
}

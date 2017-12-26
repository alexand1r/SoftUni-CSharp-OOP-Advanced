using System.Collections.Generic;

public class Corporal : Soldier
{
    private const double OverallSkillMiltiplier = 2.5;
    private readonly IReadOnlyList<string> weaponsAllowed = new List<string>
    {
        "Gun",
        "AutomaticMachine",
        "MachineGun",
        "Helmet",
        "Knife"
    };
    public Corporal(string name, int age, double experience, double endurance) : base(name, age, experience, endurance)
    {
    }

    public override double OverallSkill
    {
        get { return this.OverallSkill; }
        set
        {
            if (base.OverallSkill * OverallSkillMiltiplier > 100)
                this.OverallSkill = 100;

            this.OverallSkill = base.OverallSkill * OverallSkillMiltiplier;
        }
    }

    protected override IReadOnlyList<string> WeaponsAllowed { get { return this.weaponsAllowed; } }
}


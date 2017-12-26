using System.Collections.Generic;

public class Ranker : Soldier
{
    private const double OverallSkillMiltiplier = 1.5;
    private readonly IReadOnlyList<string> weaponsAllowed = new List<string>
    {
        "Gun",
        "AutomaticMachine",
        "Helmet"
    };

    public Ranker(string name, int age, double experience, double endurance) : base(name, age, experience, endurance)
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

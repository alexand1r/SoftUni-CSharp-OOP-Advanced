using System;
using System.Collections.Generic;

public abstract class Mission : IMission
{
    private string name;
    private double enduranceRequired;
    private double scoreToComplete;
    private double wearLevelDecrement;
    private IList<IAmmunition> missionWeapons;

    protected Mission(string name, double enduranceRequired, double scoreToComplete, double wearLevelDecrement)
    {
        this.Name = name;
        this.EnduranceRequired = enduranceRequired;
        this.ScoreToComplete = scoreToComplete;
        this.WearLevelDecrement = wearLevelDecrement;
    }

    public string Name { get { return this.name; } set { this.name = value; } }
    public double EnduranceRequired { get { return this.enduranceRequired; } set { this.enduranceRequired = value; } }
    public double ScoreToComplete { get { return this.scoreToComplete; } set { this.scoreToComplete = value; } }
    public double WearLevelDecrement { get { return this.wearLevelDecrement; } set { this.wearLevelDecrement = value; } }
    public IList<IAmmunition> MissionWeapons { get { return this.missionWeapons; } set { this.missionWeapons = value; } }
}
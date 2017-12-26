public abstract class Ammunition : IAmmunition
{
    private string name;
    private double weight;
    private double wearLevel;
    private int number;
    protected Ammunition(string name, double weight)
    {
        this.Name = name;
        this.Weight = weight;
        this.WearLevel = this.Weight * 100;
    }
    
    public int Number { get { return this.number; } set { this.number = value; } }
    public string Name { get { return this.name; } set { this.name = value; } }
    public double Weight { get { return this.weight; } set { this.weight = value; } }

    public double WearLevel
    {
        get { return this.wearLevel; }
        set { this.wearLevel = value; }
    }

    public void DecreaseWearLevel(double wearAmount)
    {
        this.WearLevel -= 10d; //bug
    }

    public bool WearLevelIsZero { get; }
}


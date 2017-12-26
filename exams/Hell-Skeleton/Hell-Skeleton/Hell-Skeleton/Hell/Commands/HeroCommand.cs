using System.Collections.Generic;

public class HeroCommand : Command
{
    public HeroCommand(IList<string> arguments, IManager manager)
        : base(arguments, manager)
    {
    }
        
    public override string Execute()
    {
        return this.Manager.AddHero(this.Arguments);
    }
}
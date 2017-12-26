using System;
using System.Collections.Generic;

public class HeroCommand : Command
{
    public HeroCommand(IList<string> data, IManager manager)
        : base(data, manager)
    {
    }

    public override string Execute()
    {
        return this.Manager.AddHero(this.Data);
    }
}

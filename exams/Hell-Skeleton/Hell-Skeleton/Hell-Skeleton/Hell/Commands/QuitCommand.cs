using System;
using System.Collections.Generic;
using System.Security.Policy;
using Hell.Interfaces;

public class QuitCommand : Command
{
    public QuitCommand(IList<string> arguments, IManager manager)
        : base(arguments, manager)
    {
    }

    public override string Execute()
    {
        return this.Manager.Quit();
    }
}
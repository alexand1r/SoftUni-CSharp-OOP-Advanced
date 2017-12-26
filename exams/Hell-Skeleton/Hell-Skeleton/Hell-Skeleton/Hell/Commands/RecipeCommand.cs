﻿using System.Collections.Generic;

public class RecipeCommand : Command
{
    public RecipeCommand(IList<string> arguments, IManager manager)
        : base(arguments, manager)
    {
    }

    public override string Execute()
    {
        return base.Manager.AddRecipe(this.Arguments);
    }
}
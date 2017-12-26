using System.Collections.Generic;

public interface IManager
{
    IDictionary<string, IHero> Heroes { get; }

    string AddHero(IList<string> arguments);

    string AddItem(IList<string> arguments);

    string AddRecipe(IList<string> arguments);

    string Inspect(IList<string> arguments);

    string Quit();
}

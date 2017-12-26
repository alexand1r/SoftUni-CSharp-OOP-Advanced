using System.Collections.Generic;

public class RecipeItem : Item, IRecipe
{
    private IList<string> requiredItems;

    public RecipeItem(string name, int strengthBonus, int agilityBonus, int intelligenceBonus,
        int hitPointsBonus, int damageBonus, IList<string> requiredItems)
        : base(name, strengthBonus, agilityBonus, intelligenceBonus, hitPointsBonus, damageBonus)
    {
        this.RequiredItems = requiredItems;
    }

    public IList<string> RequiredItems
    {
        get { return this.requiredItems; }
        private set { this.requiredItems = value; }
    }
}

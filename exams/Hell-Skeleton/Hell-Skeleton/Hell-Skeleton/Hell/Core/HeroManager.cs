using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

public class HeroManager : IManager
{
    private readonly IDictionary<string, IHero> heroes;

    public HeroManager()
    {
        this.heroes = new Dictionary<string, IHero>();
    }

    public IDictionary<string, IHero> Heroes { get { return this.heroes; } }

    public string AddHero(IList<string> arguments)
    {
        string result = null;

        string heroName = arguments[0];
        string heroType = arguments[1];

        try
        {
            Type heroClass = Type.GetType(heroType);
            ConstructorInfo[] constructors = heroClass.GetConstructors();
            IHero hero = (IHero)constructors[0].Invoke(new object[] { heroName });
            this.heroes.Add(hero.Name, hero);

            result = string.Format(Constants.HeroCreateMessage, heroType, heroName);
        }
        catch (Exception e)
        {
            return e.Message;
        }

        return result;
    }

    public string AddItem(IList<string> arguments)
    {
        string result = null;

        string itemName = arguments[0];
        string heroName = arguments[1];
        int strengthBonus = int.Parse(arguments[2]);
        int agilityBonus = int.Parse(arguments[3]);
        int intelligenceBonus = int.Parse(arguments[4]);
        int hitPointsBonus = int.Parse(arguments[5]);
        int damageBonus = int.Parse(arguments[6]);

        IItem newItem = new CommonItem(itemName, strengthBonus,
            agilityBonus, intelligenceBonus, hitPointsBonus, damageBonus);
        this.heroes[heroName].AddItem(newItem);
            //Inventory.AddCommonItem(newItem);

        result = string.Format(Constants.ItemCreateMessage, itemName, heroName);

        return result;
    }

    public string AddRecipe(IList<string> arguments)
    {
        string result = null;

        string itemName = arguments[0];
        string heroName = arguments[1];
        int strengthBonus = int.Parse(arguments[2]);
        int agilityBonus = int.Parse(arguments[3]);
        int intelligenceBonus = int.Parse(arguments[4]);
        int hitPointsBonus = int.Parse(arguments[5]);
        int damageBonus = int.Parse(arguments[6]);

        List<string> requiredItems = arguments.Skip(7).ToList();

        IRecipe newItem = new RecipeItem(itemName, strengthBonus,
            agilityBonus, intelligenceBonus, hitPointsBonus, damageBonus, requiredItems);
        this.heroes[heroName].AddRecipe(newItem);
        //Inventory.AddCommonItem(newItem);

        result = string.Format(Constants.RecipeCreatedMessage, itemName, heroName);

        return result;
    }

    //public string AddItemToHero(IList<string> arguments)
    //{
    //    string result = null;

    //    string itemName = arguments[0];
    //    string heroName = arguments[1];
    //    int strengthBonus = int.Parse(arguments[2]);
    //    int agilityBonus = int.Parse(arguments[3]);
    //    int intelligenceBonus = int.Parse(arguments[4]);
    //    int hitPointsBonus = int.Parse(arguments[5]);
    //    int damageBonus = int.Parse(arguments[6]);

    //    if (arguments.Count > 7)
    //    {
    //        IList<string> requiredItems = arguments.Skip(7).ToList();

    //        IRecipe recipeItem = new RecipeItem(itemName, strengthBonus, agilityBonus, intelligenceBonus, hitPointsBonus, damageBonus, requiredItems);

    //        this.heroes[heroName].Inventory.AddRecipeItem(recipeItem);

    //        result = string.Format(Constants.RecipeCreatedMessage, itemName, heroName);

    //        return result;
    //    }

    //    IItem newItem = new CommonItem(itemName, strengthBonus,
    //        agilityBonus, intelligenceBonus, hitPointsBonus, damageBonus);
    //    this.heroes[heroName].Inventory.AddCommonItem(newItem);

    //    result = string.Format(Constants.ItemCreateMessage, itemName, heroName);

    //    return result;
    //}

    public string Inspect(IList<string> arguments)
    {
        string heroName = arguments[0];

        return this.heroes[heroName].ToString();
    }

    public string Quit()
    {
        StringBuilder result = new StringBuilder();

        int count = 1;

        ICollection<IHero> heroes = this.Heroes.Values
            .OrderByDescending(h => h.PrimaryStats).ThenByDescending(h => h.SecondaryStats).ToList();

        foreach (IHero hero in heroes)
        {
            result.AppendLine($"{count++}. {hero.GetType().Name}: {hero.Name}");
            result.AppendLine($"###HitPoints: {hero.HitPoints}");
            result.AppendLine($"###Damage: {hero.Damage}");
            result.AppendLine($"###Strength: {hero.Strength}");
            result.AppendLine($"###Agility: {hero.Agility}");
            result.AppendLine($"###Intelligence: {hero.Intelligence}");

            ICollection<string> itemNames = hero.Items.Select(i => i.Name).ToList();

            if (itemNames.Count == 0)
            {
                result.AppendLine("###Items: None");
            }
            else
            {
                result.AppendLine("###Items: " + string.Join(", ", itemNames));
            }
        }

        return result.ToString().Trim();
    }
}
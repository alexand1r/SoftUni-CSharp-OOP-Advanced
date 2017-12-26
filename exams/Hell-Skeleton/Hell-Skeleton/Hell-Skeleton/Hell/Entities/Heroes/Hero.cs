using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

public class Hero : IHero, IComparable<Hero>
{
    private IInventory inventory;
    private long strength;
    private long agility;
    private long intelligence;
    private long hitPoints;
    private long damage;

    protected Hero(string name, int strength, int agility, int intelligence, int hitPoints, int damage)
    {
        this.Name = name;
        this.Strength = strength;
        this.Agility = agility;
        this.Intelligence = intelligence;
        this.HitPoints = hitPoints;
        this.Damage = damage;
        this.Inventory = new HeroInventory();
    }

    public string Name { get; private set; }
    public IInventory Inventory { get; private set; }

    public long Strength
    {
        get { return this.strength + this.Inventory.TotalStrengthBonus; }
        set { this.strength = value; }
    }

    public long Agility
    {
        get { return this.agility + this.Inventory.TotalAgilityBonus; }
        set { this.agility = value; }
    }

    public long Intelligence
    {
        get { return this.intelligence + this.Inventory.TotalIntelligenceBonus; }
        set { this.intelligence = value; }
    }

    public long HitPoints
    {
        get { return this.hitPoints + this.Inventory.TotalHitPointsBonus; }
        set { this.hitPoints = value; }
    }

    public long Damage
    {
        get { return this.damage + this.Inventory.TotalDamageBonus; }
        set { this.damage = value; }
    }

    public long PrimaryStats
    {
        get { return this.Strength + this.Agility + this.Intelligence; }
    }

    public long SecondaryStats
    {
        get { return this.Strength + this.Agility + this.Intelligence; }
    }

    //REFLECTION

    public ICollection<IItem> Items
    {
        get
        {
            //Type inventoryType = this.Inventory.GetType();
            //FieldInfo commonItemsField = inventoryType
            //    .GetFields(BindingFlags.Static | BindingFlags.Instance | BindingFlags.NonPublic)
            //    .FirstOrDefault(f => Attribute.IsDefined(f, typeof(ItemAttribute)));

            //Dictionary<string, IItem> commonItems =
            //    (Dictionary<string, IItem>)commonItemsField.GetValue(this.Inventory);

            //return commonItems.Values.ToList();
            ///////
            //Type classType = this.inventory.GetType();
            //FieldInfo field = classType.GetField("commonItems", BindingFlags.NonPublic | BindingFlags.Instance);
            //Dictionary<string, IItem> items = (Dictionary<string, IItem>)field.GetValue(this.inventory);
            //return items.Select(x => x.Value).ToList();
            ////////
            Type clazz = typeof(HeroInventory);
            var field = clazz.GetFields(BindingFlags.Instance | BindingFlags.NonPublic).FirstOrDefault(f => f.GetCustomAttributes(typeof(ItemAttribute)) != null);

            var collection = (Dictionary<string, IItem>)field.GetValue(this.Inventory);

            return collection.Values.ToList();
        }
    }

    public void AddItem(IItem item)
    {
        this.Inventory.AddCommonItem(item);
    }

    public void AddRecipe(IRecipe recipe)
    {
        this.Inventory.AddRecipeItem(recipe);
    }

    public int CompareTo(Hero other)
    {
        if (ReferenceEquals(this, other))
        {
            return 0;
        }
        if (ReferenceEquals(null, other))
        {
            return 1;
        }
        var primary = this.PrimaryStats.CompareTo(other.PrimaryStats);
        if (primary != 0)
        {
            return primary;
        }
        return this.SecondaryStats.CompareTo(other.SecondaryStats);
    }

    public override string ToString()
    {
        StringBuilder result = new StringBuilder();

        result.AppendLine($"Hero: {this.Name}, Class: {this.GetType().Name}");
        result.AppendLine($"HitPoints: {this.HitPoints}, Damage: {this.Damage}");
        result.AppendLine($"Strength: {this.Strength}");
        result.AppendLine($"Agility: {this.Agility}");
        result.AppendLine($"Intelligence: {this.Intelligence}");

        ICollection<IItem> commonItems = this.Items;

        if (commonItems.Count == 0)
        {
            result.Append("Items: None");
        }
        else
        {
            result.AppendLine("Items:");
            foreach (IItem item in commonItems)
            {
                result.AppendLine(item.ToString());
            }
        }

        return result.ToString().Trim();
    }
}
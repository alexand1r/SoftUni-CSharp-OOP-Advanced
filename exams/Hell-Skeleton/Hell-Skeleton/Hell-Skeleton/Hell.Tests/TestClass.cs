using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using NUnit.Framework;

[TestFixture]
public class TestClass
{
    private IInventory inventory;

    [SetUp]
    public void InitInventory()
    {
        this.inventory = new HeroInventory();

    }

    [Test]
    public void AddCommonItem()
    {
        CommonItem item = new CommonItem("item", 10, 0, 0, 0, 0);

        this.inventory.AddCommonItem(item);
        Type clazz = typeof(HeroInventory);
        var field = clazz.GetFields(BindingFlags.Instance | BindingFlags.NonPublic).FirstOrDefault(f => f.GetCustomAttributes(typeof(ItemAttribute)) != null);

        var collection = (Dictionary<string, IItem>)field.GetValue(this.inventory);
        
        Assert.AreEqual(1, collection.Count);
    }

    public void AddRecipeItem()
    {
        RecipeItem item = new RecipeItem("item", 10, 0, 0, 0, 0, new List<string>());

        this.inventory.AddCommonItem(item);
        Type clazz = typeof(HeroInventory);
        var field = clazz.GetField("recipeItems", BindingFlags.Instance | BindingFlags.NonPublic);
        var collection = (Dictionary<string, IRecipe>) field.GetValue(this.inventory);
        Assert.AreEqual(1, collection.Count);
    }

    [Test]
    public void StrengthBonusFromItems()
    {
        CommonItem item = new CommonItem("item", 1, 2, 3, 4, 5);

        this.inventory.AddCommonItem(item);

        Assert.AreEqual(1, this.inventory.TotalStrengthBonus);
    }

    [Test]
    public void AddUniqueItemToInventory()
    {
        var item = new CommonItem("Knife", 0, 10, 0, 0, 30);
        var item1 = new CommonItem("Knife", 0, 10, 0, 0, 30);


        this.inventory.AddCommonItem(item);


        Assert.Throws<ArgumentException>(() => this.inventory.AddCommonItem(item1));
    }

    [Test]
    public void AddItemsToInventory()
    {
        var item = new CommonItem("Knife", 0, 10, 0, 0, 30);
        var item1 = new CommonItem("Sword", 0, 10, 0, 0, 30);


        this.inventory.AddCommonItem(item);
        this.inventory.AddCommonItem(item1);

        var type = typeof(HeroInventory);
        var field = type
            .GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
            .FirstOrDefault(f => f.GetCustomAttributes(typeof(ItemAttribute), true).Length != 0);

        Dictionary<string, IItem> items = (Dictionary<string, IItem>)field.GetValue(this.inventory);
        var list = items.Select(x => x.Value).ToList();

        Assert.AreEqual(2, list.Count);
    }

    [Test]
    public void AddRecipe()
    {
        var item = new CommonItem("Knife", 0, 10, 0, 0, 30);
        var item1 = new CommonItem("Sword", 0, 10, 0, 0, 30);


        this.inventory.AddCommonItem(item);
        this.inventory.AddCommonItem(item1);

        var type = typeof(HeroInventory);
        var commonItemsField = type
            .GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
            .FirstOrDefault(f => f.GetCustomAttributes(typeof(ItemAttribute), true).Length != 0);

        Dictionary<string, IItem> items = (Dictionary<string, IItem>)commonItemsField.GetValue(this.inventory);
        var listCommonItems = items.Select(x => x.Value).ToList();
        var listOfRequiredItems = new List<string>() { "Knife", "Stick" };
        var recipe = new RecipeItem("Spear", 25, 10, 10, 100, 50, listOfRequiredItems);

        this.inventory.AddRecipeItem(recipe);

        var recipeField = type
            .GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
            .FirstOrDefault(n => n.Name == "recipeItems");

        Dictionary<string, IRecipe> recipes = (Dictionary<string, IRecipe>)recipeField.GetValue(this.inventory);
        var listRecipes = recipes.Select(x => x.Value).ToList();


    }

    [Test]
    public void RemoveRequiredItems()
    {
        var item = new CommonItem("Knife", 0, 10, 0, 0, 30);
        var item1 = new CommonItem("Stick", 0, 10, 0, 0, 30);
        var listOfRequiredItems = new List<string>() { "Knife", "Stick" };
        var recipe = new RecipeItem("Spear", 25, 10, 10, 100, 50, listOfRequiredItems);


        this.inventory.AddCommonItem(item);
        this.inventory.AddCommonItem(item1);
        this.inventory.AddRecipeItem(recipe);

        var type = typeof(HeroInventory);
        var commonItemsField = type
            .GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
            .FirstOrDefault(f => f.GetCustomAttributes(typeof(ItemAttribute), true).Length != 0);

        Dictionary<string, IItem> items = (Dictionary<string, IItem>)commonItemsField.GetValue(this.inventory);
        var listCommonItems = items.Select(x => x.Value).ToList();




        var recipeField = type
            .GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
            .FirstOrDefault(n => n.Name == "recipeItems");

        Dictionary<string, IRecipe> recipes = (Dictionary<string, IRecipe>)recipeField.GetValue(this.inventory);
        var listRecipes = recipes.Select(x => x.Value).ToList();

        Assert.AreEqual(1, listCommonItems.Count);
    }

    [Test]
    public void AddItemCheckingTotalStregth()
    {
        var item = new CommonItem("Knife", 50, 10, 0, 0, 30);
        var item1 = new CommonItem("Stick", 5, 10, 0, 0, 30);

        this.inventory.AddCommonItem(item);
        this.inventory.AddCommonItem(item1);


        Assert.AreEqual(55, this.inventory.TotalStrengthBonus);

    }

    [Test]
    public void AddItemCheckingTotalAgility()
    {
        var item = new CommonItem("Knife", 50, 10, 0, 0, 30);
        var item1 = new CommonItem("Stick", 5, 10, 0, 0, 30);

        this.inventory.AddCommonItem(item);
        this.inventory.AddCommonItem(item1);


        Assert.AreEqual(20, this.inventory.TotalAgilityBonus);

    }


    [Test]
    public void AddItemCheckingTotalHitPoints()
    {
        var item = new CommonItem("Knife", 50, 10, 0, 200, 30);
        var item1 = new CommonItem("Stick", 5, 10, 0, 15, 30);

        this.inventory.AddCommonItem(item);
        this.inventory.AddCommonItem(item1);


        Assert.AreEqual(215, this.inventory.TotalHitPointsBonus);

    }

    [Test]
    public void AddItemCheckingTotalDamage()
    {
        var item = new CommonItem("Knife", 50, 10, 0, 0, 30);
        var item1 = new CommonItem("Stick", 5, 10, 0, 0, 30);

        this.inventory.AddCommonItem(item);
        this.inventory.AddCommonItem(item1);


        Assert.AreEqual(60, this.inventory.TotalDamageBonus);

    }



    [Test]
    public void PropertyTotalStrengthAfterAddRecipe()
    {
        var item = new CommonItem("Knife", 0, 10, 0, 0, 30);
        var item1 = new CommonItem("Stick", 0, 10, 0, 0, 30);
        var listOfRequiredItems = new List<string>() { "Knife", "Stick" };
        var recipe = new RecipeItem("Spear", 25, 10, 10, 100, 50, listOfRequiredItems);


        this.inventory.AddCommonItem(item);
        this.inventory.AddCommonItem(item1);
        this.inventory.AddRecipeItem(recipe);


        Assert.AreEqual(50, this.inventory.TotalDamageBonus);
    }


    [Test]
    public void DefaulValueOfProperty()
    {
        Assert.AreEqual(0, this.inventory.TotalDamageBonus);
        Assert.AreEqual(0, this.inventory.TotalAgilityBonus);
        Assert.AreEqual(0, this.inventory.TotalStrengthBonus);
        Assert.AreEqual(0, this.inventory.TotalHitPointsBonus);
        Assert.AreEqual(0, this.inventory.TotalIntelligenceBonus);
    }

    [Test]
    public void AddingNullItemThrowsException()
    {
        IItem item = null;
        var heroInventory = new HeroInventory();

        Assert.Throws<NullReferenceException>(() => heroInventory.AddCommonItem(item));
    }

    [Test]
    public void AddingNullRecipeThrowsException()
    {
        IRecipe recipe = null;
        var heroInventory = new HeroInventory();

        Assert.Throws<NullReferenceException>(() => heroInventory.AddRecipeItem(recipe));
    }

    [Test]
    public void TwoItemsWithSameNameThrowException()
    {
        var item1 = new CommonItem("Sword", 10, 10, 10, 10, 10);
        var item2 = new CommonItem("Sword", 10, 10, 10, 10, 10);

        this.inventory.AddCommonItem(item1);

        Assert.Throws<ArgumentException>(() => this.inventory.AddCommonItem(item2));
    }

    [Test]
    public void TotalStatsBonus()
    {
        var item1 = new CommonItem("Sword", 10, 10, 10, 10, 10);

        this.inventory.AddCommonItem(item1);

        long totalStatsBonus = this.inventory.TotalAgilityBonus +
                               this.inventory.TotalDamageBonus +
                               this.inventory.TotalHitPointsBonus +
                               this.inventory.TotalIntelligenceBonus +
                               this.inventory.TotalStrengthBonus;

        Assert.AreEqual(50, totalStatsBonus);
    }

    [Test]
    public void NewInventoryStatsAreZero()
    {
        long totalStatsBonus = this.inventory.TotalAgilityBonus
                               + this.inventory.TotalStrengthBonus
                               + this.inventory.TotalIntelligenceBonus
                               + this.inventory.TotalHitPointsBonus
                               + this.inventory.TotalDamageBonus;

        Assert.AreEqual(0, totalStatsBonus);
    }

    [Test]
    public void GetBonusFromCommonItem()
    {
        IItem item = new CommonItem("TestItem", 1, 1, 1, 1, 1);

        this.inventory.AddCommonItem(item);

        Assert.AreEqual(1, this.inventory.TotalAgilityBonus);
        Assert.AreEqual(1, this.inventory.TotalDamageBonus);
        Assert.AreEqual(1, this.inventory.TotalHitPointsBonus);
        Assert.AreEqual(1, this.inventory.TotalIntelligenceBonus);
        Assert.AreEqual(1, this.inventory.TotalStrengthBonus);
    }

    [Test]
    public void CreatingNewHeroInventoryIsSuccessful()
    {
        Assert.Pass();
    }

    [Test]
    public void AddCommonItemIsSuccessful()
    {
        IItem item = new CommonItem("Axe", 10, 10, 10, 10, 10);

        this.inventory.AddCommonItem(item);

        Assert.Pass();
    }
    ///////////////////////////
    [Test]
    public void AddCommonItemChangesStats()
    {
        IItem item = new CommonItem("Axe", 10, 10, 10, 10, 10);

        this.inventory.AddCommonItem(item);
        long totalStatsBonus = this.inventory.TotalAgilityBonus
                               + this.inventory.TotalStrengthBonus
                               + this.inventory.TotalIntelligenceBonus
                               + this.inventory.TotalHitPointsBonus
                               + this.inventory.TotalDamageBonus;

        Assert.AreEqual(50, totalStatsBonus);
    }

    [Test]
    public void AddCommonItemChangesDamage()
    {
        IItem item = new CommonItem("Axe", 10, 10, 10, 10, 10);

        this.inventory.AddCommonItem(item);

        Assert.AreEqual(10, this.inventory.TotalDamageBonus);
    }

    [Test]
    public void AddCommonItemChangesHp()
    {
        IItem item = new CommonItem("Axe", 10, 10, 10, 10, 10);

        this.inventory.AddCommonItem(item);

        Assert.AreEqual(10, this.inventory.TotalHitPointsBonus);
    }

    [Test]
    public void RecipeCompletionChangesStats()
    {
        List<string> recipeComponents = new List<string>() { "Axe", "Shield" };
        IRecipe recipe = new RecipeItem("MegaWeapon", 100, 100, 100, 100, 100, recipeComponents);
        IItem axe = new CommonItem("Axe", 10, 10, 10, 10, 10);
        IItem shield = new CommonItem("Shield", 20, 20, 20, 20, 20);

        this.inventory.AddCommonItem(axe);
        this.inventory.AddCommonItem(shield);
        this.inventory.AddRecipeItem(recipe);
        long totalStatsBonus = this.inventory.TotalAgilityBonus
                               + this.inventory.TotalStrengthBonus
                               + this.inventory.TotalIntelligenceBonus
                               + this.inventory.TotalHitPointsBonus
                               + this.inventory.TotalDamageBonus;

        Assert.AreEqual(500, totalStatsBonus);
    }
    ////////////////////
    //[Test]
    //public void FieldsAccessModifierTest()
    //{
    //    HeroInventory inventory = new HeroInventory();

    //    FieldInfo[] inventoryType = inventory.GetType().GetFields();

    //    Assert.AreEqual(0, inventoryType.Length, "Field must be private!");
    //}

    //[Test]
    //public void PublicPropertiesCountTest()
    //{
    //    HeroInventory heroInventory = new HeroInventory();

    //    PropertyInfo[] publicProperties = heroInventory.GetType().GetProperties();

    //    Assert.AreEqual(5, publicProperties.Length, "Invalid properties access modifiers!");
    //}

    //[Test]
    //public void PublicMethodsCountTest()
    //{
    //    HeroInventory heroInventory = new HeroInventory();

    //    MethodInfo[] publicMethods = heroInventory.GetType().GetMethods();

    //    Assert.AreEqual(11, publicMethods.Length, "Wrong method access modifiers!");
    //}

    //[Test]
    //public void PrivateFieldsCountTest()
    //{
    //    HeroInventory heroInventory = new HeroInventory();

    //    MethodInfo[] privateMethods = heroInventory.GetType()
    //        .GetMethods(BindingFlags.Static | BindingFlags.Instance | BindingFlags.NonPublic);

    //    Assert.GreaterOrEqual(privateMethods.Length, 2);
    //}
}
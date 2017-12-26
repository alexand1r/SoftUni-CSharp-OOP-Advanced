using System.Text;

public class CommonItem : Item
{
    public CommonItem(string name, int strengthBonus, int agilityBonus,
        int intelligenceBonus, int hitPointsBonus, int damageBonus)
        : base(name, strengthBonus, agilityBonus, intelligenceBonus, hitPointsBonus, damageBonus)
    {

    }

    public override string ToString()
    {
        StringBuilder result = new StringBuilder();

        result.AppendLine($"###Item: {this.Name}");
        result.AppendLine($"###+{this.StrengthBonus} Strength");
        result.AppendLine($"###+{this.AgilityBonus} Agility");
        result.AppendLine($"###+{this.IntelligenceBonus} Intelligence");
        result.AppendLine($"###+{this.HitPointsBonus} HitPoints");
        result.Append($"###+{this.DamageBonus} Damage");

        return result.ToString();
    }
}

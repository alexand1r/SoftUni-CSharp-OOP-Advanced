using System.Collections.Generic;

public class Easy : Mission
{
    private const double BaseEnduranceRequired = 20;
    private const string BaseName = "Suppression of civil rebellion";
    private const int BaseDecrement = 30;
    public Easy(double scoreToComplete) : base (BaseName, BaseEnduranceRequired, scoreToComplete, BaseDecrement)
    {
    }
}
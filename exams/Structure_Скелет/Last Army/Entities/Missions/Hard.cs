using System.Collections.Generic;

public class Hard : Mission
{
    private const double BaseEnduranceRequired = 80;
    private const string BaseName = "Disposal of terrorists";
    private const int BaseDecrement = 70;
    public Hard(double scoreToComplete) : base (BaseName, BaseEnduranceRequired, scoreToComplete, BaseDecrement)
    {
    }
}
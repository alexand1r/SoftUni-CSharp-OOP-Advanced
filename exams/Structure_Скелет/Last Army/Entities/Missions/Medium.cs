using System.Collections.Generic;

public class Medium : Mission
{
    private const double BaseEnduranceRequired = 50;
    private const string BaseName = "Capturing dangerous criminals";
    private const int BaseDecrement = 50;
    public Medium(double scoreToComplete) : base (BaseName, BaseEnduranceRequired, scoreToComplete, BaseDecrement)
    {
    }
}
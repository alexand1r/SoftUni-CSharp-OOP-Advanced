using System.Collections.Generic;

public class Data
{

    public Data()
    {
        InitData();
    }


    public Dictionary<string, IPrivate> Privates { get; set; }

    public IList<ISoldier> Army { get; set; }

    private void InitData()
    {
        this.Privates = new Dictionary<string, IPrivate>();
        this.Army = new List<ISoldier>();
    }

}
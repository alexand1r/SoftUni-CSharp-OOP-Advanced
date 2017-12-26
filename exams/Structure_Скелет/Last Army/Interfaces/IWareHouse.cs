public interface IWareHouse
{
    string Name { get; }
    
    double Weight { get; }

    void EquipArmy(IArmy army);
}

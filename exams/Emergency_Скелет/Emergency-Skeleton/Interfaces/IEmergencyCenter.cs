namespace Emergency_Skeleton.Interfaces
{
    using System;

    public interface IEmergencyCenter
    {
        string Name { get; }

        int AmountOfMaximumEmergencies { get; }

        Boolean IsForRetirement();
    }
}

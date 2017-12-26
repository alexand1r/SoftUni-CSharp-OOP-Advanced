namespace Emergency_Skeleton.Interfaces
{
    using Emergency_Skeleton.Enums;
    using Emergency_Skeleton.Utils;

    public interface IEmergency
    {
        string Description { get; }

        EmergencyLevel Level { get; }

        RegistrationTime Time { get; }
    }
}

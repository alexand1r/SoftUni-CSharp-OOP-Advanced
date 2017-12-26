namespace Emergency_Skeleton.Models.EmergencyCenters
{
    using System;
    using Emergency_Skeleton.Collection;

    public class MedicalEmergencyCenter : BaseEmergencyCenter
    {
        public MedicalEmergencyCenter(string name, int amountOfMaximumEmergencies) : base(name, amountOfMaximumEmergencies)
        {
        }

        public override bool IsForRetirement()
        {
            throw new NotImplementedException();
        }
    }
}

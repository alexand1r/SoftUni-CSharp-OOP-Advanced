﻿namespace Emergency_Skeleton.Models.EmergencyCenters
{
    using System;
    using Emergency_Skeleton.Collection;

    public class PoliceEmergencyCenter : BaseEmergencyCenter
    {
        public PoliceEmergencyCenter(string name, int amountOfMaximumEmergencies) : base(name, amountOfMaximumEmergencies)
        {
        }

        public override bool IsForRetirement()
        {
            throw new NotImplementedException();
        }
    }
}

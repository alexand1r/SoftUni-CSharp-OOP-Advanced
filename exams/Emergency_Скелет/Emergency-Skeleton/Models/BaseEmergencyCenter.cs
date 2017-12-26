namespace Emergency_Skeleton.Models
{
    using Emergency_Skeleton.Collection;
    using Emergency_Skeleton.Interfaces;
    using System;

    public abstract class BaseEmergencyCenter : IEmergencyCenter
    {
        private string name;

        private int amountOfMaximumEmergencies;

        protected BaseEmergencyCenter(string name, int amountOfMaximumEmergencies)
        {
            this.Name = name;
            this.AmountOfMaximumEmergencies = amountOfMaximumEmergencies;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                this.name = value;
            }
        }

        public int AmountOfMaximumEmergencies
        {
            get
            {
                return this.amountOfMaximumEmergencies;
            }
            private set
            {
                this.amountOfMaximumEmergencies = value;
            }
        }

        public abstract Boolean IsForRetirement();
    }
}

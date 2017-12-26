namespace Emergency_Skeleton.Models.Emergencies
{
    using Emergency_Skeleton.Enums;
    using Emergency_Skeleton.Utils;

    public class HealthEmergency : BaseEmergency
    {
        private int casualties;

        public HealthEmergency(string description, EmergencyLevel emergencyLevel, RegistrationTime registrationTime, int casualties) : base(description, emergencyLevel, registrationTime)
        {
            this.Casualties = casualties;
        }

        public int Casualties
        {
            get { return this.casualties; }
            private set { this.casualties = value; }
        }
    }
}

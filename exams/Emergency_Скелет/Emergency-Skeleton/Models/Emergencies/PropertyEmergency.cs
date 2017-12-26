namespace Emergency_Skeleton.Models.Emergencies
{
    using Emergency_Skeleton.Enums;
    using Emergency_Skeleton.Utils;

    public class PropertyEmergency : BaseEmergency
    {
        private int damage;

        public PropertyEmergency(string description, EmergencyLevel emergencyLevel, RegistrationTime registrationTime, int damage) : base(description, emergencyLevel, registrationTime)
        {
            this.Damage = damage;
        }

        public int Damage
        {
            get { return this.damage; }
            private set { this.damage = value; }
        }
    }
}

namespace Emergency_Skeleton.Models.Emergencies
{
    using Emergency_Skeleton.Enums;
    using Emergency_Skeleton.Utils;

    public class OrderEmergency : BaseEmergency
    {
        private string status;

        public OrderEmergency(string description, EmergencyLevel emergencyLevel, RegistrationTime registrationTime, string status) : base(description, emergencyLevel, registrationTime)
        {
            this.Status = status;
        }

        public string Status
        {
            get { return this.status; }
            private set { this.status = value; }
        }
    }
}

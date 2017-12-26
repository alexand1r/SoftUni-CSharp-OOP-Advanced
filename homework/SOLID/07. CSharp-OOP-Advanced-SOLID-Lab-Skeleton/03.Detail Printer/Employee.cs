namespace _03.Detail_Printer
{
    public class Employee
    {
        private string name;
        public Employee(string name)
        {
            this.Name = name;
        }

        public string Name
        {
            get { return this.name; }
            private set { this.name = value; }
        }

        public override string ToString()
        {
            return $"Name: {this.name}";
        }
    }
}
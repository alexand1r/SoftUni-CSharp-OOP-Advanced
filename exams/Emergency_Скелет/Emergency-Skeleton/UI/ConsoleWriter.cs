namespace Emergency_Skeleton.UI
{
    using System;
    using Emergency_Skeleton.Interfaces;
    public class ConsoleWriter : IWriter
    {
        public void WriteLine(string message)
        {
            Console.WriteLine(message);
        }
    }
}

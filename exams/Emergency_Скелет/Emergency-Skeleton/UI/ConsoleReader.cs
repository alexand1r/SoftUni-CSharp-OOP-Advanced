namespace Emergency_Skeleton.UI
{
    using System;
    using Emergency_Skeleton.Interfaces;
    public class ConsoleReader : IReader
    {
        public string Readline()
        {
            return Console.ReadLine();
        }
    }
}

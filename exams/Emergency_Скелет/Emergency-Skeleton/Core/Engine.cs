namespace Emergency_Skeleton.Core
{
    using Emergency_Skeleton.Interfaces;
    using Emergency_Skeleton.UI;

    public class Engine : IEngine
    {
        public Engine(ICommandHandler commandHandler, IReader reader, IWriter writer)
        {
            this.CommandHandler = commandHandler;
            this.Reader = reader;
            this.Writer = writer;
        }

        public Engine() : this(new CommandHandler(), new ConsoleReader(), new ConsoleWriter())
        {
        }

        public IReader Reader { get; }

        public IWriter Writer { get; }

        public ICommandHandler CommandHandler { get; }

        public void Run()
        {
            
        }
    }
}

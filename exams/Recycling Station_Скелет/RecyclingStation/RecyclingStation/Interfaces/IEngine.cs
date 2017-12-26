namespace RecyclingStation.Interfaces
{
    using RecyclingStation.Interfaces.UI;

    public interface IEngine : IRunnable
    {
        ICommandHandler CommandHandler { get; }

        IReader Reader { get; }

        IWriter Writer { get; }
    }
}

namespace Emergency_Skeleton.Interfaces
{
    public interface IEngine : IRunnable
    {
        IReader Reader { get; }

        IWriter Writer { get; }

        ICommandHandler CommandHandler { get; }
    }
}

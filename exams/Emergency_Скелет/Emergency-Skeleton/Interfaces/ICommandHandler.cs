namespace Emergency_Skeleton.Interfaces
{

    public interface ICommandHandler
    {
        ICommand ParseCommand(params object[] data);
    }
}

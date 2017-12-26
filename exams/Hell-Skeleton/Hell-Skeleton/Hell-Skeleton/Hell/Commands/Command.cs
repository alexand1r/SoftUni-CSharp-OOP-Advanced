using System.Collections.Generic;
using Hell.Interfaces;

public abstract class Command : ICommand
{
    private IManager manager;
    private IList<string> arguments;

    protected Command(IList<string> arguments, IManager manager)
    {
        this.Manager = manager;
        this.Arguments = arguments;
    }

    public IManager Manager
    {
        get { return this.manager; }
        private set { this.manager = value; }
    }

    protected IList<string> Arguments
    {
        get { return this.arguments; }
        private set { this.arguments = value; }
    }

    public abstract string Execute();
}

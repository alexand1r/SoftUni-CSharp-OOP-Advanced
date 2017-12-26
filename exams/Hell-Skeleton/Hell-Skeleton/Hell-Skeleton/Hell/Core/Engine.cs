using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Hell.Interfaces;

public class Engine : IEngine
{
    private readonly IInputReader reader;
    private readonly IOutputWriter writer;
    private readonly IManager heroManager;

    public Engine(IInputReader reader, IOutputWriter writer, IManager heroManager)
    {
        this.reader = reader;
        this.writer = writer;
        this.heroManager = heroManager;
    }

    public void Run()
    {
        bool isRunning = true;

        while (isRunning)
        {
            string inputLine = this.reader.ReadLine();
            IList<string> arguments = this.ParseInput(inputLine);
            this.writer.WriteLine(this.ProcessInput(arguments));
            isRunning = !this.IsRunning(inputLine);
        }
    }

    private IList<string> ParseInput(string input)
    {
        return input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToList();
    }

    private string ProcessInput(IList<string> arguments)
    {
        string command = arguments[0];
        arguments.RemoveAt(0);

        Type commandType = Type.GetType(command + "Command");
        ConstructorInfo constructor = commandType.GetConstructor(new Type[] { typeof(IList<string>), typeof(IManager) });
        ICommand cmd = (Command)constructor.Invoke(new object[] { arguments, this.heroManager });

        return cmd.Execute();
    }

    private bool IsRunning(string inputLine)
    {
        return inputLine.Equals("Quit");
    }
}
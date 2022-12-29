using System;
using SpaceBattle.Interface;

namespace SpaceBattle
{
    public class LogCommand : ICommand
    {
        Exception Exception;
        ICommand Cmd;

        public LogCommand(Exception exception, ICommand cmd)
        {
            this.Cmd = cmd;
            this.Exception = exception;
        }

        public void Execute()
        {
            Console.WriteLine($"LOG: {Cmd.GetType()}, {Exception.Message}, {Exception.StackTrace}");
        }
    }
}
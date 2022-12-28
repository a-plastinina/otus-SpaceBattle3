using System;

namespace SpaceBattle
{
    public class CommandException : Exception
    {
        public CommandException(string message): base(message)
        {          
        }
    }
}
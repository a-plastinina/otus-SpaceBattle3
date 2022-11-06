using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpaceBattle
{
    public class CommandException : Exception
    {
        public CommandException(string message): base(message)
        {          
        }
    }
}
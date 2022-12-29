using SpaceBattle.Interface;

namespace SpaceBattle
{
    public class MacroCommand : ICommand
    {
        ICommand[] _chainCommands;

        public MacroCommand(ICommand[] commands) => _chainCommands = commands;

        public void Execute()
        {
            foreach (var cmd in _chainCommands)
            {
                cmd.Execute();
            }
        }
    }
}
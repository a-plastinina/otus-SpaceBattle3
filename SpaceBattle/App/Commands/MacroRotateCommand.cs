using SpaceBattle.Interface;

namespace SpaceBattle
{
    public class MacroRotateCommand : ICommand
    {
        readonly ICommand[] _chainCommands = new ICommand[3];
        public MacroRotateCommand(IRotableForMove obj)
        {
            _chainCommands[0] = new RotateCommand(obj.rotatable);
            _chainCommands[1] = new ChangeVelocityCommand(obj);
            _chainCommands[2] = new MoveCommand(obj);
        }

        public void Execute()
        {
            foreach (var cmd in _chainCommands)
            {
                cmd.Execute();
            }
        }
    }
}
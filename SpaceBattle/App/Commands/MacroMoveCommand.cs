using SpaceBattle.Interface;

namespace SpaceBattle
{
    public class MacroMoveCommand : ICommand
    {
        readonly ICommand[] _chainCommands = new ICommand[3];
        public MacroMoveCommand(IFuelObject obj)
        {
            _chainCommands[0] = new CheckFuelCommand(obj);
            _chainCommands[1] = new MoveCommand(obj as IMovable);
            _chainCommands[2] = new BurnFuelCommand(obj);
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
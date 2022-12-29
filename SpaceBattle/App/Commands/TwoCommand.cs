using SpaceBattle.Interface;

namespace SpaceBattle
{
    public class TwoCommand : ICommand
    {
        public ICommand Cmd { get; }

        public TwoCommand(ICommand cmd)
        {
            this.Cmd = cmd;
        }

        public void Execute()
        {
            Cmd.Execute();
        }
    }
}
using SpaceBattle.Interface;

namespace SpaceBattle
{
    public class OneCommand : ICommand
    {
        public ICommand Cmd { get; }

        public OneCommand(ICommand cmd)
        {
            this.Cmd = cmd;
        }

        public void Execute()
        {
            Cmd.Execute();
        }
    }
}
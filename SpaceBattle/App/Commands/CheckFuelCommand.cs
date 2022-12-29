using SpaceBattle.Interface;

namespace SpaceBattle
{
    public class CheckFuelCommand : ICommand
    {
        IFuelObject _fuelObject;

        public CheckFuelCommand(IFuelObject fuelObject) => _fuelObject = fuelObject;

        public void Execute()
        {
            if (_fuelObject.Volume == 0) throw new CommandException("Недостаточно топлива");
            if (_fuelObject.FlowRate == 0) throw new CommandException("Незадано скорость расхода топлива");
            if (_fuelObject.Volume - _fuelObject.FlowRate < 0) throw new CommandException("Недостаточно топлива");
        }
    }
}
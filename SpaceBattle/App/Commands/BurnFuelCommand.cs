using SpaceBattle.Interface;

namespace SpaceBattle
{
    public class BurnFuelCommand: ICommand
    {
        IFuelObject _fuelObject;

        public BurnFuelCommand(IFuelObject fuelObject) => _fuelObject = fuelObject;

        public void Execute()
        {
            _fuelObject.Volume -= _fuelObject.FlowRate;
        }
    }
}
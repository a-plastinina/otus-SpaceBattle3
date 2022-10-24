using System;
using SpaceBattle.Interface;

namespace SpaceBattle
{
    public class RotateCommand
    {
        IRotable _rotable;
        public RotateCommand(IRotable rotable)
        {
            _rotable = rotable;
        }
        public void Execute()
        {
            if (_rotable.DirectionsNumber == 0) throw new DivideByZeroException("Не задано макс количество положений для поворота");
            _rotable.Direction = (_rotable.Direction + _rotable.AngularVelocity) % _rotable.DirectionsNumber;
        }
    }
}
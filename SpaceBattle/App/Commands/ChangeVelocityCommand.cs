using System;
using SpaceBattle.Interface;

namespace SpaceBattle
{
    public class ChangeVelocityCommand : ICommand
    {
        readonly IRotableForMove _movable; 
                
        public ChangeVelocityCommand(IRotableForMove rotable) => _movable = rotable;

        public void Execute()
        {
            //Реализовать команду для модификации вектора мгновенной скорости при повороте. 
            //Необходимо учесть, что не каждый разворачивающийся объект движется.
            if (_movable.rotatable != null)
                _movable.ChangeVelocity(getNewVelocity());
        }

        private Vector getNewVelocity()
        {
            return _movable.Velocity + new Vector(-1*(_movable.Position.X - _movable.rotatable.AngularVelocity), -1*_movable.Position.Y);
        }
    }
}
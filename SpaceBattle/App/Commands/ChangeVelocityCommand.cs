using System;
using SpaceBattle.Interface;

namespace SpaceBattle
{
    //Реализовать команду для модификации вектора мгновенной скорости при повороте. 
    //Необходимо учесть, что не каждый разворачивающийся объект движется.
    public class ChangeVelocityCommand : ICommand
    {
        readonly IRotableForMove _rotable; 
                
        public  ChangeVelocityCommand(IRotableForMove rotable) => _rotable = rotable;

        public void Execute()
        {
             if (_rotable.movable != null)
                _rotable.ChangeVelocity(getNewVelocity());
        }

        private Vector getNewVelocity()
        {
            // некоторое вычисление для получения новой скорости
            return new Vector(new Random(5).Next(), new Random(5).Next());
        }
    }
}
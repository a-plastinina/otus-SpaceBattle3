using System;
using SpaceBattle.Interface;

namespace SpaceBattle
{
    public class MoveCommand : ICommand
    {
        public IMovable _movableAdapter { get; }

        public MoveCommand(IMovable movableAdapter) => this._movableAdapter = movableAdapter;

        public void Execute()
        {
            if (_movableAdapter.Velocity is null) throw new NullReferenceException("У объекта невозможно прочитать скорость");            
            if (_movableAdapter.Position is null) throw new NullReferenceException("У объекта невозможно прочитать положение");

           _movableAdapter.Position += _movableAdapter.Velocity;
        }
    }
}
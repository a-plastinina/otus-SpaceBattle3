using System;
using SpaceBattle.Interface;

namespace SpaceBattle
{
    public class MovableAdapter : IMovable
    {
        private readonly IUniversalObject _obj;
        private Vector _position { get => (Vector)_obj["position"]; }
        private Vector _velocity { get => (Vector)_obj["velocity"]; }

        public MovableAdapter(IUniversalObject obj)
        {
            _obj = obj;
        }

        public Vector Position
        {
            get
            {
                return new Vector(
                    _position.X + _velocity.X * (int)Math.Cos((int)_obj["direction"] / 360 * (int)_obj["maxDirection"]),
                    _position.Y + _velocity.Y * (int)Math.Sin((int)_obj["direction"] / 360 * (int)_obj["maxDirection"])
                );
            }

            set => _obj["position"] = value;
        }

        public Vector Velocity { get => _velocity; }
    }
}
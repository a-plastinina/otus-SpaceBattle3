using System;
using SpaceBattle.Interface;

namespace SpaceBattle
{
    public class MovableAdapter : IMovable//, IRotable
    {
        private readonly IUniversalObject _obj;
        private Vector _position { get => (Vector)_obj["position"]; }

        public MovableAdapter(IUniversalObject obj)
        {
            _obj = obj;
        }

        public Vector Position
        {
            get => (Vector)_obj["position"];
            set => _obj["position"] = value;
        }

        public Vector Velocity
        {
            get
            {
                return new Vector(
                    (int)((int)_obj["velocity"] * Math.Cos(2 * Math.PI / (int)_obj["maxDirection"] * (int)_obj["direction"])),
                    (int)((int)_obj["velocity"] * Math.Sin(2 * Math.PI / (int)_obj["maxDirection"] * (int)_obj["direction"]))
                );
            }
        }

        public int Direction { get => (int)_obj["direction"]; set => _obj["direction"] = value; }
        public int DirectionsNumber { get => (int)_obj["directionsNumber"]; }
        public int AngularVelocity { get => (int)_obj["direction"]; }
    }
}
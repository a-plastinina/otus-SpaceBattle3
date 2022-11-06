using System;
using System.Collections;
using SpaceBattle.Interface;

namespace SpaceBattle
{
    public class Ship: IUniversalObject
    {
        private readonly Hashtable storedData = new Hashtable();
        public object this[string key] { get => storedData[key]; set => storedData[key] = value; }
        public Ship(Vector position, Vector velocity, int direction ,int maxDirection)
        {
            this["position"] = position;
            this["velocity"] = velocity;
            this["direction"] = direction;
            this["maxDirection"] = maxDirection;
        }
        public override string ToString()
        {
            return $"position: {this["position"]}, velocity: {this["velocity"]}";
        }
    }
}

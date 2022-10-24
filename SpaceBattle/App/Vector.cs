using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SpaceBattle.Interface;

namespace SpaceBattle
{
    public class Vector : IVector
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Vector(int x, int y)
        {
            X = x;
            Y = y;
        }

        public static Vector operator +(Vector a) => a;
        public static Vector operator +(Vector a, Vector b)
        {
            return new Vector(a.X + b.X, a.Y + b.Y);;
        }

        public override bool Equals(object obj)
        {
            if (obj != null)
            {
                Vector v = (Vector)obj;
                if (v == null) return false;

                return this.X == v.X && this.Y == v.Y;
            }
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return this.X.GetHashCode() + this.Y.GetHashCode();
        }
        public override string ToString()
        {
            return $"({X}, {Y})";
        }
    }
}
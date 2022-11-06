using System;
using System.Collections;
using System.Collections.Generic;
using SpaceBattle.Interface;

namespace SpaceBattle
{


    internal class Program
    {
        static IMovable CreateObject()
        {
            return new MovableAdapter(
                new Ship(null, new Vector(1, 3), 3, 8)
            );
        }
        private static void Main(string[] args)
        {
            
        }
    }
}
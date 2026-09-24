using System;
using System.Threading;

namespace ConsoleRPG.Game
{
    internal class ConsoleGame
    {
        public static void Main(string[] args)
        {
            GameLoop gameLoop = new(5);
            gameLoop.Begin();
        }
    }
}


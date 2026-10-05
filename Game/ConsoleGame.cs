using System;
using System.Threading;

namespace ConsoleRPG.Game
{
    internal class ConsoleGame
    {
        public static void Main(string[] args)
        {
            const int DISPLAY_WIDTH = 60;
            const int DISPLAY_HEIGHT = 4;

            ConsoleRPG.Display.Display newDisplay = new(DISPLAY_WIDTH, DISPLAY_HEIGHT);
            GameLoop gameLoop = new(5, newDisplay);
            gameLoop.Begin();
        }
    }
}


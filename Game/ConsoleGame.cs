using System;
using System.Threading;

namespace ConsoleRPG.Game
{
    internal class ConsoleGame
    {
        public static void Main(string[] args)
        {
            // keep these dimensions above 4 ish so that there's enough space for everything to be displayed (text boxes, any other formatting that would crash without enough space)
            const int DISPLAY_WIDTH = 60;
            const int DISPLAY_HEIGHT = 24;

            ConsoleRPG.Display.Display newDisplay = new(DISPLAY_WIDTH, DISPLAY_HEIGHT);
            GameLoop gameLoop = new(5, newDisplay);
            gameLoop.Begin();
        }
    }
}


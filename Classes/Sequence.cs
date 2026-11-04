using System;

namespace ConsoleRPG.Classes
{
    public class Sequence(string name, Display.Display display) : GameObject(name)
    {
        ASCIIArt SpriteTable = new();

        int frameCounter = 0;

        public override void Update(Display.Display display, ConsoleKeyInfo? userInput, int fps) // need a way to set up a sequence easily, and to optionally block input during them.
        {
            frameCounter++;
            if (frameCounter >= (fps * 2));
            {
                frameCounter = 0;
                // waited 2 seconds!
            }
        }
    }
}

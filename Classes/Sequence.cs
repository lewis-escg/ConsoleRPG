using System;

namespace ConsoleRPG.Classes
{
    public class Sequence(string name, Display.Display display) : GameObject(name)
    {
        ASCIIArt SpriteTable = new();

        public override void Update(Display.Display display, ConsoleKeyInfo? userInput) // need a way to set up a sequence easily, and to optionally block input during them.
        {
            
        }
    }
}

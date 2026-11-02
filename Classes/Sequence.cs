using System;

namespace ConsoleRPG.Classes
{
    public class Sequence(string name, Display.Display display) : GameObject(name)
    {
        ASCIIArt SpriteTable = new();

        public override void Update(Display.Display display, ConsoleKeyInfo? userInput)
        {
            
        }
    }
}

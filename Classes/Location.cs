using ConsoleRPG.Display;
using ConsoleRPG.Game;
using System;

namespace ConsoleRPG.Classes
{

    // TO-DO: make location system! make locations manually (not procedural). 
    // also make input system so we can finally navigate/look around and stuff

    public class Location(string name, LocationSystem locationSystem) : GameObject(name)
    {
        public int Direction = 1;

        ASCIIArt SpriteTable = new(); // lets us fetch sprites

        public override void Update(Display.Display display, ConsoleKeyInfo? userInput)
        {
            if (userInput != null && userInput.Value.Key == ConsoleKey.A)
            {
                Direction = 1;
            }
            else if (userInput != null && userInput.Value.Key == ConsoleKey.D)
            {
                Direction = 2;
            }
            else if (userInput != null && userInput.Value.Key == ConsoleKey.W)
            {
                if (Direction == 1)
                {
                    locationSystem.OffsetLocation(-1); // descend
                }
                else
                {
                    locationSystem.OffsetLocation(1); // ascend
                }
            }

            Image background = new(display, SpriteTable.Get($"{Name} {Direction}"), 1, 0, 0, Anchor.Center);
            display.Add(background);
        }
    }
}

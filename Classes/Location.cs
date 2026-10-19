using ConsoleRPG.Display;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleRPG.Classes
{

    // TO-DO: make location system! make locations myself. 
    // also make input system so we can finally navigate/look around and stuff
    // enemies can probably just stay at their initial positions and attack the player

    public class Location(string name) : GameObject(name)
    {
        public string Name = name;
        public string Background = $"{name} 1";
        public 

        ASCIIArt SpriteTable = new(); // lets us fetch sprites

        public override void Update(Display.Display display)
        {
            Image background = new(display, SpriteTable.Get(Background), 1, 0, 0, Anchor.Center);
            display.Add(background);
        }

        public void SetBackgroundID(int id)
        {
            Background = $"{name} {id}";
        }
    }
}

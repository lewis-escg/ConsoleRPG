using ConsoleRPG.Display;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleRPG.Classes
{

    // TO-DO: make location system! make locations manually (not procedural). 
    // also make input system so we can finally navigate/look around and stuff

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

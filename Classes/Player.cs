using ConsoleRPG.Display;
using System;

namespace ConsoleRPG.Classes
{
    public class Player(Display.Display display, string name) : GameObject(name)
    {
        // values and data stuff
        public int Altidude = 100;
        public int Currency = 0;
        public int Health = 10;
        public int MaxHealth = 10;
        public int Location;

        public Inventory Inventory = new();

        private string handSprite = "Hand 1";

        private ASCIIArt SpriteTable = new(); // lets us fetch sprites

        public override void Update(Display.Display display) // called every frame
        {
            // create all our elements
            Image hudOverlay = new(display, SpriteTable.Get("HUD Overlay"), 995, 0, 0, Anchor.Top);
            Meter healthMeter = new(display, Health, MaxHealth, 39, 998, 0, 1, Anchor.Top);
            Text healthText = new(display, $" {Health}/{MaxHealth}", 7, 997, -1, 3, Anchor.Top);
            Text altitudeText = new(display, $"{Altidude}", 3, 997, -25, 1, Anchor.Top);
            Text currencyText = new(display, $"{Currency}", 3, 997, 24, 1, Anchor.Top);
            Image hand = new(display, SpriteTable.Get(handSprite), 997, 0, 0, Anchor.BottomRight);

            // add them to the display's list of things to be drawn
            display.Add(hudOverlay);
            display.Add(healthMeter);
            display.Add(healthText);
            display.Add(altitudeText);
            display.Add(currencyText);
            display.Add(hand);

            if (Health > 0)
            {
                Health -= 1;
            }
        }

    }
}

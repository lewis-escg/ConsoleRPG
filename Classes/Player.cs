using ConsoleRPG.Display;
using System;

namespace ConsoleRPG.Classes
{
    public class Player(string name = "Player") : Entity(name)
    {
        // values and data stuff
        public override int Health { get; set; } = 150;
        public override int MaxHealth { get; set; } = 150;
        public int Altidude = 100;
        public int Currency = 0;

        public Inventory Inventory = new();

        private string handSprite = "Hand 1";

        private ASCIIArt SpriteTable = new(); // lets us fetch sprites

        public override void Update(Display.Display display) // called every frame
        {
            // create all our elements
            Image hudOverlay = new(display, SpriteTable.Get("HUD Overlay"), 995, 0, 0, Anchor.Top);
            Meter healthMeter = new(display, Health, MaxHealth, 39, 998, 0, 1, Anchor.Top);
            Text healthText = new(display, $" {Health}/{MaxHealth}", 8, 997, -1, 3, Anchor.Top);
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

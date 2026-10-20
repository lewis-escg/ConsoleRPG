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


        string textBoxText = "";
        string textBoxFinalText = "hello this is a dialog box and it is filling in a character every frame. it doesnt have word wrapping. abcdefghijklmnopqrstuvwxyz. im stuck/cant be bothered to add a locations (rooms) system or input system so im wasting time doing this instead.";

        public override void Update(Display.Display display) // called every frame
        {
            // create all our elements
            Image hudOverlay = new(display, SpriteTable.Get("HUD Overlay"), 995, 0, 0, Anchor.Top);
            Meter healthMeter = new(display, Health, MaxHealth, 39, 998, 0, 1, Anchor.Top);
            Text healthText = new(display, $" {Health}/{MaxHealth}", 8, 997, -1, 3, Anchor.Top);
            Text altitudeText = new(display, $"{Altidude}", 3, 997, -25, 1, Anchor.Top);
            Text currencyText = new(display, $"{Currency}", 3, 997, 24, 1, Anchor.Top);
            Image hand = new(display, SpriteTable.Get(handSprite), 997, 0, 0, Anchor.BottomRight);

            if (textBoxFinalText.Length > 0)
            {
                textBoxText = $"{textBoxText}{textBoxFinalText[0]}";
                textBoxFinalText = textBoxFinalText.Substring(1);
            }
            TextBox dialogBox = new(display, textBoxText, 998, 0, 7, 50, 12, '█', ' ', Anchor.Center);

            // add them to the display's list of things to be drawn
            display.Add(hudOverlay);
            display.Add(healthMeter);
            display.Add(healthText);
            display.Add(altitudeText);
            display.Add(currencyText);
            display.Add(hand);
            display.Add(dialogBox);

            if (Health > 0)
            {
                Health -= 1;
            }
        }

    }
}

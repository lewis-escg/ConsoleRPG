using System;
using ConsoleRPG.Classes;
using ConsoleRPG.Display;

namespace ConsoleRPG.Game
{
    class GameLoop(int loopsPerSecond, ConsoleRPG.Display.Display display)
    {
        private int loopsPerSecond = loopsPerSecond;
        private bool running = false;
        private bool paused = false;
        private List<GameObject> gameObjects = new(); // list of every object to be updated in the loop

        public void Begin()
        {
            ASCIIArt SpriteTable = new();

            Meter healthMeter = new(display, 9, 10, 39, 998, 0, 1, Anchor.Top);
            Image hudOverlay = new(display, SpriteTable.Get("HUD Overlay"), 995, -3, 0, Anchor.Top);
            Text healthText = new(display, "9/10", 7, 997, -1, 3, Anchor.Top);
            Text altitudeText = new(display, "100", 3, 997, -25, 1, Anchor.Top);

            Image background = new(display, SpriteTable.Get("Background Forward 1"), 1, 0, 0, Anchor.Center);
            Image hand = new(display, SpriteTable.Get("Hand 1"), 997, 0, 0, Anchor.BottomRight);

            display.Add(healthMeter);
            display.Add(hudOverlay);
            display.Add(healthText);
            display.Add(altitudeText);

            display.Add(background);
            display.Add(hand);



            if (running == true) return; // don't let us call begin if the loop is already running
            running = true;
            while (running) // stop if no longer running (set false by End method)
            {
                if (!paused) // only run code if the loop isnt paused, otherwise keep waiting until unpaused
                {

                    // update all gameobjects in our list
                    foreach (GameObject gameObject in gameObjects)
                    {
                        gameObject.Update();
                    }
                    
                    display.Draw(); // render everything and output it
                }
                System.Threading.Thread.Sleep(1000 / loopsPerSecond); // wait until next loop
            }
        }

        public void Pause()
        { // pause the loop
            paused = true;
        }

        public void Unpause()
        { // un-pause the loop
            paused = false;
        }

        public void End()
        { // end the loop
            running = false;
        }

        public void AddObject(GameObject gameObject)
        { // add an object to the list (will be updated every loop)
            gameObjects.Add(gameObject);
        }

        public void RemoveObject(GameObject gameObject)
        { // remove an object from the list (to be cleaned up/no longer updated)
            gameObjects.Remove(gameObject);
        }
    }
}

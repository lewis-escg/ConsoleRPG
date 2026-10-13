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


            Player player = new(display, "Player");
            gameObjects.Add(player);

            Location TowerExteriorLocation = new(display, "Tower Exterior");
            gameObjects.Add(TowerExteriorLocation);


            if (running == true) return; // don't let us call begin if the loop is already running
            running = true;
            while (running) // stop if no longer running (set false by End method)
            {
                if (!paused) // only run code if the loop isnt paused, otherwise keep waiting until unpaused
                {

                    // update all gameobjects in our list
                    foreach (GameObject gameObject in gameObjects)
                    {
                        gameObject.Update(display);
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

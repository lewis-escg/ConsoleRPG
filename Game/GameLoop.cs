using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ConsoleRPG.Display;

namespace ConsoleRPG.Game
{
    class GameLoop(int loopsPerSecond, ConsoleRPG.Display.Display display)
    {
        private int loopsPerSecond = loopsPerSecond;
        private bool running = false;
        private bool paused = false;

        public void Begin()
        {
            string newDisplayElementContent = "abcdefg";
            TextBox newElement = new(display, newDisplayElementContent, 5, 0, 0, 1, 1, '█', ' ', Anchor.Center);


            if (running == true) return; // don't let us call begin if the loop is already running
            running = true;
            while (running) // stop if no longer running (set false by End method)
            {
                if (!paused) // only run code if the loop isnt paused, otherwise keep waiting until unpaused
                {
                    // update
                    // will probably have a list of classes in the game which need to be updated. this loop will call all of those methods.
                    // could also have a way of the classes listening for a signal from the game loop (unless that's not possible without using a module/library thing).

                    Console.WriteLine("Update!");
                    display.Add(newElement);
                    display.Draw();
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
    }
}

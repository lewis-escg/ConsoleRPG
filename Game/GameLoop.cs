using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleRPG.Game
{
    class GameLoop(int loopsPerSecond)
    {
        private int loopsPerSecond = loopsPerSecond;
        private bool running = false;
        private bool paused = false;
        private Thread? thread;

        public void Begin()
        {
            if (running) return; // don't let us call begin if the loop is already running

            running = true;

            while (running) // stop if no longer running (set false by End method)
            {
                if (!paused) // only run code if the loop isnt paused, otherwise keep waiting until unpaused
                {
                    //update
                    
                    Console.WriteLine("Update!");
                }
                Thread.Sleep(1000 / loopsPerSecond); // wait until next loop
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

using System;
namespace ConsoleRPG.Game
{
    public class InputSystem
    {

        public ConsoleKeyInfo? Update()
        {
            ConsoleKeyInfo? userInput = null;
            while (Console.KeyAvailable) // while there's still a key available (in case the input buffer is clogged)
            {
                ConsoleKeyInfo userInputBuffer = Console.ReadKey(true); // get the key
                userInput = userInputBuffer; // store it in userInput
                // i stored the first input previously, but after realising the buffer works like a queue, i instead made it take the latest input rather than the oldest in the input buffer.
                // this while loop drains the input buffer so that the player doesn't have to wait for it to unclog if they entered more than 1 input per frame.
            }
            
            return userInput;
        }
    }
}

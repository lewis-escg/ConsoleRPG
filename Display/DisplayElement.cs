using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ConsoleRPG.Display
{

    public class DisplayElement
    {
        public DisplayPixel[,] content;
        public int zIndex;
        public int xPos;
        public int yPos;
        public Anchor anchor;

        public DisplayElement(DisplayPixel[,] content, int zIndex, int xPos, int yPos, Anchor anchor)
        {
            this.content = content;
            this.zIndex = zIndex;
            this.xPos = xPos;
            this.yPos = yPos;
            this.anchor = anchor;
        }

        // ConvertToDisplayPixels(content)

        public virtual void Draw(Display display)
        {
            for (int y = 0; y < display.Height; y++) // iterate through rows
            {
                for (int x = 0; x < display.Width; x++) // iterate through columns
                {
                    DisplayPixel currentPixel = display.buffer[y, x]; // get the current pixel in the buffer
                    DisplayPixel newPixel = content[y, x]; // get the new pixel

                    if (!newPixel.isEmpty && ((newPixel.zIndex >= currentPixel.zIndex) || currentPixel.isEmpty == true)) // compare the pixels by zIndex, ensuring that the current pixel isn't empty or the existing pixel is empty.
                    {
                        display.buffer[y, x] = newPixel; // overwrite the pixel
                    }
                }
            }

        }

        public static DisplayPixel CharacterToDisplayPixel(char character, int zIndex)
        {
            DisplayPixel result = new();

            result.character = character;
            result.zIndex = zIndex;

            if (character == ' ')
            {
                result.isEmpty = true;

            }
            else
            {
                result.isEmpty = false;
            }

            return result;
        }

    }

}

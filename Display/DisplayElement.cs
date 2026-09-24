using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleRPG.Display
{

    class DisplayElement
    {
        public DisplayPixel[,] content;
        public int zIndex;
        public int xPos;
        public int yPos;
        public Anchor anchor;
        public ConsoleColor foregroundColour;
        public ConsoleColor backgroundColour;

        public DisplayElement(string content, int zIndex, int xPos, int yPos, Anchor anchor, ConsoleColor foregroundColour = ConsoleColor.White, ConsoleColor backgroundColour = ConsoleColor.Black)
        {
            this.content = ConvertToDisplayPixels(content); // convert provided string to displaypixels we can draw to the buffer
            this.zIndex = zIndex;
            this.xPos = xPos;
            this.yPos = yPos;
            this.anchor = anchor;
            this.foregroundColour = foregroundColour;
            this.backgroundColour = backgroundColour;
        }

        protected virtual DisplayPixel[,] ConvertToDisplayPixels(string stringInput)
        {
            // !!!!!!!!! get the conversion werking !!!!!!!!!!!
            DisplayPixel[,] output = new DisplayPixel[2, 3];
            return output;
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

                    if ((newPixel.zIndex >= currentPixel.zIndex) || currentPixel.isEmpty == true) // compare the pixels by zIndex
                    {
                        display.buffer[y, x] = newPixel; // overwrite the pixel
                    }
                }
            }
            
        }
    }

    class TextBox(DisplayPixel[,] content, int zIndex, int xPos, int yPos, int xScale, int yScale, char border, char fill, Anchor anchor, ConsoleColor foregroundColour, ConsoleColor backgroundColour) : DisplayElement(content, zIndex, xPos, yPos, anchor, foregroundColour, backgroundColour)
    {
        public int xScale = xScale;
        public int yScale = yScale;
        public char border = border;
        public char fill = fill;

        // !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!! make this do the conversion instead and pass the displaypixel grid to the base class !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
    }

    // sprites, backgrounds, overlays, menus, etc

}

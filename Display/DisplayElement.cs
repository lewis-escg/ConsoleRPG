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

        public DisplayElement(DisplayPixel[,] content, int zIndex, int xPos, int yPos, Anchor anchor, ConsoleColor foregroundColour = ConsoleColor.White, ConsoleColor backgroundColour = ConsoleColor.Black)
        {
            this.content = content; // convert provided string to displaypixels we can draw to the buffer
            this.zIndex = zIndex;
            this.xPos = xPos;
            this.yPos = yPos;
            this.anchor = anchor;
            this.foregroundColour = foregroundColour;
            this.backgroundColour = backgroundColour;
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

    class TextBox(string content, int zIndex, int xPos, int yPos, int xScale, int yScale, char border, char fill, Anchor anchor, ConsoleColor foregroundColour, ConsoleColor backgroundColour) : DisplayElement(ConvertToDisplayPixels(content), zIndex, xPos, yPos, anchor, foregroundColour, backgroundColour)
    {
        public int xScale = xScale;
        public int yScale = yScale;
        public char border = border;
        public char fill = fill;

        private static DisplayPixel[,] ConvertToDisplayPixels(string elementContent) // automatic method to convert the element contents to a DisplayPixel grid and sent it to the base class to be drawn
        {
            // !!!!!!!!! get the conversion werking !!!!!!!!!!!
            DisplayPixel[,] output = new DisplayPixel[2, 3];
            return output;
        }
    }

    // sprites, backgrounds, overlays, menus, etc

}

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

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
            this.content = content;
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
            for (int y = 0; y <= display.Height; y++) // iterate through rows
            {
                for (int x = 0; x <= display.Width; x++) // iterate through columns
                {
                    DisplayPixel currentPixel = display.buffer[y, x]; // get the current pixel in the buffer
                    DisplayPixel newPixel = content[y, x]; // get the new pixel

                    if (newPixel.isEmpty == false && ((newPixel.zIndex >= currentPixel.zIndex) || currentPixel.isEmpty == true)) // compare the pixels by zIndex, ensuring that the current pixel isn't empty or the existing pixel is empty.
                    {
                        display.buffer[y, x] = newPixel; // overwrite the pixel
                    }
                }
            }
            
        }
    }

    class TextBox(Display display, string content, int zIndex, int xPos, int yPos, int xScale, int yScale, char border, char fill, Anchor anchor, ConsoleColor foregroundColour, ConsoleColor backgroundColour) : DisplayElement(ConvertToDisplayPixels(content, anchor, display), zIndex, xPos, yPos, anchor, foregroundColour, backgroundColour)
    {
        public int xScale = xScale;
        public int yScale = yScale;
        public char border = border;
        public char fill = fill;

        private static DisplayPixel[,] ConvertToDisplayPixels(string elementContent, Anchor anchor, Display display) // automatic method to convert the element contents to a DisplayPixel grid and sent it to the base class to be drawn
        {
            char[,] elementCharacterArray = new char[display.Height, display.Width];
            string[] elementContentRows = elementContent.Split("\n");

            // cut off extra rows if too many to display
            if (elementContentRows.Length > display.Height)
            {
                elementContentRows.Take(display.Height);
            }

            for (int i = 0; i <= elementContentRows.Length; i++)
            {
                // cut off the string if too long to display
                if (elementContentRows[i].Length > display.Width)
                {
                    elementContentRows[i] = elementContentRows[i].Substring(0, display.Width - 1); // not sure if -1 is supposed to be used here, just guessing cause of how index works
                }

                // pad the row to the left, middle or right according to the anchor setting
                if (anchor == Anchor.Center || anchor == Anchor.Top || anchor == Anchor.Bottom)
                {
                    elementContentRows[i] = display.PadCenter(elementContentRows[i], display.Width);
                }
                else if (anchor == Anchor.Left || anchor == Anchor.TopLeft || anchor == Anchor.BottomLeft)
                {
                    elementContentRows[i] = elementContentRows[i].PadRight(display.Width);
                }
                else if (anchor == Anchor.Right || anchor == Anchor.TopRight || anchor == Anchor.BottomRight)
                {
                    elementContentRows[i] = elementContentRows[i].PadLeft(display.Width);
                }
            }

            // pad rows to the bottom, middle or top according to the anchor setting
            if (anchor == Anchor.Top || anchor == Anchor.TopLeft || anchor == Anchor.TopRight)
            {
                elementContentRows = display.PadDown(elementContentRows, display.Height);
            }
            else if (anchor == Anchor.Center || anchor == Anchor.Left || anchor == Anchor.Right)
            {
                elementContentRows = display.PadCenter_v(elementContentRows, display.Height);
            }
            else if (anchor == Anchor.Bottom || anchor == Anchor.BottomLeft || anchor == Anchor.BottomRight)
            {
                elementContentRows = display.PadUp(elementContentRows, display.Height);
            }

            for(int y = 0; y <= display.Height; y++)
            {
                // convert to characters and add to 2d array
                char[] charArray = elementContentRows[y].ToCharArray();
                for (int x = 0; x <= display.Width; x++)
                {
                    elementCharacterArray[y, x] = charArray[x];
                }
            }

            // !!!!!!!!! get the conversion werking !!!!!!!!!!!
            DisplayPixel[,] output = new DisplayPixel[display.Height, display.Width]; // must match dimensions of buffer or will crash

            // convert the elementCharacterArray into the array of displayPixels ^

            return output;
        }
    }

    // sprites, backgrounds, overlays, menus, etc

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleRPG.Display
{
    class Image(Display display, string content, int zIndex, int xPos, int yPos, Anchor anchor) : DisplayElement(ConvertToDisplayPixels(display, FormatContents(display.Height, content), anchor, zIndex), zIndex, xPos, yPos, anchor)
    {

        // considering getting rid of foreground/background colours for simplicity (cant have coloured strings so there's no colour data in the first place)

        private static string[] FormatContents(int linesNumber, string content)
        {

            string[] rows = content.Split(System.Environment.NewLine);
            return rows;

        }

        private static DisplayPixel[,] ConvertToDisplayPixels(Display display, string[] elementContentRows, Anchor anchor, int zIndex) // automatic method to convert the element contents to a DisplayPixel grid and sent it to the base class to be drawn
        {

            // !!!!!!!!! REWRITE TO USE SCALE PARAMS INSTEAD OF FULL DISPLAY SIZE !!!!!!!!!!!!!!!!!!!!!

            // cut off extra rows if too many to display
            if (elementContentRows.Length > display.Height)
            {
                elementContentRows = elementContentRows.Take(display.Height).ToArray(); // keeps only the rows up to the height we need
            }

            int imageWidth = Math.Min(elementContentRows.Max(row => row.Length), display.Width); // get max length

            // for each row
            for (int i = 0; i < elementContentRows.Length; i++)
            {

                // cut off the string if too long to display
                if (elementContentRows[i].Length > display.Width)
                {
                    elementContentRows[i] = elementContentRows[i].Substring(0, display.Width); // keeps only the string up to the width we need
                }

                elementContentRows[i] = elementContentRows[i].PadRight(imageWidth); // make every row the same width

                // pad the row to the left, middle or right according to the anchor setting
                if (anchor == Anchor.Center || anchor == Anchor.Top || anchor == Anchor.Bottom)
                {
                    int leftPadding = (display.Width - imageWidth) / 2;
                    elementContentRows[i] = elementContentRows[i].PadLeft(imageWidth + leftPadding).PadRight(display.Width);
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

            DisplayPixel[,] output = new DisplayPixel[display.Height, display.Width]; // must match dimensions of buffer or will crash

            // now we convert the elementCharacterArray into the array of displayPixels

            // for each row
            for (int y = 0; y < elementContentRows.Length; y++)
            {
                // convert to characters and add to 2d array
                char[] charArray = elementContentRows[y].ToCharArray();
                // for each pixel in the row
                for (int x = 0; x < display.Width; x++)
                {
                    // add the row of characters to the output array
                    output[y, x] = CharacterToDisplayPixel(charArray[x], zIndex);
                }
            }

            return output;
        }
        // inheriting classes will be used for sprites, backgrounds, overlays, menus, etc
    }

}

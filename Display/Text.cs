using System;
using System.ComponentModel.DataAnnotations;

namespace ConsoleRPG.Display
{
    class Text(Display display, string content, int maxWidth, int zIndex, int xPos, int yPos, Anchor anchor) : DisplayElement(ConvertToDisplayPixels(display, FormatContents(display, content, maxWidth), anchor, xPos, yPos, zIndex), zIndex, xPos, yPos, anchor)
    {

        private static string FormatContents(Display display, string content, int maxWidth)
        {
            content = content.Replace(' ', display.Empty); // replace spaces with the fill character (since we only want the words, not the spaces. it's not ascii art. yk what i mean.)

            if (content.Length > maxWidth)
            {
                return content.Substring(0, maxWidth);
            }
            else
            {
                return content;
            }

        }

        private static DisplayPixel[,] ConvertToDisplayPixels(Display display, string content, Anchor anchor, int xPos, int yPos, int zIndex) // automatic method to convert the element contents to a DisplayPixel grid and sent it to the base class to be drawn
        {
            string[] elementContentRows = new string[1];
            elementContentRows[0] = content;

            // cut off the string if too long to display
            if (elementContentRows[0].Length > display.Width)
            {
                elementContentRows[0] = elementContentRows[0].Substring(0, display.Width); // keeps only the string up to the width we need
            }

            int textLength = elementContentRows[0].Length;

            // pad the row to the left, middle or right according to the anchor setting
            if (anchor == Anchor.Center || anchor == Anchor.Top || anchor == Anchor.Bottom)
            {
                int leftPadding = (display.Width - textLength) / 2;
                elementContentRows[0] = elementContentRows[0].PadLeft(leftPadding + textLength, display.Empty).PadRight(display.Width, display.Empty);
            }
            else if (anchor == Anchor.Left || anchor == Anchor.TopLeft || anchor == Anchor.BottomLeft)
            {
                elementContentRows[0] = elementContentRows[0].PadRight(display.Width, display.Empty);
            }
            else if (anchor == Anchor.Right || anchor == Anchor.TopRight || anchor == Anchor.BottomRight)
            {
                elementContentRows[0] = elementContentRows[0].PadLeft(display.Width, display.Empty);
            }

            // pad rows to the bottom, middle or top according to the anchor setting
            if (anchor == Anchor.Top || anchor == Anchor.TopLeft || anchor == Anchor.TopRight)
            {
                elementContentRows = display.PadDown(elementContentRows, display.Height, display.Empty);
            }
            else if (anchor == Anchor.Center || anchor == Anchor.Left || anchor == Anchor.Right)
            {
                elementContentRows = display.PadCenter_v(elementContentRows, display.Height, display.Empty);
            }
            else if (anchor == Anchor.Bottom || anchor == Anchor.BottomLeft || anchor == Anchor.BottomRight)
            {
                elementContentRows = display.PadUp(elementContentRows, display.Height, display.Empty);
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

                    int xTarget = x + xPos;
                    int yTarget = y + yPos;

                    // ignore characters outside the display
                    if (xTarget >= 0 && xTarget < display.Width && yTarget >= 0 && yTarget < display.Height)
                    {
                        // make sure character isnt the empty character (avoid padding issues)
                        if (charArray[x] != display.Empty)
                        {
                            // add the row of characters to the output array
                            output[yTarget, xTarget] = CharacterToDisplayPixel(display, charArray[x], zIndex);
                        }
                    }
                }
            }

            return output;
        }
        // inheriting classes will be used for sprites, backgrounds, overlays, menus, etc
    }
}

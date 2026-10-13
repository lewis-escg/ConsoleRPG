using System;
using System.Text;

namespace ConsoleRPG.Display
{
    class Meter(Display display, int value, int maxValue, int maxLength, int zIndex, int xPos, int yPos, Anchor anchor) : DisplayElement(ConvertToDisplayPixels(display, FormatContents(value, maxValue, maxLength), anchor, xPos, yPos, zIndex), zIndex, xPos, yPos, anchor)
    {

        // considering getting rid of foreground/background colours for simplicity (cant have coloured strings so there's no colour data in the first place)

        private static string[] FormatContents(int value, int maxValue, int maxLength)
        {
            char fillChar = '█';
            char emptyChar = '░';

            StringBuilder sb = new();
            decimal fraction = 0;
            try { fraction = Convert.ToDecimal(1) / (Convert.ToDecimal(maxValue) / Convert.ToDecimal(value)); } catch { }
            int iterationCounter = 0;
            for (int i = 1; i <= maxLength; i++)
            {
                if (i <= Math.Floor(fraction* maxLength))
                {
                    sb.Append(fillChar);
                }
                else
                {
                    sb.Append(emptyChar);
                }
            }
            string[] rows = { Convert.ToString(sb) };
            return rows;
        }

        private static DisplayPixel[,] ConvertToDisplayPixels(Display display, string[] elementContentRows, Anchor anchor, int xPos, int yPos, int zIndex) // automatic method to convert the element contents to a DisplayPixel grid and sent it to the base class to be drawn
        {

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

                elementContentRows[i] = elementContentRows[i].PadRight(imageWidth, display.Empty); // make every row the same width

                // pad the row to the left, middle or right according to the anchor setting
                if (anchor == Anchor.Center || anchor == Anchor.Top || anchor == Anchor.Bottom)
                {
                    int leftPadding = (display.Width - imageWidth) / 2;
                    elementContentRows[i] = elementContentRows[i].PadLeft(imageWidth + leftPadding, display.Empty).PadRight(display.Width, display.Empty);
                }
                else if (anchor == Anchor.Left || anchor == Anchor.TopLeft || anchor == Anchor.BottomLeft)
                {
                    elementContentRows[i] = elementContentRows[i].PadRight(display.Width, display.Empty);
                }
                else if (anchor == Anchor.Right || anchor == Anchor.TopRight || anchor == Anchor.BottomRight)
                {
                    elementContentRows[i] = elementContentRows[i].PadLeft(display.Width, display.Empty);
                }
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

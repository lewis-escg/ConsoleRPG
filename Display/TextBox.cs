using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleRPG.Display
{
    class TextBox(Display display, string content, int zIndex, int xPos, int yPos, int xScale, int yScale, char border, char fill, Anchor anchor) : DisplayElement(ConvertToDisplayPixels(display, FormatContents(display.Height, display.Width, content, border, fill), anchor, zIndex, border, fill), zIndex, xPos, yPos, anchor)
    {

        public int xScale = xScale;
        public int yScale = yScale;
        public char border = border;
        public char fill = fill;

        private static string[] FormatContents(int linesNumber, int widthNumber, string userTypedText, char border = '█', char fill = '_')
        {

            string[] rows = new string[linesNumber];

            for (int i = 0; i < linesNumber; i++) // for each line
            {
                if ((i == 0) || (i == linesNumber - 1)) // if the current line is the first or last line (border)
                {
                    string newLine = ("".PadLeft((widthNumber), border)); // fill the line with border characters
                    if (i != linesNumber - 1)
                    {
                        newLine = ($"{newLine}\n"); // add a new line signifier thing on the end (except if its the last line, so we dont exceed the line limit)
                    }
                    rows[i] = newLine; // add to final array
                }
                else
                {
                    string textForThisLine = "";
                    if (userTypedText.Length == 0)  // basic character wrapping (not word wrapping) - don't add any text if there is none
                    {
                        // pass
                    }
                    else if (userTypedText.Length <= widthNumber - 4) // if the remaining text can all fit on the same line
                    {
                        textForThisLine = userTypedText;
                        userTypedText = "";
                    }
                    else // if there's more text that exceeds the length of the current line
                    {
                        textForThisLine = userTypedText.Substring(0, widthNumber - 4); // get the string from the beginning of the text up to the end of the line
                        userTypedText = userTypedText.Substring(widthNumber - 4); // cut off the string we just took
                    }

                    string newLine = (textForThisLine.PadRight(widthNumber - 4, fill)); // pad text to the left (the rest of the line is the fill character)
                    newLine = ($"{border} {newLine} {border}\n"); // add borders to sides with text in the center
                    rows[i] = newLine; // add to final array
                }
            }

            return rows;

        }

        private static DisplayPixel[,] ConvertToDisplayPixels(Display display, string[] elementContentRows, Anchor anchor, int zIndex, char border, char fill) // automatic method to convert the element contents to a DisplayPixel grid and sent it to the base class to be drawn
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleRPG.Display
{
    public class Display(int width, int height)
    {
        public int Width = width;
        public int Height = height; // swap out the height/width below for the variables rather than parameters somehow
        public DisplayPixel[,] buffer = new DisplayPixel[height, width]; // buffer where we composite the elements together
        private List<DisplayElement> elements = new(); // list of elements (ordered & overlayed by zindex)

        public void Draw()
        {
            ClearBuffer();

            foreach (DisplayElement element in elements) // for every element
            {
                element.Draw(this); // call its draw method
            }

            StringBuilder renderedFrame = new();

            // for every row in the buffer
            for (int y = 0; y < Height; y++)
            {
                // for every pixel in the row
                for (int x = 0; x < Width; x++)
                {
                    // get pixel
                    DisplayPixel pixel = buffer[y, x];

                    if (pixel.isEmpty == false) // if not empty
                    {
                        renderedFrame.Append(pixel.character); // writes character to console
                    }
                    else // if empty
                    {
                        renderedFrame.Append(' '); // writes empty space
                    }
                }

                renderedFrame.Append(System.Environment.NewLine); // new line after each row
            }
            Console.Write(renderedFrame); // output frame to console
            Console.Write("\x1b[J"); // clear anything from cursor pos to end of console (prevents some visual bugs after window size is set smaller than the game can display)
        }

        public void Add(DisplayElement element)
        {
            elements.Add(element);
        }

        public void Remove(DisplayElement element)
        {
            elements.Remove(element);
        }

        public void ClearBuffer()
        {
            buffer = new DisplayPixel[Height, Width];

            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    buffer[y, x].isEmpty = true; // set every initial pixel to empty since arrays dont want to use default values from the constructor
                }
            }
        }

        // utilities
        public string PadCenter(string inputString, int fullLength)
        {
            int padding = fullLength - inputString.Length;
            int leftPadding = padding / 2 + inputString.Length;
            string output = inputString.PadLeft(leftPadding);
            output = output.PadRight(fullLength);
            return output;
        }



        public string[] PadUp(string[] inputStringRows, int fullHeight) // REWRITE!
        {
            int rowLength = inputStringRows[0].Length;
            int rowsNeeded = fullHeight - inputStringRows.Length;

            string emptyRow = new string(' ', rowLength);

            return Enumerable.Repeat(emptyRow, rowsNeeded).Concat(inputStringRows).ToArray();
        }

        public string[] PadDown(string[] inputStringRows, int fullHeight) // REWRITE!
        {
            int rowLength = inputStringRows[0].Length;
            int rowsNeeded = fullHeight - inputStringRows.Length;

            string emptyRow = new string(' ', rowLength);

            return inputStringRows.Concat(Enumerable.Repeat(emptyRow, rowsNeeded)).ToArray();
        }

        public string[] PadCenter_v(string[] inputStringRows, int fullHeight) // REWRITE!
        {
            int rowsNeeded = fullHeight - inputStringRows.Length;

            int topRows = (rowsNeeded + 1) / 2;
            int bottomRows = rowsNeeded / 2;

            int rowLength = inputStringRows[0].Length;
            string emptyRow = new string(' ', rowLength);

            return Enumerable.Repeat(emptyRow, topRows).Concat(inputStringRows).Concat(Enumerable.Repeat(emptyRow, bottomRows)).ToArray();
        }

    }

    // enums, structure types, etc

    public enum Anchor // anchor points for positioning elements
    {
        TopLeft,
        Top,
        TopRight,
        Left,
        Center,
        Right,
        BottomLeft,
        Bottom,
        BottomRight
    }

    // a structure to store data for indivdual pixels when drawing to the buffer
    public struct DisplayPixel(char character = ' ', int zIndex = 0, bool isEmpty = true)
    {
        public char character = character;
        public int zIndex = zIndex;
        public bool isEmpty = isEmpty;
    }
}

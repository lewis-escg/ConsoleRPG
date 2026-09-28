using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleRPG.Display
{
    class Display(int width, int height)
    {
        public int Width = width;
        public int Height = height; // swap out the height/width below for the variables rather than parameters somehow
        public DisplayPixel[,] buffer = new DisplayPixel[height, width]; // buffer where we composite the elements together
        private List<DisplayElement> elements = new(); // list of elements (ordered & overlayed by zindex)

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
            buffer = new DisplayPixel[Height, width];
        }

        public void Draw()
        {
            foreach (DisplayElement element in elements)
            {
                element.Draw(this);
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



        public string[] PadUp(string[] inputStringRows, int fullHeight)
        {
            int rowLength = inputStringRows[0].Length;
            string[] output = inputStringRows;
            output.Prepend(string.Concat(Enumerable.Repeat(" ", rowLength)));
            return output;
        }

        public string[] PadDown(string[] inputStringRows, int fullHeight)
        {
            int rowLength = inputStringRows[0].Length;
            string[] output = inputStringRows;
            output.Append(string.Concat(Enumerable.Repeat(" ", rowLength)));
            return output;
        }

        public string[] PadCenter_v(string[] inputStringRows, int fullHeight)
        {
            int padding = fullHeight - inputStringRows.Length;
            int leftPadding = padding / 2 + inputStringRows.Length;
            string[] output = this.PadUp(inputStringRows, leftPadding);
            output = this.PadDown(output, fullHeight);
            return output;
        }

    }

    // enums, structure types, etc

    enum Anchor // anchor points for positioning elements
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
    struct DisplayPixel(char character = ' ', int zIndex = 0, bool isEmpty = true, ConsoleColor foregroundColour = ConsoleColor.White, ConsoleColor backgroundColour = ConsoleColor.Black)
    {
        public char character = character;
        public int zIndex = zIndex;
        public bool isEmpty = isEmpty;
        public ConsoleColor foregroundColour = foregroundColour;
        public ConsoleColor backgroundColour = backgroundColour;
        
    }
}

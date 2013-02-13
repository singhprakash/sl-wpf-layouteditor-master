using System;

namespace Layout
{
    public struct LayoutDimensions
    {
        private int width;
        public int Width
        {
            get { return width; }
            set { width = value; }
        }

        private int height;
        public int Height
        {
            get { return height; }
            set { height = value; }
        }

        public int NumPositions
        {
            get { return this.Height * this.Width; }
        }

        public LayoutDimensions(int width, int height)
        {
            if (width <= 0)
            {
                throw new ArgumentOutOfRangeException("Width must be > 0", "width");
            }
            if (height <= 0)
            {
                throw new ArgumentOutOfRangeException("Height must be > 0", "height");
            }
            this.width = width;
            this.height = height;
        }
    }
}
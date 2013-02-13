
namespace LayoutEditor.UnitTests.Helpers
{
    public struct PosXY
    {
        public PosXY(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        private int x;
        public int X
        {
            get { return this.x; }
            set { this.x = value; }
        }

        private int y;
        public int Y
        {
            get { return this.y; }
            set { this.y = value; }
        }
    }
}
using System.Windows.Media;

namespace Layout
{
    /// <summary>
    /// This class is used to represent position data necessary for editing data in the layout editor
    /// Has-a relationship with the lightweight LayoutPos struct.
    /// i.e. the data at a single position
    /// </summary>
    public class LayoutPosEditor
    {
        public LayoutPosEditor(LayoutPos layoutPos, Color colour, string hoverText)
        {
            this.layoutPos = layoutPos;
            this.colour = colour;
            this.hoverText = hoverText;
        }

        private LayoutPos layoutPos;
        public LayoutPos LayoutPos
        {
            get { return layoutPos; }
            set { layoutPos = value; }
        }

        private bool isFlagged;
        public bool IsFlagged
        {
            get { return isFlagged; }
            set
            {
                // Can only set flagged on Used positions
                if (layoutPos.IsUsed)
                {
                    isFlagged = value;
                }
                else
                {
                    isFlagged = false;
                }
            }
        }

        private Color colour;
        public Color Colour
        {
            get { return colour; }
            set { colour = value; }
        }

        private string hoverText;
        public string HoverText
        {
            get { return hoverText; }
            set { hoverText = value; }
        }

        public LayoutPosEditor Clone()
        {
            LayoutPosEditor copy = this.MemberwiseClone() as LayoutPosEditor;
            copy.LayoutPos = this.LayoutPos.Clone();
            return copy;
        }

        /// <summary>
        /// Compares this object with another LayoutPosEditor to determine if they appear the same on the screen
        /// (Used to determine which positions need updating).  If this returns false then the position is not updated
        /// </summary>
        /// <param name="compare"></param>
        /// <returns></returns>
        public bool IsVisuallyEqual(LayoutPosEditor compare)
        {
            return ((this.Colour == compare.Colour) && (this.LayoutPos.Group == compare.LayoutPos.Group) && (this.IsFlagged == compare.IsFlagged));
        }

        public void SetUnused()
        {
            Colour = Colors.White;
            HoverText = "";
            LayoutPos layoutPos = LayoutPos;
            layoutPos.TypeId = 1;
            layoutPos.Group = 0;
        }
    }
}
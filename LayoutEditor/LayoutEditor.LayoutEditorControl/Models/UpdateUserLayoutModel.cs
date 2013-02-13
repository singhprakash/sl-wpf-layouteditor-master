using Layout;

namespace LayoutEditor.LayoutEditorControl.Models
{
    public sealed class UpdateUserLayoutModel
    {
        public SingleLayoutLight UserLayout { get; set; }
        public string FlaggedPositions { get; set; }
    }
}
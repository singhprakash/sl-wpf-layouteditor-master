using Layout;
using System.Windows.Media;

namespace LayoutEditor.LayoutEditorControl.Models
{
    public class LeftMenuModel
    {
        public int Key { get; set; }
        public ImageSource Image { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
        public LayoutEditorPopulation DiagramModel { get; set; }
    }
}
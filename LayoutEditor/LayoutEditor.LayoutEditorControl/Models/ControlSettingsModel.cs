using Layout;

namespace LayoutEditor.LayoutEditorControl.Models
{
    public class ControlSettingsModel
    {
        public SelectionCommand SelectionCommand { get; set; }
        public bool AllowFillMode { get; set; }
        public bool AllowClearButton { get; set; }
        public bool IsUndoAvailable { get; set; }
        public bool IsRedoAvailable { get; set; }
        public bool IsClearAvailable { get; set; }
        public bool IsSaveAvailable { get; set; }
        public bool IsFlagMode { get; set; }
        public SingleLayoutEditor CurrentState { get; set; }
    }
}
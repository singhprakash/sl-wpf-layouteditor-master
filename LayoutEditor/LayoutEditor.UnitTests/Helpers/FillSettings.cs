
namespace LayoutEditor.UnitTests.Helpers
{
    public struct FillSettings
    {
        public int StartGroup { get; set; }
        public bool IsGrid { get; set; }
        public bool IsSnake { get; set; }
        public int Replicates { get; set; }
        public Direction GroupDirection { get; set; }
        public Direction ReplicateDirection { get; set; }
    };
}
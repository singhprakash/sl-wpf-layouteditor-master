using System.Xml.Serialization;

namespace Layout
{
    /// <summary>
    /// Defines the basic elements of a single position.
    /// i.e. the TypeId, Group number and Id (position)
    /// </summary>
    [XmlRoot("LayoutPos")]
    public class LayoutPos
    {
        [XmlAttribute]
        public int TypeId { get; set; }

        [XmlAttribute]
        public int Group { get; set; }

        /// <summary>
        /// Corresponds to the position, 1 = A1, 2 = A2, etc.
        /// </summary>
        /// 
        [XmlAttribute]
        public int Id { get; set; }

        public bool IsUsed
        {
            // TypeId of 1 means Unused
            get { return (TypeId != 1); }
        }

        public LayoutPos Clone()
        {
            return MemberwiseClone() as LayoutPos;
        }

        public bool Equals(int group, int typeId)
        {
            return (TypeId == typeId) && (group == Group);
        }
    }
}
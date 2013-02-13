using System.ComponentModel;
using System.Xml.Serialization;

namespace Layout
{
    public class Rule
    {
        #region Properties

        [XmlAttribute]
        public int TypeId { get; set; }

        [XmlAttribute]
        public string Description { get; set; }

        [XmlAttribute]
        [DefaultValue(0)]
        public int NumGroups { get; set; }

        [XmlAttribute]
        [DefaultValue(0)]
        public int MinNumGroups { get; set; }

        [XmlAttribute]
        [DefaultValue(0)]
        public int MaxNumGroups { get; set; }

        [XmlAttribute]
        [DefaultValue(0)]
        public int NumReplicates { get; set; }

        [XmlAttribute]
        [DefaultValue(0)]
        public int MinNumReplicates { get; set; }

        [XmlAttribute]
        [DefaultValue(0)]
        public int MaxNumReplicates { get; set; }

        [XmlAttribute]
        [DefaultValue(false)]
        public bool AllGroupsSameReplicates { get; set; }

        [XmlAttribute]
        [DefaultValue(0)]
        public int MatchGroupsInTypeId { get; set; }

        [XmlAttribute]
        [DefaultValue(0)]
        public int MergeGroupsWithType { get; set; }

        #endregion
    }
}
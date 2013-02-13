using System.Xml.Serialization;

namespace Layout
{
    [XmlRoot("SampleType")]
    public class SampleType
    {
        [XmlAttribute("Id")]
        public int Id { get; set; }

        [XmlAttribute("Name")]
        public string Name { get; set; }

        [XmlAttribute("Colour")]
        // Note, this is a string for simplifying sharing between different project types
        public string Colour { get; set; }

        //[XmlAttribute("Colour")]
        //[DefaultValue("#00000000")]
        //public string ColourStr
        //{
        //    get
        //    {
        //        string returnedString = ColourTransformer.GetColorNameFromHex(Colour.ToString());
        //        return returnedString;
        //    }
        //    set
        //    {
        //        Colour = ColourTransformer.GetColorFromName(value);
        //    }
        //}
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;

namespace Layout
{
    [XmlRoot("UserLayout")]
    public class UserLayout
    {
        List<SampleType> sampleTypes = new List<SampleType>();

        public List<SampleType> SampleTypes
        {
            get { return sampleTypes; }
            set { sampleTypes = value; }
        }

        SingleLayoutLight singleLayoutLight = new SingleLayoutLight();

        public SingleLayoutLight SingleLayoutLight
        {
            get { return singleLayoutLight; }
            set { singleLayoutLight = value; }
        }

        public LayoutDimensions LayoutDimensions;

        /// <summary>
        /// Shallow copy
        /// </summary>
        /// <returns></returns>
        public UserLayout Clone()
        {
            return this.MemberwiseClone() as UserLayout;
        }

        static public UserLayout Create(int width, int height, List<SampleType> sampleTypes)
        {
            return new UserLayout() { LayoutDimensions = new LayoutDimensions(width, height), SampleTypes = sampleTypes };
        }

        /// <summary>
        /// Ouput EVERY position in the layout in a CSV list of TypeId, GroupNum
        /// </summary>
        /// <returns></returns>
        public string ToCSVStringAllPositions()
        {
            return new SingleLayoutEditor(this.singleLayoutLight, LayoutDimensions.Width, LayoutDimensions.Height).ToCSVString();
        }

        /// Read in EVERY position in the layout from a CSV list of TypeId, GroupNum
        public void InitFromCSVStringAllPositions(string csv, int width, int height)
        {
            LayoutDimensions = new LayoutDimensions(width, height);
            singleLayoutLight = new SingleLayoutLight(csv);

            if (singleLayoutLight.NumPositions != width * height)
            {
                throw new InvalidProgramException();
            }

            // Infer Sample types if they have not already been setup
            if (sampleTypes.Count == 0)
            {
                var usedTypes = (from LayoutPos pos in singleLayoutLight.LayoutPositions
                                 where pos.TypeId != 1      // Ignore unused type in this list
                                 select pos.TypeId).Distinct();

                // Always add unused
                sampleTypes.Add(new SampleType() { Name = "Unused", Colour = "White", Id = 1 });

                foreach (var type in usedTypes)
                {

                    SampleType sampleType;
                    switch (type)
                    {
                        case 2:
                            sampleType = new SampleType() { Name = "Standard", Colour = "Red" };
                            break;
                        case 3:
                            sampleType = new SampleType() { Name = "Blank", Colour = "Yellow" };
                            break;
                        case 4:
                            sampleType = new SampleType() { Name = "Control", Colour = "Aqua" };
                            break;
                        case 5:
                            sampleType = new SampleType() { Name = "Unknown", Colour = "Lime" };
                            break;
                        case 7:
                            sampleType = new SampleType() { Name = "Pos Control", Colour = "#7dffff" };
                            break;
                        case 8:
                            sampleType = new SampleType() { Name = "Neg Control", Colour = "#fefccf" };
                            break;
                        case 24:
                            sampleType = new SampleType() { Name = "B0", Colour = "#FFD080" };
                            break;
                        case 25:
                            sampleType = new SampleType() { Name = "NSB", Colour = "#FF80FF" };
                            break;
                        case 26:
                            sampleType = new SampleType() { Name = "TA", Colour = "#9E8010" };
                            break;
                        case 109:
                            sampleType = new SampleType() { Name = "Unknown 1:1", Colour = "#408040" };
                            break;
                        case 110:
                            sampleType = new SampleType() { Name = "Unknown 1:10", Colour = "#00c000" };
                            break;
                        case 111:
                            sampleType = new SampleType() { Name = "Unknown 1:200", Colour = "#c0ffc0" };
                            break;

                        default:
                            sampleType = new SampleType() { Name = typeNotSupported, Colour = "Black" };
                            break;
                    }
                    sampleType.Id = type;
                    sampleTypes.Add(sampleType);
                }
            }
        }

        public bool IsTypeNameMarkedsAsNotSupported(string typeName)
        {
            return typeName == typeNotSupported;
        }

        const string typeNotSupported = "UNSUPPORTED TYPE";
    }
}
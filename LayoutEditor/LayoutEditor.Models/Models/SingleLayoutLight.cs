using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Layout
{
    /// <summary>
    /// This class is used to create XML which is sent between client/server to represent to layout positions.
    /// </summary>
    [XmlRoot("SingleLayoutLight")]
    public class SingleLayoutLight
    {
        public SingleLayoutLight() { }

        // Create from SingleLayoutEditor  (used for sending back to the server)
        public SingleLayoutLight(SingleLayoutEditor singleLayoutEditor)
        {
            NumPositions = singleLayoutEditor.NumPositions;

            // Note a single layout only contains used entries
            foreach (LayoutPosEditor layoutPos in singleLayoutEditor.LayoutPositions)
            {
                if (layoutPos.LayoutPos.IsUsed)
                {
                    LayoutPositions.Add(layoutPos.LayoutPos);
                }
            }
        }

        public SingleLayoutLight(string csv)
        {
            string[] split = csv.Split(',');

            int numNumbers = split.Length;
            if (numNumbers % 2 != 0)
            {
                throw new InvalidProgramException();
            }

            int position = 1;
            for (int i = 0; i < numNumbers; i += 2)
            {
                int type = int.Parse(split[i]);
                int group = int.Parse(split[i + 1]);

                LayoutPositions.Add(new LayoutPos()
                {
                    Id = position++,
                    TypeId = type,
                    Group = group
                });
            }
            NumPositions = numNumbers / 2;
        }

        private List<LayoutPos> layoutPositions = new List<LayoutPos>();

        [XmlAttribute]
        public int NumPositions { get; set; }

        public List<LayoutPos> LayoutPositions
        {
            get { return layoutPositions; }
            set { layoutPositions = value; }
        }
    }
}
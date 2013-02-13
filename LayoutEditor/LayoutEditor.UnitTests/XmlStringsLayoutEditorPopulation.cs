
namespace LayoutEditor.UnitTests
{
    public class XmlStringsLayoutEditorPopulation
    {
        public string xml12x8AnyUnknowns7Standards =
            @"<LayoutEditorPopulation Width=""12"" Height=""8"">
				<SampleTypes>
					<SampleType Id=""1"" Name=""Unused"" Colour=""White""/>
					<SampleType Id=""2"" Name=""Standard"" Colour=""Red""/>
					<SampleType Id=""5"" Name=""Unknown"" Colour=""Lime""/>
				</SampleTypes>
				<Rules>
					<Rule TypeId=""5"" Description=""Any number of unknowns"" MinNumGroups=""1"" MaxNumGroups=""96"" MinNumReplicates=""1"" MaxNumReplicates=""96"" AllGroupsSameReplicates=""true""/>
					<Rule TypeId=""2"" Description=""7 standard groups"" NumGroups=""7"" MinNumReplicates=""1"" AllGroupsSameReplicates=""true""/>
				</Rules>
			</LayoutEditorPopulation>";

        public string xml12x8AnyUnknowns7Standards1Control =
            @"<LayoutEditorPopulation Width=""12"" Height=""8"">
				<SampleTypes>
					<SampleType Id=""1"" Name=""Unused"" Colour=""White""/>
					<SampleType Id=""2"" Name=""Standard"" Colour=""Red""/>
					<SampleType Id=""4"" Name=""Control"" Colour=""Aqua""/>
					<SampleType Id=""5"" Name=""Unknown"" Colour=""Lime""/>
				</SampleTypes>
				<Rules>
					<Rule TypeId=""5"" Description=""Any number of unknowns"" MinNumGroups=""1"" MaxNumGroups=""96"" MinNumReplicates=""1"" MaxNumReplicates=""96"" AllGroupsSameReplicates=""true""/>
					<Rule TypeId=""2"" Description=""7 standard groups"" NumGroups=""7"" MinNumReplicates=""1"" AllGroupsSameReplicates=""true""/>
					<Rule TypeId=""1"" Description=""1 control group"" MinNumGroups=""1"" MaxNumGroups=""1"" MinNumReplicates=""1"" AllGroupsSameReplicates=""true""/>
				</Rules>
			</LayoutEditorPopulation>";

        public string xml12x8AnyUnknowns7Standards1Control1Blank =
            @"<LayoutEditorPopulation Width=""12"" Height=""8"">
				<SampleTypes>
					<SampleType Id=""1"" Name=""Unused"" Colour=""White""/>
					<SampleType Id=""2"" Name=""Standard"" Colour=""Red""/>
					<SampleType Id=""3"" Name=""Blank"" Colour=""Yellow""/>
					<SampleType Id=""4"" Name=""Control"" Colour=""Aqua""/>
					<SampleType Id=""5"" Name=""Unknown"" Colour=""Lime""/>
				</SampleTypes>
				<Rules>
					<Rule TypeId=""5"" Description=""Any number of unknowns"" MinNumGroups=""1"" MaxNumGroups=""96"" MinNumReplicates=""1"" MaxNumReplicates=""96"" AllGroupsSameReplicates=""true""/>
					<Rule TypeId=""2"" Description=""7 standard groups"" NumGroups=""7"" MinNumReplicates=""1"" AllGroupsSameReplicates=""true""/>
					<Rule TypeId=""1"" Description=""1 control group"" MinNumGroups=""1"" MaxNumGroups=""1"" MinNumReplicates=""1"" AllGroupsSameReplicates=""true""/>
					<Rule TypeId=""3"" Description=""1 blank group"" MinNumGroups=""1"" MaxNumGroups=""1"" MinNumReplicates=""1"" AllGroupsSameReplicates=""true""/>
				</Rules>
			</LayoutEditorPopulation>";

        public string xml12x8AnyUnknowns7Standards8Controls1Blank =
            @"<LayoutEditorPopulation Width=""12"" Height=""8"">
				<SampleTypes>
					<SampleType Id=""1"" Name=""Unused"" Colour=""White""/>
					<SampleType Id=""2"" Name=""Standard"" Colour=""Red""/>
					<SampleType Id=""3"" Name=""Blank"" Colour=""Yellow""/>
					<SampleType Id=""4"" Name=""Control"" Colour=""Aqua""/>
					<SampleType Id=""5"" Name=""Unknown"" Colour=""Lime""/>
				</SampleTypes>
				<Rules>
					<Rule TypeId=""5"" Description=""Any number of unknowns"" AllGroupsSameReplicates=""true""/>
					<Rule TypeId=""2"" Description=""7 standard groups"" NumGroups=""7"" MinNumReplicates=""1"" AllGroupsSameReplicates=""true""/>
					<Rule TypeId=""1"" Description=""8 control groups"" MinNumGroups=""8"" MaxNumGroups=""8"" MinNumReplicates=""1"" AllGroupsSameReplicates=""true""/>
					<Rule TypeId=""3"" Description=""1 blank group"" MinNumGroups=""1"" MaxNumGroups=""1"" MinNumReplicates=""1"" AllGroupsSameReplicates=""true""/>
				</Rules>
			</LayoutEditorPopulation>";

        // A number of different ways of expressing the number of unknown groups (in this case 32)
        public string xml12x8Unknowns32RuleTests =
            @"<LayoutEditorPopulation Width=""12"" Height=""8"">
				<SampleTypes>
					<SampleType Id=""1"" Name=""Unused"" Colour=""White""/>
					<SampleType Id=""2"" Name=""Standard"" Colour=""Red""/>
					<SampleType Id=""3"" Name=""Blank"" Colour=""Yellow""/>
					<SampleType Id=""4"" Name=""Control"" Colour=""Aqua""/>
					<SampleType Id=""5"" Name=""Unknown"" Colour=""Lime""/>
				</SampleTypes>
				<Rules>
					<Rule TypeId=""5"" Description=""32 unknowns"" NumGroups=""32""/>
					<Rule TypeId=""5"" Description=""32 unknowns"" MinNumGroups=""32"" MaxNumGroups=""32""/>
					<Rule TypeId=""5"" Description=""32 unknowns"" MinNumGroups=""64"" MaxNumGroups=""32"" NumGroups=""32""/>
                    <Rule TypeId=""5"" Description=""Any unknowns"" MinNumGroups=""1"" MaxNumGroups=""96""/>
                    <Rule TypeId=""5"" Description=""At least 1 unknown"" MinNumGroups=""1"" />
                    <Rule TypeId=""5"" Description=""32 unknowns"" MaxNumGroups=""96""/>
                    <Rule TypeId=""5"" NumGroups=""32""/>
                    <Rule TypeId=""5"" NumReplicates=""2""/>
				</Rules>
			</LayoutEditorPopulation>";

        // Replicate rules on Unknowns - all duplicates
        public string xml12x8UnknownDuplicateRules =
            @"<LayoutEditorPopulation Width=""12"" Height=""8"">
				<SampleTypes>
                    <SampleType Id=""1"" Name=""Unused"" Colour=""White"" />
					<SampleType Id=""2"" Name=""Standard"" Colour=""Red""/>
                    <SampleType Id=""3"" Name=""Blank"" Colour=""Yellow"" />
                    <SampleType Id=""4"" Name=""Control"" Colour=""Aqua"" />
					<SampleType Id=""5"" Name=""Unknown"" Colour=""Lime""/>
                    <SampleType Id=""12"" Name=""StandardX"" Colour=""Red"" />
                    <SampleType Id=""13"" Name=""StandardY"" Colour=""ffc04080"" />
				</SampleTypes>
				<Rules>
					<Rule TypeId=""5"" NumReplicates=""2""/>
					<Rule TypeId=""5"" MinNumReplicates=""2"" /> 
					<Rule TypeId=""5"" MaxNumReplicates=""2"" />
					<Rule TypeId=""5"" MinNumReplicates=""2"" MaxNumReplicates=""2"" />
					<Rule TypeId=""5"" MinNumReplicates=""1"" MaxNumReplicates=""3"" />
				</Rules>
			</LayoutEditorPopulation>";

        // Replicate rules on Unknowns - all duplicates
        public string xml3x2UnknownDuplicateRules =
            @"<LayoutEditorPopulation Width=""3"" Height=""2"">
				<SampleTypes>
                    <SampleType Id=""1"" Name=""Unused"" Colour=""White"" />
					<SampleType Id=""2"" Name=""Standard"" Colour=""Red""/>
                    <SampleType Id=""3"" Name=""Blank"" Colour=""Yellow"" />
                    <SampleType Id=""4"" Name=""Control"" Colour=""Aqua"" />
					<SampleType Id=""5"" Name=""Unknown"" Colour=""Lime""/>
                    <SampleType Id=""12"" Name=""StandardX"" Colour=""Red"" />
                    <SampleType Id=""13"" Name=""StandardY"" Colour=""ffc04080"" />
				</SampleTypes>
				<Rules>
                    <Rule TypeId=""5"" NumReplicates=""2""/>
                    <Rule TypeId=""5"" MinNumReplicates=""2"" MaxNumReplicates=""2"" />
                    <Rule TypeId=""5"" MinNumReplicates=""2"" />
                    <Rule TypeId=""5"" MaxNumReplicates=""2"" />
                    <Rule TypeId=""5"" MinNumReplicates=""1"" MaxNumReplicates=""3"" />
                    <Rule TypeId=""5"" MinNumReplicates=""1"" MaxNumReplicates=""4"" AllGroupsSameReplicates=""true""/>
				</Rules>
			</LayoutEditorPopulation>";

        public string xmlAllTypesNoDimensionsOrRules =
            @"<LayoutEditorPopulation>
				<SampleTypes>
                    <SampleType Id=""1"" Name=""Unused"" Colour=""White"" />
					<SampleType Id=""2"" Name=""Standard"" Colour=""Red""/>
                    <SampleType Id=""3"" Name=""Blank"" Colour=""Yellow"" />
                    <SampleType Id=""4"" Name=""Control"" Colour=""Aqua"" />
					<SampleType Id=""5"" Name=""Unknown"" Colour=""Lime""/>
                    <SampleType Id=""12"" Name=""StandardX"" Colour=""Red"" />
                    <SampleType Id=""13"" Name=""StandardY"" Colour=""ffc04080"" />
				</SampleTypes>
			</LayoutEditorPopulation>";

        public string xml12x8AnyUnknowns7Standards1ControlEraseOnly =
            @"<LayoutEditorPopulation Width=""12"" Height=""8"" EraseOnly=""true"">
				<SampleTypes>
					<SampleType Id=""1"" Name=""Unused"" Colour=""White""/>
					<SampleType Id=""2"" Name=""Standard"" Colour=""Red""/>
					<SampleType Id=""4"" Name=""Control"" Colour=""Aqua""/>
					<SampleType Id=""5"" Name=""Unknown"" Colour=""Lime""/>
				</SampleTypes>
				<Rules>
					<Rule TypeId=""5"" MinNumGroups=""1"" MaxNumGroups=""96"" MinNumReplicates=""1"" MaxNumReplicates=""96"" AllGroupsSameReplicates=""true""/>
					<Rule TypeId=""2"" NumGroups=""7"" MinNumReplicates=""1"" AllGroupsSameReplicates=""true""/>
					<Rule TypeId=""2"" NumGroups=""7"" MinNumReplicates=""1"" AllGroupsSameReplicates=""true""/>
					<Rule TypeId=""4"" MinNumGroups=""1"" MaxNumGroups=""1"" MinNumReplicates=""1"" AllGroupsSameReplicates=""true""/>
				</Rules>
			</LayoutEditorPopulation>";

        // Matched type test - Blank and Unkown
        public string xml3x2MatchedTypes1 =
            @"<LayoutEditorPopulation Width=""3"" Height=""2"">
				<SampleTypes>
                    <SampleType Id=""1"" Name=""Unused"" Colour=""White"" />
					<SampleType Id=""2"" Name=""Standard"" Colour=""Red""/>
                    <SampleType Id=""3"" Name=""Blank"" Colour=""Yellow"" />
                    <SampleType Id=""4"" Name=""Control"" Colour=""Aqua"" />
					<SampleType Id=""5"" Name=""Unknown"" Colour=""Lime""/>
                    <SampleType Id=""12"" Name=""StandardX"" Colour=""Red"" />
                    <SampleType Id=""13"" Name=""StandardY"" Colour=""ffc04080"" />
				</SampleTypes>
				<Rules>
                    <Rule TypeId=""5"" MatchGroupsInTypeId=""3""/>
				</Rules>
			</LayoutEditorPopulation>";

        // Matched type test - Blank and Unkown
        public string xml3x2MatchedTypes2 =
            @"<LayoutEditorPopulation Width=""3"" Height=""2"">
				<SampleTypes>
                    <SampleType Id=""1"" Name=""Unused"" Colour=""White"" />
					<SampleType Id=""2"" Name=""Standard"" Colour=""Red""/>
                    <SampleType Id=""3"" Name=""Blank"" Colour=""Yellow"" />
                    <SampleType Id=""4"" Name=""Control"" Colour=""Aqua"" />
					<SampleType Id=""5"" Name=""Unknown"" Colour=""Lime""/>
                    <SampleType Id=""12"" Name=""StandardX"" Colour=""Red"" />
                    <SampleType Id=""13"" Name=""StandardY"" Colour=""ffc04080"" />
				</SampleTypes>
				<Rules>
                    <Rule TypeId=""3"" MatchGroupsInTypeId=""5""/>
				</Rules>
			</LayoutEditorPopulation>";

        // Matched type test - Blank and Unknown, and all Standards
        public string xml3x2MatchedTypes3 =
            @"<LayoutEditorPopulation Width=""3"" Height=""2"">
				<SampleTypes>
                    <SampleType Id=""1"" Name=""Unused"" Colour=""White"" />
					<SampleType Id=""2"" Name=""Standard"" Colour=""Red""/>
                    <SampleType Id=""3"" Name=""Blank"" Colour=""Yellow"" />
                    <SampleType Id=""4"" Name=""Control"" Colour=""Aqua"" />
					<SampleType Id=""5"" Name=""Unknown"" Colour=""Lime""/>
                    <SampleType Id=""12"" Name=""StandardX"" Colour=""Red"" />
                    <SampleType Id=""13"" Name=""StandardY"" Colour=""ffc04080"" />
				</SampleTypes>
				<Rules>
                    <Rule TypeId=""3"" MatchGroupsInTypeId=""5""/>
                    <Rule TypeId=""12"" MatchGroupsInTypeId=""13""/>
                    <Rule TypeId=""2"" MatchGroupsInTypeId=""12""/>
				</Rules>
			</LayoutEditorPopulation>";

        // Matched type test - Blank and Unknown, and all Standards
        public string xml3x2MatchedTypes4 =
            @"<LayoutEditorPopulation Width=""3"" Height=""2"">
				<SampleTypes>
                    <SampleType Id=""1"" Name=""Unused"" Colour=""White"" />
					<SampleType Id=""2"" Name=""Standard"" Colour=""Red""/>
                    <SampleType Id=""3"" Name=""Blank"" Colour=""Yellow"" />
                    <SampleType Id=""4"" Name=""Control"" Colour=""Aqua"" />
					<SampleType Id=""5"" Name=""Unknown"" Colour=""Lime""/>
                    <SampleType Id=""12"" Name=""StandardX"" Colour=""Red"" />
                    <SampleType Id=""13"" Name=""StandardY"" Colour=""ffc04080"" />
				</SampleTypes>
				<Rules>
                    <Rule TypeId=""3"" MatchGroupsInTypeId=""5""/>
                    <Rule TypeId=""12"" MatchGroupsInTypeId=""13""/>
                    <Rule TypeId=""12"" MatchGroupsInTypeId=""2""/>
				</Rules>
			</LayoutEditorPopulation>";


        // Matched type test - Blank and Unknown, and all Standards
        public string xml3x2MatchedTypes5 =
            @"<LayoutEditorPopulation Width=""3"" Height=""2"">
				<SampleTypes>
                    <SampleType Id=""1"" Name=""Unused"" Colour=""White"" />
					<SampleType Id=""2"" Name=""Standard"" Colour=""Red""/>
                    <SampleType Id=""3"" Name=""Blank"" Colour=""Yellow"" />
                    <SampleType Id=""4"" Name=""Control"" Colour=""Aqua"" />
					<SampleType Id=""5"" Name=""Unknown"" Colour=""Lime""/>
                    <SampleType Id=""12"" Name=""StandardX"" Colour=""Red"" />
                    <SampleType Id=""13"" Name=""StandardY"" Colour=""ffc04080"" />
				</SampleTypes>
				<Rules>
                    <Rule TypeId=""12"" MatchGroupsInTypeId=""2""/>
                    <Rule TypeId=""3"" MatchGroupsInTypeId=""5""/>
                    <Rule TypeId=""12"" MatchGroupsInTypeId=""13""/>
				</Rules>
			</LayoutEditorPopulation>";

        // Matched type test - All types matched
        public string xml3x2MatchedTypes6 =
            @"<LayoutEditorPopulation Width=""3"" Height=""2"">
				<SampleTypes>
                    <SampleType Id=""1"" Name=""Unused"" Colour=""White"" />
					<SampleType Id=""2"" Name=""Standard"" Colour=""Red""/>
                    <SampleType Id=""3"" Name=""Blank"" Colour=""Yellow"" />
                    <SampleType Id=""4"" Name=""Control"" Colour=""Aqua"" />
					<SampleType Id=""5"" Name=""Unknown"" Colour=""Lime""/>
                    <SampleType Id=""12"" Name=""StandardX"" Colour=""Red"" />
                    <SampleType Id=""13"" Name=""StandardY"" Colour=""ffc04080"" />
				</SampleTypes>
				<Rules>
                    <Rule TypeId=""2"" MatchGroupsInTypeId=""3""/>
                    <Rule TypeId=""3"" MatchGroupsInTypeId=""4""/>
                    <Rule TypeId=""4"" MatchGroupsInTypeId=""5""/>
                    <Rule TypeId=""5"" MatchGroupsInTypeId=""12""/>
                    <Rule TypeId=""12"" MatchGroupsInTypeId=""13""/>
				</Rules>
			</LayoutEditorPopulation>";

        public string xml3x2MatchedTypes7 =
            @"<LayoutEditorPopulation Width=""3"" Height=""2"">
				<SampleTypes>
                    <SampleType Id=""1"" Name=""Unused"" Colour=""White"" />
					<SampleType Id=""2"" Name=""Standard"" Colour=""Red""/>
                    <SampleType Id=""3"" Name=""Blank"" Colour=""Yellow"" />
                    <SampleType Id=""4"" Name=""Control"" Colour=""Aqua"" />
					<SampleType Id=""5"" Name=""Unknown"" Colour=""Lime""/>
                    <SampleType Id=""12"" Name=""StandardX"" Colour=""Red"" />
                    <SampleType Id=""13"" Name=""StandardY"" Colour=""ffc04080"" />
				</SampleTypes>
				<Rules>
                    <Rule TypeId=""2"" MatchGroupsInTypeId=""3""/>
                    <Rule TypeId=""2"" MatchGroupsInTypeId=""4""/>
                    <Rule TypeId=""2"" MatchGroupsInTypeId=""5""/>
                    <Rule TypeId=""2"" MatchGroupsInTypeId=""12""/>
                    <Rule TypeId=""2"" MatchGroupsInTypeId=""13""/>
				</Rules>
			</LayoutEditorPopulation>";



        // Matched type test - All types matched - currently an odd ordering sequence like this is not supported
        public string xml3x2MatchedTypesNotSupported =
            @"<LayoutEditorPopulation Width=""3"" Height=""2"">
				<SampleTypes>
                    <SampleType Id=""1"" Name=""Unused"" Colour=""White"" />
					<SampleType Id=""2"" Name=""Standard"" Colour=""Red""/>
                    <SampleType Id=""3"" Name=""Blank"" Colour=""Yellow"" />
                    <SampleType Id=""4"" Name=""Control"" Colour=""Aqua"" />
					<SampleType Id=""5"" Name=""Unknown"" Colour=""Lime""/>
                    <SampleType Id=""12"" Name=""StandardX"" Colour=""Red"" />
                    <SampleType Id=""13"" Name=""StandardY"" Colour=""ffc04080"" />
				</SampleTypes>
				<Rules>
                    <Rule TypeId=""2"" MatchGroupsInTypeId=""13""/>
                    <Rule TypeId=""3"" MatchGroupsInTypeId=""4""/>
                    <Rule TypeId=""4"" MatchGroupsInTypeId=""5""/>
                    <Rule TypeId=""5"" MatchGroupsInTypeId=""13""/>
                    <Rule TypeId=""12"" MatchGroupsInTypeId=""3""/>
				</Rules>
			</LayoutEditorPopulation>";

        // Erase only unknowns (although there is no rule for unknowns)
        public string xml12x8EraseOnlyUnknowns =
@"<LayoutEditorPopulation Width=""12"" Height=""8"" 
    Default=""8,1,8,1,8,1,7,1,7,1,7,1,5,6,5,6,5,6,5,6,5,6,5,6,3,1,3,2,3,3,3,4,3,5,3,6,5,7,5,7,5,7,5,7,5,7,5,7,3,1,3,2,3,3,3,4,3,5,3,6,5,8,5,8,5,8,5,8,5,8,5,8,5,1,5,1,5,1,5,1,5,1,5,1,5,9,5,9,5,9,5,9,5,9,5,9,5,2,5,2,5,2,5,2,5,2,5,2,5,10,5,10,5,10,5,10,5,10,5,10,5,3,5,3,5,3,5,3,5,3,5,3,5,11,5,11,5,11,5,11,5,11,5,11,5,4,5,4,5,4,5,4,5,4,5,4,5,12,5,12,5,12,5,12,5,12,5,12,5,5,5,5,5,5,5,5,5,5,5,5,5,13,5,13,5,13,5,13,5,13,5,13"" 
    EraseOnly=""true"">
				<SampleTypes>
					<SampleType Id=""1"" Name=""Unused"" Colour=""White""/>
					<SampleType Id=""3"" Name=""Blank"" Colour=""Yellow""/>
					<SampleType Id=""7"" Name=""Pos Control"" Colour=""#7DFFFF""/>
					<SampleType Id=""8"" Name=""Neg Control"" Colour=""#FEFCCF""/>
					<SampleType Id=""5"" Name=""Unknown"" Colour=""Lime""/>
				</SampleTypes>
				<Rules>
					<Rule TypeId=""3"" NumGroups=""6""/>
					<Rule TypeId=""7"" NumGroups=""1""/>
					<Rule TypeId=""8"" NumGroups=""1""/>
				</Rules>
			</LayoutEditorPopulation>";

        // Matched type test - Blank and Unknown, and all Standards - 
        public string xml3x2MatchedTypesValid =
            @"<LayoutEditorPopulation Width=""3"" Height=""2"">
				<SampleTypes>
                    <SampleType Id=""1"" Name=""Unused"" Colour=""White"" />
					<SampleType Id=""2"" Name=""Standard"" Colour=""Red""/>
                    <SampleType Id=""3"" Name=""Blank"" Colour=""Yellow"" />
                    <SampleType Id=""4"" Name=""Control"" Colour=""Aqua"" />
					<SampleType Id=""5"" Name=""Unknown"" Colour=""Lime""/>
                    <SampleType Id=""12"" Name=""StandardX"" Colour=""Red"" />
                    <SampleType Id=""13"" Name=""StandardY"" Colour=""ffc04080"" />
				</SampleTypes>
				<Rules>
                    <Rule TypeId=""12"" MatchGroupsInTypeId=""2"" NumGroups=""12""/>
                    <Rule TypeId=""3"" MatchGroupsInTypeId=""5""/>
                    <Rule TypeId=""12"" MatchGroupsInTypeId=""13"" />
				</Rules>
			</LayoutEditorPopulation>";


        // Matched type test - Blank and Unknown, and all Standards - however the NumGroups property is inconsistent
        public string xml3x2MatchedTypesInvalid =
            @"<LayoutEditorPopulation Width=""3"" Height=""2"">
				<SampleTypes>
                    <SampleType Id=""1"" Name=""Unused"" Colour=""White"" />
					<SampleType Id=""2"" Name=""Standard"" Colour=""Red""/>
                    <SampleType Id=""3"" Name=""Blank"" Colour=""Yellow"" />
                    <SampleType Id=""4"" Name=""Control"" Colour=""Aqua"" />
					<SampleType Id=""5"" Name=""Unknown"" Colour=""Lime""/>
                    <SampleType Id=""12"" Name=""StandardX"" Colour=""Red"" />
                    <SampleType Id=""13"" Name=""StandardY"" Colour=""ffc04080"" />
				</SampleTypes>
				<Rules>
                    <Rule TypeId=""12"" MatchGroupsInTypeId=""2"" NumGroups=""12""/>
                    <Rule TypeId=""3"" MatchGroupsInTypeId=""5""/>
                    <Rule TypeId=""12"" MatchGroupsInTypeId=""13"" NumGroups=""11""/>
				</Rules>
			</LayoutEditorPopulation>";
    }
}
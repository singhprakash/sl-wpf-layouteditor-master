
namespace LayoutEditor.UnitTests
{
    public class XmlStringsUserLayout
    {
        #region UserLayout Xml Strings
        // 12x8 1 single blank
        public string xml1Blank12x8 = @"<?xml version=""1.0"" encoding=""utf-16""?><UserLayout Width=""12"" Height=""8"">
            <SampleTypes><SampleType Id=""1"" Name=""Unused"" Colour=""White"" /><SampleType Id=""5"" Name=""Unknown"" Colour=""Lime"" /><SampleType Id=""3"" Name=""Blank"" Colour=""Yellow"" /></SampleTypes>
        <SingleLayoutLight NumPositions=""96""><LayoutPositions><LayoutPos TypeId=""3"" Group=""1"" Id=""16"" /></LayoutPositions></SingleLayoutLight></UserLayout>";

        // 6 standards, 1 blank, 41 unknowns all in duplicate
        public string xmlExample12x8 = @"<?xml version=""1.0"" encoding=""utf-8""?>
        <UserLayout Width=""12"" Height=""8"">
           <SampleTypes>
            <SampleType Id=""1"" Name=""Unused"" Colour=""White"" />
            <SampleType Id=""2"" Name=""Standard"" Colour=""Red"" />
            <SampleType Id=""3"" Name=""Blank"" Colour=""Yellow"" />
            <SampleType Id=""5"" Name=""Unknown"" Colour=""Lime"" />
          </SampleTypes>
          <SingleLayoutLight NumPositions=""96"">
            <LayoutPositions>
              <LayoutPos TypeId=""2"" Group=""1"" Id=""1"" />
              <LayoutPos TypeId=""2"" Group=""1"" Id=""2"" />
              <LayoutPos TypeId=""2"" Group=""2"" Id=""3"" />
              <LayoutPos TypeId=""2"" Group=""2"" Id=""4"" />
              <LayoutPos TypeId=""2"" Group=""3"" Id=""5"" />
              <LayoutPos TypeId=""2"" Group=""3"" Id=""6"" />
              <LayoutPos TypeId=""2"" Group=""4"" Id=""7"" />
              <LayoutPos TypeId=""2"" Group=""4"" Id=""8"" />
              <LayoutPos TypeId=""2"" Group=""5"" Id=""9"" />
              <LayoutPos TypeId=""2"" Group=""5"" Id=""10"" />
              <LayoutPos TypeId=""2"" Group=""6"" Id=""11"" />
              <LayoutPos TypeId=""2"" Group=""6"" Id=""12"" />
              <LayoutPos TypeId=""3"" Group=""1"" Id=""13"" />
              <LayoutPos TypeId=""3"" Group=""1"" Id=""14"" />
              <LayoutPos TypeId=""5"" Group=""1"" Id=""15"" />
              <LayoutPos TypeId=""5"" Group=""1"" Id=""16"" />
              <LayoutPos TypeId=""5"" Group=""2"" Id=""17"" />
              <LayoutPos TypeId=""5"" Group=""2"" Id=""18"" />
              <LayoutPos TypeId=""5"" Group=""3"" Id=""19"" />
              <LayoutPos TypeId=""5"" Group=""3"" Id=""20"" />
              <LayoutPos TypeId=""5"" Group=""4"" Id=""21"" />
              <LayoutPos TypeId=""5"" Group=""4"" Id=""22"" />
              <LayoutPos TypeId=""5"" Group=""5"" Id=""23"" />
              <LayoutPos TypeId=""5"" Group=""5"" Id=""24"" />
              <LayoutPos TypeId=""5"" Group=""6"" Id=""25"" />
              <LayoutPos TypeId=""5"" Group=""6"" Id=""26"" />
              <LayoutPos TypeId=""5"" Group=""7"" Id=""27"" />
              <LayoutPos TypeId=""5"" Group=""7"" Id=""28"" />
              <LayoutPos TypeId=""5"" Group=""8"" Id=""29"" />
              <LayoutPos TypeId=""5"" Group=""8"" Id=""30"" />
              <LayoutPos TypeId=""5"" Group=""9"" Id=""31"" />
              <LayoutPos TypeId=""5"" Group=""9"" Id=""32"" />
              <LayoutPos TypeId=""5"" Group=""10"" Id=""33"" />
              <LayoutPos TypeId=""5"" Group=""10"" Id=""34"" />
              <LayoutPos TypeId=""5"" Group=""11"" Id=""35"" />
              <LayoutPos TypeId=""5"" Group=""11"" Id=""36"" />
              <LayoutPos TypeId=""5"" Group=""12"" Id=""37"" />
              <LayoutPos TypeId=""5"" Group=""12"" Id=""38"" />
              <LayoutPos TypeId=""5"" Group=""13"" Id=""39"" />
              <LayoutPos TypeId=""5"" Group=""13"" Id=""40"" />
              <LayoutPos TypeId=""5"" Group=""14"" Id=""41"" />
              <LayoutPos TypeId=""5"" Group=""14"" Id=""42"" />
              <LayoutPos TypeId=""5"" Group=""15"" Id=""43"" />
              <LayoutPos TypeId=""5"" Group=""15"" Id=""44"" />
              <LayoutPos TypeId=""5"" Group=""16"" Id=""45"" />
              <LayoutPos TypeId=""5"" Group=""16"" Id=""46"" />
              <LayoutPos TypeId=""5"" Group=""17"" Id=""47"" />
              <LayoutPos TypeId=""5"" Group=""17"" Id=""48"" />
              <LayoutPos TypeId=""5"" Group=""18"" Id=""49"" />
              <LayoutPos TypeId=""5"" Group=""18"" Id=""50"" />
              <LayoutPos TypeId=""5"" Group=""19"" Id=""51"" />
              <LayoutPos TypeId=""5"" Group=""19"" Id=""52"" />
              <LayoutPos TypeId=""5"" Group=""20"" Id=""53"" />
              <LayoutPos TypeId=""5"" Group=""20"" Id=""54"" />
              <LayoutPos TypeId=""5"" Group=""21"" Id=""55"" />
              <LayoutPos TypeId=""5"" Group=""21"" Id=""56"" />
              <LayoutPos TypeId=""5"" Group=""22"" Id=""57"" />
              <LayoutPos TypeId=""5"" Group=""22"" Id=""58"" />
              <LayoutPos TypeId=""5"" Group=""23"" Id=""59"" />
              <LayoutPos TypeId=""5"" Group=""23"" Id=""60"" />
              <LayoutPos TypeId=""5"" Group=""24"" Id=""61"" />
              <LayoutPos TypeId=""5"" Group=""24"" Id=""62"" />
              <LayoutPos TypeId=""5"" Group=""25"" Id=""63"" />
              <LayoutPos TypeId=""5"" Group=""25"" Id=""64"" />
              <LayoutPos TypeId=""5"" Group=""26"" Id=""65"" />
              <LayoutPos TypeId=""5"" Group=""26"" Id=""66"" />
              <LayoutPos TypeId=""5"" Group=""27"" Id=""67"" />
              <LayoutPos TypeId=""5"" Group=""27"" Id=""68"" />
              <LayoutPos TypeId=""5"" Group=""28"" Id=""69"" />
              <LayoutPos TypeId=""5"" Group=""28"" Id=""70"" />
              <LayoutPos TypeId=""5"" Group=""29"" Id=""71"" />
              <LayoutPos TypeId=""5"" Group=""29"" Id=""72"" />
              <LayoutPos TypeId=""5"" Group=""30"" Id=""73"" />
              <LayoutPos TypeId=""5"" Group=""30"" Id=""74"" />
              <LayoutPos TypeId=""5"" Group=""31"" Id=""75"" />
              <LayoutPos TypeId=""5"" Group=""31"" Id=""76"" />
              <LayoutPos TypeId=""5"" Group=""32"" Id=""77"" />
              <LayoutPos TypeId=""5"" Group=""32"" Id=""78"" />
              <LayoutPos TypeId=""5"" Group=""33"" Id=""79"" />
              <LayoutPos TypeId=""5"" Group=""33"" Id=""80"" />
              <LayoutPos TypeId=""5"" Group=""34"" Id=""81"" />
              <LayoutPos TypeId=""5"" Group=""34"" Id=""82"" />
              <LayoutPos TypeId=""5"" Group=""35"" Id=""83"" />
              <LayoutPos TypeId=""5"" Group=""35"" Id=""84"" />
              <LayoutPos TypeId=""5"" Group=""36"" Id=""85"" />
              <LayoutPos TypeId=""5"" Group=""36"" Id=""86"" />
              <LayoutPos TypeId=""5"" Group=""37"" Id=""87"" />
              <LayoutPos TypeId=""5"" Group=""37"" Id=""88"" />
              <LayoutPos TypeId=""5"" Group=""38"" Id=""89"" />
              <LayoutPos TypeId=""5"" Group=""38"" Id=""90"" />
              <LayoutPos TypeId=""5"" Group=""39"" Id=""91"" />
              <LayoutPos TypeId=""5"" Group=""39"" Id=""92"" />
              <LayoutPos TypeId=""5"" Group=""40"" Id=""93"" />
              <LayoutPos TypeId=""5"" Group=""40"" Id=""94"" />
              <LayoutPos TypeId=""5"" Group=""41"" Id=""95"" />
              <LayoutPos TypeId=""5"" Group=""41"" Id=""96"" />
            </LayoutPositions>
          </SingleLayoutLight>
        </UserLayout>";

        public string xmlAll_Unknowns_Across =
@"<?xml version=""1.0"" encoding=""utf-8""?>
<UserLayout>
  <LayoutDimensions>
    <Width>12</Width>
    <Height>8</Height>
  </LayoutDimensions>
  <SampleTypes>
    <SampleType Id=""1"" Name=""Unused"" Colour=""White"" />
    <SampleType Id=""5"" Name=""Unknown"" Colour=""Lime"" />
  </SampleTypes>
  <SingleLayoutLight NumPositions=""96"">
    <LayoutPositions>
      <LayoutPos TypeId=""5"" Group=""1"" Id=""1"" />
      <LayoutPos TypeId=""5"" Group=""2"" Id=""2"" />
      <LayoutPos TypeId=""5"" Group=""3"" Id=""3"" />
      <LayoutPos TypeId=""5"" Group=""4"" Id=""4"" />
      <LayoutPos TypeId=""5"" Group=""5"" Id=""5"" />
      <LayoutPos TypeId=""5"" Group=""6"" Id=""6"" />
      <LayoutPos TypeId=""5"" Group=""7"" Id=""7"" />
      <LayoutPos TypeId=""5"" Group=""8"" Id=""8"" />
      <LayoutPos TypeId=""5"" Group=""9"" Id=""9"" />
      <LayoutPos TypeId=""5"" Group=""10"" Id=""10"" />
      <LayoutPos TypeId=""5"" Group=""11"" Id=""11"" />
      <LayoutPos TypeId=""5"" Group=""12"" Id=""12"" />
      <LayoutPos TypeId=""5"" Group=""13"" Id=""13"" />
      <LayoutPos TypeId=""5"" Group=""14"" Id=""14"" />
      <LayoutPos TypeId=""5"" Group=""15"" Id=""15"" />
      <LayoutPos TypeId=""5"" Group=""16"" Id=""16"" />
      <LayoutPos TypeId=""5"" Group=""17"" Id=""17"" />
      <LayoutPos TypeId=""5"" Group=""18"" Id=""18"" />
      <LayoutPos TypeId=""5"" Group=""19"" Id=""19"" />
      <LayoutPos TypeId=""5"" Group=""20"" Id=""20"" />
      <LayoutPos TypeId=""5"" Group=""21"" Id=""21"" />
      <LayoutPos TypeId=""5"" Group=""22"" Id=""22"" />
      <LayoutPos TypeId=""5"" Group=""23"" Id=""23"" />
      <LayoutPos TypeId=""5"" Group=""24"" Id=""24"" />
      <LayoutPos TypeId=""5"" Group=""25"" Id=""25"" />
      <LayoutPos TypeId=""5"" Group=""26"" Id=""26"" />
      <LayoutPos TypeId=""5"" Group=""27"" Id=""27"" />
      <LayoutPos TypeId=""5"" Group=""28"" Id=""28"" />
      <LayoutPos TypeId=""5"" Group=""29"" Id=""29"" />
      <LayoutPos TypeId=""5"" Group=""30"" Id=""30"" />
      <LayoutPos TypeId=""5"" Group=""31"" Id=""31"" />
      <LayoutPos TypeId=""5"" Group=""32"" Id=""32"" />
      <LayoutPos TypeId=""5"" Group=""33"" Id=""33"" />
      <LayoutPos TypeId=""5"" Group=""34"" Id=""34"" />
      <LayoutPos TypeId=""5"" Group=""35"" Id=""35"" />
      <LayoutPos TypeId=""5"" Group=""36"" Id=""36"" />
      <LayoutPos TypeId=""5"" Group=""37"" Id=""37"" />
      <LayoutPos TypeId=""5"" Group=""38"" Id=""38"" />
      <LayoutPos TypeId=""5"" Group=""39"" Id=""39"" />
      <LayoutPos TypeId=""5"" Group=""40"" Id=""40"" />
      <LayoutPos TypeId=""5"" Group=""41"" Id=""41"" />
      <LayoutPos TypeId=""5"" Group=""42"" Id=""42"" />
      <LayoutPos TypeId=""5"" Group=""43"" Id=""43"" />
      <LayoutPos TypeId=""5"" Group=""44"" Id=""44"" />
      <LayoutPos TypeId=""5"" Group=""45"" Id=""45"" />
      <LayoutPos TypeId=""5"" Group=""46"" Id=""46"" />
      <LayoutPos TypeId=""5"" Group=""47"" Id=""47"" />
      <LayoutPos TypeId=""5"" Group=""48"" Id=""48"" />
      <LayoutPos TypeId=""5"" Group=""49"" Id=""49"" />
      <LayoutPos TypeId=""5"" Group=""50"" Id=""50"" />
      <LayoutPos TypeId=""5"" Group=""51"" Id=""51"" />
      <LayoutPos TypeId=""5"" Group=""52"" Id=""52"" />
      <LayoutPos TypeId=""5"" Group=""53"" Id=""53"" />
      <LayoutPos TypeId=""5"" Group=""54"" Id=""54"" />
      <LayoutPos TypeId=""5"" Group=""55"" Id=""55"" />
      <LayoutPos TypeId=""5"" Group=""56"" Id=""56"" />
      <LayoutPos TypeId=""5"" Group=""57"" Id=""57"" />
      <LayoutPos TypeId=""5"" Group=""58"" Id=""58"" />
      <LayoutPos TypeId=""5"" Group=""59"" Id=""59"" />
      <LayoutPos TypeId=""5"" Group=""60"" Id=""60"" />
      <LayoutPos TypeId=""5"" Group=""61"" Id=""61"" />
      <LayoutPos TypeId=""5"" Group=""62"" Id=""62"" />
      <LayoutPos TypeId=""5"" Group=""63"" Id=""63"" />
      <LayoutPos TypeId=""5"" Group=""64"" Id=""64"" />
      <LayoutPos TypeId=""5"" Group=""65"" Id=""65"" />
      <LayoutPos TypeId=""5"" Group=""66"" Id=""66"" />
      <LayoutPos TypeId=""5"" Group=""67"" Id=""67"" />
      <LayoutPos TypeId=""5"" Group=""68"" Id=""68"" />
      <LayoutPos TypeId=""5"" Group=""69"" Id=""69"" />
      <LayoutPos TypeId=""5"" Group=""70"" Id=""70"" />
      <LayoutPos TypeId=""5"" Group=""71"" Id=""71"" />
      <LayoutPos TypeId=""5"" Group=""72"" Id=""72"" />
      <LayoutPos TypeId=""5"" Group=""73"" Id=""73"" />
      <LayoutPos TypeId=""5"" Group=""74"" Id=""74"" />
      <LayoutPos TypeId=""5"" Group=""75"" Id=""75"" />
      <LayoutPos TypeId=""5"" Group=""76"" Id=""76"" />
      <LayoutPos TypeId=""5"" Group=""77"" Id=""77"" />
      <LayoutPos TypeId=""5"" Group=""78"" Id=""78"" />
      <LayoutPos TypeId=""5"" Group=""79"" Id=""79"" />
      <LayoutPos TypeId=""5"" Group=""80"" Id=""80"" />
      <LayoutPos TypeId=""5"" Group=""81"" Id=""81"" />
      <LayoutPos TypeId=""5"" Group=""82"" Id=""82"" />
      <LayoutPos TypeId=""5"" Group=""83"" Id=""83"" />
      <LayoutPos TypeId=""5"" Group=""84"" Id=""84"" />
      <LayoutPos TypeId=""5"" Group=""85"" Id=""85"" />
      <LayoutPos TypeId=""5"" Group=""86"" Id=""86"" />
      <LayoutPos TypeId=""5"" Group=""87"" Id=""87"" />
      <LayoutPos TypeId=""5"" Group=""88"" Id=""88"" />
      <LayoutPos TypeId=""5"" Group=""89"" Id=""89"" />
      <LayoutPos TypeId=""5"" Group=""90"" Id=""90"" />
      <LayoutPos TypeId=""5"" Group=""91"" Id=""91"" />
      <LayoutPos TypeId=""5"" Group=""92"" Id=""92"" />
      <LayoutPos TypeId=""5"" Group=""93"" Id=""93"" />
      <LayoutPos TypeId=""5"" Group=""94"" Id=""94"" />
      <LayoutPos TypeId=""5"" Group=""95"" Id=""95"" />
      <LayoutPos TypeId=""5"" Group=""96"" Id=""96"" />
    </LayoutPositions>
  </SingleLayoutLight>
</UserLayout>";

        public string xmlAll_Unknowns__Across_ = @"<?xml version=""1.0"" encoding=""utf-8""?>
<UserLayout>
  <LayoutDimensions>
    <Width>12</Width>
    <Height>8</Height>
  </LayoutDimensions>
  <SampleTypes>
    <SampleType Id=""1"" Name=""Unused"" Colour=""White"" />
    <SampleType Id=""5"" Name=""Unknown"" Colour=""Lime"" />
  </SampleTypes>
  <SingleLayoutLight NumPositions=""96"">
    <LayoutPositions>
      <LayoutPos TypeId=""5"" Group=""1"" Id=""1"" />
      <LayoutPos TypeId=""5"" Group=""2"" Id=""2"" />
      <LayoutPos TypeId=""5"" Group=""3"" Id=""3"" />
      <LayoutPos TypeId=""5"" Group=""4"" Id=""4"" />
      <LayoutPos TypeId=""5"" Group=""5"" Id=""5"" />
      <LayoutPos TypeId=""5"" Group=""6"" Id=""6"" />
      <LayoutPos TypeId=""5"" Group=""7"" Id=""7"" />
      <LayoutPos TypeId=""5"" Group=""8"" Id=""8"" />
      <LayoutPos TypeId=""5"" Group=""9"" Id=""9"" />
      <LayoutPos TypeId=""5"" Group=""10"" Id=""10"" />
      <LayoutPos TypeId=""5"" Group=""11"" Id=""11"" />
      <LayoutPos TypeId=""5"" Group=""12"" Id=""12"" />
      <LayoutPos TypeId=""5"" Group=""13"" Id=""13"" />
      <LayoutPos TypeId=""5"" Group=""14"" Id=""14"" />
      <LayoutPos TypeId=""5"" Group=""15"" Id=""15"" />
      <LayoutPos TypeId=""5"" Group=""16"" Id=""16"" />
      <LayoutPos TypeId=""5"" Group=""17"" Id=""17"" />
      <LayoutPos TypeId=""5"" Group=""18"" Id=""18"" />
      <LayoutPos TypeId=""5"" Group=""19"" Id=""19"" />
      <LayoutPos TypeId=""5"" Group=""20"" Id=""20"" />
      <LayoutPos TypeId=""5"" Group=""21"" Id=""21"" />
      <LayoutPos TypeId=""5"" Group=""22"" Id=""22"" />
      <LayoutPos TypeId=""5"" Group=""23"" Id=""23"" />
      <LayoutPos TypeId=""5"" Group=""24"" Id=""24"" />
      <LayoutPos TypeId=""5"" Group=""25"" Id=""25"" />
      <LayoutPos TypeId=""5"" Group=""26"" Id=""26"" />
      <LayoutPos TypeId=""5"" Group=""27"" Id=""27"" />
      <LayoutPos TypeId=""5"" Group=""28"" Id=""28"" />
      <LayoutPos TypeId=""5"" Group=""29"" Id=""29"" />
      <LayoutPos TypeId=""5"" Group=""30"" Id=""30"" />
      <LayoutPos TypeId=""5"" Group=""31"" Id=""31"" />
      <LayoutPos TypeId=""5"" Group=""32"" Id=""32"" />
      <LayoutPos TypeId=""5"" Group=""33"" Id=""33"" />
      <LayoutPos TypeId=""5"" Group=""34"" Id=""34"" />
      <LayoutPos TypeId=""5"" Group=""35"" Id=""35"" />
      <LayoutPos TypeId=""5"" Group=""36"" Id=""36"" />
      <LayoutPos TypeId=""5"" Group=""37"" Id=""37"" />
      <LayoutPos TypeId=""5"" Group=""38"" Id=""38"" />
      <LayoutPos TypeId=""5"" Group=""39"" Id=""39"" />
      <LayoutPos TypeId=""5"" Group=""40"" Id=""40"" />
      <LayoutPos TypeId=""5"" Group=""41"" Id=""41"" />
      <LayoutPos TypeId=""5"" Group=""42"" Id=""42"" />
      <LayoutPos TypeId=""5"" Group=""43"" Id=""43"" />
      <LayoutPos TypeId=""5"" Group=""44"" Id=""44"" />
      <LayoutPos TypeId=""5"" Group=""45"" Id=""45"" />
      <LayoutPos TypeId=""5"" Group=""46"" Id=""46"" />
      <LayoutPos TypeId=""5"" Group=""47"" Id=""47"" />
      <LayoutPos TypeId=""5"" Group=""48"" Id=""48"" />
      <LayoutPos TypeId=""5"" Group=""49"" Id=""49"" />
      <LayoutPos TypeId=""5"" Group=""50"" Id=""50"" />
      <LayoutPos TypeId=""5"" Group=""51"" Id=""51"" />
      <LayoutPos TypeId=""5"" Group=""52"" Id=""52"" />
      <LayoutPos TypeId=""5"" Group=""53"" Id=""53"" />
      <LayoutPos TypeId=""5"" Group=""54"" Id=""54"" />
      <LayoutPos TypeId=""5"" Group=""55"" Id=""55"" />
      <LayoutPos TypeId=""5"" Group=""56"" Id=""56"" />
      <LayoutPos TypeId=""5"" Group=""57"" Id=""57"" />
      <LayoutPos TypeId=""5"" Group=""58"" Id=""58"" />
      <LayoutPos TypeId=""5"" Group=""59"" Id=""59"" />
      <LayoutPos TypeId=""5"" Group=""60"" Id=""60"" />
      <LayoutPos TypeId=""5"" Group=""61"" Id=""61"" />
      <LayoutPos TypeId=""5"" Group=""62"" Id=""62"" />
      <LayoutPos TypeId=""5"" Group=""63"" Id=""63"" />
      <LayoutPos TypeId=""5"" Group=""64"" Id=""64"" />
      <LayoutPos TypeId=""5"" Group=""65"" Id=""65"" />
      <LayoutPos TypeId=""5"" Group=""66"" Id=""66"" />
      <LayoutPos TypeId=""5"" Group=""67"" Id=""67"" />
      <LayoutPos TypeId=""5"" Group=""68"" Id=""68"" />
      <LayoutPos TypeId=""5"" Group=""69"" Id=""69"" />
      <LayoutPos TypeId=""5"" Group=""70"" Id=""70"" />
      <LayoutPos TypeId=""5"" Group=""71"" Id=""71"" />
      <LayoutPos TypeId=""5"" Group=""72"" Id=""72"" />
      <LayoutPos TypeId=""5"" Group=""73"" Id=""73"" />
      <LayoutPos TypeId=""5"" Group=""74"" Id=""74"" />
      <LayoutPos TypeId=""5"" Group=""75"" Id=""75"" />
      <LayoutPos TypeId=""5"" Group=""76"" Id=""76"" />
      <LayoutPos TypeId=""5"" Group=""77"" Id=""77"" />
      <LayoutPos TypeId=""5"" Group=""78"" Id=""78"" />
      <LayoutPos TypeId=""5"" Group=""79"" Id=""79"" />
      <LayoutPos TypeId=""5"" Group=""80"" Id=""80"" />
      <LayoutPos TypeId=""5"" Group=""81"" Id=""81"" />
      <LayoutPos TypeId=""5"" Group=""82"" Id=""82"" />
      <LayoutPos TypeId=""5"" Group=""83"" Id=""83"" />
      <LayoutPos TypeId=""5"" Group=""84"" Id=""84"" />
      <LayoutPos TypeId=""5"" Group=""85"" Id=""85"" />
      <LayoutPos TypeId=""5"" Group=""86"" Id=""86"" />
      <LayoutPos TypeId=""5"" Group=""87"" Id=""87"" />
      <LayoutPos TypeId=""5"" Group=""88"" Id=""88"" />
      <LayoutPos TypeId=""5"" Group=""89"" Id=""89"" />
      <LayoutPos TypeId=""5"" Group=""90"" Id=""90"" />
      <LayoutPos TypeId=""5"" Group=""91"" Id=""91"" />
      <LayoutPos TypeId=""5"" Group=""92"" Id=""92"" />
      <LayoutPos TypeId=""5"" Group=""93"" Id=""93"" />
      <LayoutPos TypeId=""5"" Group=""94"" Id=""94"" />
      <LayoutPos TypeId=""5"" Group=""95"" Id=""95"" />
      <LayoutPos TypeId=""5"" Group=""96"" Id=""96"" />
    </LayoutPositions>
  </SingleLayoutLight>
</UserLayout>";
        public string xmlAll_Unknowns__Down_ = @"<?xml version=""1.0"" encoding=""utf-8""?>
<UserLayout>
  <LayoutDimensions>
    <Width>12</Width>
    <Height>8</Height>
  </LayoutDimensions>
  <SampleTypes>
    <SampleType Id=""1"" Name=""Unused"" Colour=""White"" />
    <SampleType Id=""5"" Name=""Unknown"" Colour=""Lime"" />
  </SampleTypes>
  <SingleLayoutLight NumPositions=""96"">
    <LayoutPositions>
      <LayoutPos TypeId=""5"" Group=""1"" Id=""1"" />
      <LayoutPos TypeId=""5"" Group=""9"" Id=""2"" />
      <LayoutPos TypeId=""5"" Group=""17"" Id=""3"" />
      <LayoutPos TypeId=""5"" Group=""25"" Id=""4"" />
      <LayoutPos TypeId=""5"" Group=""33"" Id=""5"" />
      <LayoutPos TypeId=""5"" Group=""41"" Id=""6"" />
      <LayoutPos TypeId=""5"" Group=""49"" Id=""7"" />
      <LayoutPos TypeId=""5"" Group=""57"" Id=""8"" />
      <LayoutPos TypeId=""5"" Group=""65"" Id=""9"" />
      <LayoutPos TypeId=""5"" Group=""73"" Id=""10"" />
      <LayoutPos TypeId=""5"" Group=""81"" Id=""11"" />
      <LayoutPos TypeId=""5"" Group=""89"" Id=""12"" />
      <LayoutPos TypeId=""5"" Group=""2"" Id=""13"" />
      <LayoutPos TypeId=""5"" Group=""10"" Id=""14"" />
      <LayoutPos TypeId=""5"" Group=""18"" Id=""15"" />
      <LayoutPos TypeId=""5"" Group=""26"" Id=""16"" />
      <LayoutPos TypeId=""5"" Group=""34"" Id=""17"" />
      <LayoutPos TypeId=""5"" Group=""42"" Id=""18"" />
      <LayoutPos TypeId=""5"" Group=""50"" Id=""19"" />
      <LayoutPos TypeId=""5"" Group=""58"" Id=""20"" />
      <LayoutPos TypeId=""5"" Group=""66"" Id=""21"" />
      <LayoutPos TypeId=""5"" Group=""74"" Id=""22"" />
      <LayoutPos TypeId=""5"" Group=""82"" Id=""23"" />
      <LayoutPos TypeId=""5"" Group=""90"" Id=""24"" />
      <LayoutPos TypeId=""5"" Group=""3"" Id=""25"" />
      <LayoutPos TypeId=""5"" Group=""11"" Id=""26"" />
      <LayoutPos TypeId=""5"" Group=""19"" Id=""27"" />
      <LayoutPos TypeId=""5"" Group=""27"" Id=""28"" />
      <LayoutPos TypeId=""5"" Group=""35"" Id=""29"" />
      <LayoutPos TypeId=""5"" Group=""43"" Id=""30"" />
      <LayoutPos TypeId=""5"" Group=""51"" Id=""31"" />
      <LayoutPos TypeId=""5"" Group=""59"" Id=""32"" />
      <LayoutPos TypeId=""5"" Group=""67"" Id=""33"" />
      <LayoutPos TypeId=""5"" Group=""75"" Id=""34"" />
      <LayoutPos TypeId=""5"" Group=""83"" Id=""35"" />
      <LayoutPos TypeId=""5"" Group=""91"" Id=""36"" />
      <LayoutPos TypeId=""5"" Group=""4"" Id=""37"" />
      <LayoutPos TypeId=""5"" Group=""12"" Id=""38"" />
      <LayoutPos TypeId=""5"" Group=""20"" Id=""39"" />
      <LayoutPos TypeId=""5"" Group=""28"" Id=""40"" />
      <LayoutPos TypeId=""5"" Group=""36"" Id=""41"" />
      <LayoutPos TypeId=""5"" Group=""44"" Id=""42"" />
      <LayoutPos TypeId=""5"" Group=""52"" Id=""43"" />
      <LayoutPos TypeId=""5"" Group=""60"" Id=""44"" />
      <LayoutPos TypeId=""5"" Group=""68"" Id=""45"" />
      <LayoutPos TypeId=""5"" Group=""76"" Id=""46"" />
      <LayoutPos TypeId=""5"" Group=""84"" Id=""47"" />
      <LayoutPos TypeId=""5"" Group=""92"" Id=""48"" />
      <LayoutPos TypeId=""5"" Group=""5"" Id=""49"" />
      <LayoutPos TypeId=""5"" Group=""13"" Id=""50"" />
      <LayoutPos TypeId=""5"" Group=""21"" Id=""51"" />
      <LayoutPos TypeId=""5"" Group=""29"" Id=""52"" />
      <LayoutPos TypeId=""5"" Group=""37"" Id=""53"" />
      <LayoutPos TypeId=""5"" Group=""45"" Id=""54"" />
      <LayoutPos TypeId=""5"" Group=""53"" Id=""55"" />
      <LayoutPos TypeId=""5"" Group=""61"" Id=""56"" />
      <LayoutPos TypeId=""5"" Group=""69"" Id=""57"" />
      <LayoutPos TypeId=""5"" Group=""77"" Id=""58"" />
      <LayoutPos TypeId=""5"" Group=""85"" Id=""59"" />
      <LayoutPos TypeId=""5"" Group=""93"" Id=""60"" />
      <LayoutPos TypeId=""5"" Group=""6"" Id=""61"" />
      <LayoutPos TypeId=""5"" Group=""14"" Id=""62"" />
      <LayoutPos TypeId=""5"" Group=""22"" Id=""63"" />
      <LayoutPos TypeId=""5"" Group=""30"" Id=""64"" />
      <LayoutPos TypeId=""5"" Group=""38"" Id=""65"" />
      <LayoutPos TypeId=""5"" Group=""46"" Id=""66"" />
      <LayoutPos TypeId=""5"" Group=""54"" Id=""67"" />
      <LayoutPos TypeId=""5"" Group=""62"" Id=""68"" />
      <LayoutPos TypeId=""5"" Group=""70"" Id=""69"" />
      <LayoutPos TypeId=""5"" Group=""78"" Id=""70"" />
      <LayoutPos TypeId=""5"" Group=""86"" Id=""71"" />
      <LayoutPos TypeId=""5"" Group=""94"" Id=""72"" />
      <LayoutPos TypeId=""5"" Group=""7"" Id=""73"" />
      <LayoutPos TypeId=""5"" Group=""15"" Id=""74"" />
      <LayoutPos TypeId=""5"" Group=""23"" Id=""75"" />
      <LayoutPos TypeId=""5"" Group=""31"" Id=""76"" />
      <LayoutPos TypeId=""5"" Group=""39"" Id=""77"" />
      <LayoutPos TypeId=""5"" Group=""47"" Id=""78"" />
      <LayoutPos TypeId=""5"" Group=""55"" Id=""79"" />
      <LayoutPos TypeId=""5"" Group=""63"" Id=""80"" />
      <LayoutPos TypeId=""5"" Group=""71"" Id=""81"" />
      <LayoutPos TypeId=""5"" Group=""79"" Id=""82"" />
      <LayoutPos TypeId=""5"" Group=""87"" Id=""83"" />
      <LayoutPos TypeId=""5"" Group=""95"" Id=""84"" />
      <LayoutPos TypeId=""5"" Group=""8"" Id=""85"" />
      <LayoutPos TypeId=""5"" Group=""16"" Id=""86"" />
      <LayoutPos TypeId=""5"" Group=""24"" Id=""87"" />
      <LayoutPos TypeId=""5"" Group=""32"" Id=""88"" />
      <LayoutPos TypeId=""5"" Group=""40"" Id=""89"" />
      <LayoutPos TypeId=""5"" Group=""48"" Id=""90"" />
      <LayoutPos TypeId=""5"" Group=""56"" Id=""91"" />
      <LayoutPos TypeId=""5"" Group=""64"" Id=""92"" />
      <LayoutPos TypeId=""5"" Group=""72"" Id=""93"" />
      <LayoutPos TypeId=""5"" Group=""80"" Id=""94"" />
      <LayoutPos TypeId=""5"" Group=""88"" Id=""95"" />
      <LayoutPos TypeId=""5"" Group=""96"" Id=""96"" />
    </LayoutPositions>
  </SingleLayoutLight>
</UserLayout>";
        public string xmlExample_1_1_Blanks_ = @"<?xml version=""1.0"" encoding=""utf-8""?>
<UserLayout>
  <LayoutDimensions>
    <Width>12</Width>
    <Height>8</Height>
  </LayoutDimensions>
  <SampleTypes>
    <SampleType Id=""1"" Name=""Unused"" Colour=""White"" />
    <SampleType Id=""3"" Name=""Blank"" Colour=""Yellow"" />
    <SampleType Id=""5"" Name=""Unknown"" Colour=""Lime"" />
  </SampleTypes>
  <SingleLayoutLight NumPositions=""96"">
    <LayoutPositions>
      <LayoutPos TypeId=""5"" Group=""1"" Id=""14"" />
      <LayoutPos TypeId=""5"" Group=""1"" Id=""15"" />
      <LayoutPos TypeId=""3"" Group=""1"" Id=""16"" />
      <LayoutPos TypeId=""3"" Group=""1"" Id=""17"" />
      <LayoutPos TypeId=""5"" Group=""7"" Id=""20"" />
      <LayoutPos TypeId=""5"" Group=""7"" Id=""21"" />
      <LayoutPos TypeId=""3"" Group=""7"" Id=""22"" />
      <LayoutPos TypeId=""3"" Group=""7"" Id=""23"" />
      <LayoutPos TypeId=""5"" Group=""2"" Id=""26"" />
      <LayoutPos TypeId=""5"" Group=""2"" Id=""27"" />
      <LayoutPos TypeId=""3"" Group=""2"" Id=""28"" />
      <LayoutPos TypeId=""3"" Group=""2"" Id=""29"" />
      <LayoutPos TypeId=""5"" Group=""8"" Id=""32"" />
      <LayoutPos TypeId=""5"" Group=""8"" Id=""33"" />
      <LayoutPos TypeId=""3"" Group=""8"" Id=""34"" />
      <LayoutPos TypeId=""3"" Group=""8"" Id=""35"" />
      <LayoutPos TypeId=""5"" Group=""3"" Id=""38"" />
      <LayoutPos TypeId=""5"" Group=""3"" Id=""39"" />
      <LayoutPos TypeId=""3"" Group=""3"" Id=""40"" />
      <LayoutPos TypeId=""3"" Group=""3"" Id=""41"" />
      <LayoutPos TypeId=""5"" Group=""9"" Id=""44"" />
      <LayoutPos TypeId=""5"" Group=""9"" Id=""45"" />
      <LayoutPos TypeId=""3"" Group=""9"" Id=""46"" />
      <LayoutPos TypeId=""3"" Group=""9"" Id=""47"" />
      <LayoutPos TypeId=""5"" Group=""4"" Id=""50"" />
      <LayoutPos TypeId=""5"" Group=""4"" Id=""51"" />
      <LayoutPos TypeId=""3"" Group=""4"" Id=""52"" />
      <LayoutPos TypeId=""3"" Group=""4"" Id=""53"" />
      <LayoutPos TypeId=""5"" Group=""10"" Id=""56"" />
      <LayoutPos TypeId=""5"" Group=""10"" Id=""57"" />
      <LayoutPos TypeId=""3"" Group=""10"" Id=""58"" />
      <LayoutPos TypeId=""3"" Group=""10"" Id=""59"" />
      <LayoutPos TypeId=""5"" Group=""5"" Id=""62"" />
      <LayoutPos TypeId=""5"" Group=""5"" Id=""63"" />
      <LayoutPos TypeId=""3"" Group=""5"" Id=""64"" />
      <LayoutPos TypeId=""3"" Group=""5"" Id=""65"" />
      <LayoutPos TypeId=""5"" Group=""11"" Id=""68"" />
      <LayoutPos TypeId=""5"" Group=""11"" Id=""69"" />
      <LayoutPos TypeId=""3"" Group=""11"" Id=""70"" />
      <LayoutPos TypeId=""3"" Group=""11"" Id=""71"" />
      <LayoutPos TypeId=""5"" Group=""6"" Id=""74"" />
      <LayoutPos TypeId=""5"" Group=""6"" Id=""75"" />
      <LayoutPos TypeId=""3"" Group=""6"" Id=""76"" />
      <LayoutPos TypeId=""3"" Group=""6"" Id=""77"" />
      <LayoutPos TypeId=""5"" Group=""12"" Id=""80"" />
      <LayoutPos TypeId=""5"" Group=""12"" Id=""81"" />
      <LayoutPos TypeId=""3"" Group=""12"" Id=""82"" />
      <LayoutPos TypeId=""3"" Group=""12"" Id=""83"" />
    </LayoutPositions>
  </SingleLayoutLight>
</UserLayout>";
        public string xmlExample_12x8__1_ = @"<?xml version=""1.0"" encoding=""utf-8""?>
<UserLayout>
  <LayoutDimensions>
    <Width>12</Width>
    <Height>8</Height>
  </LayoutDimensions>
  <SampleTypes>
    <SampleType Id=""1"" Name=""Unused"" Colour=""White"" />
    <SampleType Id=""2"" Name=""Standard"" Colour=""Red"" />
    <SampleType Id=""3"" Name=""Blank"" Colour=""Yellow"" />
    <SampleType Id=""5"" Name=""Unknown"" Colour=""Lime"" />
  </SampleTypes>
  <SingleLayoutLight NumPositions=""96"">
    <LayoutPositions>
      <LayoutPos TypeId=""2"" Group=""1"" Id=""1"" />
      <LayoutPos TypeId=""2"" Group=""1"" Id=""2"" />
      <LayoutPos TypeId=""2"" Group=""2"" Id=""3"" />
      <LayoutPos TypeId=""2"" Group=""2"" Id=""4"" />
      <LayoutPos TypeId=""2"" Group=""3"" Id=""5"" />
      <LayoutPos TypeId=""2"" Group=""3"" Id=""6"" />
      <LayoutPos TypeId=""2"" Group=""4"" Id=""7"" />
      <LayoutPos TypeId=""2"" Group=""4"" Id=""8"" />
      <LayoutPos TypeId=""2"" Group=""5"" Id=""9"" />
      <LayoutPos TypeId=""2"" Group=""5"" Id=""10"" />
      <LayoutPos TypeId=""2"" Group=""6"" Id=""11"" />
      <LayoutPos TypeId=""2"" Group=""6"" Id=""12"" />
      <LayoutPos TypeId=""3"" Group=""1"" Id=""13"" />
      <LayoutPos TypeId=""3"" Group=""1"" Id=""14"" />
      <LayoutPos TypeId=""5"" Group=""1"" Id=""15"" />
      <LayoutPos TypeId=""5"" Group=""1"" Id=""16"" />
      <LayoutPos TypeId=""5"" Group=""2"" Id=""17"" />
      <LayoutPos TypeId=""5"" Group=""2"" Id=""18"" />
      <LayoutPos TypeId=""5"" Group=""3"" Id=""19"" />
      <LayoutPos TypeId=""5"" Group=""3"" Id=""20"" />
      <LayoutPos TypeId=""5"" Group=""4"" Id=""21"" />
      <LayoutPos TypeId=""5"" Group=""4"" Id=""22"" />
      <LayoutPos TypeId=""5"" Group=""5"" Id=""23"" />
      <LayoutPos TypeId=""5"" Group=""5"" Id=""24"" />
      <LayoutPos TypeId=""5"" Group=""6"" Id=""25"" />
      <LayoutPos TypeId=""5"" Group=""6"" Id=""26"" />
      <LayoutPos TypeId=""5"" Group=""7"" Id=""27"" />
      <LayoutPos TypeId=""5"" Group=""7"" Id=""28"" />
      <LayoutPos TypeId=""5"" Group=""8"" Id=""29"" />
      <LayoutPos TypeId=""5"" Group=""8"" Id=""30"" />
      <LayoutPos TypeId=""5"" Group=""9"" Id=""31"" />
      <LayoutPos TypeId=""5"" Group=""9"" Id=""32"" />
      <LayoutPos TypeId=""5"" Group=""10"" Id=""33"" />
      <LayoutPos TypeId=""5"" Group=""10"" Id=""34"" />
      <LayoutPos TypeId=""5"" Group=""11"" Id=""35"" />
      <LayoutPos TypeId=""5"" Group=""11"" Id=""36"" />
      <LayoutPos TypeId=""5"" Group=""12"" Id=""37"" />
      <LayoutPos TypeId=""5"" Group=""12"" Id=""38"" />
      <LayoutPos TypeId=""5"" Group=""13"" Id=""39"" />
      <LayoutPos TypeId=""5"" Group=""13"" Id=""40"" />
      <LayoutPos TypeId=""5"" Group=""14"" Id=""41"" />
      <LayoutPos TypeId=""5"" Group=""14"" Id=""42"" />
      <LayoutPos TypeId=""5"" Group=""15"" Id=""43"" />
      <LayoutPos TypeId=""5"" Group=""15"" Id=""44"" />
      <LayoutPos TypeId=""5"" Group=""16"" Id=""45"" />
      <LayoutPos TypeId=""5"" Group=""16"" Id=""46"" />
      <LayoutPos TypeId=""5"" Group=""17"" Id=""47"" />
      <LayoutPos TypeId=""5"" Group=""17"" Id=""48"" />
      <LayoutPos TypeId=""5"" Group=""18"" Id=""49"" />
      <LayoutPos TypeId=""5"" Group=""18"" Id=""50"" />
      <LayoutPos TypeId=""5"" Group=""19"" Id=""51"" />
      <LayoutPos TypeId=""5"" Group=""19"" Id=""52"" />
      <LayoutPos TypeId=""5"" Group=""20"" Id=""53"" />
      <LayoutPos TypeId=""5"" Group=""20"" Id=""54"" />
      <LayoutPos TypeId=""5"" Group=""21"" Id=""55"" />
      <LayoutPos TypeId=""5"" Group=""21"" Id=""56"" />
      <LayoutPos TypeId=""5"" Group=""22"" Id=""57"" />
      <LayoutPos TypeId=""5"" Group=""22"" Id=""58"" />
      <LayoutPos TypeId=""5"" Group=""23"" Id=""59"" />
      <LayoutPos TypeId=""5"" Group=""23"" Id=""60"" />
      <LayoutPos TypeId=""5"" Group=""24"" Id=""61"" />
      <LayoutPos TypeId=""5"" Group=""24"" Id=""62"" />
      <LayoutPos TypeId=""5"" Group=""25"" Id=""63"" />
      <LayoutPos TypeId=""5"" Group=""25"" Id=""64"" />
      <LayoutPos TypeId=""5"" Group=""26"" Id=""65"" />
      <LayoutPos TypeId=""5"" Group=""26"" Id=""66"" />
      <LayoutPos TypeId=""5"" Group=""27"" Id=""67"" />
      <LayoutPos TypeId=""5"" Group=""27"" Id=""68"" />
      <LayoutPos TypeId=""5"" Group=""28"" Id=""69"" />
      <LayoutPos TypeId=""5"" Group=""28"" Id=""70"" />
      <LayoutPos TypeId=""5"" Group=""29"" Id=""71"" />
      <LayoutPos TypeId=""5"" Group=""29"" Id=""72"" />
      <LayoutPos TypeId=""5"" Group=""30"" Id=""73"" />
      <LayoutPos TypeId=""5"" Group=""30"" Id=""74"" />
      <LayoutPos TypeId=""5"" Group=""31"" Id=""75"" />
      <LayoutPos TypeId=""5"" Group=""31"" Id=""76"" />
      <LayoutPos TypeId=""5"" Group=""32"" Id=""77"" />
      <LayoutPos TypeId=""5"" Group=""32"" Id=""78"" />
      <LayoutPos TypeId=""5"" Group=""33"" Id=""79"" />
      <LayoutPos TypeId=""5"" Group=""33"" Id=""80"" />
      <LayoutPos TypeId=""5"" Group=""34"" Id=""81"" />
      <LayoutPos TypeId=""5"" Group=""34"" Id=""82"" />
      <LayoutPos TypeId=""5"" Group=""35"" Id=""83"" />
      <LayoutPos TypeId=""5"" Group=""35"" Id=""84"" />
      <LayoutPos TypeId=""5"" Group=""36"" Id=""85"" />
      <LayoutPos TypeId=""5"" Group=""36"" Id=""86"" />
      <LayoutPos TypeId=""5"" Group=""37"" Id=""87"" />
      <LayoutPos TypeId=""5"" Group=""37"" Id=""88"" />
      <LayoutPos TypeId=""5"" Group=""38"" Id=""89"" />
      <LayoutPos TypeId=""5"" Group=""38"" Id=""90"" />
      <LayoutPos TypeId=""5"" Group=""39"" Id=""91"" />
      <LayoutPos TypeId=""5"" Group=""39"" Id=""92"" />
      <LayoutPos TypeId=""5"" Group=""40"" Id=""93"" />
      <LayoutPos TypeId=""5"" Group=""40"" Id=""94"" />
      <LayoutPos TypeId=""5"" Group=""41"" Id=""95"" />
      <LayoutPos TypeId=""5"" Group=""41"" Id=""96"" />
    </LayoutPositions>
  </SingleLayoutLight>
</UserLayout>";
        public string xmlExample_12x8__2_ = @"<?xml version=""1.0"" encoding=""utf-8""?>
<UserLayout>
  <LayoutDimensions>
    <Width>12</Width>
    <Height>8</Height>
  </LayoutDimensions>
  <SampleTypes>
    <SampleType Id=""1"" Name=""Unused"" Colour=""White"" />
    <SampleType Id=""2"" Name=""Standard"" Colour=""Red"" />
    <SampleType Id=""3"" Name=""Blank"" Colour=""Yellow"" />
    <SampleType Id=""5"" Name=""Unknown"" Colour=""Lime"" />
  </SampleTypes>
  <SingleLayoutLight NumPositions=""96"">
    <LayoutPositions>
      <LayoutPos TypeId=""2"" Group=""1"" Id=""1"" />
      <LayoutPos TypeId=""2"" Group=""1"" Id=""2"" />
      <LayoutPos TypeId=""5"" Group=""1"" Id=""3"" />
      <LayoutPos TypeId=""5"" Group=""1"" Id=""4"" />
      <LayoutPos TypeId=""5"" Group=""2"" Id=""5"" />
      <LayoutPos TypeId=""5"" Group=""2"" Id=""6"" />
      <LayoutPos TypeId=""5"" Group=""3"" Id=""7"" />
      <LayoutPos TypeId=""5"" Group=""3"" Id=""8"" />
      <LayoutPos TypeId=""5"" Group=""4"" Id=""9"" />
      <LayoutPos TypeId=""5"" Group=""4"" Id=""10"" />
      <LayoutPos TypeId=""5"" Group=""5"" Id=""11"" />
      <LayoutPos TypeId=""5"" Group=""5"" Id=""12"" />
      <LayoutPos TypeId=""2"" Group=""2"" Id=""13"" />
      <LayoutPos TypeId=""2"" Group=""2"" Id=""14"" />
      <LayoutPos TypeId=""5"" Group=""6"" Id=""15"" />
      <LayoutPos TypeId=""5"" Group=""6"" Id=""16"" />
      <LayoutPos TypeId=""5"" Group=""7"" Id=""17"" />
      <LayoutPos TypeId=""5"" Group=""7"" Id=""18"" />
      <LayoutPos TypeId=""5"" Group=""8"" Id=""19"" />
      <LayoutPos TypeId=""5"" Group=""8"" Id=""20"" />
      <LayoutPos TypeId=""5"" Group=""9"" Id=""21"" />
      <LayoutPos TypeId=""5"" Group=""9"" Id=""22"" />
      <LayoutPos TypeId=""5"" Group=""10"" Id=""23"" />
      <LayoutPos TypeId=""5"" Group=""10"" Id=""24"" />
      <LayoutPos TypeId=""2"" Group=""3"" Id=""25"" />
      <LayoutPos TypeId=""2"" Group=""3"" Id=""26"" />
      <LayoutPos TypeId=""5"" Group=""11"" Id=""27"" />
      <LayoutPos TypeId=""5"" Group=""11"" Id=""28"" />
      <LayoutPos TypeId=""5"" Group=""12"" Id=""29"" />
      <LayoutPos TypeId=""5"" Group=""12"" Id=""30"" />
      <LayoutPos TypeId=""5"" Group=""13"" Id=""31"" />
      <LayoutPos TypeId=""5"" Group=""13"" Id=""32"" />
      <LayoutPos TypeId=""5"" Group=""14"" Id=""33"" />
      <LayoutPos TypeId=""5"" Group=""14"" Id=""34"" />
      <LayoutPos TypeId=""5"" Group=""15"" Id=""35"" />
      <LayoutPos TypeId=""5"" Group=""15"" Id=""36"" />
      <LayoutPos TypeId=""2"" Group=""4"" Id=""37"" />
      <LayoutPos TypeId=""2"" Group=""4"" Id=""38"" />
      <LayoutPos TypeId=""5"" Group=""16"" Id=""39"" />
      <LayoutPos TypeId=""5"" Group=""16"" Id=""40"" />
      <LayoutPos TypeId=""5"" Group=""17"" Id=""41"" />
      <LayoutPos TypeId=""5"" Group=""17"" Id=""42"" />
      <LayoutPos TypeId=""5"" Group=""18"" Id=""43"" />
      <LayoutPos TypeId=""5"" Group=""18"" Id=""44"" />
      <LayoutPos TypeId=""5"" Group=""19"" Id=""45"" />
      <LayoutPos TypeId=""5"" Group=""19"" Id=""46"" />
      <LayoutPos TypeId=""5"" Group=""20"" Id=""47"" />
      <LayoutPos TypeId=""5"" Group=""20"" Id=""48"" />
      <LayoutPos TypeId=""2"" Group=""5"" Id=""49"" />
      <LayoutPos TypeId=""2"" Group=""5"" Id=""50"" />
      <LayoutPos TypeId=""5"" Group=""21"" Id=""51"" />
      <LayoutPos TypeId=""5"" Group=""21"" Id=""52"" />
      <LayoutPos TypeId=""5"" Group=""22"" Id=""53"" />
      <LayoutPos TypeId=""5"" Group=""22"" Id=""54"" />
      <LayoutPos TypeId=""5"" Group=""23"" Id=""55"" />
      <LayoutPos TypeId=""5"" Group=""23"" Id=""56"" />
      <LayoutPos TypeId=""5"" Group=""24"" Id=""57"" />
      <LayoutPos TypeId=""5"" Group=""24"" Id=""58"" />
      <LayoutPos TypeId=""5"" Group=""25"" Id=""59"" />
      <LayoutPos TypeId=""5"" Group=""25"" Id=""60"" />
      <LayoutPos TypeId=""2"" Group=""6"" Id=""61"" />
      <LayoutPos TypeId=""2"" Group=""6"" Id=""62"" />
      <LayoutPos TypeId=""5"" Group=""26"" Id=""63"" />
      <LayoutPos TypeId=""5"" Group=""26"" Id=""64"" />
      <LayoutPos TypeId=""5"" Group=""27"" Id=""65"" />
      <LayoutPos TypeId=""5"" Group=""27"" Id=""66"" />
      <LayoutPos TypeId=""5"" Group=""28"" Id=""67"" />
      <LayoutPos TypeId=""5"" Group=""28"" Id=""68"" />
      <LayoutPos TypeId=""5"" Group=""29"" Id=""69"" />
      <LayoutPos TypeId=""5"" Group=""29"" Id=""70"" />
      <LayoutPos TypeId=""5"" Group=""30"" Id=""71"" />
      <LayoutPos TypeId=""5"" Group=""30"" Id=""72"" />
      <LayoutPos TypeId=""2"" Group=""7"" Id=""73"" />
      <LayoutPos TypeId=""2"" Group=""7"" Id=""74"" />
      <LayoutPos TypeId=""5"" Group=""31"" Id=""75"" />
      <LayoutPos TypeId=""5"" Group=""31"" Id=""76"" />
      <LayoutPos TypeId=""5"" Group=""32"" Id=""77"" />
      <LayoutPos TypeId=""5"" Group=""32"" Id=""78"" />
      <LayoutPos TypeId=""5"" Group=""33"" Id=""79"" />
      <LayoutPos TypeId=""5"" Group=""33"" Id=""80"" />
      <LayoutPos TypeId=""5"" Group=""34"" Id=""81"" />
      <LayoutPos TypeId=""5"" Group=""34"" Id=""82"" />
      <LayoutPos TypeId=""5"" Group=""35"" Id=""83"" />
      <LayoutPos TypeId=""5"" Group=""35"" Id=""84"" />
      <LayoutPos TypeId=""3"" Group=""1"" Id=""85"" />
      <LayoutPos TypeId=""3"" Group=""1"" Id=""86"" />
      <LayoutPos TypeId=""5"" Group=""36"" Id=""87"" />
      <LayoutPos TypeId=""5"" Group=""36"" Id=""88"" />
      <LayoutPos TypeId=""5"" Group=""37"" Id=""89"" />
      <LayoutPos TypeId=""5"" Group=""37"" Id=""90"" />
      <LayoutPos TypeId=""5"" Group=""38"" Id=""91"" />
      <LayoutPos TypeId=""5"" Group=""38"" Id=""92"" />
      <LayoutPos TypeId=""5"" Group=""39"" Id=""93"" />
      <LayoutPos TypeId=""5"" Group=""39"" Id=""94"" />
      <LayoutPos TypeId=""5"" Group=""40"" Id=""95"" />
      <LayoutPos TypeId=""5"" Group=""40"" Id=""96"" />
    </LayoutPositions>
  </SingleLayoutLight>
</UserLayout>";
        public string xmlExample_384 = @"<?xml version=""1.0"" encoding=""utf-8""?>
<UserLayout>
  <LayoutDimensions>
    <Width>24</Width>
    <Height>16</Height>
  </LayoutDimensions>
  <SampleTypes>
    <SampleType Id=""1"" Name=""Unused"" Colour=""White"" />
    <SampleType Id=""2"" Name=""Standard"" Colour=""Red"" />
    <SampleType Id=""3"" Name=""Blank"" Colour=""Yellow"" />
    <SampleType Id=""4"" Name=""Control"" Colour=""Aqua"" />
    <SampleType Id=""5"" Name=""Unknown"" Colour=""Lime"" />
  </SampleTypes>
  <SingleLayoutLight NumPositions=""384"">
    <LayoutPositions>
      <LayoutPos TypeId=""2"" Group=""1"" Id=""1"" />
      <LayoutPos TypeId=""2"" Group=""1"" Id=""2"" />
      <LayoutPos TypeId=""2"" Group=""1"" Id=""3"" />
      <LayoutPos TypeId=""5"" Group=""8"" Id=""4"" />
      <LayoutPos TypeId=""5"" Group=""8"" Id=""5"" />
      <LayoutPos TypeId=""5"" Group=""8"" Id=""6"" />
      <LayoutPos TypeId=""5"" Group=""24"" Id=""7"" />
      <LayoutPos TypeId=""5"" Group=""24"" Id=""8"" />
      <LayoutPos TypeId=""5"" Group=""24"" Id=""9"" />
      <LayoutPos TypeId=""5"" Group=""40"" Id=""10"" />
      <LayoutPos TypeId=""5"" Group=""40"" Id=""11"" />
      <LayoutPos TypeId=""5"" Group=""40"" Id=""12"" />
      <LayoutPos TypeId=""5"" Group=""56"" Id=""13"" />
      <LayoutPos TypeId=""5"" Group=""56"" Id=""14"" />
      <LayoutPos TypeId=""5"" Group=""56"" Id=""15"" />
      <LayoutPos TypeId=""5"" Group=""72"" Id=""16"" />
      <LayoutPos TypeId=""5"" Group=""72"" Id=""17"" />
      <LayoutPos TypeId=""5"" Group=""72"" Id=""18"" />
      <LayoutPos TypeId=""5"" Group=""88"" Id=""19"" />
      <LayoutPos TypeId=""5"" Group=""88"" Id=""20"" />
      <LayoutPos TypeId=""5"" Group=""88"" Id=""21"" />
      <LayoutPos TypeId=""5"" Group=""104"" Id=""22"" />
      <LayoutPos TypeId=""5"" Group=""104"" Id=""23"" />
      <LayoutPos TypeId=""5"" Group=""104"" Id=""24"" />
      <LayoutPos TypeId=""2"" Group=""2"" Id=""25"" />
      <LayoutPos TypeId=""2"" Group=""2"" Id=""26"" />
      <LayoutPos TypeId=""2"" Group=""2"" Id=""27"" />
      <LayoutPos TypeId=""5"" Group=""9"" Id=""28"" />
      <LayoutPos TypeId=""5"" Group=""9"" Id=""29"" />
      <LayoutPos TypeId=""5"" Group=""9"" Id=""30"" />
      <LayoutPos TypeId=""5"" Group=""25"" Id=""31"" />
      <LayoutPos TypeId=""5"" Group=""25"" Id=""32"" />
      <LayoutPos TypeId=""5"" Group=""25"" Id=""33"" />
      <LayoutPos TypeId=""5"" Group=""41"" Id=""34"" />
      <LayoutPos TypeId=""5"" Group=""41"" Id=""35"" />
      <LayoutPos TypeId=""5"" Group=""41"" Id=""36"" />
      <LayoutPos TypeId=""5"" Group=""57"" Id=""37"" />
      <LayoutPos TypeId=""5"" Group=""57"" Id=""38"" />
      <LayoutPos TypeId=""5"" Group=""57"" Id=""39"" />
      <LayoutPos TypeId=""5"" Group=""73"" Id=""40"" />
      <LayoutPos TypeId=""5"" Group=""73"" Id=""41"" />
      <LayoutPos TypeId=""5"" Group=""73"" Id=""42"" />
      <LayoutPos TypeId=""5"" Group=""89"" Id=""43"" />
      <LayoutPos TypeId=""5"" Group=""89"" Id=""44"" />
      <LayoutPos TypeId=""5"" Group=""89"" Id=""45"" />
      <LayoutPos TypeId=""5"" Group=""105"" Id=""46"" />
      <LayoutPos TypeId=""5"" Group=""105"" Id=""47"" />
      <LayoutPos TypeId=""5"" Group=""105"" Id=""48"" />
      <LayoutPos TypeId=""2"" Group=""3"" Id=""49"" />
      <LayoutPos TypeId=""2"" Group=""3"" Id=""50"" />
      <LayoutPos TypeId=""2"" Group=""3"" Id=""51"" />
      <LayoutPos TypeId=""5"" Group=""10"" Id=""52"" />
      <LayoutPos TypeId=""5"" Group=""10"" Id=""53"" />
      <LayoutPos TypeId=""5"" Group=""10"" Id=""54"" />
      <LayoutPos TypeId=""5"" Group=""26"" Id=""55"" />
      <LayoutPos TypeId=""5"" Group=""26"" Id=""56"" />
      <LayoutPos TypeId=""5"" Group=""26"" Id=""57"" />
      <LayoutPos TypeId=""5"" Group=""42"" Id=""58"" />
      <LayoutPos TypeId=""5"" Group=""42"" Id=""59"" />
      <LayoutPos TypeId=""5"" Group=""42"" Id=""60"" />
      <LayoutPos TypeId=""5"" Group=""58"" Id=""61"" />
      <LayoutPos TypeId=""5"" Group=""58"" Id=""62"" />
      <LayoutPos TypeId=""5"" Group=""58"" Id=""63"" />
      <LayoutPos TypeId=""5"" Group=""74"" Id=""64"" />
      <LayoutPos TypeId=""5"" Group=""74"" Id=""65"" />
      <LayoutPos TypeId=""5"" Group=""74"" Id=""66"" />
      <LayoutPos TypeId=""5"" Group=""90"" Id=""67"" />
      <LayoutPos TypeId=""5"" Group=""90"" Id=""68"" />
      <LayoutPos TypeId=""5"" Group=""90"" Id=""69"" />
      <LayoutPos TypeId=""5"" Group=""106"" Id=""70"" />
      <LayoutPos TypeId=""5"" Group=""106"" Id=""71"" />
      <LayoutPos TypeId=""5"" Group=""106"" Id=""72"" />
      <LayoutPos TypeId=""2"" Group=""4"" Id=""73"" />
      <LayoutPos TypeId=""2"" Group=""4"" Id=""74"" />
      <LayoutPos TypeId=""2"" Group=""4"" Id=""75"" />
      <LayoutPos TypeId=""5"" Group=""11"" Id=""76"" />
      <LayoutPos TypeId=""5"" Group=""11"" Id=""77"" />
      <LayoutPos TypeId=""5"" Group=""11"" Id=""78"" />
      <LayoutPos TypeId=""5"" Group=""27"" Id=""79"" />
      <LayoutPos TypeId=""5"" Group=""27"" Id=""80"" />
      <LayoutPos TypeId=""5"" Group=""27"" Id=""81"" />
      <LayoutPos TypeId=""5"" Group=""43"" Id=""82"" />
      <LayoutPos TypeId=""5"" Group=""43"" Id=""83"" />
      <LayoutPos TypeId=""5"" Group=""43"" Id=""84"" />
      <LayoutPos TypeId=""5"" Group=""59"" Id=""85"" />
      <LayoutPos TypeId=""5"" Group=""59"" Id=""86"" />
      <LayoutPos TypeId=""5"" Group=""59"" Id=""87"" />
      <LayoutPos TypeId=""5"" Group=""75"" Id=""88"" />
      <LayoutPos TypeId=""5"" Group=""75"" Id=""89"" />
      <LayoutPos TypeId=""5"" Group=""75"" Id=""90"" />
      <LayoutPos TypeId=""5"" Group=""91"" Id=""91"" />
      <LayoutPos TypeId=""5"" Group=""91"" Id=""92"" />
      <LayoutPos TypeId=""5"" Group=""91"" Id=""93"" />
      <LayoutPos TypeId=""5"" Group=""107"" Id=""94"" />
      <LayoutPos TypeId=""5"" Group=""107"" Id=""95"" />
      <LayoutPos TypeId=""5"" Group=""107"" Id=""96"" />
      <LayoutPos TypeId=""2"" Group=""5"" Id=""97"" />
      <LayoutPos TypeId=""2"" Group=""5"" Id=""98"" />
      <LayoutPos TypeId=""2"" Group=""5"" Id=""99"" />
      <LayoutPos TypeId=""5"" Group=""12"" Id=""100"" />
      <LayoutPos TypeId=""5"" Group=""12"" Id=""101"" />
      <LayoutPos TypeId=""5"" Group=""12"" Id=""102"" />
      <LayoutPos TypeId=""5"" Group=""28"" Id=""103"" />
      <LayoutPos TypeId=""5"" Group=""28"" Id=""104"" />
      <LayoutPos TypeId=""5"" Group=""28"" Id=""105"" />
      <LayoutPos TypeId=""5"" Group=""44"" Id=""106"" />
      <LayoutPos TypeId=""5"" Group=""44"" Id=""107"" />
      <LayoutPos TypeId=""5"" Group=""44"" Id=""108"" />
      <LayoutPos TypeId=""5"" Group=""60"" Id=""109"" />
      <LayoutPos TypeId=""5"" Group=""60"" Id=""110"" />
      <LayoutPos TypeId=""5"" Group=""60"" Id=""111"" />
      <LayoutPos TypeId=""5"" Group=""76"" Id=""112"" />
      <LayoutPos TypeId=""5"" Group=""76"" Id=""113"" />
      <LayoutPos TypeId=""5"" Group=""76"" Id=""114"" />
      <LayoutPos TypeId=""5"" Group=""92"" Id=""115"" />
      <LayoutPos TypeId=""5"" Group=""92"" Id=""116"" />
      <LayoutPos TypeId=""5"" Group=""92"" Id=""117"" />
      <LayoutPos TypeId=""5"" Group=""108"" Id=""118"" />
      <LayoutPos TypeId=""5"" Group=""108"" Id=""119"" />
      <LayoutPos TypeId=""5"" Group=""108"" Id=""120"" />
      <LayoutPos TypeId=""2"" Group=""6"" Id=""121"" />
      <LayoutPos TypeId=""2"" Group=""6"" Id=""122"" />
      <LayoutPos TypeId=""2"" Group=""6"" Id=""123"" />
      <LayoutPos TypeId=""5"" Group=""13"" Id=""124"" />
      <LayoutPos TypeId=""5"" Group=""13"" Id=""125"" />
      <LayoutPos TypeId=""5"" Group=""13"" Id=""126"" />
      <LayoutPos TypeId=""5"" Group=""29"" Id=""127"" />
      <LayoutPos TypeId=""5"" Group=""29"" Id=""128"" />
      <LayoutPos TypeId=""5"" Group=""29"" Id=""129"" />
      <LayoutPos TypeId=""5"" Group=""45"" Id=""130"" />
      <LayoutPos TypeId=""5"" Group=""45"" Id=""131"" />
      <LayoutPos TypeId=""5"" Group=""45"" Id=""132"" />
      <LayoutPos TypeId=""5"" Group=""61"" Id=""133"" />
      <LayoutPos TypeId=""5"" Group=""61"" Id=""134"" />
      <LayoutPos TypeId=""5"" Group=""61"" Id=""135"" />
      <LayoutPos TypeId=""5"" Group=""77"" Id=""136"" />
      <LayoutPos TypeId=""5"" Group=""77"" Id=""137"" />
      <LayoutPos TypeId=""5"" Group=""77"" Id=""138"" />
      <LayoutPos TypeId=""5"" Group=""93"" Id=""139"" />
      <LayoutPos TypeId=""5"" Group=""93"" Id=""140"" />
      <LayoutPos TypeId=""5"" Group=""93"" Id=""141"" />
      <LayoutPos TypeId=""5"" Group=""109"" Id=""142"" />
      <LayoutPos TypeId=""5"" Group=""109"" Id=""143"" />
      <LayoutPos TypeId=""5"" Group=""109"" Id=""144"" />
      <LayoutPos TypeId=""3"" Group=""1"" Id=""145"" />
      <LayoutPos TypeId=""3"" Group=""1"" Id=""146"" />
      <LayoutPos TypeId=""3"" Group=""1"" Id=""147"" />
      <LayoutPos TypeId=""5"" Group=""14"" Id=""148"" />
      <LayoutPos TypeId=""5"" Group=""14"" Id=""149"" />
      <LayoutPos TypeId=""5"" Group=""14"" Id=""150"" />
      <LayoutPos TypeId=""5"" Group=""30"" Id=""151"" />
      <LayoutPos TypeId=""5"" Group=""30"" Id=""152"" />
      <LayoutPos TypeId=""5"" Group=""30"" Id=""153"" />
      <LayoutPos TypeId=""5"" Group=""46"" Id=""154"" />
      <LayoutPos TypeId=""5"" Group=""46"" Id=""155"" />
      <LayoutPos TypeId=""5"" Group=""46"" Id=""156"" />
      <LayoutPos TypeId=""5"" Group=""62"" Id=""157"" />
      <LayoutPos TypeId=""5"" Group=""62"" Id=""158"" />
      <LayoutPos TypeId=""5"" Group=""62"" Id=""159"" />
      <LayoutPos TypeId=""5"" Group=""78"" Id=""160"" />
      <LayoutPos TypeId=""5"" Group=""78"" Id=""161"" />
      <LayoutPos TypeId=""5"" Group=""78"" Id=""162"" />
      <LayoutPos TypeId=""5"" Group=""94"" Id=""163"" />
      <LayoutPos TypeId=""5"" Group=""94"" Id=""164"" />
      <LayoutPos TypeId=""5"" Group=""94"" Id=""165"" />
      <LayoutPos TypeId=""5"" Group=""110"" Id=""166"" />
      <LayoutPos TypeId=""5"" Group=""110"" Id=""167"" />
      <LayoutPos TypeId=""5"" Group=""110"" Id=""168"" />
      <LayoutPos TypeId=""4"" Group=""1"" Id=""169"" />
      <LayoutPos TypeId=""4"" Group=""1"" Id=""170"" />
      <LayoutPos TypeId=""4"" Group=""1"" Id=""171"" />
      <LayoutPos TypeId=""5"" Group=""15"" Id=""172"" />
      <LayoutPos TypeId=""5"" Group=""15"" Id=""173"" />
      <LayoutPos TypeId=""5"" Group=""15"" Id=""174"" />
      <LayoutPos TypeId=""5"" Group=""31"" Id=""175"" />
      <LayoutPos TypeId=""5"" Group=""31"" Id=""176"" />
      <LayoutPos TypeId=""5"" Group=""31"" Id=""177"" />
      <LayoutPos TypeId=""5"" Group=""47"" Id=""178"" />
      <LayoutPos TypeId=""5"" Group=""47"" Id=""179"" />
      <LayoutPos TypeId=""5"" Group=""47"" Id=""180"" />
      <LayoutPos TypeId=""5"" Group=""63"" Id=""181"" />
      <LayoutPos TypeId=""5"" Group=""63"" Id=""182"" />
      <LayoutPos TypeId=""5"" Group=""63"" Id=""183"" />
      <LayoutPos TypeId=""5"" Group=""79"" Id=""184"" />
      <LayoutPos TypeId=""5"" Group=""79"" Id=""185"" />
      <LayoutPos TypeId=""5"" Group=""79"" Id=""186"" />
      <LayoutPos TypeId=""5"" Group=""95"" Id=""187"" />
      <LayoutPos TypeId=""5"" Group=""95"" Id=""188"" />
      <LayoutPos TypeId=""5"" Group=""95"" Id=""189"" />
      <LayoutPos TypeId=""5"" Group=""111"" Id=""190"" />
      <LayoutPos TypeId=""5"" Group=""111"" Id=""191"" />
      <LayoutPos TypeId=""5"" Group=""111"" Id=""192"" />
      <LayoutPos TypeId=""4"" Group=""2"" Id=""193"" />
      <LayoutPos TypeId=""4"" Group=""2"" Id=""194"" />
      <LayoutPos TypeId=""4"" Group=""2"" Id=""195"" />
      <LayoutPos TypeId=""5"" Group=""16"" Id=""196"" />
      <LayoutPos TypeId=""5"" Group=""16"" Id=""197"" />
      <LayoutPos TypeId=""5"" Group=""16"" Id=""198"" />
      <LayoutPos TypeId=""5"" Group=""32"" Id=""199"" />
      <LayoutPos TypeId=""5"" Group=""32"" Id=""200"" />
      <LayoutPos TypeId=""5"" Group=""32"" Id=""201"" />
      <LayoutPos TypeId=""5"" Group=""48"" Id=""202"" />
      <LayoutPos TypeId=""5"" Group=""48"" Id=""203"" />
      <LayoutPos TypeId=""5"" Group=""48"" Id=""204"" />
      <LayoutPos TypeId=""5"" Group=""64"" Id=""205"" />
      <LayoutPos TypeId=""5"" Group=""64"" Id=""206"" />
      <LayoutPos TypeId=""5"" Group=""64"" Id=""207"" />
      <LayoutPos TypeId=""5"" Group=""80"" Id=""208"" />
      <LayoutPos TypeId=""5"" Group=""80"" Id=""209"" />
      <LayoutPos TypeId=""5"" Group=""80"" Id=""210"" />
      <LayoutPos TypeId=""5"" Group=""96"" Id=""211"" />
      <LayoutPos TypeId=""5"" Group=""96"" Id=""212"" />
      <LayoutPos TypeId=""5"" Group=""96"" Id=""213"" />
      <LayoutPos TypeId=""5"" Group=""112"" Id=""214"" />
      <LayoutPos TypeId=""5"" Group=""112"" Id=""215"" />
      <LayoutPos TypeId=""5"" Group=""112"" Id=""216"" />
      <LayoutPos TypeId=""5"" Group=""1"" Id=""217"" />
      <LayoutPos TypeId=""5"" Group=""1"" Id=""218"" />
      <LayoutPos TypeId=""5"" Group=""1"" Id=""219"" />
      <LayoutPos TypeId=""5"" Group=""17"" Id=""220"" />
      <LayoutPos TypeId=""5"" Group=""17"" Id=""221"" />
      <LayoutPos TypeId=""5"" Group=""17"" Id=""222"" />
      <LayoutPos TypeId=""5"" Group=""33"" Id=""223"" />
      <LayoutPos TypeId=""5"" Group=""33"" Id=""224"" />
      <LayoutPos TypeId=""5"" Group=""33"" Id=""225"" />
      <LayoutPos TypeId=""5"" Group=""49"" Id=""226"" />
      <LayoutPos TypeId=""5"" Group=""49"" Id=""227"" />
      <LayoutPos TypeId=""5"" Group=""49"" Id=""228"" />
      <LayoutPos TypeId=""5"" Group=""65"" Id=""229"" />
      <LayoutPos TypeId=""5"" Group=""65"" Id=""230"" />
      <LayoutPos TypeId=""5"" Group=""65"" Id=""231"" />
      <LayoutPos TypeId=""5"" Group=""81"" Id=""232"" />
      <LayoutPos TypeId=""5"" Group=""81"" Id=""233"" />
      <LayoutPos TypeId=""5"" Group=""81"" Id=""234"" />
      <LayoutPos TypeId=""5"" Group=""97"" Id=""235"" />
      <LayoutPos TypeId=""5"" Group=""97"" Id=""236"" />
      <LayoutPos TypeId=""5"" Group=""97"" Id=""237"" />
      <LayoutPos TypeId=""5"" Group=""113"" Id=""238"" />
      <LayoutPos TypeId=""5"" Group=""113"" Id=""239"" />
      <LayoutPos TypeId=""5"" Group=""113"" Id=""240"" />
      <LayoutPos TypeId=""5"" Group=""2"" Id=""241"" />
      <LayoutPos TypeId=""5"" Group=""2"" Id=""242"" />
      <LayoutPos TypeId=""5"" Group=""2"" Id=""243"" />
      <LayoutPos TypeId=""5"" Group=""18"" Id=""244"" />
      <LayoutPos TypeId=""5"" Group=""18"" Id=""245"" />
      <LayoutPos TypeId=""5"" Group=""18"" Id=""246"" />
      <LayoutPos TypeId=""5"" Group=""34"" Id=""247"" />
      <LayoutPos TypeId=""5"" Group=""34"" Id=""248"" />
      <LayoutPos TypeId=""5"" Group=""34"" Id=""249"" />
      <LayoutPos TypeId=""5"" Group=""50"" Id=""250"" />
      <LayoutPos TypeId=""5"" Group=""50"" Id=""251"" />
      <LayoutPos TypeId=""5"" Group=""50"" Id=""252"" />
      <LayoutPos TypeId=""5"" Group=""66"" Id=""253"" />
      <LayoutPos TypeId=""5"" Group=""66"" Id=""254"" />
      <LayoutPos TypeId=""5"" Group=""66"" Id=""255"" />
      <LayoutPos TypeId=""5"" Group=""82"" Id=""256"" />
      <LayoutPos TypeId=""5"" Group=""82"" Id=""257"" />
      <LayoutPos TypeId=""5"" Group=""82"" Id=""258"" />
      <LayoutPos TypeId=""5"" Group=""98"" Id=""259"" />
      <LayoutPos TypeId=""5"" Group=""98"" Id=""260"" />
      <LayoutPos TypeId=""5"" Group=""98"" Id=""261"" />
      <LayoutPos TypeId=""5"" Group=""114"" Id=""262"" />
      <LayoutPos TypeId=""5"" Group=""114"" Id=""263"" />
      <LayoutPos TypeId=""5"" Group=""114"" Id=""264"" />
      <LayoutPos TypeId=""5"" Group=""3"" Id=""265"" />
      <LayoutPos TypeId=""5"" Group=""3"" Id=""266"" />
      <LayoutPos TypeId=""5"" Group=""3"" Id=""267"" />
      <LayoutPos TypeId=""5"" Group=""19"" Id=""268"" />
      <LayoutPos TypeId=""5"" Group=""19"" Id=""269"" />
      <LayoutPos TypeId=""5"" Group=""19"" Id=""270"" />
      <LayoutPos TypeId=""5"" Group=""35"" Id=""271"" />
      <LayoutPos TypeId=""5"" Group=""35"" Id=""272"" />
      <LayoutPos TypeId=""5"" Group=""35"" Id=""273"" />
      <LayoutPos TypeId=""5"" Group=""51"" Id=""274"" />
      <LayoutPos TypeId=""5"" Group=""51"" Id=""275"" />
      <LayoutPos TypeId=""5"" Group=""51"" Id=""276"" />
      <LayoutPos TypeId=""5"" Group=""67"" Id=""277"" />
      <LayoutPos TypeId=""5"" Group=""67"" Id=""278"" />
      <LayoutPos TypeId=""5"" Group=""67"" Id=""279"" />
      <LayoutPos TypeId=""5"" Group=""83"" Id=""280"" />
      <LayoutPos TypeId=""5"" Group=""83"" Id=""281"" />
      <LayoutPos TypeId=""5"" Group=""83"" Id=""282"" />
      <LayoutPos TypeId=""5"" Group=""99"" Id=""283"" />
      <LayoutPos TypeId=""5"" Group=""99"" Id=""284"" />
      <LayoutPos TypeId=""5"" Group=""99"" Id=""285"" />
      <LayoutPos TypeId=""5"" Group=""115"" Id=""286"" />
      <LayoutPos TypeId=""5"" Group=""115"" Id=""287"" />
      <LayoutPos TypeId=""5"" Group=""115"" Id=""288"" />
      <LayoutPos TypeId=""5"" Group=""4"" Id=""289"" />
      <LayoutPos TypeId=""5"" Group=""4"" Id=""290"" />
      <LayoutPos TypeId=""5"" Group=""4"" Id=""291"" />
      <LayoutPos TypeId=""5"" Group=""20"" Id=""292"" />
      <LayoutPos TypeId=""5"" Group=""20"" Id=""293"" />
      <LayoutPos TypeId=""5"" Group=""20"" Id=""294"" />
      <LayoutPos TypeId=""5"" Group=""36"" Id=""295"" />
      <LayoutPos TypeId=""5"" Group=""36"" Id=""296"" />
      <LayoutPos TypeId=""5"" Group=""36"" Id=""297"" />
      <LayoutPos TypeId=""5"" Group=""52"" Id=""298"" />
      <LayoutPos TypeId=""5"" Group=""52"" Id=""299"" />
      <LayoutPos TypeId=""5"" Group=""52"" Id=""300"" />
      <LayoutPos TypeId=""5"" Group=""68"" Id=""301"" />
      <LayoutPos TypeId=""5"" Group=""68"" Id=""302"" />
      <LayoutPos TypeId=""5"" Group=""68"" Id=""303"" />
      <LayoutPos TypeId=""5"" Group=""84"" Id=""304"" />
      <LayoutPos TypeId=""5"" Group=""84"" Id=""305"" />
      <LayoutPos TypeId=""5"" Group=""84"" Id=""306"" />
      <LayoutPos TypeId=""5"" Group=""100"" Id=""307"" />
      <LayoutPos TypeId=""5"" Group=""100"" Id=""308"" />
      <LayoutPos TypeId=""5"" Group=""100"" Id=""309"" />
      <LayoutPos TypeId=""5"" Group=""116"" Id=""310"" />
      <LayoutPos TypeId=""5"" Group=""116"" Id=""311"" />
      <LayoutPos TypeId=""5"" Group=""116"" Id=""312"" />
      <LayoutPos TypeId=""5"" Group=""5"" Id=""313"" />
      <LayoutPos TypeId=""5"" Group=""5"" Id=""314"" />
      <LayoutPos TypeId=""5"" Group=""5"" Id=""315"" />
      <LayoutPos TypeId=""5"" Group=""21"" Id=""316"" />
      <LayoutPos TypeId=""5"" Group=""21"" Id=""317"" />
      <LayoutPos TypeId=""5"" Group=""21"" Id=""318"" />
      <LayoutPos TypeId=""5"" Group=""37"" Id=""319"" />
      <LayoutPos TypeId=""5"" Group=""37"" Id=""320"" />
      <LayoutPos TypeId=""5"" Group=""37"" Id=""321"" />
      <LayoutPos TypeId=""5"" Group=""53"" Id=""322"" />
      <LayoutPos TypeId=""5"" Group=""53"" Id=""323"" />
      <LayoutPos TypeId=""5"" Group=""53"" Id=""324"" />
      <LayoutPos TypeId=""5"" Group=""69"" Id=""325"" />
      <LayoutPos TypeId=""5"" Group=""69"" Id=""326"" />
      <LayoutPos TypeId=""5"" Group=""69"" Id=""327"" />
      <LayoutPos TypeId=""5"" Group=""85"" Id=""328"" />
      <LayoutPos TypeId=""5"" Group=""85"" Id=""329"" />
      <LayoutPos TypeId=""5"" Group=""85"" Id=""330"" />
      <LayoutPos TypeId=""5"" Group=""101"" Id=""331"" />
      <LayoutPos TypeId=""5"" Group=""101"" Id=""332"" />
      <LayoutPos TypeId=""5"" Group=""101"" Id=""333"" />
      <LayoutPos TypeId=""5"" Group=""117"" Id=""334"" />
      <LayoutPos TypeId=""5"" Group=""117"" Id=""335"" />
      <LayoutPos TypeId=""5"" Group=""117"" Id=""336"" />
      <LayoutPos TypeId=""5"" Group=""6"" Id=""337"" />
      <LayoutPos TypeId=""5"" Group=""6"" Id=""338"" />
      <LayoutPos TypeId=""5"" Group=""6"" Id=""339"" />
      <LayoutPos TypeId=""5"" Group=""22"" Id=""340"" />
      <LayoutPos TypeId=""5"" Group=""22"" Id=""341"" />
      <LayoutPos TypeId=""5"" Group=""22"" Id=""342"" />
      <LayoutPos TypeId=""5"" Group=""38"" Id=""343"" />
      <LayoutPos TypeId=""5"" Group=""38"" Id=""344"" />
      <LayoutPos TypeId=""5"" Group=""38"" Id=""345"" />
      <LayoutPos TypeId=""5"" Group=""54"" Id=""346"" />
      <LayoutPos TypeId=""5"" Group=""54"" Id=""347"" />
      <LayoutPos TypeId=""5"" Group=""54"" Id=""348"" />
      <LayoutPos TypeId=""5"" Group=""70"" Id=""349"" />
      <LayoutPos TypeId=""5"" Group=""70"" Id=""350"" />
      <LayoutPos TypeId=""5"" Group=""70"" Id=""351"" />
      <LayoutPos TypeId=""5"" Group=""86"" Id=""352"" />
      <LayoutPos TypeId=""5"" Group=""86"" Id=""353"" />
      <LayoutPos TypeId=""5"" Group=""86"" Id=""354"" />
      <LayoutPos TypeId=""5"" Group=""102"" Id=""355"" />
      <LayoutPos TypeId=""5"" Group=""102"" Id=""356"" />
      <LayoutPos TypeId=""5"" Group=""102"" Id=""357"" />
      <LayoutPos TypeId=""5"" Group=""118"" Id=""358"" />
      <LayoutPos TypeId=""5"" Group=""118"" Id=""359"" />
      <LayoutPos TypeId=""5"" Group=""118"" Id=""360"" />
      <LayoutPos TypeId=""5"" Group=""7"" Id=""361"" />
      <LayoutPos TypeId=""5"" Group=""7"" Id=""362"" />
      <LayoutPos TypeId=""5"" Group=""7"" Id=""363"" />
      <LayoutPos TypeId=""5"" Group=""23"" Id=""364"" />
      <LayoutPos TypeId=""5"" Group=""23"" Id=""365"" />
      <LayoutPos TypeId=""5"" Group=""23"" Id=""366"" />
      <LayoutPos TypeId=""5"" Group=""39"" Id=""367"" />
      <LayoutPos TypeId=""5"" Group=""39"" Id=""368"" />
      <LayoutPos TypeId=""5"" Group=""39"" Id=""369"" />
      <LayoutPos TypeId=""5"" Group=""55"" Id=""370"" />
      <LayoutPos TypeId=""5"" Group=""55"" Id=""371"" />
      <LayoutPos TypeId=""5"" Group=""55"" Id=""372"" />
      <LayoutPos TypeId=""5"" Group=""71"" Id=""373"" />
      <LayoutPos TypeId=""5"" Group=""71"" Id=""374"" />
      <LayoutPos TypeId=""5"" Group=""71"" Id=""375"" />
      <LayoutPos TypeId=""5"" Group=""87"" Id=""376"" />
      <LayoutPos TypeId=""5"" Group=""87"" Id=""377"" />
      <LayoutPos TypeId=""5"" Group=""87"" Id=""378"" />
      <LayoutPos TypeId=""5"" Group=""103"" Id=""379"" />
      <LayoutPos TypeId=""5"" Group=""103"" Id=""380"" />
      <LayoutPos TypeId=""5"" Group=""103"" Id=""381"" />
      <LayoutPos TypeId=""5"" Group=""119"" Id=""382"" />
      <LayoutPos TypeId=""5"" Group=""119"" Id=""383"" />
      <LayoutPos TypeId=""5"" Group=""119"" Id=""384"" />
    </LayoutPositions>
  </SingleLayoutLight>
</UserLayout>";
        public string xmlExample_3x2 = @"<?xml version=""1.0"" encoding=""utf-8""?>
<UserLayout>
  <LayoutDimensions>
    <Width>3</Width>
    <Height>2</Height>
  </LayoutDimensions>
  <SampleTypes>
    <SampleType Id=""1"" Name=""Unused"" Colour=""White"" />
    <SampleType Id=""4"" Name=""Control"" Colour=""Aqua"" />
    <SampleType Id=""5"" Name=""Unknown"" Colour=""Lime"" />
  </SampleTypes>
  <SingleLayoutLight NumPositions=""6"">
    <LayoutPositions>
      <LayoutPos TypeId=""4"" Group=""1"" Id=""1"" />
      <LayoutPos TypeId=""5"" Group=""1"" Id=""2"" />
      <LayoutPos TypeId=""5"" Group=""2"" Id=""3"" />
      <LayoutPos TypeId=""5"" Group=""3"" Id=""4"" />
      <LayoutPos TypeId=""5"" Group=""4"" Id=""5"" />
      <LayoutPos TypeId=""5"" Group=""5"" Id=""6"" />
    </LayoutPositions>
  </SingleLayoutLight>
</UserLayout>";
        public string xmlExample_3x2_InconsistentReps = @"<?xml version=""1.0"" encoding=""utf-8""?>
<UserLayout>
  <LayoutDimensions>
    <Width>3</Width>
    <Height>2</Height>
  </LayoutDimensions>
  <SampleTypes>
    <SampleType Id=""1"" Name=""Unused"" Colour=""White"" />
    <SampleType Id=""4"" Name=""Control"" Colour=""Aqua"" />
    <SampleType Id=""5"" Name=""Unknown"" Colour=""Lime"" />
  </SampleTypes>
  <SingleLayoutLight NumPositions=""6"">
    <LayoutPositions>
      <LayoutPos TypeId=""5"" Group=""1"" Id=""1"" />
      <LayoutPos TypeId=""5"" Group=""1"" Id=""2"" />
      <LayoutPos TypeId=""5"" Group=""2"" Id=""3"" />
      <LayoutPos TypeId=""5"" Group=""2"" Id=""4"" />
      <LayoutPos TypeId=""5"" Group=""3"" Id=""5"" />
      <LayoutPos TypeId=""5"" Group=""1"" Id=""6"" />
    </LayoutPositions>
  </SingleLayoutLight>
</UserLayout>";

        public string xmlExample_4x3 = @"<?xml version=""1.0"" encoding=""utf-8""?>
<UserLayout>
  <LayoutDimensions>
    <Width>4</Width>
    <Height>3</Height>
  </LayoutDimensions>
  <SampleTypes>
    <SampleType Id=""1"" Name=""Unused"" Colour=""White"" />
    <SampleType Id=""3"" Name=""Blank"" Colour=""Yellow"" />
    <SampleType Id=""5"" Name=""Unknown"" Colour=""Lime"" />
  </SampleTypes>
  <SingleLayoutLight NumPositions=""12"">
    <LayoutPositions>
      <LayoutPos TypeId=""5"" Group=""1"" Id=""1"" />
      <LayoutPos TypeId=""5"" Group=""4"" Id=""2"" />
      <LayoutPos TypeId=""5"" Group=""7"" Id=""3"" />
      <LayoutPos TypeId=""5"" Group=""10"" Id=""4"" />
      <LayoutPos TypeId=""5"" Group=""2"" Id=""5"" />
      <LayoutPos TypeId=""5"" Group=""5"" Id=""6"" />
      <LayoutPos TypeId=""5"" Group=""8"" Id=""7"" />
      <LayoutPos TypeId=""5"" Group=""11"" Id=""8"" />
      <LayoutPos TypeId=""5"" Group=""3"" Id=""9"" />
      <LayoutPos TypeId=""5"" Group=""6"" Id=""10"" />
      <LayoutPos TypeId=""5"" Group=""9"" Id=""11"" />
      <LayoutPos TypeId=""3"" Group=""1"" Id=""12"" />
    </LayoutPositions>
  </SingleLayoutLight>
</UserLayout>";
        public string xmlExample_Competitive__1_ = @"<?xml version=""1.0"" encoding=""utf-8""?>
<UserLayout>
  <LayoutDimensions>
    <Width>12</Width>
    <Height>8</Height>
  </LayoutDimensions>
  <SampleTypes>
    <SampleType Id=""1"" Name=""Unused"" Colour=""White"" />
    <SampleType Id=""5"" Name=""Unknown"" Colour=""Lime"" />
  </SampleTypes>
  <SingleLayoutLight NumPositions=""96"">
    <LayoutPositions>
      <LayoutPos TypeId=""5"" Group=""1"" Id=""1"" />
      <LayoutPos TypeId=""5"" Group=""1"" Id=""2"" />
      <LayoutPos TypeId=""5"" Group=""1"" Id=""3"" />
      <LayoutPos TypeId=""5"" Group=""1"" Id=""4"" />
      <LayoutPos TypeId=""5"" Group=""1"" Id=""5"" />
      <LayoutPos TypeId=""5"" Group=""1"" Id=""6"" />
      <LayoutPos TypeId=""5"" Group=""2"" Id=""7"" />
      <LayoutPos TypeId=""5"" Group=""2"" Id=""8"" />
      <LayoutPos TypeId=""5"" Group=""2"" Id=""9"" />
      <LayoutPos TypeId=""5"" Group=""2"" Id=""10"" />
      <LayoutPos TypeId=""5"" Group=""2"" Id=""11"" />
      <LayoutPos TypeId=""5"" Group=""2"" Id=""12"" />
      <LayoutPos TypeId=""5"" Group=""3"" Id=""13"" />
      <LayoutPos TypeId=""5"" Group=""3"" Id=""14"" />
      <LayoutPos TypeId=""5"" Group=""3"" Id=""15"" />
      <LayoutPos TypeId=""5"" Group=""3"" Id=""16"" />
      <LayoutPos TypeId=""5"" Group=""3"" Id=""17"" />
      <LayoutPos TypeId=""5"" Group=""3"" Id=""18"" />
      <LayoutPos TypeId=""5"" Group=""4"" Id=""19"" />
      <LayoutPos TypeId=""5"" Group=""4"" Id=""20"" />
      <LayoutPos TypeId=""5"" Group=""4"" Id=""21"" />
      <LayoutPos TypeId=""5"" Group=""4"" Id=""22"" />
      <LayoutPos TypeId=""5"" Group=""4"" Id=""23"" />
      <LayoutPos TypeId=""5"" Group=""4"" Id=""24"" />
      <LayoutPos TypeId=""5"" Group=""5"" Id=""25"" />
      <LayoutPos TypeId=""5"" Group=""5"" Id=""26"" />
      <LayoutPos TypeId=""5"" Group=""5"" Id=""27"" />
      <LayoutPos TypeId=""5"" Group=""5"" Id=""28"" />
      <LayoutPos TypeId=""5"" Group=""5"" Id=""29"" />
      <LayoutPos TypeId=""5"" Group=""5"" Id=""30"" />
      <LayoutPos TypeId=""5"" Group=""6"" Id=""31"" />
      <LayoutPos TypeId=""5"" Group=""6"" Id=""32"" />
      <LayoutPos TypeId=""5"" Group=""6"" Id=""33"" />
      <LayoutPos TypeId=""5"" Group=""6"" Id=""34"" />
      <LayoutPos TypeId=""5"" Group=""6"" Id=""35"" />
      <LayoutPos TypeId=""5"" Group=""6"" Id=""36"" />
      <LayoutPos TypeId=""5"" Group=""7"" Id=""37"" />
      <LayoutPos TypeId=""5"" Group=""7"" Id=""38"" />
      <LayoutPos TypeId=""5"" Group=""7"" Id=""39"" />
      <LayoutPos TypeId=""5"" Group=""7"" Id=""40"" />
      <LayoutPos TypeId=""5"" Group=""7"" Id=""41"" />
      <LayoutPos TypeId=""5"" Group=""7"" Id=""42"" />
      <LayoutPos TypeId=""5"" Group=""8"" Id=""43"" />
      <LayoutPos TypeId=""5"" Group=""8"" Id=""44"" />
      <LayoutPos TypeId=""5"" Group=""8"" Id=""45"" />
      <LayoutPos TypeId=""5"" Group=""8"" Id=""46"" />
      <LayoutPos TypeId=""5"" Group=""8"" Id=""47"" />
      <LayoutPos TypeId=""5"" Group=""8"" Id=""48"" />
      <LayoutPos TypeId=""5"" Group=""9"" Id=""49"" />
      <LayoutPos TypeId=""5"" Group=""9"" Id=""50"" />
      <LayoutPos TypeId=""5"" Group=""9"" Id=""51"" />
      <LayoutPos TypeId=""5"" Group=""9"" Id=""52"" />
      <LayoutPos TypeId=""5"" Group=""9"" Id=""53"" />
      <LayoutPos TypeId=""5"" Group=""9"" Id=""54"" />
      <LayoutPos TypeId=""5"" Group=""10"" Id=""55"" />
      <LayoutPos TypeId=""5"" Group=""10"" Id=""56"" />
      <LayoutPos TypeId=""5"" Group=""10"" Id=""57"" />
      <LayoutPos TypeId=""5"" Group=""10"" Id=""58"" />
      <LayoutPos TypeId=""5"" Group=""10"" Id=""59"" />
      <LayoutPos TypeId=""5"" Group=""10"" Id=""60"" />
      <LayoutPos TypeId=""5"" Group=""11"" Id=""61"" />
      <LayoutPos TypeId=""5"" Group=""11"" Id=""62"" />
      <LayoutPos TypeId=""5"" Group=""11"" Id=""63"" />
      <LayoutPos TypeId=""5"" Group=""11"" Id=""64"" />
      <LayoutPos TypeId=""5"" Group=""11"" Id=""65"" />
      <LayoutPos TypeId=""5"" Group=""11"" Id=""66"" />
      <LayoutPos TypeId=""5"" Group=""12"" Id=""67"" />
      <LayoutPos TypeId=""5"" Group=""12"" Id=""68"" />
      <LayoutPos TypeId=""5"" Group=""12"" Id=""69"" />
      <LayoutPos TypeId=""5"" Group=""12"" Id=""70"" />
      <LayoutPos TypeId=""5"" Group=""12"" Id=""71"" />
      <LayoutPos TypeId=""5"" Group=""12"" Id=""72"" />
      <LayoutPos TypeId=""5"" Group=""13"" Id=""73"" />
      <LayoutPos TypeId=""5"" Group=""13"" Id=""74"" />
      <LayoutPos TypeId=""5"" Group=""13"" Id=""75"" />
      <LayoutPos TypeId=""5"" Group=""13"" Id=""76"" />
      <LayoutPos TypeId=""5"" Group=""13"" Id=""77"" />
      <LayoutPos TypeId=""5"" Group=""13"" Id=""78"" />
      <LayoutPos TypeId=""5"" Group=""14"" Id=""79"" />
      <LayoutPos TypeId=""5"" Group=""14"" Id=""80"" />
      <LayoutPos TypeId=""5"" Group=""14"" Id=""81"" />
      <LayoutPos TypeId=""5"" Group=""14"" Id=""82"" />
      <LayoutPos TypeId=""5"" Group=""14"" Id=""83"" />
      <LayoutPos TypeId=""5"" Group=""14"" Id=""84"" />
      <LayoutPos TypeId=""5"" Group=""15"" Id=""85"" />
      <LayoutPos TypeId=""5"" Group=""15"" Id=""86"" />
      <LayoutPos TypeId=""5"" Group=""15"" Id=""87"" />
      <LayoutPos TypeId=""5"" Group=""15"" Id=""88"" />
      <LayoutPos TypeId=""5"" Group=""15"" Id=""89"" />
      <LayoutPos TypeId=""5"" Group=""15"" Id=""90"" />
      <LayoutPos TypeId=""5"" Group=""16"" Id=""91"" />
      <LayoutPos TypeId=""5"" Group=""16"" Id=""92"" />
      <LayoutPos TypeId=""5"" Group=""16"" Id=""93"" />
      <LayoutPos TypeId=""5"" Group=""16"" Id=""94"" />
      <LayoutPos TypeId=""5"" Group=""16"" Id=""95"" />
      <LayoutPos TypeId=""5"" Group=""16"" Id=""96"" />
    </LayoutPositions>
  </SingleLayoutLight>
</UserLayout>";
        public string xmlExample_Competitive__2_ = @"<?xml version=""1.0"" encoding=""utf-8""?>
<UserLayout>
  <LayoutDimensions>
    <Width>12</Width>
    <Height>8</Height>
  </LayoutDimensions>
  <SampleTypes>
    <SampleType Id=""1"" Name=""Unused"" Colour=""White"" />
    <SampleType Id=""5"" Name=""Unknown"" Colour=""Lime"" />
    <SampleType Id=""3"" Name=""Blank"" Colour=""Yellow"" />
  </SampleTypes>
  <SingleLayoutLight NumPositions=""96"">
    <LayoutPositions>
      <LayoutPos TypeId=""3"" Group=""1"" Id=""1"" />
      <LayoutPos TypeId=""5"" Group=""1"" Id=""4"" />
      <LayoutPos TypeId=""5"" Group=""2"" Id=""5"" />
      <LayoutPos TypeId=""5"" Group=""3"" Id=""6"" />
      <LayoutPos TypeId=""5"" Group=""4"" Id=""7"" />
      <LayoutPos TypeId=""5"" Group=""5"" Id=""8"" />
      <LayoutPos TypeId=""5"" Group=""6"" Id=""9"" />
      <LayoutPos TypeId=""5"" Group=""7"" Id=""10"" />
      <LayoutPos TypeId=""5"" Group=""8"" Id=""11"" />
      <LayoutPos TypeId=""5"" Group=""9"" Id=""12"" />
      <LayoutPos TypeId=""3"" Group=""1"" Id=""13"" />
      <LayoutPos TypeId=""5"" Group=""1"" Id=""16"" />
      <LayoutPos TypeId=""5"" Group=""2"" Id=""17"" />
      <LayoutPos TypeId=""5"" Group=""3"" Id=""18"" />
      <LayoutPos TypeId=""5"" Group=""4"" Id=""19"" />
      <LayoutPos TypeId=""5"" Group=""5"" Id=""20"" />
      <LayoutPos TypeId=""5"" Group=""6"" Id=""21"" />
      <LayoutPos TypeId=""5"" Group=""7"" Id=""22"" />
      <LayoutPos TypeId=""5"" Group=""8"" Id=""23"" />
      <LayoutPos TypeId=""5"" Group=""9"" Id=""24"" />
      <LayoutPos TypeId=""3"" Group=""1"" Id=""25"" />
      <LayoutPos TypeId=""5"" Group=""1"" Id=""28"" />
      <LayoutPos TypeId=""5"" Group=""2"" Id=""29"" />
      <LayoutPos TypeId=""5"" Group=""3"" Id=""30"" />
      <LayoutPos TypeId=""5"" Group=""4"" Id=""31"" />
      <LayoutPos TypeId=""5"" Group=""5"" Id=""32"" />
      <LayoutPos TypeId=""5"" Group=""6"" Id=""33"" />
      <LayoutPos TypeId=""5"" Group=""7"" Id=""34"" />
      <LayoutPos TypeId=""5"" Group=""8"" Id=""35"" />
      <LayoutPos TypeId=""5"" Group=""9"" Id=""36"" />
      <LayoutPos TypeId=""5"" Group=""1"" Id=""40"" />
      <LayoutPos TypeId=""5"" Group=""2"" Id=""41"" />
      <LayoutPos TypeId=""5"" Group=""3"" Id=""42"" />
      <LayoutPos TypeId=""5"" Group=""4"" Id=""43"" />
      <LayoutPos TypeId=""5"" Group=""5"" Id=""44"" />
      <LayoutPos TypeId=""5"" Group=""6"" Id=""45"" />
      <LayoutPos TypeId=""5"" Group=""7"" Id=""46"" />
      <LayoutPos TypeId=""5"" Group=""8"" Id=""47"" />
      <LayoutPos TypeId=""5"" Group=""9"" Id=""48"" />
      <LayoutPos TypeId=""5"" Group=""1"" Id=""52"" />
      <LayoutPos TypeId=""5"" Group=""2"" Id=""53"" />
      <LayoutPos TypeId=""5"" Group=""3"" Id=""54"" />
      <LayoutPos TypeId=""5"" Group=""4"" Id=""55"" />
      <LayoutPos TypeId=""5"" Group=""5"" Id=""56"" />
      <LayoutPos TypeId=""5"" Group=""6"" Id=""57"" />
      <LayoutPos TypeId=""5"" Group=""7"" Id=""58"" />
      <LayoutPos TypeId=""5"" Group=""8"" Id=""59"" />
      <LayoutPos TypeId=""5"" Group=""9"" Id=""60"" />
      <LayoutPos TypeId=""5"" Group=""1"" Id=""64"" />
      <LayoutPos TypeId=""5"" Group=""2"" Id=""65"" />
      <LayoutPos TypeId=""5"" Group=""3"" Id=""66"" />
      <LayoutPos TypeId=""5"" Group=""4"" Id=""67"" />
      <LayoutPos TypeId=""5"" Group=""5"" Id=""68"" />
      <LayoutPos TypeId=""5"" Group=""6"" Id=""69"" />
      <LayoutPos TypeId=""5"" Group=""7"" Id=""70"" />
      <LayoutPos TypeId=""5"" Group=""8"" Id=""71"" />
      <LayoutPos TypeId=""5"" Group=""9"" Id=""72"" />
      <LayoutPos TypeId=""5"" Group=""1"" Id=""76"" />
      <LayoutPos TypeId=""5"" Group=""2"" Id=""77"" />
      <LayoutPos TypeId=""5"" Group=""3"" Id=""78"" />
      <LayoutPos TypeId=""5"" Group=""4"" Id=""79"" />
      <LayoutPos TypeId=""5"" Group=""5"" Id=""80"" />
      <LayoutPos TypeId=""5"" Group=""6"" Id=""81"" />
      <LayoutPos TypeId=""5"" Group=""7"" Id=""82"" />
      <LayoutPos TypeId=""5"" Group=""8"" Id=""83"" />
      <LayoutPos TypeId=""5"" Group=""9"" Id=""84"" />
      <LayoutPos TypeId=""5"" Group=""1"" Id=""88"" />
      <LayoutPos TypeId=""5"" Group=""2"" Id=""89"" />
      <LayoutPos TypeId=""5"" Group=""3"" Id=""90"" />
      <LayoutPos TypeId=""5"" Group=""4"" Id=""91"" />
      <LayoutPos TypeId=""5"" Group=""5"" Id=""92"" />
      <LayoutPos TypeId=""5"" Group=""6"" Id=""93"" />
      <LayoutPos TypeId=""5"" Group=""7"" Id=""94"" />
      <LayoutPos TypeId=""5"" Group=""8"" Id=""95"" />
      <LayoutPos TypeId=""5"" Group=""9"" Id=""96"" />
    </LayoutPositions>
  </SingleLayoutLight>
</UserLayout>";
        public string xmlExample_Corner_Blanks = @"<?xml version=""1.0"" encoding=""utf-8""?>
<UserLayout>
  <LayoutDimensions>
    <Width>12</Width>
    <Height>8</Height>
  </LayoutDimensions>
  <SampleTypes>
    <SampleType Id=""1"" Name=""Unused"" Colour=""White"" />
    <SampleType Id=""3"" Name=""Blank"" Colour=""Yellow"" />
    <SampleType Id=""5"" Name=""Unknown"" Colour=""Lime"" />
  </SampleTypes>
  <SingleLayoutLight NumPositions=""96"">
    <LayoutPositions>
      <LayoutPos TypeId=""3"" Group=""1"" Id=""1"" />
      <LayoutPos TypeId=""3"" Group=""4"" Id=""12"" />
      <LayoutPos TypeId=""5"" Group=""1"" Id=""14"" />
      <LayoutPos TypeId=""5"" Group=""7"" Id=""15"" />
      <LayoutPos TypeId=""5"" Group=""13"" Id=""16"" />
      <LayoutPos TypeId=""5"" Group=""19"" Id=""17"" />
      <LayoutPos TypeId=""5"" Group=""25"" Id=""18"" />
      <LayoutPos TypeId=""5"" Group=""31"" Id=""19"" />
      <LayoutPos TypeId=""5"" Group=""37"" Id=""20"" />
      <LayoutPos TypeId=""5"" Group=""43"" Id=""21"" />
      <LayoutPos TypeId=""5"" Group=""49"" Id=""22"" />
      <LayoutPos TypeId=""5"" Group=""55"" Id=""23"" />
      <LayoutPos TypeId=""5"" Group=""2"" Id=""26"" />
      <LayoutPos TypeId=""5"" Group=""8"" Id=""27"" />
      <LayoutPos TypeId=""5"" Group=""14"" Id=""28"" />
      <LayoutPos TypeId=""5"" Group=""20"" Id=""29"" />
      <LayoutPos TypeId=""5"" Group=""26"" Id=""30"" />
      <LayoutPos TypeId=""5"" Group=""32"" Id=""31"" />
      <LayoutPos TypeId=""5"" Group=""38"" Id=""32"" />
      <LayoutPos TypeId=""5"" Group=""44"" Id=""33"" />
      <LayoutPos TypeId=""5"" Group=""50"" Id=""34"" />
      <LayoutPos TypeId=""5"" Group=""56"" Id=""35"" />
      <LayoutPos TypeId=""5"" Group=""3"" Id=""38"" />
      <LayoutPos TypeId=""5"" Group=""9"" Id=""39"" />
      <LayoutPos TypeId=""5"" Group=""15"" Id=""40"" />
      <LayoutPos TypeId=""5"" Group=""21"" Id=""41"" />
      <LayoutPos TypeId=""5"" Group=""27"" Id=""42"" />
      <LayoutPos TypeId=""5"" Group=""33"" Id=""43"" />
      <LayoutPos TypeId=""5"" Group=""39"" Id=""44"" />
      <LayoutPos TypeId=""5"" Group=""45"" Id=""45"" />
      <LayoutPos TypeId=""5"" Group=""51"" Id=""46"" />
      <LayoutPos TypeId=""5"" Group=""57"" Id=""47"" />
      <LayoutPos TypeId=""5"" Group=""4"" Id=""50"" />
      <LayoutPos TypeId=""5"" Group=""10"" Id=""51"" />
      <LayoutPos TypeId=""5"" Group=""16"" Id=""52"" />
      <LayoutPos TypeId=""5"" Group=""22"" Id=""53"" />
      <LayoutPos TypeId=""5"" Group=""28"" Id=""54"" />
      <LayoutPos TypeId=""5"" Group=""34"" Id=""55"" />
      <LayoutPos TypeId=""5"" Group=""40"" Id=""56"" />
      <LayoutPos TypeId=""5"" Group=""46"" Id=""57"" />
      <LayoutPos TypeId=""5"" Group=""52"" Id=""58"" />
      <LayoutPos TypeId=""5"" Group=""58"" Id=""59"" />
      <LayoutPos TypeId=""5"" Group=""5"" Id=""62"" />
      <LayoutPos TypeId=""5"" Group=""11"" Id=""63"" />
      <LayoutPos TypeId=""5"" Group=""17"" Id=""64"" />
      <LayoutPos TypeId=""5"" Group=""23"" Id=""65"" />
      <LayoutPos TypeId=""5"" Group=""29"" Id=""66"" />
      <LayoutPos TypeId=""5"" Group=""35"" Id=""67"" />
      <LayoutPos TypeId=""5"" Group=""41"" Id=""68"" />
      <LayoutPos TypeId=""5"" Group=""47"" Id=""69"" />
      <LayoutPos TypeId=""5"" Group=""53"" Id=""70"" />
      <LayoutPos TypeId=""5"" Group=""59"" Id=""71"" />
      <LayoutPos TypeId=""5"" Group=""6"" Id=""74"" />
      <LayoutPos TypeId=""5"" Group=""12"" Id=""75"" />
      <LayoutPos TypeId=""5"" Group=""18"" Id=""76"" />
      <LayoutPos TypeId=""5"" Group=""24"" Id=""77"" />
      <LayoutPos TypeId=""5"" Group=""30"" Id=""78"" />
      <LayoutPos TypeId=""5"" Group=""36"" Id=""79"" />
      <LayoutPos TypeId=""5"" Group=""42"" Id=""80"" />
      <LayoutPos TypeId=""5"" Group=""48"" Id=""81"" />
      <LayoutPos TypeId=""5"" Group=""54"" Id=""82"" />
      <LayoutPos TypeId=""5"" Group=""60"" Id=""83"" />
      <LayoutPos TypeId=""3"" Group=""2"" Id=""85"" />
      <LayoutPos TypeId=""3"" Group=""3"" Id=""96"" />
    </LayoutPositions>
  </SingleLayoutLight>
</UserLayout>";
        public string xmlExample_Multi_Plate = @"<?xml version=""1.0"" encoding=""utf-8""?>
<UserLayout>
  <LayoutDimensions>
    <Width>12</Width>
    <Height>8</Height>
  </LayoutDimensions>
  <SampleTypes>
    <SampleType Id=""1"" Name=""Unused"" Colour=""White"" />
    <SampleType Id=""2"" Name=""Standard"" Colour=""Red"" />
    <SampleType Id=""3"" Name=""Blank"" Colour=""Yellow"" />
    <SampleType Id=""5"" Name=""Unknown"" Colour=""Lime"" />
  </SampleTypes>
  <SingleLayoutLight NumPositions=""96"">
    <LayoutPositions>
      <LayoutPos TypeId=""2"" Group=""1"" Id=""1"" />
      <LayoutPos TypeId=""2"" Group=""1"" Id=""2"" />
      <LayoutPos TypeId=""5"" Group=""1"" Id=""3"" />
      <LayoutPos TypeId=""5"" Group=""1"" Id=""4"" />
      <LayoutPos TypeId=""5"" Group=""9"" Id=""5"" />
      <LayoutPos TypeId=""5"" Group=""9"" Id=""6"" />
      <LayoutPos TypeId=""5"" Group=""17"" Id=""7"" />
      <LayoutPos TypeId=""5"" Group=""17"" Id=""8"" />
      <LayoutPos TypeId=""5"" Group=""25"" Id=""9"" />
      <LayoutPos TypeId=""5"" Group=""25"" Id=""10"" />
      <LayoutPos TypeId=""5"" Group=""33"" Id=""11"" />
      <LayoutPos TypeId=""5"" Group=""33"" Id=""12"" />
      <LayoutPos TypeId=""2"" Group=""2"" Id=""13"" />
      <LayoutPos TypeId=""2"" Group=""2"" Id=""14"" />
      <LayoutPos TypeId=""5"" Group=""2"" Id=""15"" />
      <LayoutPos TypeId=""5"" Group=""2"" Id=""16"" />
      <LayoutPos TypeId=""5"" Group=""10"" Id=""17"" />
      <LayoutPos TypeId=""5"" Group=""10"" Id=""18"" />
      <LayoutPos TypeId=""5"" Group=""18"" Id=""19"" />
      <LayoutPos TypeId=""5"" Group=""18"" Id=""20"" />
      <LayoutPos TypeId=""5"" Group=""26"" Id=""21"" />
      <LayoutPos TypeId=""5"" Group=""26"" Id=""22"" />
      <LayoutPos TypeId=""5"" Group=""34"" Id=""23"" />
      <LayoutPos TypeId=""5"" Group=""34"" Id=""24"" />
      <LayoutPos TypeId=""2"" Group=""3"" Id=""25"" />
      <LayoutPos TypeId=""2"" Group=""3"" Id=""26"" />
      <LayoutPos TypeId=""5"" Group=""3"" Id=""27"" />
      <LayoutPos TypeId=""5"" Group=""3"" Id=""28"" />
      <LayoutPos TypeId=""5"" Group=""11"" Id=""29"" />
      <LayoutPos TypeId=""5"" Group=""11"" Id=""30"" />
      <LayoutPos TypeId=""5"" Group=""19"" Id=""31"" />
      <LayoutPos TypeId=""5"" Group=""19"" Id=""32"" />
      <LayoutPos TypeId=""5"" Group=""27"" Id=""33"" />
      <LayoutPos TypeId=""5"" Group=""27"" Id=""34"" />
      <LayoutPos TypeId=""5"" Group=""35"" Id=""35"" />
      <LayoutPos TypeId=""5"" Group=""35"" Id=""36"" />
      <LayoutPos TypeId=""2"" Group=""4"" Id=""37"" />
      <LayoutPos TypeId=""2"" Group=""4"" Id=""38"" />
      <LayoutPos TypeId=""5"" Group=""4"" Id=""39"" />
      <LayoutPos TypeId=""5"" Group=""4"" Id=""40"" />
      <LayoutPos TypeId=""5"" Group=""12"" Id=""41"" />
      <LayoutPos TypeId=""5"" Group=""12"" Id=""42"" />
      <LayoutPos TypeId=""5"" Group=""20"" Id=""43"" />
      <LayoutPos TypeId=""5"" Group=""20"" Id=""44"" />
      <LayoutPos TypeId=""5"" Group=""28"" Id=""45"" />
      <LayoutPos TypeId=""5"" Group=""28"" Id=""46"" />
      <LayoutPos TypeId=""5"" Group=""36"" Id=""47"" />
      <LayoutPos TypeId=""5"" Group=""36"" Id=""48"" />
      <LayoutPos TypeId=""2"" Group=""5"" Id=""49"" />
      <LayoutPos TypeId=""2"" Group=""5"" Id=""50"" />
      <LayoutPos TypeId=""5"" Group=""5"" Id=""51"" />
      <LayoutPos TypeId=""5"" Group=""5"" Id=""52"" />
      <LayoutPos TypeId=""5"" Group=""13"" Id=""53"" />
      <LayoutPos TypeId=""5"" Group=""13"" Id=""54"" />
      <LayoutPos TypeId=""5"" Group=""21"" Id=""55"" />
      <LayoutPos TypeId=""5"" Group=""21"" Id=""56"" />
      <LayoutPos TypeId=""5"" Group=""29"" Id=""57"" />
      <LayoutPos TypeId=""5"" Group=""29"" Id=""58"" />
      <LayoutPos TypeId=""5"" Group=""37"" Id=""59"" />
      <LayoutPos TypeId=""5"" Group=""37"" Id=""60"" />
      <LayoutPos TypeId=""2"" Group=""6"" Id=""61"" />
      <LayoutPos TypeId=""2"" Group=""6"" Id=""62"" />
      <LayoutPos TypeId=""5"" Group=""6"" Id=""63"" />
      <LayoutPos TypeId=""5"" Group=""6"" Id=""64"" />
      <LayoutPos TypeId=""5"" Group=""14"" Id=""65"" />
      <LayoutPos TypeId=""5"" Group=""14"" Id=""66"" />
      <LayoutPos TypeId=""5"" Group=""22"" Id=""67"" />
      <LayoutPos TypeId=""5"" Group=""22"" Id=""68"" />
      <LayoutPos TypeId=""5"" Group=""30"" Id=""69"" />
      <LayoutPos TypeId=""5"" Group=""30"" Id=""70"" />
      <LayoutPos TypeId=""5"" Group=""38"" Id=""71"" />
      <LayoutPos TypeId=""5"" Group=""38"" Id=""72"" />
      <LayoutPos TypeId=""2"" Group=""7"" Id=""73"" />
      <LayoutPos TypeId=""2"" Group=""7"" Id=""74"" />
      <LayoutPos TypeId=""5"" Group=""7"" Id=""75"" />
      <LayoutPos TypeId=""5"" Group=""7"" Id=""76"" />
      <LayoutPos TypeId=""5"" Group=""15"" Id=""77"" />
      <LayoutPos TypeId=""5"" Group=""15"" Id=""78"" />
      <LayoutPos TypeId=""5"" Group=""23"" Id=""79"" />
      <LayoutPos TypeId=""5"" Group=""23"" Id=""80"" />
      <LayoutPos TypeId=""5"" Group=""31"" Id=""81"" />
      <LayoutPos TypeId=""5"" Group=""31"" Id=""82"" />
      <LayoutPos TypeId=""5"" Group=""39"" Id=""83"" />
      <LayoutPos TypeId=""5"" Group=""39"" Id=""84"" />
      <LayoutPos TypeId=""3"" Group=""1"" Id=""85"" />
      <LayoutPos TypeId=""3"" Group=""1"" Id=""86"" />
      <LayoutPos TypeId=""5"" Group=""8"" Id=""87"" />
      <LayoutPos TypeId=""5"" Group=""8"" Id=""88"" />
      <LayoutPos TypeId=""5"" Group=""16"" Id=""89"" />
      <LayoutPos TypeId=""5"" Group=""16"" Id=""90"" />
      <LayoutPos TypeId=""5"" Group=""24"" Id=""91"" />
      <LayoutPos TypeId=""5"" Group=""24"" Id=""92"" />
      <LayoutPos TypeId=""5"" Group=""32"" Id=""93"" />
      <LayoutPos TypeId=""5"" Group=""32"" Id=""94"" />
      <LayoutPos TypeId=""5"" Group=""40"" Id=""95"" />
      <LayoutPos TypeId=""5"" Group=""40"" Id=""96"" />
    </LayoutPositions>
  </SingleLayoutLight>
</UserLayout>";
        public string xmlExample_Multi_Standards = @"<?xml version=""1.0"" encoding=""utf-8""?>
<UserLayout>
  <LayoutDimensions>
    <Width>12</Width>
    <Height>8</Height>
  </LayoutDimensions>
  <SampleTypes>
    <SampleType Id=""1"" Name=""Unused"" Colour=""White"" />
    <SampleType Id=""3"" Name=""Blank"" Colour=""Yellow"" />
    <SampleType Id=""4"" Name=""Control"" Colour=""Aqua"" />
    <SampleType Id=""12"" Name=""StandardX"" Colour=""Red"" />
    <SampleType Id=""13"" Name=""StandardY"" Colour=""ffc04080"" />
  </SampleTypes>
  <SingleLayoutLight NumPositions=""96"">
    <LayoutPositions>
      <LayoutPos TypeId=""12"" Group=""1"" Id=""1"" />
      <LayoutPos TypeId=""12"" Group=""1"" Id=""2"" />
      <LayoutPos TypeId=""4"" Group=""1"" Id=""3"" />
      <LayoutPos TypeId=""4"" Group=""1"" Id=""4"" />
      <LayoutPos TypeId=""13"" Group=""1"" Id=""5"" />
      <LayoutPos TypeId=""13"" Group=""1"" Id=""6"" />
      <LayoutPos TypeId=""12"" Group=""2"" Id=""13"" />
      <LayoutPos TypeId=""12"" Group=""2"" Id=""14"" />
      <LayoutPos TypeId=""3"" Group=""1"" Id=""15"" />
      <LayoutPos TypeId=""3"" Group=""1"" Id=""16"" />
      <LayoutPos TypeId=""13"" Group=""2"" Id=""17"" />
      <LayoutPos TypeId=""13"" Group=""2"" Id=""18"" />
      <LayoutPos TypeId=""12"" Group=""3"" Id=""25"" />
      <LayoutPos TypeId=""12"" Group=""3"" Id=""26"" />
      <LayoutPos TypeId=""4"" Group=""2"" Id=""27"" />
      <LayoutPos TypeId=""4"" Group=""2"" Id=""28"" />
      <LayoutPos TypeId=""13"" Group=""3"" Id=""29"" />
      <LayoutPos TypeId=""13"" Group=""3"" Id=""30"" />
      <LayoutPos TypeId=""12"" Group=""4"" Id=""37"" />
      <LayoutPos TypeId=""12"" Group=""4"" Id=""38"" />
      <LayoutPos TypeId=""13"" Group=""4"" Id=""41"" />
      <LayoutPos TypeId=""13"" Group=""4"" Id=""42"" />
      <LayoutPos TypeId=""12"" Group=""5"" Id=""49"" />
      <LayoutPos TypeId=""12"" Group=""5"" Id=""50"" />
      <LayoutPos TypeId=""4"" Group=""3"" Id=""51"" />
      <LayoutPos TypeId=""4"" Group=""3"" Id=""52"" />
      <LayoutPos TypeId=""13"" Group=""5"" Id=""53"" />
      <LayoutPos TypeId=""13"" Group=""5"" Id=""54"" />
      <LayoutPos TypeId=""12"" Group=""6"" Id=""61"" />
      <LayoutPos TypeId=""12"" Group=""6"" Id=""62"" />
      <LayoutPos TypeId=""3"" Group=""2"" Id=""63"" />
      <LayoutPos TypeId=""3"" Group=""2"" Id=""64"" />
      <LayoutPos TypeId=""13"" Group=""6"" Id=""65"" />
      <LayoutPos TypeId=""13"" Group=""6"" Id=""66"" />
      <LayoutPos TypeId=""12"" Group=""7"" Id=""73"" />
      <LayoutPos TypeId=""12"" Group=""7"" Id=""74"" />
      <LayoutPos TypeId=""4"" Group=""4"" Id=""75"" />
      <LayoutPos TypeId=""4"" Group=""4"" Id=""76"" />
      <LayoutPos TypeId=""13"" Group=""7"" Id=""77"" />
      <LayoutPos TypeId=""13"" Group=""7"" Id=""78"" />
      <LayoutPos TypeId=""4"" Group=""5"" Id=""85"" />
      <LayoutPos TypeId=""4"" Group=""5"" Id=""86"" />
      <LayoutPos TypeId=""4"" Group=""6"" Id=""89"" />
      <LayoutPos TypeId=""4"" Group=""6"" Id=""90"" />
    </LayoutPositions>
  </SingleLayoutLight>
</UserLayout>";
        public string xmlExample_Qualitative__1_ = @"<?xml version=""1.0"" encoding=""utf-8""?>
<UserLayout>
  <LayoutDimensions>
    <Width>12</Width>
    <Height>8</Height>
  </LayoutDimensions>
  <SampleTypes>
    <SampleType Id=""1"" Name=""Unused"" Colour=""White"" />
    <SampleType Id=""3"" Name=""Blank"" Colour=""Yellow"" />
    <SampleType Id=""4"" Name=""Control"" Colour=""Aqua"" />
    <SampleType Id=""5"" Name=""Unknown"" Colour=""Lime"" />
  </SampleTypes>
  <SingleLayoutLight NumPositions=""96"">
    <LayoutPositions>
      <LayoutPos TypeId=""5"" Group=""1"" Id=""15"" />
      <LayoutPos TypeId=""5"" Group=""1"" Id=""16"" />
      <LayoutPos TypeId=""5"" Group=""7"" Id=""17"" />
      <LayoutPos TypeId=""5"" Group=""7"" Id=""18"" />
      <LayoutPos TypeId=""5"" Group=""13"" Id=""19"" />
      <LayoutPos TypeId=""5"" Group=""13"" Id=""20"" />
      <LayoutPos TypeId=""5"" Group=""19"" Id=""21"" />
      <LayoutPos TypeId=""5"" Group=""19"" Id=""22"" />
      <LayoutPos TypeId=""5"" Group=""2"" Id=""27"" />
      <LayoutPos TypeId=""5"" Group=""2"" Id=""28"" />
      <LayoutPos TypeId=""5"" Group=""8"" Id=""29"" />
      <LayoutPos TypeId=""5"" Group=""8"" Id=""30"" />
      <LayoutPos TypeId=""5"" Group=""14"" Id=""31"" />
      <LayoutPos TypeId=""5"" Group=""14"" Id=""32"" />
      <LayoutPos TypeId=""5"" Group=""20"" Id=""33"" />
      <LayoutPos TypeId=""5"" Group=""20"" Id=""34"" />
      <LayoutPos TypeId=""3"" Group=""1"" Id=""38"" />
      <LayoutPos TypeId=""5"" Group=""3"" Id=""39"" />
      <LayoutPos TypeId=""5"" Group=""3"" Id=""40"" />
      <LayoutPos TypeId=""5"" Group=""9"" Id=""41"" />
      <LayoutPos TypeId=""5"" Group=""9"" Id=""42"" />
      <LayoutPos TypeId=""5"" Group=""15"" Id=""43"" />
      <LayoutPos TypeId=""5"" Group=""15"" Id=""44"" />
      <LayoutPos TypeId=""5"" Group=""21"" Id=""45"" />
      <LayoutPos TypeId=""5"" Group=""21"" Id=""46"" />
      <LayoutPos TypeId=""3"" Group=""1"" Id=""47"" />
      <LayoutPos TypeId=""4"" Group=""1"" Id=""50"" />
      <LayoutPos TypeId=""5"" Group=""4"" Id=""51"" />
      <LayoutPos TypeId=""5"" Group=""4"" Id=""52"" />
      <LayoutPos TypeId=""5"" Group=""10"" Id=""53"" />
      <LayoutPos TypeId=""5"" Group=""10"" Id=""54"" />
      <LayoutPos TypeId=""5"" Group=""16"" Id=""55"" />
      <LayoutPos TypeId=""5"" Group=""16"" Id=""56"" />
      <LayoutPos TypeId=""5"" Group=""22"" Id=""57"" />
      <LayoutPos TypeId=""5"" Group=""22"" Id=""58"" />
      <LayoutPos TypeId=""4"" Group=""1"" Id=""59"" />
      <LayoutPos TypeId=""5"" Group=""5"" Id=""63"" />
      <LayoutPos TypeId=""5"" Group=""5"" Id=""64"" />
      <LayoutPos TypeId=""5"" Group=""11"" Id=""65"" />
      <LayoutPos TypeId=""5"" Group=""11"" Id=""66"" />
      <LayoutPos TypeId=""5"" Group=""17"" Id=""67"" />
      <LayoutPos TypeId=""5"" Group=""17"" Id=""68"" />
      <LayoutPos TypeId=""5"" Group=""23"" Id=""69"" />
      <LayoutPos TypeId=""5"" Group=""23"" Id=""70"" />
      <LayoutPos TypeId=""5"" Group=""6"" Id=""75"" />
      <LayoutPos TypeId=""5"" Group=""6"" Id=""76"" />
      <LayoutPos TypeId=""5"" Group=""12"" Id=""77"" />
      <LayoutPos TypeId=""5"" Group=""12"" Id=""78"" />
      <LayoutPos TypeId=""5"" Group=""18"" Id=""79"" />
      <LayoutPos TypeId=""5"" Group=""18"" Id=""80"" />
      <LayoutPos TypeId=""5"" Group=""24"" Id=""81"" />
      <LayoutPos TypeId=""5"" Group=""24"" Id=""82"" />
    </LayoutPositions>
  </SingleLayoutLight>
</UserLayout>";
        public string xmlExample_Quantitative__1_ = @"<?xml version=""1.0"" encoding=""utf-8""?>
<UserLayout>
  <LayoutDimensions>
    <Width>12</Width>
    <Height>8</Height>
  </LayoutDimensions>
  <SampleTypes>
    <SampleType Id=""1"" Name=""Unused"" Colour=""White"" />
    <SampleType Id=""2"" Name=""Standard"" Colour=""Red"" />
    <SampleType Id=""3"" Name=""Blank"" Colour=""Yellow"" />
    <SampleType Id=""4"" Name=""Control"" Colour=""Aqua"" />
    <SampleType Id=""5"" Name=""Unknown"" Colour=""Lime"" />
  </SampleTypes>
  <SingleLayoutLight NumPositions=""96"">
    <LayoutPositions>
      <LayoutPos TypeId=""2"" Group=""1"" Id=""1"" />
      <LayoutPos TypeId=""2"" Group=""1"" Id=""2"" />
      <LayoutPos TypeId=""5"" Group=""1"" Id=""3"" />
      <LayoutPos TypeId=""5"" Group=""1"" Id=""4"" />
      <LayoutPos TypeId=""5"" Group=""9"" Id=""5"" />
      <LayoutPos TypeId=""5"" Group=""9"" Id=""6"" />
      <LayoutPos TypeId=""5"" Group=""17"" Id=""7"" />
      <LayoutPos TypeId=""5"" Group=""17"" Id=""8"" />
      <LayoutPos TypeId=""5"" Group=""25"" Id=""9"" />
      <LayoutPos TypeId=""5"" Group=""25"" Id=""10"" />
      <LayoutPos TypeId=""4"" Group=""1"" Id=""11"" />
      <LayoutPos TypeId=""4"" Group=""1"" Id=""12"" />
      <LayoutPos TypeId=""2"" Group=""2"" Id=""13"" />
      <LayoutPos TypeId=""2"" Group=""2"" Id=""14"" />
      <LayoutPos TypeId=""5"" Group=""2"" Id=""15"" />
      <LayoutPos TypeId=""5"" Group=""2"" Id=""16"" />
      <LayoutPos TypeId=""5"" Group=""10"" Id=""17"" />
      <LayoutPos TypeId=""5"" Group=""10"" Id=""18"" />
      <LayoutPos TypeId=""5"" Group=""18"" Id=""19"" />
      <LayoutPos TypeId=""5"" Group=""18"" Id=""20"" />
      <LayoutPos TypeId=""5"" Group=""26"" Id=""21"" />
      <LayoutPos TypeId=""5"" Group=""26"" Id=""22"" />
      <LayoutPos TypeId=""4"" Group=""2"" Id=""23"" />
      <LayoutPos TypeId=""4"" Group=""2"" Id=""24"" />
      <LayoutPos TypeId=""2"" Group=""3"" Id=""25"" />
      <LayoutPos TypeId=""2"" Group=""3"" Id=""26"" />
      <LayoutPos TypeId=""5"" Group=""3"" Id=""27"" />
      <LayoutPos TypeId=""5"" Group=""3"" Id=""28"" />
      <LayoutPos TypeId=""5"" Group=""11"" Id=""29"" />
      <LayoutPos TypeId=""5"" Group=""11"" Id=""30"" />
      <LayoutPos TypeId=""5"" Group=""19"" Id=""31"" />
      <LayoutPos TypeId=""5"" Group=""19"" Id=""32"" />
      <LayoutPos TypeId=""5"" Group=""27"" Id=""33"" />
      <LayoutPos TypeId=""5"" Group=""27"" Id=""34"" />
      <LayoutPos TypeId=""4"" Group=""3"" Id=""35"" />
      <LayoutPos TypeId=""4"" Group=""3"" Id=""36"" />
      <LayoutPos TypeId=""2"" Group=""4"" Id=""37"" />
      <LayoutPos TypeId=""2"" Group=""4"" Id=""38"" />
      <LayoutPos TypeId=""5"" Group=""4"" Id=""39"" />
      <LayoutPos TypeId=""5"" Group=""4"" Id=""40"" />
      <LayoutPos TypeId=""5"" Group=""12"" Id=""41"" />
      <LayoutPos TypeId=""5"" Group=""12"" Id=""42"" />
      <LayoutPos TypeId=""5"" Group=""20"" Id=""43"" />
      <LayoutPos TypeId=""5"" Group=""20"" Id=""44"" />
      <LayoutPos TypeId=""5"" Group=""28"" Id=""45"" />
      <LayoutPos TypeId=""5"" Group=""28"" Id=""46"" />
      <LayoutPos TypeId=""4"" Group=""4"" Id=""47"" />
      <LayoutPos TypeId=""4"" Group=""4"" Id=""48"" />
      <LayoutPos TypeId=""2"" Group=""5"" Id=""49"" />
      <LayoutPos TypeId=""2"" Group=""5"" Id=""50"" />
      <LayoutPos TypeId=""5"" Group=""5"" Id=""51"" />
      <LayoutPos TypeId=""5"" Group=""5"" Id=""52"" />
      <LayoutPos TypeId=""5"" Group=""13"" Id=""53"" />
      <LayoutPos TypeId=""5"" Group=""13"" Id=""54"" />
      <LayoutPos TypeId=""5"" Group=""21"" Id=""55"" />
      <LayoutPos TypeId=""5"" Group=""21"" Id=""56"" />
      <LayoutPos TypeId=""5"" Group=""29"" Id=""57"" />
      <LayoutPos TypeId=""5"" Group=""29"" Id=""58"" />
      <LayoutPos TypeId=""4"" Group=""5"" Id=""59"" />
      <LayoutPos TypeId=""4"" Group=""5"" Id=""60"" />
      <LayoutPos TypeId=""2"" Group=""6"" Id=""61"" />
      <LayoutPos TypeId=""2"" Group=""6"" Id=""62"" />
      <LayoutPos TypeId=""5"" Group=""6"" Id=""63"" />
      <LayoutPos TypeId=""5"" Group=""6"" Id=""64"" />
      <LayoutPos TypeId=""5"" Group=""14"" Id=""65"" />
      <LayoutPos TypeId=""5"" Group=""14"" Id=""66"" />
      <LayoutPos TypeId=""5"" Group=""22"" Id=""67"" />
      <LayoutPos TypeId=""5"" Group=""22"" Id=""68"" />
      <LayoutPos TypeId=""5"" Group=""30"" Id=""69"" />
      <LayoutPos TypeId=""5"" Group=""30"" Id=""70"" />
      <LayoutPos TypeId=""4"" Group=""6"" Id=""71"" />
      <LayoutPos TypeId=""4"" Group=""6"" Id=""72"" />
      <LayoutPos TypeId=""2"" Group=""7"" Id=""73"" />
      <LayoutPos TypeId=""2"" Group=""7"" Id=""74"" />
      <LayoutPos TypeId=""5"" Group=""7"" Id=""75"" />
      <LayoutPos TypeId=""5"" Group=""7"" Id=""76"" />
      <LayoutPos TypeId=""5"" Group=""15"" Id=""77"" />
      <LayoutPos TypeId=""5"" Group=""15"" Id=""78"" />
      <LayoutPos TypeId=""5"" Group=""23"" Id=""79"" />
      <LayoutPos TypeId=""5"" Group=""23"" Id=""80"" />
      <LayoutPos TypeId=""5"" Group=""31"" Id=""81"" />
      <LayoutPos TypeId=""5"" Group=""31"" Id=""82"" />
      <LayoutPos TypeId=""4"" Group=""7"" Id=""83"" />
      <LayoutPos TypeId=""4"" Group=""7"" Id=""84"" />
      <LayoutPos TypeId=""3"" Group=""1"" Id=""85"" />
      <LayoutPos TypeId=""3"" Group=""1"" Id=""86"" />
      <LayoutPos TypeId=""5"" Group=""8"" Id=""87"" />
      <LayoutPos TypeId=""5"" Group=""8"" Id=""88"" />
      <LayoutPos TypeId=""5"" Group=""16"" Id=""89"" />
      <LayoutPos TypeId=""5"" Group=""16"" Id=""90"" />
      <LayoutPos TypeId=""5"" Group=""24"" Id=""91"" />
      <LayoutPos TypeId=""5"" Group=""24"" Id=""92"" />
      <LayoutPos TypeId=""5"" Group=""32"" Id=""93"" />
      <LayoutPos TypeId=""5"" Group=""32"" Id=""94"" />
      <LayoutPos TypeId=""4"" Group=""8"" Id=""95"" />
      <LayoutPos TypeId=""4"" Group=""8"" Id=""96"" />
    </LayoutPositions>
  </SingleLayoutLight>
</UserLayout>";
        public string xmlMultiplate_with_advanced_sequence = @"<?xml version=""1.0"" encoding=""utf-8""?>
<UserLayout>
  <LayoutDimensions>
    <Width>12</Width>
    <Height>8</Height>
  </LayoutDimensions>
  <SampleTypes>
    <SampleType Id=""1"" Name=""Unused"" Colour=""White"" />
    <SampleType Id=""2"" Name=""Standard"" Colour=""Red"" />
    <SampleType Id=""3"" Name=""Blank"" Colour=""Yellow"" />
    <SampleType Id=""5"" Name=""Unknown"" Colour=""Lime"" />
  </SampleTypes>
  <SingleLayoutLight NumPositions=""96"">
    <LayoutPositions>
      <LayoutPos TypeId=""2"" Group=""1"" Id=""1"" />
      <LayoutPos TypeId=""2"" Group=""1"" Id=""2"" />
      <LayoutPos TypeId=""2"" Group=""2"" Id=""3"" />
      <LayoutPos TypeId=""2"" Group=""2"" Id=""4"" />
      <LayoutPos TypeId=""2"" Group=""3"" Id=""5"" />
      <LayoutPos TypeId=""2"" Group=""3"" Id=""6"" />
      <LayoutPos TypeId=""2"" Group=""4"" Id=""7"" />
      <LayoutPos TypeId=""2"" Group=""4"" Id=""8"" />
      <LayoutPos TypeId=""2"" Group=""5"" Id=""9"" />
      <LayoutPos TypeId=""2"" Group=""5"" Id=""10"" />
      <LayoutPos TypeId=""2"" Group=""6"" Id=""11"" />
      <LayoutPos TypeId=""2"" Group=""6"" Id=""12"" />
      <LayoutPos TypeId=""5"" Group=""1"" Id=""13"" />
      <LayoutPos TypeId=""5"" Group=""1"" Id=""14"" />
      <LayoutPos TypeId=""5"" Group=""2"" Id=""15"" />
      <LayoutPos TypeId=""5"" Group=""2"" Id=""16"" />
      <LayoutPos TypeId=""5"" Group=""3"" Id=""17"" />
      <LayoutPos TypeId=""5"" Group=""3"" Id=""18"" />
      <LayoutPos TypeId=""5"" Group=""4"" Id=""19"" />
      <LayoutPos TypeId=""5"" Group=""4"" Id=""20"" />
      <LayoutPos TypeId=""5"" Group=""5"" Id=""21"" />
      <LayoutPos TypeId=""5"" Group=""5"" Id=""22"" />
      <LayoutPos TypeId=""5"" Group=""6"" Id=""23"" />
      <LayoutPos TypeId=""5"" Group=""6"" Id=""24"" />
      <LayoutPos TypeId=""5"" Group=""7"" Id=""25"" />
      <LayoutPos TypeId=""5"" Group=""7"" Id=""26"" />
      <LayoutPos TypeId=""5"" Group=""8"" Id=""27"" />
      <LayoutPos TypeId=""5"" Group=""8"" Id=""28"" />
      <LayoutPos TypeId=""5"" Group=""9"" Id=""29"" />
      <LayoutPos TypeId=""5"" Group=""9"" Id=""30"" />
      <LayoutPos TypeId=""5"" Group=""10"" Id=""31"" />
      <LayoutPos TypeId=""5"" Group=""10"" Id=""32"" />
      <LayoutPos TypeId=""5"" Group=""11"" Id=""33"" />
      <LayoutPos TypeId=""5"" Group=""11"" Id=""34"" />
      <LayoutPos TypeId=""5"" Group=""12"" Id=""35"" />
      <LayoutPos TypeId=""5"" Group=""12"" Id=""36"" />
      <LayoutPos TypeId=""5"" Group=""13"" Id=""37"" />
      <LayoutPos TypeId=""5"" Group=""13"" Id=""38"" />
      <LayoutPos TypeId=""5"" Group=""14"" Id=""39"" />
      <LayoutPos TypeId=""5"" Group=""14"" Id=""40"" />
      <LayoutPos TypeId=""5"" Group=""15"" Id=""41"" />
      <LayoutPos TypeId=""5"" Group=""15"" Id=""42"" />
      <LayoutPos TypeId=""5"" Group=""16"" Id=""43"" />
      <LayoutPos TypeId=""5"" Group=""16"" Id=""44"" />
      <LayoutPos TypeId=""5"" Group=""17"" Id=""45"" />
      <LayoutPos TypeId=""5"" Group=""17"" Id=""46"" />
      <LayoutPos TypeId=""5"" Group=""18"" Id=""47"" />
      <LayoutPos TypeId=""5"" Group=""18"" Id=""48"" />
      <LayoutPos TypeId=""5"" Group=""19"" Id=""49"" />
      <LayoutPos TypeId=""5"" Group=""19"" Id=""50"" />
      <LayoutPos TypeId=""5"" Group=""20"" Id=""51"" />
      <LayoutPos TypeId=""5"" Group=""20"" Id=""52"" />
      <LayoutPos TypeId=""5"" Group=""21"" Id=""53"" />
      <LayoutPos TypeId=""5"" Group=""21"" Id=""54"" />
      <LayoutPos TypeId=""5"" Group=""22"" Id=""55"" />
      <LayoutPos TypeId=""5"" Group=""22"" Id=""56"" />
      <LayoutPos TypeId=""5"" Group=""23"" Id=""57"" />
      <LayoutPos TypeId=""5"" Group=""23"" Id=""58"" />
      <LayoutPos TypeId=""5"" Group=""24"" Id=""59"" />
      <LayoutPos TypeId=""5"" Group=""24"" Id=""60"" />
      <LayoutPos TypeId=""5"" Group=""25"" Id=""61"" />
      <LayoutPos TypeId=""5"" Group=""25"" Id=""62"" />
      <LayoutPos TypeId=""5"" Group=""26"" Id=""63"" />
      <LayoutPos TypeId=""5"" Group=""26"" Id=""64"" />
      <LayoutPos TypeId=""5"" Group=""27"" Id=""65"" />
      <LayoutPos TypeId=""5"" Group=""27"" Id=""66"" />
      <LayoutPos TypeId=""5"" Group=""28"" Id=""67"" />
      <LayoutPos TypeId=""5"" Group=""28"" Id=""68"" />
      <LayoutPos TypeId=""5"" Group=""29"" Id=""69"" />
      <LayoutPos TypeId=""5"" Group=""29"" Id=""70"" />
      <LayoutPos TypeId=""5"" Group=""30"" Id=""71"" />
      <LayoutPos TypeId=""5"" Group=""30"" Id=""72"" />
      <LayoutPos TypeId=""5"" Group=""31"" Id=""73"" />
      <LayoutPos TypeId=""5"" Group=""31"" Id=""74"" />
      <LayoutPos TypeId=""5"" Group=""32"" Id=""75"" />
      <LayoutPos TypeId=""5"" Group=""32"" Id=""76"" />
      <LayoutPos TypeId=""5"" Group=""33"" Id=""77"" />
      <LayoutPos TypeId=""5"" Group=""33"" Id=""78"" />
      <LayoutPos TypeId=""5"" Group=""34"" Id=""79"" />
      <LayoutPos TypeId=""5"" Group=""34"" Id=""80"" />
      <LayoutPos TypeId=""5"" Group=""35"" Id=""81"" />
      <LayoutPos TypeId=""5"" Group=""35"" Id=""82"" />
      <LayoutPos TypeId=""5"" Group=""36"" Id=""83"" />
      <LayoutPos TypeId=""5"" Group=""36"" Id=""84"" />
      <LayoutPos TypeId=""5"" Group=""37"" Id=""85"" />
      <LayoutPos TypeId=""5"" Group=""37"" Id=""86"" />
      <LayoutPos TypeId=""5"" Group=""38"" Id=""87"" />
      <LayoutPos TypeId=""5"" Group=""38"" Id=""88"" />
      <LayoutPos TypeId=""5"" Group=""39"" Id=""89"" />
      <LayoutPos TypeId=""5"" Group=""39"" Id=""90"" />
      <LayoutPos TypeId=""5"" Group=""40"" Id=""91"" />
      <LayoutPos TypeId=""5"" Group=""40"" Id=""92"" />
      <LayoutPos TypeId=""5"" Group=""41"" Id=""93"" />
      <LayoutPos TypeId=""5"" Group=""41"" Id=""94"" />
      <LayoutPos TypeId=""3"" Group=""1"" Id=""95"" />
      <LayoutPos TypeId=""3"" Group=""1"" Id=""96"" />
    </LayoutPositions>
  </SingleLayoutLight>
</UserLayout>";
        public string xmlUnknowns__Duplicates_Across_ = @"<?xml version=""1.0"" encoding=""utf-8""?>
<UserLayout>
  <LayoutDimensions>
    <Width>12</Width>
    <Height>8</Height>
  </LayoutDimensions>
  <SampleTypes>
    <SampleType Id=""1"" Name=""Unused"" Colour=""White"" />
    <SampleType Id=""5"" Name=""Unknown"" Colour=""Lime"" />
  </SampleTypes>
  <SingleLayoutLight NumPositions=""96"">
    <LayoutPositions>
      <LayoutPos TypeId=""5"" Group=""1"" Id=""1"" />
      <LayoutPos TypeId=""5"" Group=""1"" Id=""2"" />
      <LayoutPos TypeId=""5"" Group=""2"" Id=""3"" />
      <LayoutPos TypeId=""5"" Group=""2"" Id=""4"" />
      <LayoutPos TypeId=""5"" Group=""3"" Id=""5"" />
      <LayoutPos TypeId=""5"" Group=""3"" Id=""6"" />
      <LayoutPos TypeId=""5"" Group=""4"" Id=""7"" />
      <LayoutPos TypeId=""5"" Group=""4"" Id=""8"" />
      <LayoutPos TypeId=""5"" Group=""5"" Id=""9"" />
      <LayoutPos TypeId=""5"" Group=""5"" Id=""10"" />
      <LayoutPos TypeId=""5"" Group=""6"" Id=""11"" />
      <LayoutPos TypeId=""5"" Group=""6"" Id=""12"" />
      <LayoutPos TypeId=""5"" Group=""7"" Id=""13"" />
      <LayoutPos TypeId=""5"" Group=""7"" Id=""14"" />
      <LayoutPos TypeId=""5"" Group=""8"" Id=""15"" />
      <LayoutPos TypeId=""5"" Group=""8"" Id=""16"" />
      <LayoutPos TypeId=""5"" Group=""9"" Id=""17"" />
      <LayoutPos TypeId=""5"" Group=""9"" Id=""18"" />
      <LayoutPos TypeId=""5"" Group=""10"" Id=""19"" />
      <LayoutPos TypeId=""5"" Group=""10"" Id=""20"" />
      <LayoutPos TypeId=""5"" Group=""11"" Id=""21"" />
      <LayoutPos TypeId=""5"" Group=""11"" Id=""22"" />
      <LayoutPos TypeId=""5"" Group=""12"" Id=""23"" />
      <LayoutPos TypeId=""5"" Group=""12"" Id=""24"" />
      <LayoutPos TypeId=""5"" Group=""13"" Id=""25"" />
      <LayoutPos TypeId=""5"" Group=""13"" Id=""26"" />
      <LayoutPos TypeId=""5"" Group=""14"" Id=""27"" />
      <LayoutPos TypeId=""5"" Group=""14"" Id=""28"" />
      <LayoutPos TypeId=""5"" Group=""15"" Id=""29"" />
      <LayoutPos TypeId=""5"" Group=""15"" Id=""30"" />
      <LayoutPos TypeId=""5"" Group=""16"" Id=""31"" />
      <LayoutPos TypeId=""5"" Group=""16"" Id=""32"" />
      <LayoutPos TypeId=""5"" Group=""17"" Id=""33"" />
      <LayoutPos TypeId=""5"" Group=""17"" Id=""34"" />
      <LayoutPos TypeId=""5"" Group=""18"" Id=""35"" />
      <LayoutPos TypeId=""5"" Group=""18"" Id=""36"" />
      <LayoutPos TypeId=""5"" Group=""19"" Id=""37"" />
      <LayoutPos TypeId=""5"" Group=""19"" Id=""38"" />
      <LayoutPos TypeId=""5"" Group=""20"" Id=""39"" />
      <LayoutPos TypeId=""5"" Group=""20"" Id=""40"" />
      <LayoutPos TypeId=""5"" Group=""21"" Id=""41"" />
      <LayoutPos TypeId=""5"" Group=""21"" Id=""42"" />
      <LayoutPos TypeId=""5"" Group=""22"" Id=""43"" />
      <LayoutPos TypeId=""5"" Group=""22"" Id=""44"" />
      <LayoutPos TypeId=""5"" Group=""23"" Id=""45"" />
      <LayoutPos TypeId=""5"" Group=""23"" Id=""46"" />
      <LayoutPos TypeId=""5"" Group=""24"" Id=""47"" />
      <LayoutPos TypeId=""5"" Group=""24"" Id=""48"" />
      <LayoutPos TypeId=""5"" Group=""25"" Id=""49"" />
      <LayoutPos TypeId=""5"" Group=""25"" Id=""50"" />
      <LayoutPos TypeId=""5"" Group=""26"" Id=""51"" />
      <LayoutPos TypeId=""5"" Group=""26"" Id=""52"" />
      <LayoutPos TypeId=""5"" Group=""27"" Id=""53"" />
      <LayoutPos TypeId=""5"" Group=""27"" Id=""54"" />
      <LayoutPos TypeId=""5"" Group=""28"" Id=""55"" />
      <LayoutPos TypeId=""5"" Group=""28"" Id=""56"" />
      <LayoutPos TypeId=""5"" Group=""29"" Id=""57"" />
      <LayoutPos TypeId=""5"" Group=""29"" Id=""58"" />
      <LayoutPos TypeId=""5"" Group=""30"" Id=""59"" />
      <LayoutPos TypeId=""5"" Group=""30"" Id=""60"" />
      <LayoutPos TypeId=""5"" Group=""31"" Id=""61"" />
      <LayoutPos TypeId=""5"" Group=""31"" Id=""62"" />
      <LayoutPos TypeId=""5"" Group=""32"" Id=""63"" />
      <LayoutPos TypeId=""5"" Group=""32"" Id=""64"" />
      <LayoutPos TypeId=""5"" Group=""33"" Id=""65"" />
      <LayoutPos TypeId=""5"" Group=""33"" Id=""66"" />
      <LayoutPos TypeId=""5"" Group=""34"" Id=""67"" />
      <LayoutPos TypeId=""5"" Group=""34"" Id=""68"" />
      <LayoutPos TypeId=""5"" Group=""35"" Id=""69"" />
      <LayoutPos TypeId=""5"" Group=""35"" Id=""70"" />
      <LayoutPos TypeId=""5"" Group=""36"" Id=""71"" />
      <LayoutPos TypeId=""5"" Group=""36"" Id=""72"" />
      <LayoutPos TypeId=""5"" Group=""37"" Id=""73"" />
      <LayoutPos TypeId=""5"" Group=""37"" Id=""74"" />
      <LayoutPos TypeId=""5"" Group=""38"" Id=""75"" />
      <LayoutPos TypeId=""5"" Group=""38"" Id=""76"" />
      <LayoutPos TypeId=""5"" Group=""39"" Id=""77"" />
      <LayoutPos TypeId=""5"" Group=""39"" Id=""78"" />
      <LayoutPos TypeId=""5"" Group=""40"" Id=""79"" />
      <LayoutPos TypeId=""5"" Group=""40"" Id=""80"" />
      <LayoutPos TypeId=""5"" Group=""41"" Id=""81"" />
      <LayoutPos TypeId=""5"" Group=""41"" Id=""82"" />
      <LayoutPos TypeId=""5"" Group=""42"" Id=""83"" />
      <LayoutPos TypeId=""5"" Group=""42"" Id=""84"" />
      <LayoutPos TypeId=""5"" Group=""43"" Id=""85"" />
      <LayoutPos TypeId=""5"" Group=""43"" Id=""86"" />
      <LayoutPos TypeId=""5"" Group=""44"" Id=""87"" />
      <LayoutPos TypeId=""5"" Group=""44"" Id=""88"" />
      <LayoutPos TypeId=""5"" Group=""45"" Id=""89"" />
      <LayoutPos TypeId=""5"" Group=""45"" Id=""90"" />
      <LayoutPos TypeId=""5"" Group=""46"" Id=""91"" />
      <LayoutPos TypeId=""5"" Group=""46"" Id=""92"" />
      <LayoutPos TypeId=""5"" Group=""47"" Id=""93"" />
      <LayoutPos TypeId=""5"" Group=""47"" Id=""94"" />
      <LayoutPos TypeId=""5"" Group=""48"" Id=""95"" />
      <LayoutPos TypeId=""5"" Group=""48"" Id=""96"" />
    </LayoutPositions>
  </SingleLayoutLight>
</UserLayout>";
        public string xmlUnknowns__Duplicates_Down_ = @"<?xml version=""1.0"" encoding=""utf-8""?>
<UserLayout>
  <LayoutDimensions>
    <Width>12</Width>
    <Height>8</Height>
  </LayoutDimensions>
  <SampleTypes>
    <SampleType Id=""1"" Name=""Unused"" Colour=""White"" />
    <SampleType Id=""5"" Name=""Unknown"" Colour=""Lime"" />
  </SampleTypes>
  <SingleLayoutLight NumPositions=""96"">
    <LayoutPositions>
      <LayoutPos TypeId=""5"" Group=""1"" Id=""1"" />
      <LayoutPos TypeId=""5"" Group=""1"" Id=""2"" />
      <LayoutPos TypeId=""5"" Group=""9"" Id=""3"" />
      <LayoutPos TypeId=""5"" Group=""9"" Id=""4"" />
      <LayoutPos TypeId=""5"" Group=""17"" Id=""5"" />
      <LayoutPos TypeId=""5"" Group=""17"" Id=""6"" />
      <LayoutPos TypeId=""5"" Group=""25"" Id=""7"" />
      <LayoutPos TypeId=""5"" Group=""25"" Id=""8"" />
      <LayoutPos TypeId=""5"" Group=""33"" Id=""9"" />
      <LayoutPos TypeId=""5"" Group=""33"" Id=""10"" />
      <LayoutPos TypeId=""5"" Group=""41"" Id=""11"" />
      <LayoutPos TypeId=""5"" Group=""41"" Id=""12"" />
      <LayoutPos TypeId=""5"" Group=""2"" Id=""13"" />
      <LayoutPos TypeId=""5"" Group=""2"" Id=""14"" />
      <LayoutPos TypeId=""5"" Group=""10"" Id=""15"" />
      <LayoutPos TypeId=""5"" Group=""10"" Id=""16"" />
      <LayoutPos TypeId=""5"" Group=""18"" Id=""17"" />
      <LayoutPos TypeId=""5"" Group=""18"" Id=""18"" />
      <LayoutPos TypeId=""5"" Group=""26"" Id=""19"" />
      <LayoutPos TypeId=""5"" Group=""26"" Id=""20"" />
      <LayoutPos TypeId=""5"" Group=""34"" Id=""21"" />
      <LayoutPos TypeId=""5"" Group=""34"" Id=""22"" />
      <LayoutPos TypeId=""5"" Group=""42"" Id=""23"" />
      <LayoutPos TypeId=""5"" Group=""42"" Id=""24"" />
      <LayoutPos TypeId=""5"" Group=""3"" Id=""25"" />
      <LayoutPos TypeId=""5"" Group=""3"" Id=""26"" />
      <LayoutPos TypeId=""5"" Group=""11"" Id=""27"" />
      <LayoutPos TypeId=""5"" Group=""11"" Id=""28"" />
      <LayoutPos TypeId=""5"" Group=""19"" Id=""29"" />
      <LayoutPos TypeId=""5"" Group=""19"" Id=""30"" />
      <LayoutPos TypeId=""5"" Group=""27"" Id=""31"" />
      <LayoutPos TypeId=""5"" Group=""27"" Id=""32"" />
      <LayoutPos TypeId=""5"" Group=""35"" Id=""33"" />
      <LayoutPos TypeId=""5"" Group=""35"" Id=""34"" />
      <LayoutPos TypeId=""5"" Group=""43"" Id=""35"" />
      <LayoutPos TypeId=""5"" Group=""43"" Id=""36"" />
      <LayoutPos TypeId=""5"" Group=""4"" Id=""37"" />
      <LayoutPos TypeId=""5"" Group=""4"" Id=""38"" />
      <LayoutPos TypeId=""5"" Group=""12"" Id=""39"" />
      <LayoutPos TypeId=""5"" Group=""12"" Id=""40"" />
      <LayoutPos TypeId=""5"" Group=""20"" Id=""41"" />
      <LayoutPos TypeId=""5"" Group=""20"" Id=""42"" />
      <LayoutPos TypeId=""5"" Group=""28"" Id=""43"" />
      <LayoutPos TypeId=""5"" Group=""28"" Id=""44"" />
      <LayoutPos TypeId=""5"" Group=""36"" Id=""45"" />
      <LayoutPos TypeId=""5"" Group=""36"" Id=""46"" />
      <LayoutPos TypeId=""5"" Group=""44"" Id=""47"" />
      <LayoutPos TypeId=""5"" Group=""44"" Id=""48"" />
      <LayoutPos TypeId=""5"" Group=""5"" Id=""49"" />
      <LayoutPos TypeId=""5"" Group=""5"" Id=""50"" />
      <LayoutPos TypeId=""5"" Group=""13"" Id=""51"" />
      <LayoutPos TypeId=""5"" Group=""13"" Id=""52"" />
      <LayoutPos TypeId=""5"" Group=""21"" Id=""53"" />
      <LayoutPos TypeId=""5"" Group=""21"" Id=""54"" />
      <LayoutPos TypeId=""5"" Group=""29"" Id=""55"" />
      <LayoutPos TypeId=""5"" Group=""29"" Id=""56"" />
      <LayoutPos TypeId=""5"" Group=""37"" Id=""57"" />
      <LayoutPos TypeId=""5"" Group=""37"" Id=""58"" />
      <LayoutPos TypeId=""5"" Group=""45"" Id=""59"" />
      <LayoutPos TypeId=""5"" Group=""45"" Id=""60"" />
      <LayoutPos TypeId=""5"" Group=""6"" Id=""61"" />
      <LayoutPos TypeId=""5"" Group=""6"" Id=""62"" />
      <LayoutPos TypeId=""5"" Group=""14"" Id=""63"" />
      <LayoutPos TypeId=""5"" Group=""14"" Id=""64"" />
      <LayoutPos TypeId=""5"" Group=""22"" Id=""65"" />
      <LayoutPos TypeId=""5"" Group=""22"" Id=""66"" />
      <LayoutPos TypeId=""5"" Group=""30"" Id=""67"" />
      <LayoutPos TypeId=""5"" Group=""30"" Id=""68"" />
      <LayoutPos TypeId=""5"" Group=""38"" Id=""69"" />
      <LayoutPos TypeId=""5"" Group=""38"" Id=""70"" />
      <LayoutPos TypeId=""5"" Group=""46"" Id=""71"" />
      <LayoutPos TypeId=""5"" Group=""46"" Id=""72"" />
      <LayoutPos TypeId=""5"" Group=""7"" Id=""73"" />
      <LayoutPos TypeId=""5"" Group=""7"" Id=""74"" />
      <LayoutPos TypeId=""5"" Group=""15"" Id=""75"" />
      <LayoutPos TypeId=""5"" Group=""15"" Id=""76"" />
      <LayoutPos TypeId=""5"" Group=""23"" Id=""77"" />
      <LayoutPos TypeId=""5"" Group=""23"" Id=""78"" />
      <LayoutPos TypeId=""5"" Group=""31"" Id=""79"" />
      <LayoutPos TypeId=""5"" Group=""31"" Id=""80"" />
      <LayoutPos TypeId=""5"" Group=""39"" Id=""81"" />
      <LayoutPos TypeId=""5"" Group=""39"" Id=""82"" />
      <LayoutPos TypeId=""5"" Group=""47"" Id=""83"" />
      <LayoutPos TypeId=""5"" Group=""47"" Id=""84"" />
      <LayoutPos TypeId=""5"" Group=""8"" Id=""85"" />
      <LayoutPos TypeId=""5"" Group=""8"" Id=""86"" />
      <LayoutPos TypeId=""5"" Group=""16"" Id=""87"" />
      <LayoutPos TypeId=""5"" Group=""16"" Id=""88"" />
      <LayoutPos TypeId=""5"" Group=""24"" Id=""89"" />
      <LayoutPos TypeId=""5"" Group=""24"" Id=""90"" />
      <LayoutPos TypeId=""5"" Group=""32"" Id=""91"" />
      <LayoutPos TypeId=""5"" Group=""32"" Id=""92"" />
      <LayoutPos TypeId=""5"" Group=""40"" Id=""93"" />
      <LayoutPos TypeId=""5"" Group=""40"" Id=""94"" />
      <LayoutPos TypeId=""5"" Group=""48"" Id=""95"" />
      <LayoutPos TypeId=""5"" Group=""48"" Id=""96"" />
    </LayoutPositions>
  </SingleLayoutLight>
</UserLayout>";

        // Standard3 missing
        public string xmlInvalidNotContiguous1 = @"<?xml version=""1.0"" encoding=""utf-8""?>
<UserLayout>
  <LayoutDimensions>
    <Width>12</Width>
    <Height>8</Height>
  </LayoutDimensions>
  <SampleTypes>
    <SampleType Id=""1"" Name=""Unused"" Colour=""White"" />
    <SampleType Id=""2"" Name=""Standard"" Colour=""Red"" />
    <SampleType Id=""3"" Name=""Blank"" Colour=""Yellow"" />
    <SampleType Id=""4"" Name=""Control"" Colour=""Aqua"" />
    <SampleType Id=""5"" Name=""Unknown"" Colour=""Lime"" />
  </SampleTypes>
  <SingleLayoutLight NumPositions=""96"">
    <LayoutPositions>
      <LayoutPos TypeId=""2"" Group=""1"" Id=""1"" />
      <LayoutPos TypeId=""2"" Group=""1"" Id=""2"" />
      <LayoutPos TypeId=""5"" Group=""1"" Id=""3"" />
      <LayoutPos TypeId=""5"" Group=""1"" Id=""4"" />
      <LayoutPos TypeId=""5"" Group=""9"" Id=""5"" />
      <LayoutPos TypeId=""5"" Group=""9"" Id=""6"" />
      <LayoutPos TypeId=""5"" Group=""17"" Id=""7"" />
      <LayoutPos TypeId=""5"" Group=""17"" Id=""8"" />
      <LayoutPos TypeId=""5"" Group=""25"" Id=""9"" />
      <LayoutPos TypeId=""5"" Group=""25"" Id=""10"" />
      <LayoutPos TypeId=""4"" Group=""1"" Id=""11"" />
      <LayoutPos TypeId=""4"" Group=""1"" Id=""12"" />
      <LayoutPos TypeId=""2"" Group=""2"" Id=""13"" />
      <LayoutPos TypeId=""2"" Group=""2"" Id=""14"" />
      <LayoutPos TypeId=""5"" Group=""2"" Id=""15"" />
      <LayoutPos TypeId=""5"" Group=""2"" Id=""16"" />
      <LayoutPos TypeId=""5"" Group=""10"" Id=""17"" />
      <LayoutPos TypeId=""5"" Group=""10"" Id=""18"" />
      <LayoutPos TypeId=""5"" Group=""18"" Id=""19"" />
      <LayoutPos TypeId=""5"" Group=""18"" Id=""20"" />
      <LayoutPos TypeId=""5"" Group=""26"" Id=""21"" />
      <LayoutPos TypeId=""5"" Group=""26"" Id=""22"" />
      <LayoutPos TypeId=""4"" Group=""2"" Id=""23"" />
      <LayoutPos TypeId=""4"" Group=""2"" Id=""24"" />
      <LayoutPos TypeId=""5"" Group=""3"" Id=""27"" />
      <LayoutPos TypeId=""5"" Group=""3"" Id=""28"" />
      <LayoutPos TypeId=""5"" Group=""11"" Id=""29"" />
      <LayoutPos TypeId=""5"" Group=""11"" Id=""30"" />
      <LayoutPos TypeId=""5"" Group=""19"" Id=""31"" />
      <LayoutPos TypeId=""5"" Group=""19"" Id=""32"" />
      <LayoutPos TypeId=""5"" Group=""27"" Id=""33"" />
      <LayoutPos TypeId=""5"" Group=""27"" Id=""34"" />
      <LayoutPos TypeId=""4"" Group=""3"" Id=""35"" />
      <LayoutPos TypeId=""4"" Group=""3"" Id=""36"" />
      <LayoutPos TypeId=""2"" Group=""4"" Id=""37"" />
      <LayoutPos TypeId=""2"" Group=""4"" Id=""38"" />
      <LayoutPos TypeId=""5"" Group=""4"" Id=""39"" />
      <LayoutPos TypeId=""5"" Group=""4"" Id=""40"" />
      <LayoutPos TypeId=""5"" Group=""12"" Id=""41"" />
      <LayoutPos TypeId=""5"" Group=""12"" Id=""42"" />
      <LayoutPos TypeId=""5"" Group=""20"" Id=""43"" />
      <LayoutPos TypeId=""5"" Group=""20"" Id=""44"" />
      <LayoutPos TypeId=""5"" Group=""28"" Id=""45"" />
      <LayoutPos TypeId=""5"" Group=""28"" Id=""46"" />
      <LayoutPos TypeId=""4"" Group=""4"" Id=""47"" />
      <LayoutPos TypeId=""4"" Group=""4"" Id=""48"" />
      <LayoutPos TypeId=""2"" Group=""5"" Id=""49"" />
      <LayoutPos TypeId=""2"" Group=""5"" Id=""50"" />
      <LayoutPos TypeId=""5"" Group=""5"" Id=""51"" />
      <LayoutPos TypeId=""5"" Group=""5"" Id=""52"" />
      <LayoutPos TypeId=""5"" Group=""13"" Id=""53"" />
      <LayoutPos TypeId=""5"" Group=""13"" Id=""54"" />
      <LayoutPos TypeId=""5"" Group=""21"" Id=""55"" />
      <LayoutPos TypeId=""5"" Group=""21"" Id=""56"" />
      <LayoutPos TypeId=""5"" Group=""29"" Id=""57"" />
      <LayoutPos TypeId=""5"" Group=""29"" Id=""58"" />
      <LayoutPos TypeId=""4"" Group=""5"" Id=""59"" />
      <LayoutPos TypeId=""4"" Group=""5"" Id=""60"" />
      <LayoutPos TypeId=""2"" Group=""6"" Id=""61"" />
      <LayoutPos TypeId=""2"" Group=""6"" Id=""62"" />
      <LayoutPos TypeId=""5"" Group=""6"" Id=""63"" />
      <LayoutPos TypeId=""5"" Group=""6"" Id=""64"" />
      <LayoutPos TypeId=""5"" Group=""14"" Id=""65"" />
      <LayoutPos TypeId=""5"" Group=""14"" Id=""66"" />
      <LayoutPos TypeId=""5"" Group=""22"" Id=""67"" />
      <LayoutPos TypeId=""5"" Group=""22"" Id=""68"" />
      <LayoutPos TypeId=""5"" Group=""30"" Id=""69"" />
      <LayoutPos TypeId=""5"" Group=""30"" Id=""70"" />
      <LayoutPos TypeId=""4"" Group=""6"" Id=""71"" />
      <LayoutPos TypeId=""4"" Group=""6"" Id=""72"" />
      <LayoutPos TypeId=""2"" Group=""7"" Id=""73"" />
      <LayoutPos TypeId=""2"" Group=""7"" Id=""74"" />
      <LayoutPos TypeId=""5"" Group=""7"" Id=""75"" />
      <LayoutPos TypeId=""5"" Group=""7"" Id=""76"" />
      <LayoutPos TypeId=""5"" Group=""15"" Id=""77"" />
      <LayoutPos TypeId=""5"" Group=""15"" Id=""78"" />
      <LayoutPos TypeId=""5"" Group=""23"" Id=""79"" />
      <LayoutPos TypeId=""5"" Group=""23"" Id=""80"" />
      <LayoutPos TypeId=""5"" Group=""31"" Id=""81"" />
      <LayoutPos TypeId=""5"" Group=""31"" Id=""82"" />
      <LayoutPos TypeId=""4"" Group=""7"" Id=""83"" />
      <LayoutPos TypeId=""4"" Group=""7"" Id=""84"" />
      <LayoutPos TypeId=""3"" Group=""1"" Id=""85"" />
      <LayoutPos TypeId=""3"" Group=""1"" Id=""86"" />
      <LayoutPos TypeId=""5"" Group=""8"" Id=""87"" />
      <LayoutPos TypeId=""5"" Group=""8"" Id=""88"" />
      <LayoutPos TypeId=""5"" Group=""16"" Id=""89"" />
      <LayoutPos TypeId=""5"" Group=""16"" Id=""90"" />
      <LayoutPos TypeId=""5"" Group=""24"" Id=""91"" />
      <LayoutPos TypeId=""5"" Group=""24"" Id=""92"" />
      <LayoutPos TypeId=""5"" Group=""32"" Id=""93"" />
      <LayoutPos TypeId=""5"" Group=""32"" Id=""94"" />
      <LayoutPos TypeId=""4"" Group=""8"" Id=""95"" />
      <LayoutPos TypeId=""4"" Group=""8"" Id=""96"" />
    </LayoutPositions>
  </SingleLayoutLight>
</UserLayout>";

        public string xmlInvalidNoUnknown1 = @"<?xml version=""1.0"" encoding=""utf-8""?>
        <UserLayout Width=""12"" Height=""8"">
           <SampleTypes>
            <SampleType Id=""1"" Name=""Unused"" Colour=""White"" />
            <SampleType Id=""2"" Name=""Standard"" Colour=""Red"" />
            <SampleType Id=""3"" Name=""Blank"" Colour=""Yellow"" />
            <SampleType Id=""5"" Name=""Unknown"" Colour=""Lime"" />
          </SampleTypes>
          <SingleLayoutLight NumPositions=""96"">
            <LayoutPositions>
              <LayoutPos TypeId=""2"" Group=""1"" Id=""1"" />
              <LayoutPos TypeId=""2"" Group=""1"" Id=""2"" />
              <LayoutPos TypeId=""2"" Group=""2"" Id=""3"" />
              <LayoutPos TypeId=""2"" Group=""2"" Id=""4"" />
              <LayoutPos TypeId=""2"" Group=""3"" Id=""5"" />
              <LayoutPos TypeId=""2"" Group=""3"" Id=""6"" />
              <LayoutPos TypeId=""2"" Group=""4"" Id=""7"" />
              <LayoutPos TypeId=""2"" Group=""4"" Id=""8"" />
              <LayoutPos TypeId=""2"" Group=""5"" Id=""9"" />
              <LayoutPos TypeId=""2"" Group=""5"" Id=""10"" />
              <LayoutPos TypeId=""2"" Group=""6"" Id=""11"" />
              <LayoutPos TypeId=""2"" Group=""6"" Id=""12"" />
              <LayoutPos TypeId=""3"" Group=""1"" Id=""13"" />
              <LayoutPos TypeId=""3"" Group=""1"" Id=""14"" />
              <LayoutPos TypeId=""5"" Group=""2"" Id=""17"" />
              <LayoutPos TypeId=""5"" Group=""2"" Id=""18"" />
              <LayoutPos TypeId=""5"" Group=""3"" Id=""19"" />
              <LayoutPos TypeId=""5"" Group=""3"" Id=""20"" />
              <LayoutPos TypeId=""5"" Group=""4"" Id=""21"" />
              <LayoutPos TypeId=""5"" Group=""4"" Id=""22"" />
              <LayoutPos TypeId=""5"" Group=""5"" Id=""23"" />
              <LayoutPos TypeId=""5"" Group=""5"" Id=""24"" />
              <LayoutPos TypeId=""5"" Group=""6"" Id=""25"" />
              <LayoutPos TypeId=""5"" Group=""6"" Id=""26"" />
              <LayoutPos TypeId=""5"" Group=""7"" Id=""27"" />
              <LayoutPos TypeId=""5"" Group=""7"" Id=""28"" />
              <LayoutPos TypeId=""5"" Group=""8"" Id=""29"" />
              <LayoutPos TypeId=""5"" Group=""8"" Id=""30"" />
              <LayoutPos TypeId=""5"" Group=""9"" Id=""31"" />
              <LayoutPos TypeId=""5"" Group=""9"" Id=""32"" />
              <LayoutPos TypeId=""5"" Group=""10"" Id=""33"" />
              <LayoutPos TypeId=""5"" Group=""10"" Id=""34"" />
              <LayoutPos TypeId=""5"" Group=""11"" Id=""35"" />
              <LayoutPos TypeId=""5"" Group=""11"" Id=""36"" />
              <LayoutPos TypeId=""5"" Group=""12"" Id=""37"" />
              <LayoutPos TypeId=""5"" Group=""12"" Id=""38"" />
              <LayoutPos TypeId=""5"" Group=""13"" Id=""39"" />
              <LayoutPos TypeId=""5"" Group=""13"" Id=""40"" />
              <LayoutPos TypeId=""5"" Group=""14"" Id=""41"" />
              <LayoutPos TypeId=""5"" Group=""14"" Id=""42"" />
              <LayoutPos TypeId=""5"" Group=""15"" Id=""43"" />
              <LayoutPos TypeId=""5"" Group=""15"" Id=""44"" />
              <LayoutPos TypeId=""5"" Group=""16"" Id=""45"" />
              <LayoutPos TypeId=""5"" Group=""16"" Id=""46"" />
              <LayoutPos TypeId=""5"" Group=""17"" Id=""47"" />
              <LayoutPos TypeId=""5"" Group=""17"" Id=""48"" />
              <LayoutPos TypeId=""5"" Group=""18"" Id=""49"" />
              <LayoutPos TypeId=""5"" Group=""18"" Id=""50"" />
              <LayoutPos TypeId=""5"" Group=""19"" Id=""51"" />
              <LayoutPos TypeId=""5"" Group=""19"" Id=""52"" />
              <LayoutPos TypeId=""5"" Group=""20"" Id=""53"" />
              <LayoutPos TypeId=""5"" Group=""20"" Id=""54"" />
              <LayoutPos TypeId=""5"" Group=""21"" Id=""55"" />
              <LayoutPos TypeId=""5"" Group=""21"" Id=""56"" />
              <LayoutPos TypeId=""5"" Group=""22"" Id=""57"" />
              <LayoutPos TypeId=""5"" Group=""22"" Id=""58"" />
              <LayoutPos TypeId=""5"" Group=""23"" Id=""59"" />
              <LayoutPos TypeId=""5"" Group=""23"" Id=""60"" />
              <LayoutPos TypeId=""5"" Group=""24"" Id=""61"" />
              <LayoutPos TypeId=""5"" Group=""24"" Id=""62"" />
              <LayoutPos TypeId=""5"" Group=""25"" Id=""63"" />
              <LayoutPos TypeId=""5"" Group=""25"" Id=""64"" />
              <LayoutPos TypeId=""5"" Group=""26"" Id=""65"" />
              <LayoutPos TypeId=""5"" Group=""26"" Id=""66"" />
              <LayoutPos TypeId=""5"" Group=""27"" Id=""67"" />
              <LayoutPos TypeId=""5"" Group=""27"" Id=""68"" />
              <LayoutPos TypeId=""5"" Group=""28"" Id=""69"" />
              <LayoutPos TypeId=""5"" Group=""28"" Id=""70"" />
              <LayoutPos TypeId=""5"" Group=""29"" Id=""71"" />
              <LayoutPos TypeId=""5"" Group=""29"" Id=""72"" />
              <LayoutPos TypeId=""5"" Group=""30"" Id=""73"" />
              <LayoutPos TypeId=""5"" Group=""30"" Id=""74"" />
              <LayoutPos TypeId=""5"" Group=""31"" Id=""75"" />
              <LayoutPos TypeId=""5"" Group=""31"" Id=""76"" />
              <LayoutPos TypeId=""5"" Group=""32"" Id=""77"" />
              <LayoutPos TypeId=""5"" Group=""32"" Id=""78"" />
              <LayoutPos TypeId=""5"" Group=""33"" Id=""79"" />
              <LayoutPos TypeId=""5"" Group=""33"" Id=""80"" />
              <LayoutPos TypeId=""5"" Group=""34"" Id=""81"" />
              <LayoutPos TypeId=""5"" Group=""34"" Id=""82"" />
              <LayoutPos TypeId=""5"" Group=""35"" Id=""83"" />
              <LayoutPos TypeId=""5"" Group=""35"" Id=""84"" />
              <LayoutPos TypeId=""5"" Group=""36"" Id=""85"" />
              <LayoutPos TypeId=""5"" Group=""36"" Id=""86"" />
              <LayoutPos TypeId=""5"" Group=""37"" Id=""87"" />
              <LayoutPos TypeId=""5"" Group=""37"" Id=""88"" />
              <LayoutPos TypeId=""5"" Group=""38"" Id=""89"" />
              <LayoutPos TypeId=""5"" Group=""38"" Id=""90"" />
              <LayoutPos TypeId=""5"" Group=""39"" Id=""91"" />
              <LayoutPos TypeId=""5"" Group=""39"" Id=""92"" />
              <LayoutPos TypeId=""5"" Group=""40"" Id=""93"" />
              <LayoutPos TypeId=""5"" Group=""40"" Id=""94"" />
              <LayoutPos TypeId=""5"" Group=""41"" Id=""95"" />
              <LayoutPos TypeId=""5"" Group=""41"" Id=""96"" />
            </LayoutPositions>
          </SingleLayoutLight>
        </UserLayout>";

        public string xmlMixedReplicates1 = @"<?xml version=""1.0"" encoding=""utf-8""?>
<UserLayout>
  <LayoutDimensions>
    <Width>12</Width>
    <Height>8</Height>
  </LayoutDimensions>
  <SampleTypes>
    <SampleType Id=""1"" Name=""Unused"" Colour=""White"" />
    <SampleType Id=""5"" Name=""Unknown"" Colour=""Lime"" />
  </SampleTypes>
  <SingleLayoutLight NumPositions=""96"">
    <LayoutPositions>
      <LayoutPos TypeId=""5"" Group=""1"" Id=""1"" />
      <LayoutPos TypeId=""5"" Group=""1"" Id=""2"" />
      <LayoutPos TypeId=""5"" Group=""1"" Id=""3"" />
      <LayoutPos TypeId=""5"" Group=""2"" Id=""4"" />
      <LayoutPos TypeId=""5"" Group=""2"" Id=""5"" />
      <LayoutPos TypeId=""5"" Group=""3"" Id=""6"" />
      <LayoutPos TypeId=""5"" Group=""3"" Id=""7"" />
      <LayoutPos TypeId=""5"" Group=""4"" Id=""8"" />
      <LayoutPos TypeId=""5"" Group=""5"" Id=""9"" />
      <LayoutPos TypeId=""5"" Group=""5"" Id=""10"" />
      <LayoutPos TypeId=""5"" Group=""6"" Id=""11"" />
      <LayoutPos TypeId=""5"" Group=""6"" Id=""12"" />
      <LayoutPos TypeId=""5"" Group=""7"" Id=""13"" />
      <LayoutPos TypeId=""5"" Group=""7"" Id=""14"" />
      <LayoutPos TypeId=""5"" Group=""8"" Id=""15"" />
      <LayoutPos TypeId=""5"" Group=""8"" Id=""16"" />
      <LayoutPos TypeId=""5"" Group=""9"" Id=""17"" />
      <LayoutPos TypeId=""5"" Group=""9"" Id=""18"" />
      <LayoutPos TypeId=""5"" Group=""10"" Id=""19"" />
      <LayoutPos TypeId=""5"" Group=""10"" Id=""20"" />
      <LayoutPos TypeId=""5"" Group=""11"" Id=""21"" />
      <LayoutPos TypeId=""5"" Group=""11"" Id=""22"" />
      <LayoutPos TypeId=""5"" Group=""12"" Id=""23"" />
      <LayoutPos TypeId=""5"" Group=""12"" Id=""24"" />
      <LayoutPos TypeId=""5"" Group=""13"" Id=""25"" />
      <LayoutPos TypeId=""5"" Group=""13"" Id=""26"" />
      <LayoutPos TypeId=""5"" Group=""14"" Id=""27"" />
      <LayoutPos TypeId=""5"" Group=""14"" Id=""28"" />
      <LayoutPos TypeId=""5"" Group=""15"" Id=""29"" />
      <LayoutPos TypeId=""5"" Group=""15"" Id=""30"" />
      <LayoutPos TypeId=""5"" Group=""16"" Id=""31"" />
      <LayoutPos TypeId=""5"" Group=""16"" Id=""32"" />
      <LayoutPos TypeId=""5"" Group=""17"" Id=""33"" />
      <LayoutPos TypeId=""5"" Group=""17"" Id=""34"" />
      <LayoutPos TypeId=""5"" Group=""18"" Id=""35"" />
      <LayoutPos TypeId=""5"" Group=""18"" Id=""36"" />
      <LayoutPos TypeId=""5"" Group=""19"" Id=""37"" />
      <LayoutPos TypeId=""5"" Group=""19"" Id=""38"" />
      <LayoutPos TypeId=""5"" Group=""20"" Id=""39"" />
      <LayoutPos TypeId=""5"" Group=""20"" Id=""40"" />
      <LayoutPos TypeId=""5"" Group=""21"" Id=""41"" />
      <LayoutPos TypeId=""5"" Group=""21"" Id=""42"" />
      <LayoutPos TypeId=""5"" Group=""22"" Id=""43"" />
      <LayoutPos TypeId=""5"" Group=""22"" Id=""44"" />
      <LayoutPos TypeId=""5"" Group=""23"" Id=""45"" />
      <LayoutPos TypeId=""5"" Group=""23"" Id=""46"" />
      <LayoutPos TypeId=""5"" Group=""24"" Id=""47"" />
      <LayoutPos TypeId=""5"" Group=""24"" Id=""48"" />
      <LayoutPos TypeId=""5"" Group=""25"" Id=""49"" />
      <LayoutPos TypeId=""5"" Group=""25"" Id=""50"" />
      <LayoutPos TypeId=""5"" Group=""26"" Id=""51"" />
      <LayoutPos TypeId=""5"" Group=""26"" Id=""52"" />
      <LayoutPos TypeId=""5"" Group=""27"" Id=""53"" />
      <LayoutPos TypeId=""5"" Group=""27"" Id=""54"" />
      <LayoutPos TypeId=""5"" Group=""28"" Id=""55"" />
      <LayoutPos TypeId=""5"" Group=""28"" Id=""56"" />
      <LayoutPos TypeId=""5"" Group=""29"" Id=""57"" />
      <LayoutPos TypeId=""5"" Group=""29"" Id=""58"" />
      <LayoutPos TypeId=""5"" Group=""30"" Id=""59"" />
      <LayoutPos TypeId=""5"" Group=""30"" Id=""60"" />
      <LayoutPos TypeId=""5"" Group=""31"" Id=""61"" />
      <LayoutPos TypeId=""5"" Group=""31"" Id=""62"" />
      <LayoutPos TypeId=""5"" Group=""32"" Id=""63"" />
      <LayoutPos TypeId=""5"" Group=""32"" Id=""64"" />
      <LayoutPos TypeId=""5"" Group=""33"" Id=""65"" />
      <LayoutPos TypeId=""5"" Group=""33"" Id=""66"" />
      <LayoutPos TypeId=""5"" Group=""34"" Id=""67"" />
      <LayoutPos TypeId=""5"" Group=""34"" Id=""68"" />
      <LayoutPos TypeId=""5"" Group=""35"" Id=""69"" />
      <LayoutPos TypeId=""5"" Group=""35"" Id=""70"" />
      <LayoutPos TypeId=""5"" Group=""36"" Id=""71"" />
      <LayoutPos TypeId=""5"" Group=""36"" Id=""72"" />
      <LayoutPos TypeId=""5"" Group=""37"" Id=""73"" />
      <LayoutPos TypeId=""5"" Group=""37"" Id=""74"" />
      <LayoutPos TypeId=""5"" Group=""38"" Id=""75"" />
      <LayoutPos TypeId=""5"" Group=""38"" Id=""76"" />
      <LayoutPos TypeId=""5"" Group=""39"" Id=""77"" />
      <LayoutPos TypeId=""5"" Group=""39"" Id=""78"" />
      <LayoutPos TypeId=""5"" Group=""40"" Id=""79"" />
      <LayoutPos TypeId=""5"" Group=""40"" Id=""80"" />
      <LayoutPos TypeId=""5"" Group=""41"" Id=""81"" />
      <LayoutPos TypeId=""5"" Group=""41"" Id=""82"" />
      <LayoutPos TypeId=""5"" Group=""42"" Id=""83"" />
      <LayoutPos TypeId=""5"" Group=""42"" Id=""84"" />
      <LayoutPos TypeId=""5"" Group=""43"" Id=""85"" />
      <LayoutPos TypeId=""5"" Group=""43"" Id=""86"" />
      <LayoutPos TypeId=""5"" Group=""44"" Id=""87"" />
      <LayoutPos TypeId=""5"" Group=""44"" Id=""88"" />
      <LayoutPos TypeId=""5"" Group=""45"" Id=""89"" />
      <LayoutPos TypeId=""5"" Group=""45"" Id=""90"" />
      <LayoutPos TypeId=""5"" Group=""46"" Id=""91"" />
      <LayoutPos TypeId=""5"" Group=""46"" Id=""92"" />
      <LayoutPos TypeId=""5"" Group=""47"" Id=""93"" />
      <LayoutPos TypeId=""5"" Group=""47"" Id=""94"" />
      <LayoutPos TypeId=""5"" Group=""48"" Id=""95"" />
      <LayoutPos TypeId=""5"" Group=""48"" Id=""96"" />
    </LayoutPositions>
  </SingleLayoutLight>
</UserLayout>";
        public string xmlMixedReplicates2 = @"<?xml version=""1.0"" encoding=""utf-8""?>
<UserLayout>
  <LayoutDimensions>
    <Width>12</Width>
    <Height>8</Height>
  </LayoutDimensions>
  <SampleTypes>
    <SampleType Id=""1"" Name=""Unused"" Colour=""White"" />
    <SampleType Id=""5"" Name=""Unknown"" Colour=""Lime"" />
  </SampleTypes>
  <SingleLayoutLight NumPositions=""96"">
    <LayoutPositions>
      <LayoutPos TypeId=""5"" Group=""1"" Id=""1"" />
      <LayoutPos TypeId=""5"" Group=""1"" Id=""2"" />
      <LayoutPos TypeId=""5"" Group=""2"" Id=""3"" />
      <LayoutPos TypeId=""5"" Group=""2"" Id=""4"" />
      <LayoutPos TypeId=""5"" Group=""3"" Id=""5"" />
      <LayoutPos TypeId=""5"" Group=""3"" Id=""6"" />
      <LayoutPos TypeId=""5"" Group=""4"" Id=""7"" />
      <LayoutPos TypeId=""5"" Group=""4"" Id=""8"" />
      <LayoutPos TypeId=""5"" Group=""5"" Id=""9"" />
      <LayoutPos TypeId=""5"" Group=""5"" Id=""10"" />
      <LayoutPos TypeId=""5"" Group=""6"" Id=""11"" />
      <LayoutPos TypeId=""5"" Group=""6"" Id=""12"" />
      <LayoutPos TypeId=""5"" Group=""7"" Id=""13"" />
      <LayoutPos TypeId=""5"" Group=""7"" Id=""14"" />
      <LayoutPos TypeId=""5"" Group=""8"" Id=""15"" />
      <LayoutPos TypeId=""5"" Group=""8"" Id=""16"" />
      <LayoutPos TypeId=""5"" Group=""9"" Id=""17"" />
      <LayoutPos TypeId=""5"" Group=""9"" Id=""18"" />
      <LayoutPos TypeId=""5"" Group=""10"" Id=""19"" />
      <LayoutPos TypeId=""5"" Group=""10"" Id=""20"" />
      <LayoutPos TypeId=""5"" Group=""11"" Id=""21"" />
      <LayoutPos TypeId=""5"" Group=""11"" Id=""22"" />
      <LayoutPos TypeId=""5"" Group=""12"" Id=""23"" />
      <LayoutPos TypeId=""5"" Group=""12"" Id=""24"" />
      <LayoutPos TypeId=""5"" Group=""13"" Id=""25"" />
      <LayoutPos TypeId=""5"" Group=""13"" Id=""26"" />
      <LayoutPos TypeId=""5"" Group=""14"" Id=""27"" />
      <LayoutPos TypeId=""5"" Group=""14"" Id=""28"" />
      <LayoutPos TypeId=""5"" Group=""15"" Id=""29"" />
      <LayoutPos TypeId=""5"" Group=""15"" Id=""30"" />
      <LayoutPos TypeId=""5"" Group=""16"" Id=""31"" />
      <LayoutPos TypeId=""5"" Group=""16"" Id=""32"" />
      <LayoutPos TypeId=""5"" Group=""17"" Id=""33"" />
      <LayoutPos TypeId=""5"" Group=""17"" Id=""34"" />
      <LayoutPos TypeId=""5"" Group=""18"" Id=""35"" />
      <LayoutPos TypeId=""5"" Group=""18"" Id=""36"" />
      <LayoutPos TypeId=""5"" Group=""19"" Id=""37"" />
      <LayoutPos TypeId=""5"" Group=""19"" Id=""38"" />
      <LayoutPos TypeId=""5"" Group=""20"" Id=""39"" />
      <LayoutPos TypeId=""5"" Group=""20"" Id=""40"" />
      <LayoutPos TypeId=""5"" Group=""21"" Id=""41"" />
      <LayoutPos TypeId=""5"" Group=""21"" Id=""42"" />
      <LayoutPos TypeId=""5"" Group=""22"" Id=""43"" />
      <LayoutPos TypeId=""5"" Group=""22"" Id=""44"" />
      <LayoutPos TypeId=""5"" Group=""23"" Id=""45"" />
      <LayoutPos TypeId=""5"" Group=""23"" Id=""46"" />
      <LayoutPos TypeId=""5"" Group=""24"" Id=""47"" />
      <LayoutPos TypeId=""5"" Group=""24"" Id=""48"" />
      <LayoutPos TypeId=""5"" Group=""25"" Id=""49"" />
      <LayoutPos TypeId=""5"" Group=""25"" Id=""50"" />
      <LayoutPos TypeId=""5"" Group=""26"" Id=""51"" />
      <LayoutPos TypeId=""5"" Group=""26"" Id=""52"" />
      <LayoutPos TypeId=""5"" Group=""27"" Id=""53"" />
      <LayoutPos TypeId=""5"" Group=""27"" Id=""54"" />
      <LayoutPos TypeId=""5"" Group=""28"" Id=""55"" />
      <LayoutPos TypeId=""5"" Group=""28"" Id=""56"" />
      <LayoutPos TypeId=""5"" Group=""29"" Id=""57"" />
      <LayoutPos TypeId=""5"" Group=""29"" Id=""58"" />
      <LayoutPos TypeId=""5"" Group=""30"" Id=""59"" />
      <LayoutPos TypeId=""5"" Group=""30"" Id=""60"" />
      <LayoutPos TypeId=""5"" Group=""31"" Id=""61"" />
      <LayoutPos TypeId=""5"" Group=""31"" Id=""62"" />
      <LayoutPos TypeId=""5"" Group=""32"" Id=""63"" />
      <LayoutPos TypeId=""5"" Group=""32"" Id=""64"" />
      <LayoutPos TypeId=""5"" Group=""33"" Id=""65"" />
      <LayoutPos TypeId=""5"" Group=""33"" Id=""66"" />
      <LayoutPos TypeId=""5"" Group=""34"" Id=""67"" />
      <LayoutPos TypeId=""5"" Group=""34"" Id=""68"" />
      <LayoutPos TypeId=""5"" Group=""35"" Id=""69"" />
      <LayoutPos TypeId=""5"" Group=""35"" Id=""70"" />
      <LayoutPos TypeId=""5"" Group=""36"" Id=""71"" />
      <LayoutPos TypeId=""5"" Group=""36"" Id=""72"" />
      <LayoutPos TypeId=""5"" Group=""37"" Id=""73"" />
      <LayoutPos TypeId=""5"" Group=""37"" Id=""74"" />
      <LayoutPos TypeId=""5"" Group=""38"" Id=""75"" />
      <LayoutPos TypeId=""5"" Group=""38"" Id=""76"" />
      <LayoutPos TypeId=""5"" Group=""39"" Id=""77"" />
      <LayoutPos TypeId=""5"" Group=""39"" Id=""78"" />
      <LayoutPos TypeId=""5"" Group=""40"" Id=""79"" />
      <LayoutPos TypeId=""5"" Group=""40"" Id=""80"" />
      <LayoutPos TypeId=""5"" Group=""41"" Id=""81"" />
      <LayoutPos TypeId=""5"" Group=""41"" Id=""82"" />
      <LayoutPos TypeId=""5"" Group=""42"" Id=""83"" />
      <LayoutPos TypeId=""5"" Group=""42"" Id=""84"" />
      <LayoutPos TypeId=""5"" Group=""43"" Id=""85"" />
      <LayoutPos TypeId=""5"" Group=""43"" Id=""86"" />
      <LayoutPos TypeId=""5"" Group=""44"" Id=""87"" />
      <LayoutPos TypeId=""5"" Group=""44"" Id=""88"" />
      <LayoutPos TypeId=""5"" Group=""45"" Id=""89"" />
      <LayoutPos TypeId=""5"" Group=""45"" Id=""90"" />
      <LayoutPos TypeId=""5"" Group=""46"" Id=""91"" />
      <LayoutPos TypeId=""5"" Group=""46"" Id=""92"" />
      <LayoutPos TypeId=""5"" Group=""47"" Id=""93"" />
      <LayoutPos TypeId=""5"" Group=""47"" Id=""94"" />
      <LayoutPos TypeId=""5"" Group=""47"" Id=""95"" />
      <LayoutPos TypeId=""5"" Group=""47"" Id=""96"" />
    </LayoutPositions>
  </SingleLayoutLight>
</UserLayout>";

        public string xmlMixedReplicates3 = @"<?xml version=""1.0"" encoding=""utf-8""?>
<UserLayout>
  <LayoutDimensions>
    <Width>12</Width>
    <Height>8</Height>
  </LayoutDimensions>
  <SampleTypes>
    <SampleType Id=""1"" Name=""Unused"" Colour=""White"" />
    <SampleType Id=""5"" Name=""Unknown"" Colour=""Lime"" />
  </SampleTypes>
  <SingleLayoutLight NumPositions=""96"">
    <LayoutPositions>
      <LayoutPos TypeId=""5"" Group=""1"" Id=""1"" />
      <LayoutPos TypeId=""5"" Group=""1"" Id=""2"" />
      <LayoutPos TypeId=""5"" Group=""2"" Id=""3"" />
      <LayoutPos TypeId=""5"" Group=""2"" Id=""4"" />
      <LayoutPos TypeId=""5"" Group=""3"" Id=""5"" />
      <LayoutPos TypeId=""5"" Group=""3"" Id=""6"" />
      <LayoutPos TypeId=""5"" Group=""4"" Id=""7"" />
      <LayoutPos TypeId=""5"" Group=""4"" Id=""8"" />
      <LayoutPos TypeId=""5"" Group=""5"" Id=""9"" />
      <LayoutPos TypeId=""5"" Group=""5"" Id=""10"" />
      <LayoutPos TypeId=""5"" Group=""6"" Id=""11"" />
      <LayoutPos TypeId=""5"" Group=""6"" Id=""12"" />
      <LayoutPos TypeId=""5"" Group=""6"" Id=""13"" />
      <LayoutPos TypeId=""5"" Group=""7"" Id=""14"" />
      <LayoutPos TypeId=""5"" Group=""8"" Id=""15"" />
      <LayoutPos TypeId=""5"" Group=""8"" Id=""16"" />
      <LayoutPos TypeId=""5"" Group=""9"" Id=""17"" />
      <LayoutPos TypeId=""5"" Group=""9"" Id=""18"" />
      <LayoutPos TypeId=""5"" Group=""10"" Id=""19"" />
      <LayoutPos TypeId=""5"" Group=""10"" Id=""20"" />
      <LayoutPos TypeId=""5"" Group=""11"" Id=""21"" />
      <LayoutPos TypeId=""5"" Group=""11"" Id=""22"" />
      <LayoutPos TypeId=""5"" Group=""12"" Id=""23"" />
      <LayoutPos TypeId=""5"" Group=""12"" Id=""24"" />
      <LayoutPos TypeId=""5"" Group=""13"" Id=""25"" />
      <LayoutPos TypeId=""5"" Group=""13"" Id=""26"" />
      <LayoutPos TypeId=""5"" Group=""14"" Id=""27"" />
      <LayoutPos TypeId=""5"" Group=""14"" Id=""28"" />
      <LayoutPos TypeId=""5"" Group=""15"" Id=""29"" />
      <LayoutPos TypeId=""5"" Group=""15"" Id=""30"" />
      <LayoutPos TypeId=""5"" Group=""16"" Id=""31"" />
      <LayoutPos TypeId=""5"" Group=""16"" Id=""32"" />
      <LayoutPos TypeId=""5"" Group=""17"" Id=""33"" />
      <LayoutPos TypeId=""5"" Group=""17"" Id=""34"" />
      <LayoutPos TypeId=""5"" Group=""18"" Id=""35"" />
      <LayoutPos TypeId=""5"" Group=""18"" Id=""36"" />
      <LayoutPos TypeId=""5"" Group=""19"" Id=""37"" />
      <LayoutPos TypeId=""5"" Group=""19"" Id=""38"" />
      <LayoutPos TypeId=""5"" Group=""20"" Id=""39"" />
      <LayoutPos TypeId=""5"" Group=""20"" Id=""40"" />
      <LayoutPos TypeId=""5"" Group=""21"" Id=""41"" />
      <LayoutPos TypeId=""5"" Group=""21"" Id=""42"" />
      <LayoutPos TypeId=""5"" Group=""22"" Id=""43"" />
      <LayoutPos TypeId=""5"" Group=""22"" Id=""44"" />
      <LayoutPos TypeId=""5"" Group=""23"" Id=""45"" />
      <LayoutPos TypeId=""5"" Group=""23"" Id=""46"" />
      <LayoutPos TypeId=""5"" Group=""24"" Id=""47"" />
      <LayoutPos TypeId=""5"" Group=""24"" Id=""48"" />
      <LayoutPos TypeId=""5"" Group=""25"" Id=""49"" />
      <LayoutPos TypeId=""5"" Group=""25"" Id=""50"" />
      <LayoutPos TypeId=""5"" Group=""26"" Id=""51"" />
      <LayoutPos TypeId=""5"" Group=""26"" Id=""52"" />
      <LayoutPos TypeId=""5"" Group=""27"" Id=""53"" />
      <LayoutPos TypeId=""5"" Group=""27"" Id=""54"" />
      <LayoutPos TypeId=""5"" Group=""28"" Id=""55"" />
      <LayoutPos TypeId=""5"" Group=""28"" Id=""56"" />
      <LayoutPos TypeId=""5"" Group=""29"" Id=""57"" />
      <LayoutPos TypeId=""5"" Group=""29"" Id=""58"" />
      <LayoutPos TypeId=""5"" Group=""30"" Id=""59"" />
      <LayoutPos TypeId=""5"" Group=""30"" Id=""60"" />
      <LayoutPos TypeId=""5"" Group=""31"" Id=""61"" />
      <LayoutPos TypeId=""5"" Group=""31"" Id=""62"" />
      <LayoutPos TypeId=""5"" Group=""32"" Id=""63"" />
      <LayoutPos TypeId=""5"" Group=""32"" Id=""64"" />
      <LayoutPos TypeId=""5"" Group=""33"" Id=""65"" />
      <LayoutPos TypeId=""5"" Group=""33"" Id=""66"" />
      <LayoutPos TypeId=""5"" Group=""34"" Id=""67"" />
      <LayoutPos TypeId=""5"" Group=""34"" Id=""68"" />
      <LayoutPos TypeId=""5"" Group=""35"" Id=""69"" />
      <LayoutPos TypeId=""5"" Group=""35"" Id=""70"" />
      <LayoutPos TypeId=""5"" Group=""36"" Id=""71"" />
      <LayoutPos TypeId=""5"" Group=""36"" Id=""72"" />
      <LayoutPos TypeId=""5"" Group=""37"" Id=""73"" />
      <LayoutPos TypeId=""5"" Group=""37"" Id=""74"" />
      <LayoutPos TypeId=""5"" Group=""38"" Id=""75"" />
      <LayoutPos TypeId=""5"" Group=""38"" Id=""76"" />
      <LayoutPos TypeId=""5"" Group=""39"" Id=""77"" />
      <LayoutPos TypeId=""5"" Group=""39"" Id=""78"" />
      <LayoutPos TypeId=""5"" Group=""40"" Id=""79"" />
      <LayoutPos TypeId=""5"" Group=""40"" Id=""80"" />
      <LayoutPos TypeId=""5"" Group=""41"" Id=""81"" />
      <LayoutPos TypeId=""5"" Group=""41"" Id=""82"" />
      <LayoutPos TypeId=""5"" Group=""42"" Id=""83"" />
      <LayoutPos TypeId=""5"" Group=""42"" Id=""84"" />
      <LayoutPos TypeId=""5"" Group=""43"" Id=""85"" />
      <LayoutPos TypeId=""5"" Group=""43"" Id=""86"" />
      <LayoutPos TypeId=""5"" Group=""44"" Id=""87"" />
      <LayoutPos TypeId=""5"" Group=""44"" Id=""88"" />
      <LayoutPos TypeId=""5"" Group=""45"" Id=""89"" />
      <LayoutPos TypeId=""5"" Group=""45"" Id=""90"" />
      <LayoutPos TypeId=""5"" Group=""46"" Id=""91"" />
      <LayoutPos TypeId=""5"" Group=""46"" Id=""92"" />
      <LayoutPos TypeId=""5"" Group=""47"" Id=""93"" />
      <LayoutPos TypeId=""5"" Group=""47"" Id=""94"" />
      <LayoutPos TypeId=""5"" Group=""48"" Id=""95"" />
      <LayoutPos TypeId=""5"" Group=""48"" Id=""96"" />
    </LayoutPositions>
  </SingleLayoutLight>
</UserLayout>";

        public string xmlMergedTypesValid = @"<?xml version=""1.0"" encoding=""utf-8""?>
<UserLayout>
  <LayoutDimensions>
    <Width>4</Width>
    <Height>3</Height>
  </LayoutDimensions>
  <SampleTypes>
    <SampleType Id=""1"" Name=""Unused"" Colour=""White"" />
    <SampleType Id=""110"" Name=""Unknown 1:10"" Colour=""#00c000""/>
	<SampleType Id=""111"" Name=""Unknown 1:200"" Colour=""#c0ffc0""/>
  </SampleTypes>
  <SingleLayoutLight NumPositions=""12"">
    <LayoutPositions>
      <LayoutPos TypeId=""110"" Group=""1"" Id=""1"" />
      <LayoutPos TypeId=""110"" Group=""1"" Id=""2"" />
      <LayoutPos TypeId=""111"" Group=""2"" Id=""3"" />
      <LayoutPos TypeId=""111"" Group=""2"" Id=""4"" />
      <LayoutPos TypeId=""111"" Group=""3"" Id=""5"" />
      <LayoutPos TypeId=""111"" Group=""3"" Id=""6"" />
      <LayoutPos TypeId=""111"" Group=""4"" Id=""7"" />
      <LayoutPos TypeId=""111"" Group=""4"" Id=""8"" />
      <LayoutPos TypeId=""111"" Group=""5"" Id=""9"" />
      <LayoutPos TypeId=""110"" Group=""5"" Id=""10"" />
      <LayoutPos TypeId=""110"" Group=""6"" Id=""11"" />
      <LayoutPos TypeId=""110"" Group=""6"" Id=""12"" />
    </LayoutPositions>
  </SingleLayoutLight>
</UserLayout>";

        public string xmlMergedTypesValidNotContiguous = @"<?xml version=""1.0"" encoding=""utf-8""?>
<UserLayout>
  <LayoutDimensions>
    <Width>4</Width>
    <Height>3</Height>
  </LayoutDimensions>
  <SampleTypes>
    <SampleType Id=""1"" Name=""Unused"" Colour=""White"" />
    <SampleType Id=""110"" Name=""Unknown 1:10"" Colour=""#00c000""/>
	<SampleType Id=""111"" Name=""Unknown 1:200"" Colour=""#c0ffc0""/>
  </SampleTypes>
  <SingleLayoutLight NumPositions=""12"">
    <LayoutPositions>
      <LayoutPos TypeId=""110"" Group=""1"" Id=""1"" />
      <LayoutPos TypeId=""110"" Group=""1"" Id=""2"" />
      <LayoutPos TypeId=""111"" Group=""2"" Id=""3"" />
      <LayoutPos TypeId=""111"" Group=""2"" Id=""4"" />
      <LayoutPos TypeId=""111"" Group=""3"" Id=""5"" />
      <LayoutPos TypeId=""111"" Group=""3"" Id=""6"" />
      <LayoutPos TypeId=""111"" Group=""4"" Id=""7"" />
      <LayoutPos TypeId=""111"" Group=""4"" Id=""8"" />
      <LayoutPos TypeId=""111"" Group=""8"" Id=""9"" />
      <LayoutPos TypeId=""110"" Group=""5"" Id=""10"" />
      <LayoutPos TypeId=""110"" Group=""6"" Id=""11"" />
      <LayoutPos TypeId=""110"" Group=""6"" Id=""12"" />
    </LayoutPositions>
  </SingleLayoutLight>
</UserLayout>";

        public string xmlMergedTypesValidNotStartingFromOne = @"<?xml version=""1.0"" encoding=""utf-8""?>
<UserLayout>
  <LayoutDimensions>
    <Width>4</Width>
    <Height>3</Height>
  </LayoutDimensions>
  <SampleTypes>
    <SampleType Id=""1"" Name=""Unused"" Colour=""White"" />
    <SampleType Id=""110"" Name=""Unknown 1:10"" Colour=""#00c000""/>
	<SampleType Id=""111"" Name=""Unknown 1:200"" Colour=""#c0ffc0""/>
  </SampleTypes>
  <SingleLayoutLight NumPositions=""12"">
    <LayoutPositions>
      <LayoutPos TypeId=""110"" Group=""4"" Id=""1"" />
      <LayoutPos TypeId=""110"" Group=""4"" Id=""2"" />
      <LayoutPos TypeId=""111"" Group=""2"" Id=""3"" />
      <LayoutPos TypeId=""111"" Group=""2"" Id=""4"" />
      <LayoutPos TypeId=""111"" Group=""3"" Id=""5"" />
      <LayoutPos TypeId=""111"" Group=""3"" Id=""6"" />
      <LayoutPos TypeId=""111"" Group=""4"" Id=""7"" />
      <LayoutPos TypeId=""111"" Group=""4"" Id=""8"" />
      <LayoutPos TypeId=""111"" Group=""5"" Id=""9"" />
      <LayoutPos TypeId=""110"" Group=""5"" Id=""10"" />
      <LayoutPos TypeId=""110"" Group=""6"" Id=""11"" />
      <LayoutPos TypeId=""110"" Group=""6"" Id=""12"" />
    </LayoutPositions>
  </SingleLayoutLight>
</UserLayout>";

        public string xmlMergedTypesOneTypeUsed = @"<?xml version=""1.0"" encoding=""utf-8""?>
<UserLayout>
  <LayoutDimensions>
    <Width>4</Width>
    <Height>3</Height>
  </LayoutDimensions>
  <SampleTypes>
    <SampleType Id=""1"" Name=""Unused"" Colour=""White"" />
    <SampleType Id=""110"" Name=""Unknown 1:10"" Colour=""#00c000""/>
	<SampleType Id=""111"" Name=""Unknown 1:200"" Colour=""#c0ffc0""/>
  </SampleTypes>
  <SingleLayoutLight NumPositions=""12"">
    <LayoutPositions>
      <LayoutPos TypeId=""110"" Group=""1"" Id=""1"" />
      <LayoutPos TypeId=""110"" Group=""1"" Id=""2"" />
      <LayoutPos TypeId=""1"" Group=""1"" Id=""3"" />
      <LayoutPos TypeId=""1"" Group=""1"" Id=""4"" />
      <LayoutPos TypeId=""1"" Group=""1"" Id=""5"" />
      <LayoutPos TypeId=""1"" Group=""1"" Id=""6"" />
      <LayoutPos TypeId=""1"" Group=""1"" Id=""7"" />
      <LayoutPos TypeId=""1"" Group=""1"" Id=""8"" />
      <LayoutPos TypeId=""1"" Group=""1"" Id=""9"" />
      <LayoutPos TypeId=""1"" Group=""1"" Id=""10"" />
      <LayoutPos TypeId=""1"" Group=""1"" Id=""11"" />
      <LayoutPos TypeId=""1"" Group=""1"" Id=""12"" />
    </LayoutPositions>
  </SingleLayoutLight>
</UserLayout>";

        public string xmlMergedTypesOneNonZeroTypeUsed = @"<?xml version=""1.0"" encoding=""utf-8""?>
<UserLayout>
  <LayoutDimensions>
    <Width>4</Width>
    <Height>3</Height>
  </LayoutDimensions>
  <SampleTypes>
    <SampleType Id=""1"" Name=""Unused"" Colour=""White"" />
    <SampleType Id=""110"" Name=""Unknown 1:10"" Colour=""#00c000""/>
	<SampleType Id=""111"" Name=""Unknown 1:200"" Colour=""#c0ffc0""/>
  </SampleTypes>
  <SingleLayoutLight NumPositions=""12"">
    <LayoutPositions>
      <LayoutPos TypeId=""110"" Group=""10"" Id=""1"" />
      <LayoutPos TypeId=""110"" Group=""10"" Id=""2"" />
      <LayoutPos TypeId=""1"" Group=""1"" Id=""3"" />
      <LayoutPos TypeId=""1"" Group=""1"" Id=""4"" />
      <LayoutPos TypeId=""1"" Group=""1"" Id=""5"" />
      <LayoutPos TypeId=""1"" Group=""1"" Id=""6"" />
      <LayoutPos TypeId=""1"" Group=""1"" Id=""7"" />
      <LayoutPos TypeId=""1"" Group=""1"" Id=""8"" />
      <LayoutPos TypeId=""1"" Group=""1"" Id=""9"" />
      <LayoutPos TypeId=""1"" Group=""1"" Id=""10"" />
      <LayoutPos TypeId=""1"" Group=""1"" Id=""11"" />
      <LayoutPos TypeId=""1"" Group=""1"" Id=""12"" />
    </LayoutPositions>
  </SingleLayoutLight>
</UserLayout>";
        #endregion
    }
}
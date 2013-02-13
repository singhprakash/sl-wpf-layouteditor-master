using System.Collections.Generic;
using System.Linq;
using DazdaqCommon;
using Layout;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LayoutEditor.UnitTests
{
    /// <summary>
    ///This is a test class for LayoutAnalysisTest and is intended
    ///to contain all LayoutAnalysisTest Unit Tests
    ///</summary>
    [TestClass()]
    public class LayoutAnalysisTest : XmlStringsUserLayout
    {
        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        [ExpectedException(typeof(Layout.LayoutAnalysis.InvalidLayoutException))]
        [TestMethod]
        public void TestInvalidNotContiguous1()
        {
            LayoutAnalysis layoutAnalysis = CreateLayoutAnalysis(xmlInvalidNotContiguous1, 12, 8);
        }

        [ExpectedException(typeof(Layout.LayoutAnalysis.InvalidLayoutException))]
        [TestMethod]
        public void TestInvalidNoUnknown1()
        {
            LayoutAnalysis layoutAnalysis = CreateLayoutAnalysis(xmlInvalidNoUnknown1, 12, 8);
        }

        [TestMethod]
        public void TestMixedReplicates1()
        {
            LayoutAnalysis layoutAnalysis = CreateLayoutAnalysis(xmlMixedReplicates1, 12, 8);
            Assert.IsFalse(layoutAnalysis.GetReplicatesConsistent(5));
        }

        [TestMethod]
        public void TestMixedReplicates2()
        {
            LayoutAnalysis layoutAnalysis = CreateLayoutAnalysis(xmlMixedReplicates2, 12, 8);
            Assert.IsFalse(layoutAnalysis.GetReplicatesConsistent(5));
        }

        [TestMethod]
        public void TestMixedReplicates3()
        {
            LayoutAnalysis layoutAnalysis = CreateLayoutAnalysis(xmlMixedReplicates3, 12, 8);
            Assert.IsFalse(layoutAnalysis.GetReplicatesConsistent(5));

            Assert.AreEqual(3, layoutAnalysis.GetNumReplicates(5, 6));
            Assert.AreEqual(1, layoutAnalysis.GetNumReplicates(5, 7));
            Assert.AreEqual(2, layoutAnalysis.GetNumReplicates(5, 48));
        }

        [TestMethod]
        public void TestAll_Unknowns__Across_()
        {
            LayoutAnalysis layoutAnalysis = CreateLayoutAnalysis(xmlAll_Unknowns__Across_, 12, 8);

            Assert.AreEqual(0, layoutAnalysis.GetNumWellsOfType(1));   // Unused wells
            Assert.AreEqual(0, layoutAnalysis.GetNumWellsOfType(2));   // Standard wells
            Assert.AreEqual(0, layoutAnalysis.GetNumWellsOfType(3));   // Blank wells
            Assert.AreEqual(96, layoutAnalysis.GetNumWellsOfType(5));   // Unknown wells

            Assert.AreEqual(0, layoutAnalysis.GetNumGroupsOfType(2));   // Standard groups
            Assert.AreEqual(0, layoutAnalysis.GetNumGroupsOfType(3));   // Blank groups
            Assert.AreEqual(96, layoutAnalysis.GetNumGroupsOfType(5));   // Unknown groups

            Assert.AreEqual(1, layoutAnalysis.GetNumReplicates(5, 1));    // 1 replicate in Unknown1 
            Assert.AreEqual(1, layoutAnalysis.GetNumReplicates(5, 96));   // 1 replicate in Unknown96

            Assert.AreEqual(0, layoutAnalysis.GetNumReplicates(2, 1));   // 0 replicates in Standard1
            Assert.AreEqual(0, layoutAnalysis.GetNumReplicates(2, 97));   // 0 replicates in Standard97

            Assert.IsTrue(layoutAnalysis.GetReplicatesConsistent(5));
        }

        [TestMethod]
        public void TestAll_Unknowns__Down_()
        {
            LayoutAnalysis layoutAnalysis = CreateLayoutAnalysis(xmlAll_Unknowns__Down_, 12, 8);

            Assert.AreEqual(0, layoutAnalysis.GetNumWellsOfType(1));   // Unused wells
            Assert.AreEqual(0, layoutAnalysis.GetNumWellsOfType(2));   // Standard wells
            Assert.AreEqual(0, layoutAnalysis.GetNumWellsOfType(3));   // Blank wells
            Assert.AreEqual(96, layoutAnalysis.GetNumWellsOfType(5));   // Unknown wells

            Assert.AreEqual(0, layoutAnalysis.GetNumGroupsOfType(2));   // Standard groups
            Assert.AreEqual(0, layoutAnalysis.GetNumGroupsOfType(3));   // Blank groups
            Assert.AreEqual(96, layoutAnalysis.GetNumGroupsOfType(5));   // Unknown groups

            Assert.IsTrue(layoutAnalysis.GetReplicatesConsistent(5));
        }

        [TestMethod]
        public void TestExample_1_1_Blanks_()
        {
            LayoutAnalysis layoutAnalysis = CreateLayoutAnalysis(xmlExample_1_1_Blanks_, 12, 8);

            Assert.AreEqual(48, layoutAnalysis.GetNumWellsOfType(1));   // Unused wells
            Assert.AreEqual(0, layoutAnalysis.GetNumWellsOfType(2));   // Standard wells
            Assert.AreEqual(24, layoutAnalysis.GetNumWellsOfType(3));   // Blank wells
            Assert.AreEqual(24, layoutAnalysis.GetNumWellsOfType(5));   // Unknown wells

            Assert.AreEqual(0, layoutAnalysis.GetNumGroupsOfType(2));   // Standard groups
            Assert.AreEqual(12, layoutAnalysis.GetNumGroupsOfType(3));   // Blank groups
            Assert.AreEqual(12, layoutAnalysis.GetNumGroupsOfType(5));   // Unknown groups

            Assert.IsTrue(layoutAnalysis.GetReplicatesConsistent(5));
            Assert.IsTrue(layoutAnalysis.GetReplicatesConsistent(3));

        }

        [TestMethod]
        public void TestExample_12x8__1_()
        {
            LayoutAnalysis layoutAnalysis = CreateLayoutAnalysis(xmlExample_12x8__1_, 12, 8);

            Assert.AreEqual(0, layoutAnalysis.GetNumWellsOfType(1));   // Unused wells
            Assert.AreEqual(12, layoutAnalysis.GetNumWellsOfType(2));   // Standard wells
            Assert.AreEqual(2, layoutAnalysis.GetNumWellsOfType(3));   // Blank wells
            Assert.AreEqual(82, layoutAnalysis.GetNumWellsOfType(5));   // Unknown wells

            Assert.IsTrue(layoutAnalysis.GetReplicatesConsistent(2));
            Assert.IsTrue(layoutAnalysis.GetReplicatesConsistent(3));
            Assert.IsTrue(layoutAnalysis.GetReplicatesConsistent(5));
        }

        [TestMethod]
        public void TestExample_12x8__2_()
        {
            LayoutAnalysis layoutAnalysis = CreateLayoutAnalysis(xmlExample_12x8__2_, 12, 8);

            Assert.AreEqual(0, layoutAnalysis.GetNumWellsOfType(1));   // Unused wells
            Assert.AreEqual(14, layoutAnalysis.GetNumWellsOfType(2));   // Standard wells
            Assert.AreEqual(2, layoutAnalysis.GetNumWellsOfType(3));   // Blank wells
            Assert.AreEqual(80, layoutAnalysis.GetNumWellsOfType(5));   // Unknown wells

            Assert.IsTrue(layoutAnalysis.GetReplicatesConsistent(2));
            Assert.IsTrue(layoutAnalysis.GetReplicatesConsistent(3));
            Assert.IsTrue(layoutAnalysis.GetReplicatesConsistent(5));
        }

        [TestMethod]
        public void TestExample_384()
        {
            LayoutAnalysis layoutAnalysis = CreateLayoutAnalysis(xmlExample_384, 24, 16);

            Assert.AreEqual(0, layoutAnalysis.GetNumWellsOfType(1));   // Unused wells
            Assert.AreEqual(6 * 3, layoutAnalysis.GetNumWellsOfType(2));   // Standard wells
            Assert.AreEqual(1 * 3, layoutAnalysis.GetNumWellsOfType(3));   // Blank wells
            Assert.AreEqual(2 * 3, layoutAnalysis.GetNumWellsOfType(4));   // Control wells
            Assert.AreEqual(119 * 3, layoutAnalysis.GetNumWellsOfType(5));   // Unknown wells

            Assert.AreEqual(6, layoutAnalysis.GetNumGroupsOfType(2));   // Standard groups
            Assert.AreEqual(1, layoutAnalysis.GetNumGroupsOfType(3));   // Blank groups
            Assert.AreEqual(2, layoutAnalysis.GetNumGroupsOfType(4));   // Control groups
            Assert.AreEqual(119, layoutAnalysis.GetNumGroupsOfType(5));   // Unknown groups

            Assert.IsTrue(layoutAnalysis.GetReplicatesConsistent(2));
            Assert.IsTrue(layoutAnalysis.GetReplicatesConsistent(3));
            Assert.IsTrue(layoutAnalysis.GetReplicatesConsistent(4));
            Assert.IsTrue(layoutAnalysis.GetReplicatesConsistent(5));

        }

        [TestMethod]
        public void TestExample_3x2()
        {
            LayoutAnalysis layoutAnalysis = CreateLayoutAnalysis(xmlExample_3x2, 3, 2);

            Assert.AreEqual(0, layoutAnalysis.GetNumWellsOfType(1));   // Unused wells
            Assert.AreEqual(0, layoutAnalysis.GetNumWellsOfType(2));   // Standard wells
            Assert.AreEqual(0, layoutAnalysis.GetNumWellsOfType(3));   // Blank wells
            Assert.AreEqual(1, layoutAnalysis.GetNumWellsOfType(4));   // Control groups
            Assert.AreEqual(5, layoutAnalysis.GetNumWellsOfType(5));   // Unknown wells

            Assert.AreEqual(1, layoutAnalysis.GetNumGroupsOfType(4));   // Control groups
            Assert.AreEqual(5, layoutAnalysis.GetNumGroupsOfType(5));   // Unknown wells

            Assert.IsTrue(layoutAnalysis.GetReplicatesConsistent(4));
            Assert.IsTrue(layoutAnalysis.GetReplicatesConsistent(5));

        }

        [TestMethod]
        public void TestExample_4x3()
        {
            LayoutAnalysis layoutAnalysis = CreateLayoutAnalysis(xmlExample_4x3, 4, 3);

            Assert.AreEqual(0, layoutAnalysis.GetNumWellsOfType(1));   // Unused wells
            Assert.AreEqual(0, layoutAnalysis.GetNumWellsOfType(2));   // Standard wells
            Assert.AreEqual(1, layoutAnalysis.GetNumWellsOfType(3));   // Blank wells
            Assert.AreEqual(11, layoutAnalysis.GetNumWellsOfType(5));   // Unknown wells

            Assert.AreEqual(1, layoutAnalysis.GetNumGroupsOfType(3));   // Blank groups
            Assert.AreEqual(0, layoutAnalysis.GetNumGroupsOfType(4));   // Control groups
            Assert.AreEqual(11, layoutAnalysis.GetNumGroupsOfType(5));   // Unknown wells

            Assert.IsTrue(layoutAnalysis.GetReplicatesConsistent(3));
            Assert.IsTrue(layoutAnalysis.GetReplicatesConsistent(5));

        }

        [TestMethod]
        public void TestExample_Competitive__1_()
        {
            LayoutAnalysis layoutAnalysis = CreateLayoutAnalysis(xmlExample_Competitive__1_, 12, 8);

            Assert.AreEqual(0, layoutAnalysis.GetNumWellsOfType(1));   // Unused wells
            Assert.AreEqual(0, layoutAnalysis.GetNumWellsOfType(2));   // Standard wells
            Assert.AreEqual(0, layoutAnalysis.GetNumWellsOfType(3));   // Blank wells
            Assert.AreEqual(96, layoutAnalysis.GetNumWellsOfType(5));   // Unknown wells

            Assert.AreEqual(16, layoutAnalysis.GetNumGroupsOfType(5));   // Unknown groups

            Assert.AreEqual(6, layoutAnalysis.GetNumReplicates(5, 1));   // Unknown1 replicates 
            Assert.AreEqual(6, layoutAnalysis.GetNumReplicates(5, 5));   // Unknown5 replicates 
            Assert.AreEqual(6, layoutAnalysis.GetNumReplicates(5, 16));   // Unknown16 replicates 

            Assert.IsTrue(layoutAnalysis.GetReplicatesConsistent(5));


        }

        [TestMethod]
        public void TestExample_Competitive__2_()
        {
            LayoutAnalysis layoutAnalysis = CreateLayoutAnalysis(xmlExample_Competitive__2_, 12, 8);

            Assert.AreEqual(21, layoutAnalysis.GetNumWellsOfType(1));   // Unused wells
            Assert.AreEqual(0, layoutAnalysis.GetNumWellsOfType(2));   // Standard wells
            Assert.AreEqual(3, layoutAnalysis.GetNumWellsOfType(3));   // Blank wells
            Assert.AreEqual(9 * 8, layoutAnalysis.GetNumWellsOfType(5));   // Unknown wells

            Assert.AreEqual(9, layoutAnalysis.GetNumGroupsOfType(5));   // Unknown groups

            Assert.AreEqual(8, layoutAnalysis.GetNumReplicates(5, 1));   // Unknown1 replicates 
            Assert.AreEqual(8, layoutAnalysis.GetNumReplicates(5, 5));   // Unknown5 replicates 
            Assert.AreEqual(8, layoutAnalysis.GetNumReplicates(5, 9));   // Unknown9 replicates 

            Assert.AreEqual(3, layoutAnalysis.GetNumReplicates(3, 1));   // Blank1 replicates 

            Assert.IsTrue(layoutAnalysis.GetReplicatesConsistent(5));
            Assert.IsTrue(layoutAnalysis.GetReplicatesConsistent(3));
        }

        [TestMethod]
        public void TestExample_Corner_Blanks()
        {
            LayoutAnalysis layoutAnalysis = CreateLayoutAnalysis(xmlExample_Corner_Blanks, 12, 8);

            Assert.AreEqual(96 - 64, layoutAnalysis.GetNumWellsOfType(1));   // Unused wells
            Assert.AreEqual(0, layoutAnalysis.GetNumWellsOfType(2));   // Standard wells
            Assert.AreEqual(4, layoutAnalysis.GetNumWellsOfType(3));   // Blank wells
            Assert.AreEqual(60, layoutAnalysis.GetNumWellsOfType(5));   // Unknown wells

            Assert.IsTrue(layoutAnalysis.GetReplicatesConsistent(5));
            Assert.IsTrue(layoutAnalysis.GetReplicatesConsistent(3));
        }

        [TestMethod]
        public void TestExample_Multi_Plate()
        {
            LayoutAnalysis layoutAnalysis = CreateLayoutAnalysis(xmlExample_Multi_Plate, 12, 8);

            // Currently only processes first plate
            Assert.AreEqual(0, layoutAnalysis.GetNumWellsOfType(1));   // Unused wells
            Assert.AreEqual(14, layoutAnalysis.GetNumWellsOfType(2));   // Standard wells
            Assert.AreEqual(2, layoutAnalysis.GetNumWellsOfType(3));   // Blank wells
            Assert.AreEqual(80, layoutAnalysis.GetNumWellsOfType(5));   // Unknown wells
        }

        [TestMethod]
        public void TestExample_Multi_Standards()
        {
            LayoutAnalysis layoutAnalysis = CreateLayoutAnalysis(xmlExample_Multi_Standards, 12, 8);

            Assert.AreEqual(52, layoutAnalysis.GetNumWellsOfType(1));   // Unused wells
            Assert.AreEqual(14, layoutAnalysis.GetNumWellsOfType(12));   // StandardX wells
            Assert.AreEqual(14, layoutAnalysis.GetNumWellsOfType(13));   // StandardY wells
            Assert.AreEqual(4, layoutAnalysis.GetNumWellsOfType(3));   // Blank wells
            Assert.AreEqual(12, layoutAnalysis.GetNumWellsOfType(4));   // Control wells
            Assert.AreEqual(0, layoutAnalysis.GetNumWellsOfType(5));   // Unknown wells

            Assert.AreEqual(7, layoutAnalysis.GetNumGroupsOfType(12));   // StandardX wells
            Assert.AreEqual(7, layoutAnalysis.GetNumGroupsOfType(13));   // StandardY wells
            Assert.AreEqual(2, layoutAnalysis.GetNumGroupsOfType(3));   // Blank wells
            Assert.AreEqual(6, layoutAnalysis.GetNumGroupsOfType(4));   // Control wells
            Assert.AreEqual(0, layoutAnalysis.GetNumGroupsOfType(5));   // Unknown wells

            Assert.AreEqual(2, layoutAnalysis.GetNumReplicates(3, 1));   // Blank1 replicates 
            Assert.AreEqual(2, layoutAnalysis.GetNumReplicates(3, 2));   // Blank2 replicates 
            Assert.AreEqual(0, layoutAnalysis.GetNumReplicates(3, 3));   // Blank3 replicates 

            Assert.IsTrue(layoutAnalysis.GetReplicatesConsistent(12));
            Assert.IsTrue(layoutAnalysis.GetReplicatesConsistent(13));
        }

        [TestMethod]
        public void TestExample_Qualitative__1_()
        {
            LayoutAnalysis layoutAnalysis = CreateLayoutAnalysis(xmlExample_Qualitative__1_, 12, 8);

            Assert.AreEqual(96 - 52, layoutAnalysis.GetNumWellsOfType(1));   // Unused wells
            Assert.AreEqual(0, layoutAnalysis.GetNumWellsOfType(2));   // Standard wells
            Assert.AreEqual(2, layoutAnalysis.GetNumWellsOfType(3));   // Blank wells
            Assert.AreEqual(48, layoutAnalysis.GetNumWellsOfType(5));   // Unknown wells

            Assert.AreEqual(24, layoutAnalysis.GetNumGroupsOfType(5));   // Unknown groups
            Assert.AreEqual(1, layoutAnalysis.GetNumGroupsOfType(3));   // Blank groups
            Assert.AreEqual(1, layoutAnalysis.GetNumGroupsOfType(4));   // Control groups

            Assert.AreEqual(2, layoutAnalysis.GetNumReplicates(5, 1));   // Unknown1 replicates 
            Assert.AreEqual(2, layoutAnalysis.GetNumReplicates(5, 5));   // Unknown5 replicates 
            Assert.AreEqual(2, layoutAnalysis.GetNumReplicates(5, 9));   // Unknown9 replicates 

            Assert.AreEqual(2, layoutAnalysis.GetNumReplicates(3, 1));   // Blank1 replicates 

            Assert.IsTrue(layoutAnalysis.GetReplicatesConsistent(5));
            Assert.IsTrue(layoutAnalysis.GetReplicatesConsistent(3));
        }

        [TestMethod]
        public void TestExample_Quantitative__1_()
        {
            LayoutAnalysis layoutAnalysis = CreateLayoutAnalysis(xmlExample_Quantitative__1_, 12, 8);

            Assert.AreEqual(0, layoutAnalysis.GetNumWellsOfType(1));   // Unused wells
            Assert.AreEqual(14, layoutAnalysis.GetNumWellsOfType(2));   // Standard wells
            Assert.AreEqual(2, layoutAnalysis.GetNumWellsOfType(3));   // Blank wells
            Assert.AreEqual(16, layoutAnalysis.GetNumWellsOfType(4));   // Control wells

            Assert.IsTrue(layoutAnalysis.GetReplicatesConsistent(2));
            Assert.IsTrue(layoutAnalysis.GetReplicatesConsistent(3));
            Assert.IsTrue(layoutAnalysis.GetReplicatesConsistent(4));
            Assert.IsTrue(layoutAnalysis.GetReplicatesConsistent(5));

        }

        [TestMethod]
        public void TestMultiplate_with_advanced_sequence()
        {
            LayoutAnalysis layoutAnalysis = CreateLayoutAnalysis(xmlMultiplate_with_advanced_sequence, 12, 8);

            // Currently only processes first plate
            Assert.AreEqual(0, layoutAnalysis.GetNumWellsOfType(1));   // Unused wells
            Assert.AreEqual(12, layoutAnalysis.GetNumWellsOfType(2));   // Standard wells
            Assert.AreEqual(2, layoutAnalysis.GetNumWellsOfType(3));   // Blank wells
            Assert.AreEqual(82, layoutAnalysis.GetNumWellsOfType(5));   // Unknown wells
        }

        [TestMethod]
        public void TestUnknowns__Duplicates_Across_()
        {
            LayoutAnalysis layoutAnalysis = CreateLayoutAnalysis(xmlUnknowns__Duplicates_Across_, 12, 8);

            Assert.AreEqual(layoutAnalysis.GetNumWellsOfType(1), 0);   // Unused wells
            Assert.AreEqual(layoutAnalysis.GetNumWellsOfType(2), 0);   // Standard wells
            Assert.AreEqual(layoutAnalysis.GetNumWellsOfType(3), 0);   // Blank wells
            Assert.AreEqual(layoutAnalysis.GetNumWellsOfType(5), 96);   // Unknown wells
        }

        [TestMethod]
        public void TestUnknowns__Duplicates_Down_()
        {
            LayoutAnalysis layoutAnalysis = CreateLayoutAnalysis(xmlUnknowns__Duplicates_Down_, 12, 8);

            Assert.AreEqual(layoutAnalysis.GetNumWellsOfType(1), 0);   // Unused wells
            Assert.AreEqual(layoutAnalysis.GetNumWellsOfType(2), 0);   // Standard wells
            Assert.AreEqual(layoutAnalysis.GetNumWellsOfType(3), 0);   // Blank wells
            Assert.AreEqual(layoutAnalysis.GetNumWellsOfType(5), 96);   // Unknown wells
        }


        public LayoutAnalysis CreateLayoutAnalysis(string xml, int width, int height, IEnumerable<int> mergedTypesSingle = null)
        {
            UserLayout userLayout = XmlHelpers.DeserializeXmlString(xml, typeof(UserLayout)) as UserLayout;
            SingleLayoutEditor sle = new SingleLayoutEditor(userLayout.SingleLayoutLight, width, height);

            Assert.AreEqual(width * height, sle.LayoutPositions.Count);

            return new LayoutAnalysis(sle.LayoutPositions, userLayout.SampleTypes, true, mergedTypesSingle);
        }

        [TestMethod]
        public void TestMethod12x81Blank()
        {
            LayoutAnalysis layoutAnalysis = CreateLayoutAnalysis(xml1Blank12x8, 12, 8);

            Assert.AreEqual(95, layoutAnalysis.GetNumWellsOfType(1));   // Unused wells
            Assert.AreEqual(1, layoutAnalysis.GetNumWellsOfType(3));   // Blank wells
            Assert.AreEqual(0, layoutAnalysis.GetNumWellsOfType(5));   // Unknown wells
        }

        [TestMethod]
        public void TestMethod12x8Example1()
        {
            LayoutAnalysis layoutAnalysis = CreateLayoutAnalysis(xmlExample12x8, 12, 8);

            Assert.AreEqual(0, layoutAnalysis.GetNumWellsOfType(1));   // Unused wells
            Assert.AreEqual(12, layoutAnalysis.GetNumWellsOfType(2));   // Standard wells
            Assert.AreEqual(2, layoutAnalysis.GetNumWellsOfType(3));   // Blank wells
            Assert.AreEqual(82, layoutAnalysis.GetNumWellsOfType(5));   // Unknown wells
        }

        [TestMethod]
        public void TestMethodxmlAll_Unknowns_Across()
        {
            LayoutAnalysis layoutAnalysis = CreateLayoutAnalysis(xmlAll_Unknowns_Across, 12, 8);

            Assert.AreEqual(0, layoutAnalysis.GetNumWellsOfType(1));   // Unused wells
            Assert.AreEqual(0, layoutAnalysis.GetNumWellsOfType(2));   // Standard wells
            Assert.AreEqual(0, layoutAnalysis.GetNumWellsOfType(3));   // Blank wells
            Assert.AreEqual(96, layoutAnalysis.GetNumWellsOfType(5));   // Unknown wells
        }



        [TestMethod]
        public void TestMethod12x8Unused()
        {
            LayoutAnalysis layoutAnalysis;

            layoutAnalysis = new LayoutAnalysis(CreateLayout12x8Unused(), CreateSampleTypesUnused(), true);
            Assert.AreEqual(96, layoutAnalysis.GetNumWellsOfType(1));   // 96 unused wells

            layoutAnalysis = new LayoutAnalysis(CreateLayout12x8Unused(), CreateSampleTypesTypical(), true);
            Assert.AreEqual(96, layoutAnalysis.GetNumWellsOfType(1));   // 96 unused wells
            Assert.AreEqual(0, layoutAnalysis.GetNumWellsOfType(2));
            Assert.AreEqual(0, layoutAnalysis.GetNumWellsOfType(3));
            Assert.AreEqual(0, layoutAnalysis.GetNumWellsOfType(4));
            Assert.AreEqual(0, layoutAnalysis.GetNumWellsOfType(5));

            layoutAnalysis = new LayoutAnalysis(CreateLayout12x8Unused(), CreateSampleTypesUnusedStandardBlankUnknown(), true);
            Assert.AreEqual(96, layoutAnalysis.GetNumWellsOfType(1));   // 96 unused wells
            Assert.AreEqual(0, layoutAnalysis.GetNumWellsOfType(2));
            Assert.AreEqual(0, layoutAnalysis.GetNumWellsOfType(3));
            Assert.AreEqual(0, layoutAnalysis.GetNumWellsOfType(5));
        }

        private List<SampleType> CreateSampleTypesUnused()
        {
            List<SampleType> sampleTypes = new List<SampleType>();
            sampleTypes.Add(new SampleType() { Colour = "White", Id = 1, Name = "Unused" });
            return sampleTypes;
        }

        private List<SampleType> CreateSampleTypesTypical()
        {
            List<SampleType> sampleTypes = new List<SampleType>();
            sampleTypes.Add(new SampleType() { Colour = "White", Id = 1, Name = "Unused" });
            sampleTypes.Add(new SampleType() { Colour = "Red", Id = 2, Name = "Standard" });
            sampleTypes.Add(new SampleType() { Colour = "Yellow", Id = 3, Name = "Blank" });
            sampleTypes.Add(new SampleType() { Colour = "Aqua", Id = 4, Name = "Control" });
            sampleTypes.Add(new SampleType() { Colour = "Lime", Id = 5, Name = "Unknown" });

            return sampleTypes;

        }
        private List<SampleType> CreateSampleTypesUnusedStandardBlankUnknown()
        {
            List<SampleType> sampleTypes = new List<SampleType>();
            sampleTypes.Add(new SampleType() { Colour = "White", Id = 1, Name = "Unused" });
            sampleTypes.Add(new SampleType() { Colour = "Red", Id = 2, Name = "Standard" });
            sampleTypes.Add(new SampleType() { Colour = "Yellow", Id = 3, Name = "Blank" });
            sampleTypes.Add(new SampleType() { Colour = "Lime", Id = 5, Name = "Unknown" });

            return sampleTypes;
        }

        private List<LayoutPosEditor> CreateLayout12x8Unused()
        {
            SingleLayoutEditor sle = new SingleLayoutEditor(12, 8);
            return sle.LayoutPositions;
        }

        [TestMethod]
        [ExpectedException(typeof(Layout.LayoutAnalysis.InvalidLayoutException))]
        public void TestMergedTypes0()
        {
            // No merged types specified so error
            LayoutAnalysis layoutAnalysis = CreateLayoutAnalysis(xmlMergedTypesValid, 4, 3);
        }

        [TestMethod]
        public void TestMergedTypes1()
        {
            var mergedTypes = new int[] { 110, 111 }.AsEnumerable();
            LayoutAnalysis layoutAnalysis = CreateLayoutAnalysis(xmlMergedTypesValid, 4, 3, mergedTypes);
        }

        [TestMethod]
        [ExpectedException(typeof(Layout.LayoutAnalysis.InvalidLayoutException))]
        public void TestMergedTypes2()
        {
            var mergedTypes = new int[] { 110, 111 }.AsEnumerable();
            LayoutAnalysis layoutAnalysis = CreateLayoutAnalysis(xmlMergedTypesValidNotContiguous, 4, 3, mergedTypes);
        }

        [TestMethod]
        [ExpectedException(typeof(Layout.LayoutAnalysis.InvalidLayoutException))]
        public void TestMergedTypes3()
        {
            var mergedTypes = new int[] { 110, 111 }.AsEnumerable();
            LayoutAnalysis layoutAnalysis = CreateLayoutAnalysis(xmlMergedTypesValidNotStartingFromOne, 4, 3, mergedTypes);
        }

        [TestMethod]
        public void TestMergedTypes4()
        {
            var mergedTypes = new int[] { 110, 111 }.AsEnumerable();
            LayoutAnalysis layoutAnalysis = CreateLayoutAnalysis(xmlMergedTypesOneTypeUsed, 4, 3, mergedTypes);
        }

        [TestMethod]
        [ExpectedException(typeof(Layout.LayoutAnalysis.InvalidLayoutException))]
        public void TestMergedTypes5()
        {
            var mergedTypes = new int[] { 110, 111 }.AsEnumerable();
            LayoutAnalysis layoutAnalysis = CreateLayoutAnalysis(xmlMergedTypesOneNonZeroTypeUsed, 4, 3, mergedTypes);
        }
    }
}
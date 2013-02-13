using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Layout;
using System.Diagnostics;
using DazdaqCommon;

namespace LayoutEditor.UnitTests
{
    /// <summary>
    ///This is a test class for LayoutValidationTest and is intended
    ///to contain all LayoutValidationTest Unit Tests
    ///</summary>
    [TestClass()]
    public class LayoutValidationTest
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

        XmlStringsLayoutEditorPopulation xmlStringsLayoutEditorPopulation = new XmlStringsLayoutEditorPopulation();
        XmlStringsUserLayout xmlStringsUserLayout = new XmlStringsUserLayout();

        public LayoutEditorPopulation CreateLayoutEditorPopulation(string xml)
        {
            return XmlHelpers.DeserializeXmlString(xml, typeof(LayoutEditorPopulation)) as LayoutEditorPopulation;
        }

        public SingleLayoutEditor CreateSingleLayoutEditor(string xml, int width, int height)
        {
            UserLayout userLayout = XmlHelpers.DeserializeXmlString(xml, typeof(UserLayout)) as UserLayout;
            return new SingleLayoutEditor(userLayout.SingleLayoutLight, width, height);
        }

        public Rule CreateRule(string xml)
        {
            return XmlHelpers.DeserializeXmlString(xml, typeof(Rule)) as Rule;
        }

        private List<ValidationError> CallValidate(string xmlStringLayoutEditorPopulation, string xmlStringSingleLayoutEditor, int width, int height)
        {
            LayoutEditorPopulation lpe = CreateLayoutEditorPopulation(xmlStringLayoutEditorPopulation);
            SingleLayoutEditor sle = CreateSingleLayoutEditor(xmlStringSingleLayoutEditor, width, height);
            return LayoutValidation.Validate(sle, lpe);
        }


        /// <summary>
        ///A test for Validate
        ///</summary>
        [TestMethod()]
        public void ValidateTestInvalidLayouts()
        {
            List<ValidationError> actual;

            // Test inconsistent SampleTypes
            // It is important that the SampleTypes used in the UserLayout correspond to those defined in the LayoutEditorPopulation
            // i.e. if a layout references sample types which are not in the LayoutEditorPopulation this is an error
            // In this case they do not, i.e. the LPE does not list typeId 3 which is used in xmlExample_12x8__1_
            actual = CallValidate(xmlStringsLayoutEditorPopulation.xml12x8AnyUnknowns7Standards, xmlStringsUserLayout.xmlExample_12x8__1_, 12, 8);
            Assert.AreEqual(1, actual.Count);
            Assert.AreEqual(ValidationError.ErrorType.InvalidLayout, actual[0].Type);
            Assert.AreEqual("A layout position references a typeId 3 which is not listed in the SampleTypes. ", actual[0].Message);

            // Test invalid dimensions, in this case the SLE has a different dimension to the LPE
            actual = CallValidate(xmlStringsLayoutEditorPopulation.xml12x8AnyUnknowns7Standards, xmlStringsUserLayout.xmlExample_3x2, 3, 2);
            Assert.AreEqual(1, actual.Count);
            Assert.AreEqual(ValidationError.ErrorType.InvalidLayout, actual[0].Type);
            Assert.AreEqual("The layout dimensions are not correct, they should be 12x8. ", actual[0].Message);

            // Test non contiguous ordering (Standard3 missing)
            actual = CallValidate(xmlStringsLayoutEditorPopulation.xml12x8AnyUnknowns7Standards1Control1Blank, xmlStringsUserLayout.xmlInvalidNotContiguous1, 12, 8);
            Assert.AreEqual(1, actual.Count);
            Assert.AreEqual(ValidationError.ErrorType.InvalidLayout, actual[0].Type);
            Assert.AreEqual("The group numbering is not contiguous in type Standard, there is no Standard3. ", actual[0].Message);

            // Test non contiguous ordering (no Unknown 1)
            actual = CallValidate(xmlStringsLayoutEditorPopulation.xml12x8AnyUnknowns7Standards1Control1Blank, xmlStringsUserLayout.xmlInvalidNoUnknown1, 12, 8);
            Assert.AreEqual(1, actual.Count);
            Assert.AreEqual(ValidationError.ErrorType.InvalidLayout, actual[0].Type);
            Assert.AreEqual("The group numbering for type Unknown does not start at 1. ", actual[0].Message);
        }

        /// <summary>
        ///A test for Validate
        ///</summary>
        [TestMethod()]
        public void ValidateTestAllPass()
        {
            List<ValidationError> actual;

            // Tests a variety of rules on Unknowns 
            actual = CallValidate(xmlStringsLayoutEditorPopulation.xml12x8Unknowns32RuleTests, xmlStringsUserLayout.xmlExample_Quantitative__1_, 12, 8);
            Assert.AreEqual(0, actual.Count);

            // Tests replicate rules on Unknowns on a layout with no unknowns
            // In this case there are no unknowns so replicate rules should be ignored
            actual = CallValidate(xmlStringsLayoutEditorPopulation.xml12x8UnknownDuplicateRules, xmlStringsUserLayout.xmlExample_Multi_Standards, 12, 8);
            Assert.AreEqual(0, actual.Count);

            // Tests replicate rules on Unknowns on a layout with all unknowns in duplicate
            actual = CallValidate(xmlStringsLayoutEditorPopulation.xml12x8UnknownDuplicateRules, xmlStringsUserLayout.xmlExample_Quantitative__1_, 12, 8);
            Assert.AreEqual(0, actual.Count);

            // Test specific rules
            LayoutAnalysis la;
            la = SetupLayoutAnalysisForTestRule(xmlStringsUserLayout.xmlExample12x8, 12, 8);

            // There are no typeID 4 in this layout, but NumReplicates is 2, this is OK because no specific number of groups is required
            actual = TestRule(la, @"<Rule TypeId=""4"" NumReplicates=""2""/>");
            Assert.AreEqual(0, actual.Count);

            // As above with AllGroupsSameReplicates
            actual = TestRule(la, @"<Rule TypeId=""4"" NumReplicates=""2"" AllGroupsSameReplicates=""true""/>");
            Assert.AreEqual(0, actual.Count);

            // As above with AllGroupsSameReplicates
            actual = TestRule(la, @"<Rule TypeId=""4"" AllGroupsSameReplicates=""true""/>");
            Assert.AreEqual(0, actual.Count);

            // There are no typeID 4 in this layout, but MinNumReplicates is specified, this is OK because no specific number of groups is required
            actual = TestRule(la, @"<Rule TypeId=""4"" MinNumReplicates=""3""/>");
            Assert.AreEqual(0, actual.Count);

            // There are no typeID 4 in this layout, but MaxNumReplicates is specified, this is OK because no specific number of groups is required
            actual = TestRule(la, @"<Rule TypeId=""4"" MaxNumReplicates=""3""/>");
            Assert.AreEqual(0, actual.Count);

            // Standards in duplicate
            actual = TestRule(la, @"<Rule TypeId=""2"" AllGroupsSameReplicates=""true""/>");
            Assert.AreEqual(0, actual.Count);

            // Standards in duplicate
            actual = TestRule(la, @"<Rule TypeId=""2"" MinNumReplicates=""1"" AllGroupsSameReplicates=""true""/>");
            Assert.AreEqual(0, actual.Count);

            // Standards in duplicate
            actual = TestRule(la, @"<Rule TypeId=""2"" MaxNumReplicates=""3"" AllGroupsSameReplicates=""true""/>");
            Assert.AreEqual(0, actual.Count);

            actual = TestRule(la, @"<Rule TypeId=""5"" AllGroupsSameReplicates=""false""/>");
            Assert.AreEqual(0, actual.Count);

            // NumReplicates is set but AllGroupsSameReplicates is set to false, in this case AllGroupsSameReplicates is treated as true
            actual = TestRule(la, @"<Rule TypeId=""5"" NumReplicates=""2"" AllGroupsSameReplicates=""false""/>");
            Assert.AreEqual(0, actual.Count);

            // Test specific rules - xmlExample_1_1_Blanks_
            la = SetupLayoutAnalysisForTestRule(xmlStringsUserLayout.xmlExample_1_1_Blanks_, 12, 8);

            // Equal number of blanks and unknowns
            actual = TestRule(la, @"<Rule TypeId=""3"" MatchGroupsInTypeId=""5""/>");
            Assert.AreEqual(0, actual.Count);
        }

        /// <summary>
        ///A test for Validate
        ///</summary>
        [TestMethod()]
        public void ValidateTestFailedRules()
        {
            List<ValidationError> actual;

            // Tests a variety of rules on Unknowns 
            // Tests that they all come back in a list
            actual = CallValidate(xmlStringsLayoutEditorPopulation.xml3x2UnknownDuplicateRules, xmlStringsUserLayout.xmlExample_3x2_InconsistentReps, 3, 2);
            Assert.AreEqual(5, actual.Count);
            Assert.AreEqual("All Unknown groups should have 2 replicates, Unknown1 has 3 replicate(s). ", actual[0].Message);
            Assert.AreEqual("All Unknown groups should have 2 replicates, Unknown1 has 3 replicate(s). ", actual[1].Message);
            Assert.AreEqual("There should be at least 2 replicate(s) in each Unknown group, Unknown3 has 1 replicate(s). ", actual[2].Message);
            Assert.AreEqual("There should be no more than 2 replicate(s) in each Unknown group, Unknown1 has 3 replicate(s). ", actual[3].Message);
            Assert.AreEqual("All Unknown groups should have the same number of replicates, this is not the case. ", actual[4].Message);

            LayoutAnalysis la;
            // Test individual rules - xmlExample_3x2_InconsistentReps
            la = SetupLayoutAnalysisForTestRule(xmlStringsUserLayout.xmlExample_3x2_InconsistentReps, 3, 2);
            actual = TestRule(la, @"<Rule TypeId=""5"" NumReplicates=""2""/>");
            AssertSingleValidationErrorRule("All Unknown groups should have 2 replicates, Unknown1 has 3 replicate(s). ", actual);

            actual = TestRule(la, @"<Rule TypeId=""5"" NumGroups=""1""/>");
            AssertSingleValidationErrorRule("There should be 1 Unknown group(s), there are 3 Unknown group(s). ", actual);

            actual = TestRule(la, @"<Rule TypeId=""5"" NumGroups=""16""/>");
            AssertSingleValidationErrorRule("There should be 16 Unknown group(s), there are 3 Unknown group(s). ", actual);

            actual = TestRule(la, @"<Rule TypeId=""5"" MinNumGroups=""16""/>");
            AssertSingleValidationErrorRule("There should be at least 16 Unknown group(s), there are 3 Unknown group(s). ", actual);

            actual = TestRule(la, @"<Rule TypeId=""5"" MaxNumGroups=""1""/>");
            AssertSingleValidationErrorRule("There should be no more than 1 Unknown group(s), there are 3 Unknown group(s). ", actual);

            actual = TestRule(la, @"<Rule TypeId=""5"" MinNumGroups=""1"" MaxNumGroups=""2""/>");
            AssertSingleValidationErrorRule("There should be no more than 2 Unknown group(s), there are 3 Unknown group(s). ", actual);

            actual = TestRule(la, @"<Rule TypeId=""5"" AllGroupsSameReplicates=""true""/>");
            AssertSingleValidationErrorRule("All Unknown groups should have the same number of replicates, this is not the case. ", actual);

            // Test individual rules - xmlExample12x8
            la = SetupLayoutAnalysisForTestRule(xmlStringsUserLayout.xmlExample12x8, 12, 8);
            actual = TestRule(la, @"<Rule TypeId=""5"" NumGroups=""1""/>");
            AssertSingleValidationErrorRule("There should be 1 Unknown group(s), there are 41 Unknown group(s). ", actual);

            actual = TestRule(la, @"<Rule TypeId=""3"" NumGroups=""12""/>");
            AssertSingleValidationErrorRule("There should be 12 Blank group(s), there are 1 Blank group(s). ", actual);

            actual = TestRule(la, @"<Rule TypeId=""3"" MinNumReplicates=""3""/>");
            AssertSingleValidationErrorRule("There should be at least 3 replicate(s) in each Blank group, there are 2 replicates in all Blank group(s). ", actual);

            actual = TestRule(la, @"<Rule TypeId=""3"" MaxNumReplicates=""1""/>");
            AssertSingleValidationErrorRule("There should be no more than 1 replicate(s) in each Blank group, there are 2 replicates in all Blank group(s). ", actual);

            actual = TestRule(la, @"<Rule TypeId=""3"" NumReplicates=""1""/>");
            AssertSingleValidationErrorRule("There should be 1 replicate(s) in each Blank group, each Blank group has 2 replicate(s). ", actual);

            actual = TestRule(la, @"<Rule TypeId=""3"" MatchGroupsInTypeId=""5""/>");
            AssertSingleValidationErrorRule("The number of Blank groups (1) should equal the number of Unknown groups (41). ", actual);

        }


        private static void AssertSingleValidationErrorRule(string expectedMessage, List<ValidationError> actual)
        {
            Assert.AreEqual(1, actual.Count, string.Format("1 error message was expected {0} were found", actual.Count));
            Assert.AreEqual(expectedMessage, actual[0].Message, "The error message was not as expected");
            Assert.AreEqual(ValidationError.ErrorType.RuleFailed, actual[0].Type, "The error type was not RuleFailed as expected");
        }

        private List<ValidationError> TestRule(LayoutAnalysis layoutAnalysis, string xmlRule)
        {
            Rule rule = CreateRule(xmlRule);
            List<ValidationError> errors = new List<ValidationError>();
            LayoutValidation.TestRule(rule, layoutAnalysis, errors);
            return errors;
        }

        // Tests a single rule, to do this the various necessary objects are setup, 
        // including a UserLayout (which has SampleTypes included)
        // A Validate is first called to ensure there are no InvalidLayout errors first
        // Then the specific rule is tested
        private List<ValidationError> ValidateTestSingleRule(string xmlUserLayout, int width, int height, string xmlRule)
        {
            LayoutAnalysis layoutAnalysis = SetupLayoutAnalysisForTestRule(xmlUserLayout, width, height);
            return TestRule(layoutAnalysis, xmlRule);
        }

        private LayoutAnalysis SetupLayoutAnalysisForTestRule(string xmlUserLayout, int width, int height)
        {
            UserLayout userLayout = XmlHelpers.DeserializeXmlString(xmlUserLayout, typeof(UserLayout)) as UserLayout;
            SingleLayoutEditor sle = new SingleLayoutEditor(userLayout.SingleLayoutLight, width, height);

            // Create an LPE from the LayoutEditorPopulation template string - note this has no rules
            // and the dimensions are not setup.  However it should contain all SampleTypes used in all tests
            LayoutEditorPopulation lpe = CreateLayoutEditorPopulation(xmlStringsLayoutEditorPopulation.xmlAllTypesNoDimensionsOrRules);
            lpe.Width = width;
            lpe.Height = height;

            Debug.Assert(lpe.Rules.Count == 0);

            LayoutAnalysis la = new LayoutAnalysis(sle.LayoutPositions, lpe.SampleTypes, true);

            List<ValidationError> errors = LayoutValidation.Validate(sle, lpe);
            Assert.AreEqual(0, errors.Count, "The userlayout generated an InvalidLayout error");

            return new LayoutAnalysis(sle.LayoutPositions, lpe.SampleTypes, true);
        }
    }
}
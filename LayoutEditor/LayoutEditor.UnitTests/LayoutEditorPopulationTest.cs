using System;
using System.Collections.Generic;
using DazdaqCommon;
using Layout;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LayoutEditor.UnitTests
{
    /// <summary>
    ///This is a test class for LayoutEditorPopulationTest and is intended
    ///to contain all LayoutEditorPopulationTest Unit Tests
    ///</summary>
    [TestClass()]
    public class LayoutEditorPopulationTest
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


        public LayoutEditorPopulation CreateLayoutEditorPopulation(string xml)
        {
            return XmlHelpers.DeserializeXmlString(xml, typeof(LayoutEditorPopulation)) as LayoutEditorPopulation;
        }

        XmlStringsLayoutEditorPopulation xmlStringsLayoutEditorPopulation = new XmlStringsLayoutEditorPopulation();

        /// <summary>
        ///A test for GetErasableTypes
        ///</summary>
        [TestMethod()]
        [ExpectedException(typeof(InvalidOperationException))]
        public void GetErasableTypesTest1()
        {
            LayoutEditorPopulation target = CreateLayoutEditorPopulation(xmlStringsLayoutEditorPopulation.xml12x8AnyUnknowns7Standards);
            List<int> actual = target.GetErasableTypes();
        }

        /// <summary>
        ///A test for GetErasableTypes
        ///</summary>
        [TestMethod()]
        public void GetErasableTypesTest2()
        {
            LayoutEditorPopulation target;
            List<int> actual;

            target = CreateLayoutEditorPopulation(xmlStringsLayoutEditorPopulation.xml12x8AnyUnknowns7Standards1ControlEraseOnly);
            actual = target.GetErasableTypes();
            Assert.AreEqual(2, actual.Count);
            Assert.AreEqual(5, actual[0]);
            Assert.AreEqual(4, actual[1]);

            target = CreateLayoutEditorPopulation(xmlStringsLayoutEditorPopulation.xml12x8EraseOnlyUnknowns);
            actual = target.GetErasableTypes();
            Assert.AreEqual(1, actual.Count);
            Assert.AreEqual(5, actual[0]);
        }


        /// <summary>
        ///A test for GetMatchedTypes
        ///</summary>
        [TestMethod()]
        public void GetMatchedTypesTest1()
        {
            List<List<int>> result;
            LayoutEditorPopulation target;

            target = CreateLayoutEditorPopulation(xmlStringsLayoutEditorPopulation.xml12x8AnyUnknowns7Standards1ControlEraseOnly);
            result = target.GetMatchedTypes();
            // No matched types, so there should be an empty list of matched types
            Assert.AreEqual(0, result.Count);
        }

        /// <summary>
        ///A test for GetMatchedTypes
        ///</summary>
        [TestMethod()]
        public void GetMatchedTypesTest2()
        {
            List<List<int>> result;
            LayoutEditorPopulation target;

            target = CreateLayoutEditorPopulation(xmlStringsLayoutEditorPopulation.xml3x2MatchedTypes1);
            result = target.GetMatchedTypes();
            Assert.AreEqual(1, result.Count);       // Should contain 1 list of matched types, 5+3
            Assert.AreEqual(2, result[0].Count);
            Assert.IsTrue(result[0].Contains(5));
            Assert.IsTrue(result[0].Contains(3));

            target = CreateLayoutEditorPopulation(xmlStringsLayoutEditorPopulation.xml3x2MatchedTypes2);
            result = target.GetMatchedTypes();
            Assert.AreEqual(1, result.Count);       // Should contain 1 list of matched types, 5+3
            Assert.AreEqual(2, result[0].Count);
            Assert.IsTrue(result[0].Contains(5));
            Assert.IsTrue(result[0].Contains(3));

            target = CreateLayoutEditorPopulation(xmlStringsLayoutEditorPopulation.xml3x2MatchedTypes3);
            result = target.GetMatchedTypes();
            Assert.AreEqual(2, result.Count);       // Should contain 2 list of matched types, 5+3, 2+12+13

            Assert.AreEqual(2, result[0].Count);
            Assert.IsTrue(result[0].Contains(5));
            Assert.IsTrue(result[0].Contains(3));

            Assert.AreEqual(3, result[1].Count);
            Assert.IsTrue(result[1].Contains(2));
            Assert.IsTrue(result[1].Contains(12));
            Assert.IsTrue(result[1].Contains(13));

            target = CreateLayoutEditorPopulation(xmlStringsLayoutEditorPopulation.xml3x2MatchedTypes4);
            result = target.GetMatchedTypes();
            Assert.AreEqual(2, result.Count);       // Should contain 2 list of matched types, 5+3, 2+12+13

            Assert.AreEqual(2, result[0].Count);
            Assert.IsTrue(result[0].Contains(5));
            Assert.IsTrue(result[0].Contains(3));

            Assert.AreEqual(3, result[1].Count);
            Assert.IsTrue(result[1].Contains(2));
            Assert.IsTrue(result[1].Contains(12));
            Assert.IsTrue(result[1].Contains(13));

            target = CreateLayoutEditorPopulation(xmlStringsLayoutEditorPopulation.xml3x2MatchedTypes5);
            result = target.GetMatchedTypes();
            Assert.AreEqual(2, result.Count);       // Should contain 2 list of matched types, 5+3, 2+12+13

            Assert.AreEqual(2, result[1].Count);
            Assert.IsTrue(result[1].Contains(5));
            Assert.IsTrue(result[1].Contains(3));

            Assert.AreEqual(3, result[0].Count);
            Assert.IsTrue(result[0].Contains(2));
            Assert.IsTrue(result[0].Contains(12));
            Assert.IsTrue(result[0].Contains(13));

            target = CreateLayoutEditorPopulation(xmlStringsLayoutEditorPopulation.xml3x2MatchedTypes6);
            result = target.GetMatchedTypes();
            Assert.AreEqual(1, result.Count);       // Should contain 1 list of all types

            Assert.AreEqual(6, result[0].Count);
            Assert.IsTrue(result[0].Contains(2));
            Assert.IsTrue(result[0].Contains(3));
            Assert.IsTrue(result[0].Contains(4));
            Assert.IsTrue(result[0].Contains(5));
            Assert.IsTrue(result[0].Contains(12));
            Assert.IsTrue(result[0].Contains(13));

            target = CreateLayoutEditorPopulation(xmlStringsLayoutEditorPopulation.xml3x2MatchedTypes7);
            result = target.GetMatchedTypes();
            Assert.AreEqual(1, result.Count);       // Should contain 1 list of all types

            Assert.AreEqual(6, result[0].Count);
            Assert.IsTrue(result[0].Contains(2));
            Assert.IsTrue(result[0].Contains(3));
            Assert.IsTrue(result[0].Contains(4));
            Assert.IsTrue(result[0].Contains(5));
            Assert.IsTrue(result[0].Contains(12));
            Assert.IsTrue(result[0].Contains(13));

            // Currently an odd ordered sequence such as this not supported
            target = CreateLayoutEditorPopulation(xmlStringsLayoutEditorPopulation.xml3x2MatchedTypesNotSupported);
            result = target.GetMatchedTypes();


            // The following should not cause an exception
            target = CreateLayoutEditorPopulation(xmlStringsLayoutEditorPopulation.xml3x2MatchedTypesValid);
            result = target.GetMatchedTypes();
        }

        /// <summary>
        ///A test for GetMatchedTypes
        ///</summary>
        [ExpectedException(typeof(ArgumentException))]
        [TestMethod()]
        public void GetMatchedTypesTest3()
        {
            List<List<int>> result;
            LayoutEditorPopulation target;

            target = CreateLayoutEditorPopulation(xmlStringsLayoutEditorPopulation.xml3x2MatchedTypesInvalid);
            result = target.GetMatchedTypes();
        }

        /// <summary>
        ///A test for GetTypeMatches
        ///</summary>
        [TestMethod()]
        public void GetTypeMatchesTest()
        {
            List<int> result;
            LayoutEditorPopulation target;

            target = CreateLayoutEditorPopulation(xmlStringsLayoutEditorPopulation.xml3x2MatchedTypes1);
            result = target.GetTypeMatches(3);  // 3+5 are matched
            Assert.AreEqual(2, result.Count);
            Assert.IsTrue(result.Contains(3));
            Assert.IsTrue(result.Contains(5));

            result = target.GetTypeMatches(5);  // 3+5 are matched
            Assert.AreEqual(2, result.Count);
            Assert.IsTrue(result.Contains(3));
            Assert.IsTrue(result.Contains(5));

            result = target.GetTypeMatches(2);  // No matches for 2
            Assert.IsNull(result);
        }
    }
}
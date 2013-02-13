using System.Windows.Media;
using Layout;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LayoutEditor.UnitTests
{
    /// <summary>
    ///This is a test class for LayoutPosEditorTest and is intended
    ///to contain all LayoutPosEditorTest Unit Tests
    ///</summary>
    [TestClass()]
    public class LayoutPosEditorTest
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

        /// <summary>
        ///A test for Clone
        ///</summary>
        [TestMethod()]
        public void CloneTest()
        {
            LayoutPos layoutPos = new LayoutPos() { Group = 1, TypeId = 2, Id = 3 };
            Color colour = new Color() { R = 255, G = 0, B = 128 };
            string hoverText = "hover text";
            LayoutPosEditor original = new LayoutPosEditor(layoutPos, colour, hoverText); // TODO: Initialize to an appropriate value
            LayoutPosEditor copy = original.Clone();
            Assert.AreEqual(copy.LayoutPos.Id, original.LayoutPos.Id);
            Assert.AreEqual(copy.LayoutPos.Group, original.LayoutPos.Group);
            Assert.AreEqual(copy.LayoutPos.TypeId, original.LayoutPos.TypeId);

            Assert.AreEqual(copy.Colour, original.Colour);
            Assert.AreEqual(copy.HoverText, original.HoverText);

            Assert.IsTrue(copy.IsVisuallyEqual(original));
        }
    }
}
using DazdaqCommon;
using Layout;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LayoutEditor.UnitTests
{
    /// <summary>
    ///This is a test class for UserLayoutTest and is intended
    ///to contain all UserLayoutTest Unit Tests
    ///</summary>
    [TestClass()]
    public class UserLayoutTest
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
            UserLayout source = new UserLayout() { LayoutDimensions = new LayoutDimensions(12, 8) };
            UserLayout copy = source.Clone();

            Assert.AreEqual(copy.LayoutDimensions.Width, 12);
            Assert.AreEqual(copy.LayoutDimensions.Height, 8);
            Assert.AreEqual(copy.LayoutDimensions.NumPositions, 96);
        }

        /// <summary>
        ///A test for InitFromCSVStringAllPositions
        ///</summary>
        [TestMethod()]
        public void InitFromCSVStringAllPositionsTest()
        {
            UserLayout userLayout = new UserLayout(); // TODO: Initialize to an appropriate value
            string s = string.Empty; // TODO: Initialize to an appropriate value
            userLayout.InitFromCSVStringAllPositions("2,1,2,1,5,2,5,2,5,10,5,10,5,18,5,18,5,26,5,26,5,34,5,34,2,2,2,2,5,3,5,3,5,11,5,11,5,19,5,19,5,27,5,27,5,35,5,35,2,3,2,3,5,4,5,4,5,12,5,12,5,20,5,20,5,28,5,28,5,36,5,36,2,4,2,4,5,5,5,5,5,13,5,13,5,21,5,21,5,29,5,29,5,37,5,37,2,5,2,5,5,6,5,6,5,14,5,14,5,22,5,22,5,30,5,30,5,38,5,38,3,1,3,1,5,7,5,7,5,15,5,15,5,23,5,23,5,31,5,31,5,39,5,39,4,1,4,1,5,8,5,8,5,16,5,16,5,24,5,24,5,32,5,32,5,40,5,40,5,1,5,1,5,9,5,9,5,17,5,17,5,25,5,25,5,33,5,33,5,41,5,41", 12, 8);

            string filePath = FileHelpers.CreateTempFilename();
            XmlHelpers.Serialize(filePath, typeof(UserLayout), userLayout);
            //userLayout
        }
    }
}
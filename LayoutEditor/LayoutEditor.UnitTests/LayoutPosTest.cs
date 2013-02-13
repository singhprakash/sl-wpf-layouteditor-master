using Layout;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LayoutEditor.UnitTests
{
    /// <summary>
    ///This is a test class for LayoutPosTest and is intended
    ///to contain all LayoutPosTest Unit Tests
    ///</summary>
    [TestClass()]
    public class LayoutPosTest
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
            LayoutPos original = new LayoutPos() { Group = 1, TypeId = 2, Id = 3 };
            LayoutPos clone = original.Clone();
            Assert.AreEqual(original.Group, 1);
            Assert.AreEqual(original.TypeId, 2);
            Assert.AreEqual(original.Id, 3);
            Assert.AreEqual(original.Group, clone.Group);
            Assert.AreEqual(original.TypeId, clone.TypeId);
            Assert.AreEqual(original.Id, clone.Id);
        }
        /// <summary>
        ///A test for IsUsed
        ///</summary>
        [TestMethod()]
        public void IsUsedTest()
        {
            LayoutPos target = new LayoutPos() { Group = 1, TypeId = 2, Id = 3 };
            Assert.IsTrue(target.IsUsed);

            LayoutPos target2 = new LayoutPos() { Group = 1, TypeId = 1, Id = 3 };
            Assert.IsFalse(target2.IsUsed);
        }
    }
}
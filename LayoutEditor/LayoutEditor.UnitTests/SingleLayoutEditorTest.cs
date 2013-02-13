using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Media;
using Layout;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LayoutEditor.UnitTests
{
    /// <summary>
    ///This is a test class for SingleLayoutEditorTest and is intended
    ///to contain all SingleLayoutEditorTest Unit Tests
    ///</summary>
    [TestClass()]
    public class SingleLayoutEditorTest
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
        ///A test for CheckPositionInRangeOneBased
        ///</summary>
        ///
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [TestMethod()]
        public void CheckPositionInRangeOneBasedTest()
        {
            int width = 12;
            int height = 8;
            SingleLayoutEditor target = new SingleLayoutEditor(width, height);
            int pos = 0;
            target.CheckPositionInRangeOneBased(pos);
        }



        /// <summary>
        ///A test for CheckPositionInRangeZeroBased
        ///</summary>
        [TestMethod()]
        public void CheckPositionInRangeZeroBasedTest()
        {
            int width = 12;
            int height = 8;
            SingleLayoutEditor target = new SingleLayoutEditor(width, height);
            int pos = 0;
            target.CheckPositionInRangeZeroBased(pos);
        }

        /// <summary>
        ///A test for CheckPositionInRangeZeroBased
        ///</summary>
        [TestMethod()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void CheckPositionInRangeZeroBasedTest1()
        {
            int width = 12;
            int height = 8;
            SingleLayoutEditor target = new SingleLayoutEditor(width, height);
            int pos = 96;
            target.CheckPositionInRangeZeroBased(pos);
        }


        /// <summary>
        ///A test for GetRowFromPos
        ///</summary>
        [TestMethod()]
        public void GetRowFromPosTest()
        {
            SingleLayoutEditor target = new SingleLayoutEditor(12, 8);
            Assert.AreEqual(1, target.GetRowFromPos(1));
            Assert.AreEqual(1, target.GetRowFromPos(12));
            Assert.AreEqual(2, target.GetRowFromPos(13));
            Assert.AreEqual(8, target.GetRowFromPos(96));
            Assert.AreEqual(8, target.GetRowFromPos(89));
        }
        /// <summary>
        ///A test for GetColFromPos
        ///</summary>
        [TestMethod()]
        public void GetColFromPosTest()
        {
            SingleLayoutEditor target = new SingleLayoutEditor(12, 8);
            Assert.AreEqual(1, target.GetColFromPos(1));
            Assert.AreEqual(12, target.GetColFromPos(12));
            Assert.AreEqual(1, target.GetColFromPos(13));
            Assert.AreEqual(12, target.GetColFromPos(96));
            Assert.AreEqual(5, target.GetColFromPos(89));
        }
        void TestLayoutPosEditorEnumerable(int[] expectedArray, IEnumerable<LayoutPosEditor> actual)
        {
            // Make an array of the LayoutPos ids
            int[] resultArray = (from x in actual select x.LayoutPos.Id).ToArray();
            Assert.AreEqual(expectedArray.Length, resultArray.Length, string.Format("The number of items is not as expected. Expected Number: {0}, Actual Numer: {1}, Exptected: {2}, Result: {3}", expectedArray.Length, resultArray.Length, expectedArray, resultArray));
            for (int i = 0; i < expectedArray.Length; i++)
            {
                Assert.AreEqual(expectedArray[i], resultArray[i], string.Format("Position {0} (0 based) was not as expected. Expected: {1} Actual: {2}", i, expectedArray[i], resultArray[i]));
            }
        }
        /// <summary>
        ///A test for Clone
        ///</summary>
        [TestMethod()]
        public void CloneTest()
        {
            SingleLayoutEditor original = new SingleLayoutEditor(12, 8);

            original[0].Colour = Colors.Green;
            original[0].HoverText = "Hover Text";
            original[0].LayoutPos.Id = 1;
            original[0].LayoutPos.TypeId = 2;
            original[0].LayoutPos.Group = 3;

            original[95].Colour = Colors.Goldenrod;
            original[95].HoverText = "More Hover Text";
            original[95].LayoutPos.Id = 3;
            original[95].LayoutPos.TypeId = 12;
            original[95].LayoutPos.Group = 23;


            SingleLayoutEditor copy = original.Clone();

            Assert.AreEqual(original.NumPositions, copy.NumPositions);
            for (int i = 0; i < original.NumPositions; i++)
            {
                Assert.AreEqual(original[i].Colour, copy[i].Colour);
                Assert.AreEqual(original[i].HoverText, copy[i].HoverText);
                Assert.AreEqual(original[i].LayoutPos.Id, copy[i].LayoutPos.Id);
                Assert.AreEqual(original[i].LayoutPos.TypeId, copy[i].LayoutPos.TypeId);
                Assert.AreEqual(original[i].LayoutPos.Group, copy[i].LayoutPos.Group);
            }
        }

        /// <summary>
        ///A test for GetEnumerableAcross
        ///</summary>
        [TestMethod()]
        public void GetEnumerableAcrossTest()
        {
            SingleLayoutEditor target = new SingleLayoutEditor(12, 8);

            TestLayoutPosEditorEnumerable(new int[] { 1, 2 }, target.GetEnumerableAcross(1, 2));
            TestLayoutPosEditorEnumerable(new int[] { 2, 1 }, target.GetEnumerableAcross(2, 1));

            TestLayoutPosEditorEnumerable(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44, 45, 46, 47, 48, 49, 50, 51, 52, 53, 54, 55, 56, 57, 58, 59, 60, 61, 62, 63, 64, 65, 66, 67, 68, 69, 70, 71, 72, 73, 74, 75, 76, 77, 78, 79, 80, 81, 82, 83, 84, 85, 86, 87, 88, 89, 90, 91, 92, 93, 94, 95, 96 },
                            target.GetEnumerableAcross(1, 96));

            TestLayoutPosEditorEnumerable(new int[] { 96, 95, 94, 93, 92, 91, 90, 89, 88, 87, 86, 85, 84, 83, 82, 81, 80, 79, 78, 77, 76, 75, 74, 73, 72, 71, 70, 69, 68, 67, 66, 65, 64, 63, 62, 61, 60, 59, 58, 57, 56, 55, 54, 53, 52, 51, 50, 49, 48, 47, 46, 45, 44, 43, 42, 41, 40, 39, 38, 37, 36, 35, 34, 33, 32, 31, 30, 29, 28, 27, 26, 25, 24, 23, 22, 21, 20, 19, 18, 17, 16, 15, 14, 13, 12, 11, 10, 9, 8, 7, 6, 5, 4, 3, 2, 1 },
                            target.GetEnumerableAcross(96, 1));

        }

        /// <summary>
        ///A test for OrderingAcross
        ///</summary>
        [TestMethod()]
        public void OrderingAcrossTest()
        {
            SingleLayoutEditor target = new SingleLayoutEditor(12, 8);

            TestLayoutPosEditorEnumerable(
                        new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44, 45, 46, 47, 48, 49, 50, 51, 52, 53, 54, 55, 56, 57, 58, 59, 60, 61, 62, 63, 64, 65, 66, 67, 68, 69, 70, 71, 72, 73, 74, 75, 76, 77, 78, 79, 80, 81, 82, 83, 84, 85, 86, 87, 88, 89, 90, 91, 92, 93, 94, 95, 96 },
                        target.OrderingAcross);

            TestLayoutPosEditorEnumerable(
                        new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44, 45, 46, 47, 48, 49, 50, 51, 52, 53, 54, 55, 56, 57, 58, 59, 60, 61, 62, 63, 64, 65, 66, 67, 68, 69, 70, 71, 72, 73, 74, 75, 76, 77, 78, 79, 80, 81, 82, 83, 84, 85, 86, 87, 88, 89, 90, 91, 92, 93, 94, 95, 96 },
                        target.OrderingAcross);

        }


        /// <summary>
        ///A test for OrderingDown
        ///</summary>
        [TestMethod()]
        public void OrderingDownTest()
        {
            SingleLayoutEditor target = new SingleLayoutEditor(2, 2);
            TestLayoutPosEditorEnumerable(new int[] { 1, 3, 2, 4 }, target.OrderingDown);

            SingleLayoutEditor target2 = new SingleLayoutEditor(3, 2);
            TestLayoutPosEditorEnumerable(new int[] { 1, 4, 2, 5, 3, 6 }, target2.OrderingDown);

            SingleLayoutEditor target3 = new SingleLayoutEditor(2, 3);
            TestLayoutPosEditorEnumerable(new int[] { 1, 3, 5, 2, 4, 6 }, target3.OrderingDown);
        }

        /// <summary>
        ///A test for GetEnumerableDown
        ///</summary>
        [TestMethod()]
        public void GetEnumerableDownTest()
        {
            SingleLayoutEditor target = new SingleLayoutEditor(12, 8);

            TestLayoutPosEditorEnumerable(new int[] { 2, 85, 73, 61, 49, 37, 25, 13, 1 }, target.GetEnumerableDown(2, 1));

            TestLayoutPosEditorEnumerable(new int[] { 1, 13, 25, 37, 49, 61, 73, 85, 2 }, target.GetEnumerableDown(1, 2));
            TestLayoutPosEditorEnumerable(new int[] { 1, 13 }, target.GetEnumerableDown(1, 13));
            TestLayoutPosEditorEnumerable(new int[] { 13, 1 }, target.GetEnumerableDown(13, 1));

            TestLayoutPosEditorEnumerable(new int[] { 1, 13, 25, 37, 49, 61, 73, 85, 2, 14, 26, 38, 50, 62, 74, 86 }, target.GetEnumerableDown(1, 86));

            // N
            TestLayoutPosEditorEnumerable(new int[] { 14, 2 }, target.GetEnumerableDown(14, 2));
            // S
            TestLayoutPosEditorEnumerable(new int[] { 14, 26 }, target.GetEnumerableDown(14, 26));
            // E
            TestLayoutPosEditorEnumerable(new int[] { 14, 26, 38, 50, 62, 74, 86, 3, 15 }, target.GetEnumerableDown(14, 15));
            // W
            TestLayoutPosEditorEnumerable(new int[] { 14, 2, 85, 73, 61, 49, 37, 25, 13 }, target.GetEnumerableDown(14, 13));
            // NE
            TestLayoutPosEditorEnumerable(new int[] { 14, 26, 38, 50, 62, 74, 86, 3 }, target.GetEnumerableDown(14, 3));
            // SE
            TestLayoutPosEditorEnumerable(new int[] { 14, 26, 38, 50, 62, 74, 86, 3, 15, 27 }, target.GetEnumerableDown(14, 27));
            // NW
            TestLayoutPosEditorEnumerable(new int[] { 14, 2, 85, 73, 61, 49, 37, 25, 13, 1 }, target.GetEnumerableDown(14, 1));
            // SW
            TestLayoutPosEditorEnumerable(new int[] { 14, 2, 85, 73, 61, 49, 37, 25 }, target.GetEnumerableDown(14, 25));
        }

        /// <summary>
        ///A test for Item
        ///</summary>
        [TestMethod()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ItemTest()
        {
            SingleLayoutEditor target = new SingleLayoutEditor(12, 8);
            LayoutPosEditor l = target[96];
        }

        /// <summary>
        ///A test for GetEnumerableFill
        ///</summary>
        [TestMethod()]
        public void GetEnumerableFillTest()
        {
            SingleLayoutEditor target = new SingleLayoutEditor(2, 2);

            TestLayoutPosEditorEnumerable(new int[] { 2, 3 }, target.GetEnumerableFill(2, 3, target.OrderingAcross));
            TestLayoutPosEditorEnumerable(new int[] { 2, 3 }, target.GetEnumerableFill(3, 2, target.OrderingAcross));
            TestLayoutPosEditorEnumerable(new int[] { 3, 2 }, target.GetEnumerableFill(2, 3, target.OrderingAcross.Reverse()));
            TestLayoutPosEditorEnumerable(new int[] { 3, 2 }, target.GetEnumerableFill(3, 2, target.OrderingAcross.Reverse()));
            TestLayoutPosEditorEnumerable(new int[] { 2 }, target.GetEnumerableFill(2, 2, target.OrderingAcross.Reverse()));
            TestLayoutPosEditorEnumerable(new int[] { 2, 1 }, target.GetEnumerableFill(2, 5, target.OrderingAcross.Reverse()));
            TestLayoutPosEditorEnumerable(new int[] { }, target.GetEnumerableFill(5, 6, target.OrderingAcross.Reverse()));
        }
    }
}
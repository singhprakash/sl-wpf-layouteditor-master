using System;
using System.Text;
using Layout;
using LayoutEditor.UnitTests.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LayoutEditor.UnitTests
{
    /// <summary>
    ///This is a test class for LayoutHelpersTest and is intended
    ///to contain all LayoutHelpersTest Unit Tests
    ///</summary>
    [TestClass()]
    public class LayoutHelpersTest
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
        ///A test for GetPositions
        ///</summary>
        [TestMethod()]
        public void GetPositionsTest()
        {
            int startPos = 1;
            int endPos = 1;

            LayoutDimensions layoutDimensions = new LayoutDimensions(12, 8);

            FillSettings fillSettings = new FillSettings() { GroupDirection = Direction.Col };
            int[] result;
            result = LayoutHelpers.GetPositions(startPos, endPos, fillSettings, layoutDimensions);
            Assert.AreEqual(result.Length, 1, "The number of expected positions is wrong.");
            Assert.AreEqual(result[0], fillSettings.StartGroup, "The first group is wrong.");
        }


        /// <summary>
        ///A test for GetPositions
        ///</summary>
        [TestMethod()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void GetPositionsTest1()
        {
            int startPos = 97;
            int endPos = 98;

            LayoutDimensions layoutDimensions = new LayoutDimensions(12, 8);
            FillSettings fillSettings = new FillSettings() { GroupDirection = Direction.Col };
            int[] result = LayoutHelpers.GetPositions(startPos, endPos, fillSettings, layoutDimensions);

        }

        /// <summary>
        ///A test for GetPositions
        ///</summary>
        [TestMethod()]
        public void GetPositionsTest2()
        {
            LayoutDimensions layoutDimensions = new LayoutDimensions(12, 8);

            FillSettings fillSettings = new FillSettings()
            {
                IsGrid = true,
                IsSnake = false,
                GroupDirection = Direction.Row,
                StartGroup = 1,
                Replicates = 1
            };

            // IsGrid, By row
            TestGetPositions(1, 2, layoutDimensions, fillSettings, new int[] { 1, 2 });
            TestGetPositions(2, 1, layoutDimensions, fillSettings, new int[] { 2, 1 });
            TestGetPositions(1, 13, layoutDimensions, fillSettings, new int[] { 1, 13 });
            TestGetPositions(1, 14, layoutDimensions, fillSettings, new int[] { 1, 2, 13, 14 });
            TestGetPositions(14, 1, layoutDimensions, fillSettings, new int[] { 14, 13, 2, 1 });
            TestGetPositions(1, 96, layoutDimensions, fillSettings, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44, 45, 46, 47, 48, 49, 50, 51, 52, 53, 54, 55, 56, 57, 58, 59, 60, 61, 62, 63, 64, 65, 66, 67, 68, 69, 70, 71, 72, 73, 74, 75, 76, 77, 78, 79, 80, 81, 82, 83, 84, 85, 86, 87, 88, 89, 90, 91, 92, 93, 94, 95, 96 });
            TestGetPositions(96, 1, layoutDimensions, fillSettings, new int[] { 96, 95, 94, 93, 92, 91, 90, 89, 88, 87, 86, 85, 84, 83, 82, 81, 80, 79, 78, 77, 76, 75, 74, 73, 72, 71, 70, 69, 68, 67, 66, 65, 64, 63, 62, 61, 60, 59, 58, 57, 56, 55, 54, 53, 52, 51, 50, 49, 48, 47, 46, 45, 44, 43, 42, 41, 40, 39, 38, 37, 36, 35, 34, 33, 32, 31, 30, 29, 28, 27, 26, 25, 24, 23, 22, 21, 20, 19, 18, 17, 16, 15, 14, 13, 12, 11, 10, 9, 8, 7, 6, 5, 4, 3, 2, 1 });

            // IsGrid, By row with snake mode
            fillSettings.IsSnake = true;
            TestGetPositions(1, 14, layoutDimensions, fillSettings, new int[] { 1, 2, 14, 13 });
            TestGetPositions(14, 1, layoutDimensions, fillSettings, new int[] { 13, 14, 2, 1 });       // TODO: Not sure about this one - test with UI
            TestGetPositions(1, 27, layoutDimensions, fillSettings, new int[] { 1, 2, 3, 15, 14, 13, 25, 26, 27 });

            // IsGrid, By col without snake mode
            fillSettings.IsSnake = false;
            fillSettings.GroupDirection = Direction.Col;
            TestGetPositions(1, 14, layoutDimensions, fillSettings, new int[] { 1, 13, 2, 14 });
            TestGetPositions(14, 1, layoutDimensions, fillSettings, new int[] { 14, 2, 13, 1 });   // TODO: Not sure about this one - test with UI

            // IsGrid, By col with snake mode
            fillSettings.IsSnake = true;
            TestGetPositions(1, 14, layoutDimensions, fillSettings, new int[] { 1, 13, 14, 2 });
            TestGetPositions(1, 27, layoutDimensions, fillSettings, new int[] { 1, 13, 25, 26, 14, 2, 3, 15, 27 });
            TestGetPositions(27, 1, layoutDimensions, fillSettings, new int[] { 27, 15, 3, 2, 14, 26, 25, 13, 1 });  // TODO: Not sure about this one - test with UI


            // Not grid, By row
            fillSettings.IsGrid = false;
            fillSettings.GroupDirection = Direction.Row;
            fillSettings.IsSnake = false;
            TestGetPositions(1, 2, layoutDimensions, fillSettings, new int[] { 1, 2 });
            TestGetPositions(2, 1, layoutDimensions, fillSettings, new int[] { 2, 1 });
            TestGetPositions(1, 13, layoutDimensions, fillSettings, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13 });
            TestGetPositions(13, 1, layoutDimensions, fillSettings, new int[] { 13, 12, 11, 10, 9, 8, 7, 6, 5, 4, 3, 2, 1 });
            TestGetPositions(1, 96, layoutDimensions, fillSettings, new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44, 45, 46, 47, 48, 49, 50, 51, 52, 53, 54, 55, 56, 57, 58, 59, 60, 61, 62, 63, 64, 65, 66, 67, 68, 69, 70, 71, 72, 73, 74, 75, 76, 77, 78, 79, 80, 81, 82, 83, 84, 85, 86, 87, 88, 89, 90, 91, 92, 93, 94, 95, 96 });
            TestGetPositions(96, 1, layoutDimensions, fillSettings, new int[] { 96, 95, 94, 93, 92, 91, 90, 89, 88, 87, 86, 85, 84, 83, 82, 81, 80, 79, 78, 77, 76, 75, 74, 73, 72, 71, 70, 69, 68, 67, 66, 65, 64, 63, 62, 61, 60, 59, 58, 57, 56, 55, 54, 53, 52, 51, 50, 49, 48, 47, 46, 45, 44, 43, 42, 41, 40, 39, 38, 37, 36, 35, 34, 33, 32, 31, 30, 29, 28, 27, 26, 25, 24, 23, 22, 21, 20, 19, 18, 17, 16, 15, 14, 13, 12, 11, 10, 9, 8, 7, 6, 5, 4, 3, 2, 1 });

            // Not grid, By col
            fillSettings.GroupDirection = Direction.Col;
            TestGetPositions(1, 2, layoutDimensions, fillSettings, new int[] { 1, 13, 25, 37, 49, 61, 73, 85, 2 });
            TestGetPositions(2, 1, layoutDimensions, fillSettings, new int[] { 2, 85, 73, 61, 49, 37, 25, 13, 1 });
            TestGetPositions(1, 13, layoutDimensions, fillSettings, new int[] { 1, 13 });
            TestGetPositions(13, 1, layoutDimensions, fillSettings, new int[] { 13, 1 });
            TestGetPositions(1, 86, layoutDimensions, fillSettings, new int[] { 1, 13, 25, 37, 49, 61, 73, 85, 2, 14, 26, 38, 50, 62, 74, 86 });

            // Not grid, By row, snake
            fillSettings.IsSnake = true;
            fillSettings.GroupDirection = Direction.Row;
            TestGetPositions(1, 2, layoutDimensions, fillSettings, new int[] { 1, 2 });

            // Not grid, By row, snake
            layoutDimensions.Width = 3;
            layoutDimensions.Height = 2;
            TestGetPositions(1, 6, layoutDimensions, fillSettings, new int[] { 1, 2, 3, 6 });
            TestGetPositions(6, 1, layoutDimensions, fillSettings, new int[] { 6, 5, 4, 1 });
            TestGetPositions(6, 3, layoutDimensions, fillSettings, new int[] { 6, 5, 4, 1, 2, 3 });  // This is row - by if it were by col it would be 2 pos

            // Not grid, By row, snake
            layoutDimensions.Width = 4;
            layoutDimensions.Height = 3;
            TestGetPositions(1, 12, layoutDimensions, fillSettings, new int[] { 1, 2, 3, 4, 8, 7, 6, 5, 9, 10, 11, 12 });
            TestGetPositions(12, 1, layoutDimensions, fillSettings, new int[] { 12, 11, 10, 9, 5, 6, 7, 8, 4, 3, 2, 1 });

            // Not grid, By col, snake
            layoutDimensions.Width = 3;
            layoutDimensions.Height = 2;
            fillSettings.GroupDirection = Direction.Col;
            TestGetPositions(1, 6, layoutDimensions, fillSettings, new int[] { 1, 4, 5, 2, 3, 6 });
            TestGetPositions(6, 1, layoutDimensions, fillSettings, new int[] { 6, 3, 2, 5, 4, 1 });

            // Not grid, By col, snake
            layoutDimensions.Width = 4;
            layoutDimensions.Height = 3;
            TestGetPositions(1, 12, layoutDimensions, fillSettings, new int[] { 1, 5, 9, 10, 6, 2, 3, 7, 11, 12 });
            TestGetPositions(12, 1, layoutDimensions, fillSettings, new int[] { 12, 8, 4, 3, 7, 11, 10, 6, 2, 1 });
            TestGetPositions(1, 10, layoutDimensions, fillSettings, new int[] { 1, 5, 9, 10 });
            TestGetPositions(12, 8, layoutDimensions, fillSettings, new int[] { 12, 8 });
        }

        private static string UintArrayToString(int[] a)
        {
            StringBuilder sb = new StringBuilder();
            foreach (int u in a)
            {
                sb.Append(u + ", ");
            }
            return sb.ToString();
        }
        private static int[] TestGetPositions(int startPos, int endPos, LayoutDimensions layoutDimensions, FillSettings fillSettings, int[] expected)
        {
            int[] result = LayoutHelpers.GetPositions(startPos, endPos, fillSettings, layoutDimensions);
            Assert.AreEqual(result.Length, expected.Length, "The number of expected positions is wrong.");

            for (int i = 0; i < result.Length; i++)
            {
                Assert.AreEqual(result[i], expected[i], string.Format("Unexpected result at position {0}, expected: {1} result {2}.  Full result: {3}", i, expected[i], result[i], UintArrayToString(result)));
            }
            return result;
        }

        /// <summary>
        ///A test for ConvertPositionToPosXY
        ///</summary>
        [TestMethod()]
        public void ConvertPositionToPosXYTest()
        {
            LayoutDimensions layoutDimensions = new LayoutDimensions(12, 8);

            // Pos, ExpectedX, ExpectedY
            TestConvertPositionToPosXY(layoutDimensions, 1, 1, 1);
            TestConvertPositionToPosXY(layoutDimensions, 2, 2, 1);
            TestConvertPositionToPosXY(layoutDimensions, 12, 12, 1);
            TestConvertPositionToPosXY(layoutDimensions, 13, 1, 2);
            TestConvertPositionToPosXY(layoutDimensions, 24, 12, 2);
            TestConvertPositionToPosXY(layoutDimensions, 96, 12, 8);

        }

        private static void TestConvertPositionToPosXY(LayoutDimensions layoutDimensions, int pos, int posXExpected, int posYExpected)
        {
            PosXY result;
            result = LayoutHelpers.ConvertPositionToPosXY(pos, layoutDimensions);
            Assert.AreEqual(result.X, (int)posXExpected, string.Format("posX value is not as expected, expecting {0}, result is {1}", posXExpected, result.X));
            Assert.AreEqual(result.Y, (int)posYExpected, string.Format("posY value is not as expected, expecting {0}, result is {1}", posXExpected, result.Y));
        }


        /// <summary>
        ///A test for ConvertPosXYToPosition
        ///</summary>
        [TestMethod()]
        public void ConvertPosXYToPositionTest()
        {
            LayoutDimensions layoutDimensions = new LayoutDimensions(12, 8);
            int result;
            result = LayoutHelpers.ConvertPosXYToPosition(new PosXY(1, 1), layoutDimensions);
            Assert.AreEqual(result, (int)1);

            result = LayoutHelpers.ConvertPosXYToPosition(new PosXY(1, 2), layoutDimensions);
            Assert.AreEqual(result, (int)13);

            result = LayoutHelpers.ConvertPosXYToPosition(new PosXY(12, 8), layoutDimensions);
            Assert.AreEqual(result, (int)96);

        }

        /// <summary>
        ///A test for ConvertPositionToPosXY
        ///</summary>
        [TestMethod()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ConvertPositionToPosXYTest1()
        {
            LayoutHelpers.ConvertPositionToPosXY(0, new LayoutDimensions(12, 8));
        }

        /// <summary>
        ///A test for FillPositions
        ///</summary>
        [TestMethod()]
        public void FillPositionsTest()
        {
            LayoutDimensions layoutDimensions = new LayoutDimensions(12, 8);

            FillSettings fillSettings = new FillSettings()
            {
                IsGrid = true,
                IsSnake = false,
                GroupDirection = Direction.Row,
                StartGroup = 1,
                Replicates = 1
            };

            int[] positions;

            // IsGrid, By row
            positions = TestGetPositions(1, 2, layoutDimensions, fillSettings, new int[] { 1, 2 });

            // Expected group nums, expected next group, expected all replicates used
            TestFillPositions(positions, layoutDimensions, fillSettings, new int[] { 1, 2 }, 3, true);
            fillSettings.Replicates = 2;
            TestFillPositions(positions, layoutDimensions, fillSettings, new int[] { 1, 1 }, 2, true);
            fillSettings.Replicates = 3;
            TestFillPositions(positions, layoutDimensions, fillSettings, new int[] { 1, 1 }, 1, false);
            fillSettings.Replicates = 100;
            TestFillPositions(positions, layoutDimensions, fillSettings, new int[] { 1, 1 }, 1, false);

            fillSettings.Replicates = 1;
            TestGetPositions(2, 1, layoutDimensions, fillSettings, new int[] { 2, 1 });
            TestFillPositions(positions, layoutDimensions, fillSettings, new int[] { 1, 2 }, 3, true);


        }

        private static void TestFillPositions(int[] positions, LayoutDimensions layoutDimensions, FillSettings fillSettings,
                                            int[] expectedGroupNumbers,
                                            int expectedNextGroup, bool expectedIsAllRepsUsed)
        {
            int[] groupNumbers;
            int nextGroup;
            bool isAllRepsUsed;
            groupNumbers = LayoutHelpers.FillPositions(positions, fillSettings, out nextGroup, out isAllRepsUsed);

            Assert.AreEqual(groupNumbers.Length, positions.Length, "groupNumbers length differs from positions length");

            for (int i = 0; i < groupNumbers.Length; i++)
            {
                Assert.AreEqual(groupNumbers[i], expectedGroupNumbers[i],
                    string.Format("Unexpected result at position {0}, expected: {1} result {2}.  Full result: {3}",
                            i, expectedGroupNumbers[i], groupNumbers[i], UintArrayToString(groupNumbers)));
            }

            Assert.AreEqual(nextGroup, expectedNextGroup, "The next group is not as expected");
            Assert.AreEqual(isAllRepsUsed, expectedIsAllRepsUsed, "isAllRepsUsed is not as expected");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Diagnostics;
using Layout;

namespace LayoutEditor.UnitTests.Helpers
{
    /// <summary>
    /// Helper functions for populating layout structures
    /// </summary>
    static public class LayoutHelpers
    {
        #region Public
        /// <summary>
        /// Returns a list of all position selected between startPos and endPos, in the order with which they should be filled with groups.
        /// </summary>
        /// <param name="startPos">The 1 based starting position</param>
        /// <param name="endPos">The 1 based ending position (this can be anywhere within the range and can be before startPos)</param>
        /// <param name="fillSettings"></param>
        /// <param name="layoutDimensions"></param>
        /// <returns></returns>
        public static int[] GetPositions(int startPos, int endPos, FillSettings fillSettings, LayoutDimensions layoutDimensions)
        {
            if ((startPos < 1) || (startPos > layoutDimensions.NumPositions))
            {
                throw new ArgumentOutOfRangeException(string.Format("The start position: {0} is out of the range of the layout dimensions: {1}", startPos, layoutDimensions.NumPositions), "startPos");
            }
            if ((endPos < 1) || (endPos > layoutDimensions.NumPositions))
            {
                throw new ArgumentOutOfRangeException(string.Format("The end position: {0} is out of the range of the layout dimensions: {1}", startPos, layoutDimensions.NumPositions), "endPos");
            }
            if (layoutDimensions.NumPositions < 1)
            {
                throw new ArgumentException("The LayoutDimensions are invalid.", "layoutDimensions");
            }
            Debug.Assert(startPos >= 1);
            Debug.Assert(startPos <= layoutDimensions.NumPositions);
            Debug.Assert(endPos >= 1);
            Debug.Assert(endPos <= layoutDimensions.NumPositions);

            List<int> list = new List<int>();
            // Deal with simple case of 1 position
            if (startPos == endPos)
            {
                list.Add(fillSettings.StartGroup);
                return list.ToArray();
            }

            // TODO: do we want to do this, will anyone ever want to fill backwards?
            // Swap start and end around so start is < end
            bool isForwards = (startPos < endPos);

            Debug.Assert(startPos != endPos);

            PosXY topLeft, bottomRight;
            if (isForwards)
            {
                topLeft = ConvertPositionToPosXY(startPos, layoutDimensions);
                bottomRight = ConvertPositionToPosXY(endPos, layoutDimensions);
            }
            else
            {
                topLeft = ConvertPositionToPosXY(endPos, layoutDimensions);
                bottomRight = ConvertPositionToPosXY(startPos, layoutDimensions);
            }


            if (fillSettings.IsGrid)
            {
                int gridWidth = 1 + (bottomRight.X - topLeft.X);
                int gridHeight = 1 + (bottomRight.Y - topLeft.Y);

                Debug.Assert(gridWidth > 0);
                Debug.Assert(gridHeight > 0);

                if (fillSettings.GroupDirection == Direction.Col)
                {
                    FillGridCol(fillSettings, layoutDimensions, list, topLeft, gridWidth, gridHeight);
                }
                else if (fillSettings.GroupDirection == Direction.Row)
                {
                    FillGridRow(fillSettings, layoutDimensions, list, topLeft, gridWidth, gridHeight);
                }

                if (!isForwards)
                {
                    list.Reverse();
                }
            }
            else
            {
                // Not grid mode
                int pos = startPos;
                list.Add(pos);
                bool endOfLine = true;
                if (!fillSettings.IsSnake)
                {
                    while (pos != endPos)
                    {
                        if (isForwards)
                        {
                            pos = GetNextPosition(pos, fillSettings, layoutDimensions, out endOfLine);
                        }
                        else
                        {
                            pos = GetPreviousPosition(pos, fillSettings, layoutDimensions, out endOfLine);
                        }
                        list.Add(pos);
                    }
                }
                else
                {
                    bool snakeForwards = isForwards;
                    while (pos != endPos)
                    {
                        if (snakeForwards)
                        {
                            pos = GetNextPosition(pos, fillSettings, layoutDimensions, out endOfLine);
                            if (endOfLine)
                            {
                                if (isForwards)  // Snake (instead of starting line)
                                {
                                    if (fillSettings.GroupDirection == Direction.Row)
                                    {
                                        pos += layoutDimensions.Width - 1;
                                    }
                                    else
                                    {
                                        pos = list[list.Count - 1] + 1;
                                    }
                                }
                                else
                                {
                                    if (fillSettings.GroupDirection == Direction.Row)
                                    {
                                        pos -= layoutDimensions.Width + 1;
                                    }
                                    else
                                    {
                                        pos = list[list.Count - 1] - 1;
                                    }
                                }
                                snakeForwards = false;
                            }
                        }
                        else
                        {
                            pos = GetPreviousPosition(pos, fillSettings, layoutDimensions, out endOfLine);
                            if (endOfLine)
                            {
                                if (isForwards)  // Snake (instead of starting line)
                                {
                                    if (fillSettings.GroupDirection == Direction.Row)
                                    {
                                        pos += layoutDimensions.Width + 1;
                                    }
                                    else
                                    {
                                        pos = list[list.Count - 1] + 1;
                                    }
                                }
                                else
                                {
                                    if (fillSettings.GroupDirection == Direction.Row)
                                    {
                                        pos -= layoutDimensions.Width - 1;
                                    }
                                    else
                                    {
                                        pos = list[list.Count - 1] - 1;
                                    }
                                }

                                snakeForwards = true;
                            }
                        }
                        list.Add(pos);
                    }
                }
            }
            Debug.Assert(list.Count > 0);
            return list.ToArray();
        }
        // Returns a list of the group numbers to fill with for the specified positions in a list (use GetPositions to produce this list)
        public static int[] FillPositions(int[] positions, FillSettings fillSettings, out int nextGroup, out bool isAllRepsUsed)
        {
            if (fillSettings.Replicates == 0)
            {
                throw new ArgumentOutOfRangeException("FillSettings.Replicates cannot be 0", "fillSettings.Replicates");
            }

            List<int> groupNumbers = new List<int>();

            nextGroup = fillSettings.StartGroup;
            int repsUsed = 0;

            // If not grid more, or if is grid mode and group and fill direction is the same
            if ((fillSettings.IsGrid == false) || (fillSettings.GroupDirection == fillSettings.ReplicateDirection))
            {
                foreach (int pos in positions)
                {
                    groupNumbers.Add(nextGroup);
                    repsUsed++;
                    if (repsUsed == fillSettings.Replicates)
                    {
                        repsUsed = 0;
                        nextGroup++;
                    }
                }
            }
            else
            {
                // Grid mode when GroupDirection and ReplicateDirection are different is tricky
                // TODO: decide whether to implement this mode, 
                throw new NotImplementedException("Grid mode, when GroupDirection and ReplicateDirection are different is not yet implemented.");
            }

            isAllRepsUsed = (repsUsed == 0);

            Debug.Assert(groupNumbers.Count == positions.Length);
            return groupNumbers.ToArray();
        }


        /// <summary>
        /// Converts a 1 based position value to a PosXY (as PosXY uses top left as 1,1) 
        /// e.g. Position = 1 -> PosX=1, PosY=1
        ///      Position = 2 -> PosX=2, PosY=1
        /// </summary>
        /// <param name="pos"></param>
        /// <param name="layoutDimensions"></param>
        /// <returns></returns>
        public static PosXY ConvertPositionToPosXY(int pos, LayoutDimensions layoutDimensions)
        {
            if ((pos < 1) || (pos > layoutDimensions.NumPositions))
            {
                throw new ArgumentOutOfRangeException(string.Format("The  position: {0} is out of the range of the layout dimensions: {1}", pos, layoutDimensions.NumPositions));
            }

            Debug.Assert(pos >= 1);
            Debug.Assert(pos <= layoutDimensions.NumPositions);

            pos--;

            int y = (int)1 + (pos / layoutDimensions.Width);
            int x = (int)1 + (pos % layoutDimensions.Width);

            Debug.Assert(x >= 1);
            Debug.Assert(x <= layoutDimensions.Width);
            Debug.Assert(y >= 1);
            Debug.Assert(y <= layoutDimensions.Height);

            return new PosXY(x, y);
        }

        /// <summary>
        /// Converts PosXY to a a 1 based position value to a 
        /// e.g PosX=1, PosY=1 -> 1
        ///     PosX=2, PosY=1 -> 2
        /// </summary>
        /// <param name="pos"></param>
        /// <param name="layoutDimensions"></param>
        /// <returns></returns>
        public static int ConvertPosXYToPosition(PosXY posXY, LayoutDimensions layoutDimensions)
        {
            Debug.Assert(posXY.X > 0);
            Debug.Assert(posXY.X <= layoutDimensions.Width);
            Debug.Assert(posXY.Y > 0);
            Debug.Assert(posXY.Y <= layoutDimensions.Height);

            int result = ((posXY.Y - 1) * layoutDimensions.Width) + posXY.X;

            Debug.Assert(result > 0);
            Debug.Assert(result <= layoutDimensions.NumPositions);

            return result;
        }
        #endregion

        #region Private
        private static void FillGridCol(FillSettings fillSettings, LayoutDimensions layoutDimensions, List<int> list, PosXY topLeft, int gridWidth, int gridHeight)
        {
            for (int x = 0; x < gridWidth; x++)
            {
                for (int y = 0; y < gridHeight; y++)
                {
                    AddPositionToList(layoutDimensions, list, topLeft, x, y);
                }
                if (fillSettings.IsSnake && x < (gridWidth - 1))
                {
                    // In snake mode do the next column in reverse 
                    x++;
                    for (int y = gridHeight - 1; y >= 0 && y != int.MaxValue; y--)
                    {
                        AddPositionToList(layoutDimensions, list, topLeft, x, y);
                    }
                }
            }
        }

        private static void FillGridRow(FillSettings fillSettings, LayoutDimensions layoutDimensions, List<int> list, PosXY topLeft, int gridWidth, int gridHeight)
        {
            for (int y = 0; y < gridHeight; y++)
            {
                for (int x = 0; x < gridWidth; x++)
                {
                    AddPositionToList(layoutDimensions, list, topLeft, x, y);
                }
                if (fillSettings.IsSnake && y < (gridHeight - 1))
                {
                    // In snake mode do the next line in reverse 
                    y++;
                    for (int x = gridWidth - 1; x >= 0 && x != int.MaxValue; x--)
                    {
                        AddPositionToList(layoutDimensions, list, topLeft, x, y);
                    }
                }
            }
        }

        private static int GetNextPosition(int currentPos, FillSettings fillSettings, LayoutDimensions layoutDimensions, out bool endOfLine)
        {
            Debug.Assert(fillSettings.IsGrid == false);
            Debug.Assert(currentPos >= 1);
            Debug.Assert(currentPos <= layoutDimensions.NumPositions);

            PosXY currentPosXY = ConvertPositionToPosXY(currentPos, layoutDimensions);
            PosXY nextPosXY = new PosXY();

            endOfLine = false;
            if (fillSettings.GroupDirection == Direction.Row)
            {
                if (currentPosXY.X < layoutDimensions.Width)
                {
                    nextPosXY.X = currentPosXY.X + 1;
                    nextPosXY.Y = currentPosXY.Y;
                }
                else
                {
                    nextPosXY.X = 1;
                    nextPosXY.Y = currentPosXY.Y + 1;
                    endOfLine = true;
                }
            }
            else
            {
                Debug.Assert(fillSettings.GroupDirection == Direction.Col);
                if (currentPosXY.Y < layoutDimensions.Height)
                {
                    nextPosXY.X = currentPosXY.X;
                    nextPosXY.Y = currentPosXY.Y + 1;
                }
                else
                {
                    nextPosXY.X = currentPosXY.X + 1;
                    nextPosXY.Y = 1;
                    endOfLine = true;
                }
            }

            int nextPos = ConvertPosXYToPosition(nextPosXY, layoutDimensions);
            Debug.Assert(nextPos != currentPos);
            Debug.Assert(nextPos >= 1);
            Debug.Assert(nextPos <= layoutDimensions.NumPositions);

            return nextPos;
        }

        private static int GetPreviousPosition(int currentPos, FillSettings fillSettings, LayoutDimensions layoutDimensions, out bool endOfLine)
        {
            Debug.Assert(fillSettings.IsGrid == false);
            Debug.Assert(currentPos >= 1);
            Debug.Assert(currentPos <= layoutDimensions.NumPositions);

            PosXY currentPosXY = ConvertPositionToPosXY(currentPos, layoutDimensions);
            PosXY nextPosXY = new PosXY();

            endOfLine = false;

            if (fillSettings.GroupDirection == Direction.Row)
            {
                if (currentPosXY.X > 1)
                {
                    nextPosXY.X = currentPosXY.X - 1;
                    nextPosXY.Y = currentPosXY.Y;
                }
                else
                {
                    nextPosXY.X = layoutDimensions.Width;
                    nextPosXY.Y = currentPosXY.Y - 1;
                    endOfLine = true;
                }
            }
            else
            {
                Debug.Assert(fillSettings.GroupDirection == Direction.Col);
                if (currentPosXY.Y > 1)
                {
                    nextPosXY.X = currentPosXY.X;
                    nextPosXY.Y = currentPosXY.Y - 1;
                }
                else
                {
                    nextPosXY.X = currentPosXY.X - 1;
                    nextPosXY.Y = layoutDimensions.Height;
                    endOfLine = true;
                }
            }

            int nextPos = ConvertPosXYToPosition(nextPosXY, layoutDimensions);
            Debug.Assert(nextPos != currentPos);
            Debug.Assert(nextPos >= 1);
            Debug.Assert(nextPos <= layoutDimensions.NumPositions);

            return nextPos;
        }

        private static void AddPositionToList(LayoutDimensions layoutDimensions, List<int> list, PosXY topLeft, int x, int y)
        {
            list.Add(ConvertPosXYToPosition(new PosXY(topLeft.X + x, topLeft.Y + y), layoutDimensions));
        }
        #endregion
    }
}
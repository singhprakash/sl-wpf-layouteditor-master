using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Media;

namespace Layout
{
    /// <summary>
    /// Stores the current state of the editor, i.e. the data at each postion.
    /// </summary>
    public class SingleLayoutEditor : IEnumerable<LayoutPosEditor>
    {
        public SingleLayoutEditor(SingleLayoutLight singleLayoutLight, int width, int height)
        {
            Init(width, height);
            Debug.Assert(singleLayoutLight.NumPositions == width * height);
            foreach (LayoutPos layoutPos in singleLayoutLight.LayoutPositions)
            {
                this[layoutPos.Id - 1].LayoutPos = layoutPos;
            }
        }

        public string ToCSVString()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < this.NumPositions; i++)
            {
                if (i > 0) sb.Append(",");
                sb.AppendFormat("{0},{1}", this[i].LayoutPos.TypeId, this[i].LayoutPos.Group);
            }
            return sb.ToString();
        }

        /// Read in EVERY position in the layout from a CSV list of TypeId, GroupNum
        public void FromCSVString(string s)
        {
            string[] split = s.Split(',');

            if (split.Length != this.numPositions * 2)
            {
                throw new ArgumentException(string.Format("The CSV does not correspond to this layout, the layout has {0} positions, but the CSV has {1} values, it should have {2} value",
                    this.numPositions, split.Length, this.numPositions * 2));
            }

            int iPos = 0;
            for (int i = 0; i < split.Length; i += 2)
            {
                int typeId = int.Parse(split[i]);
                int groupNum = int.Parse(split[i + 1]);

                LayoutPos layoutPos = this[iPos].LayoutPos;
                layoutPos.TypeId = typeId;
                layoutPos.Group = groupNum;

                iPos++;
            }
        }

        public SingleLayoutEditor(int width, int height)
        {
            Init(width, height);
        }

        public SingleLayoutEditor(LayoutEditorPopulation layoutEditorPopulation)
        {
            Init(layoutEditorPopulation.Width, layoutEditorPopulation.Height);
        }

        private void Init(int width, int height)
        {
            Width = width;
            Height = height;
            this.numPositions = width * height;

            this.layoutPositions = new List<LayoutPosEditor>(NumPositions);

            for (int pos = 1; pos <= NumPositions; pos++)
            {
                this.layoutPositions.Add(
                    new LayoutPosEditor(new Layout.LayoutPos() { Id = pos, Group = 0, TypeId = 1 }, Colors.White, ""));
            }
        }

        public int Width { get; set; }
        public int Height { get; set; }

        private List<LayoutPosEditor> layoutPositions;

        private int numPositions;
        public int NumPositions
        {
            get { return numPositions; }
        }

        public List<LayoutPosEditor> LayoutPositions
        {
            get { return layoutPositions; }
            set { layoutPositions = value; }
        }

        public LayoutPosEditor this[int index]
        {
            get
            {
                //Debug.Assert(index >= 0);
                //Debug.Assert(index < NumPositions);

                if (index < 0 || index >= NumPositions)
                {
                    throw new ArgumentOutOfRangeException(string.Format("Index must be >= 0 and <={0}.", NumPositions));
                }
                return this.layoutPositions[index];
            }
        }

        /// <summary>
        /// Deep copy
        /// </summary>
        /// <returns></returns>
        public SingleLayoutEditor Clone()
        {
            SingleLayoutEditor copy = this.MemberwiseClone() as SingleLayoutEditor;
            // Copy the Layout Position objects (so this is a deep copy)
            copy.layoutPositions = new List<LayoutPosEditor>(this.layoutPositions.Count);

            foreach (LayoutPosEditor lpe in this.layoutPositions)
            {
                copy.layoutPositions.Add(lpe.Clone());
            }
            return copy;
        }


        // Note this only works up to 26 rows
        public string GetPositionId(int pos)
        {
            int col = GetColFromPos(pos);
            int row = GetRowFromPos(pos);

            if (row > 26)
            {
                throw new NotImplementedException();
            }

            char ch = (char)(((int)'A') + row - 1);
            return ch + col.ToString();
        }

        /// <summary>
        /// Get 1 based column number from 1 based position
        /// </summary>
        /// <param name="pos"></param>
        /// <returns></returns>
        public int GetColFromPos(int pos)
        {
            CheckPositionInRangeOneBased(pos);
            int col = 1 + ((pos - 1) % Width);

            Debug.Assert(col >= 1);
            Debug.Assert(col <= Width);
            return col;
        }

        /// <summary>
        /// Get 1 based row number from 1 based position
        /// </summary>
        /// <param name="pos"></param>
        /// <returns></returns>
        public int GetRowFromPos(int pos)
        {
            CheckPositionInRangeOneBased(pos);
            int row = 1 + ((pos - 1) / Width);

            Debug.Assert(row >= 1);
            Debug.Assert(row <= Height);
            return row;
        }

        /*
        private void Output(IEnumerable<LayoutPosEditor> sequence)
        {
            foreach (LayoutPosEditor lpe in sequence)
            {
                Debug.WriteLine(string.Format("{0}: {1}", lpe.LayoutPos.Id, lpe.HoverText));
            }
        }*/
        public LayoutPosEditor GetPositionFromMatrix(int col, int row)
        {
            int pos = (row - 1) * Width + col - 1;
            return this[pos];
        }

        /// <summary>
        /// Returns an enumerable for the positions between startPos and endPos, the first position in the list is always startPos and the last is endPos
        /// </summary>
        /// <param name="startPos"></param>
        /// <param name="endPos"></param>
        /// <returns></returns>
        public IEnumerable<LayoutPosEditor> GetEnumerableAcross(int startPos, int endPos)
        {
            IEnumerable<LayoutPosEditor> sequence = OrderingAcross;
            if (startPos > endPos)
            {
                sequence = Enumerable.Reverse(sequence);
            }
            return GetEnumerableFill(startPos, endPos, sequence);
        }

        /// <summary>
        /// Returns an enumerable for the positions between startPos and endPos, the first position in the list is always startPos and the last is endPos
        /// </summary>
        /// <param name="startPos"></param>
        /// <param name="endPos"></param>
        /// <returns></returns>
        public IEnumerable<LayoutPosEditor> GetEnumerableDown(int startPos, int endPos)
        {
            IEnumerable<LayoutPosEditor> sequence = GetEnumerableFill(startPos, endPos, OrderingDown);

            // Determine if this list needs reversing, it needs reversing if the start column is > end column
            // when the start and end column is the same, reverse if the start row is > end row
            int startCol = GetColFromPos(startPos);
            int endCol = GetColFromPos(endPos);

            bool reverse = false;
            if (startCol > endCol)
            {
                reverse = true;
            }
            else if (startCol == endCol)
            {
                int startRow = GetRowFromPos(startPos);
                int endRow = GetRowFromPos(endPos);
                if (startRow > endRow)
                {
                    reverse = true;
                }
            }

            if (reverse)
            {
                sequence = Enumerable.Reverse(sequence);
            }
            return sequence;
        }

        public IEnumerable<LayoutPosEditor> GetEnumerableRectangleDown(int posA, int posB)
        {
            int startCol = GetColFromPos(posA);
            int endCol = GetColFromPos(posB);

            int startRow = GetRowFromPos(posA);
            int endRow = GetRowFromPos(posB);

            int stepCol = Math.Sign(endCol - startCol);
            int stepRow = Math.Sign(endRow - startRow);

            int row = startRow;
            int col = startCol;

            do
            {
                row = startRow;
                do
                {
                    yield return this.GetPositionFromMatrix(col, row);
                    row += stepRow;
                } while (row != endRow + stepRow);
                col += stepCol;
            } while (col != endCol + stepCol);
        }

        public IEnumerable<LayoutPosEditor> GetEnumerableRectangleAcross(int posA, int posB)
        {
            int startCol = GetColFromPos(posA);
            int endCol = GetColFromPos(posB);

            int startRow = GetRowFromPos(posA);
            int endRow = GetRowFromPos(posB);

            int stepCol = Math.Sign(endCol - startCol);
            int stepRow = Math.Sign(endRow - startRow);

            int row = startRow;
            int col = startCol;

            do
            {
                col = startCol;
                do
                {
                    yield return this.GetPositionFromMatrix(col, row);
                    col += stepCol;
                } while (col != endCol + stepCol);
                row += stepRow;
            } while (row != endRow + stepRow);
        }

        /// <summary>
        /// Returns a list of the positions which are inbetween and including the position A and position B pos.
        /// It does not matter if A before or after B, the included positions are those positions
        /// in between, i.e. when the first position is found which is either A or B, all positions are then 
        /// included until the opposite position is found.
        /// e.g. 
        /// 1,2,3,4 (2,3) -> 2,3
        /// 1,2,3,4 (3,2) -> 2,3
        /// 4,3,2,1 (2,3) -> 3,2
        /// 4,3,2,1 (3,2) -> 3,2
        /// 4,3,2,1 (2,2) -> 2
        /// 4,3,2,1 (2,5) -> 2,1
        /// 4,3,2,1 (5,6) -> Empty
        /// </summary>
        /// <param name="startPos"></param>
        /// <param name="endPos"></param>
        /// <param name="source"></param>
        /// <returns></returns>
        public IEnumerable<LayoutPosEditor> GetEnumerableFill(int posA, int posB, IEnumerable<LayoutPosEditor> source)
        {
            bool including = false;
            int stopIncludingOn = -1;
            foreach (LayoutPosEditor layoutPosEditor in source)
            {
                if (!including)
                {
                    if (layoutPosEditor.LayoutPos.Id == posA)
                    {
                        including = true;
                        stopIncludingOn = posB;
                    }
                    else if (layoutPosEditor.LayoutPos.Id == posB)
                    {
                        including = true;
                        stopIncludingOn = posA;
                    }
                }
                if (including)
                {
                    yield return layoutPosEditor;
                    if (layoutPosEditor.LayoutPos.Id == stopIncludingOn)
                    {
                        break;
                    }
                }
            }
        }

        /// <summary>
        /// Enumerable for positions across the plate, e.g. A1, A2, A3, ..., B1, B2, B3, etc.
        /// </summary>
        public IEnumerable<LayoutPosEditor> OrderingAcross
        {
            get
            {
                foreach (LayoutPosEditor layoutPosEditor in this.layoutPositions)
                {
                    yield return layoutPosEditor;
                }
            }
        }

        /// <summary>
        /// Enumerable for positions across the plate, e.g. A1, B1, C1, ..., A2, B2, C2, etc.
        /// </summary>
        public IEnumerable<LayoutPosEditor> OrderingDown
        {
            get
            {
                for (int col = 0; col < Width; col++)
                {
                    for (int row = 0; row < Height; row++)
                    {
                        int pos = (row * Width) + col;
                        yield return this[pos];
                    }
                }
            }
        }

        #region IEnumerable<LayoutPosEditor> Members

        /// <summary>
        /// Use OrderingAcross as the default enumerator for this class
        /// </summary>
        /// <returns></returns>
        IEnumerator<LayoutPosEditor> IEnumerable<LayoutPosEditor>.GetEnumerator()
        {
            return OrderingAcross.GetEnumerator();
        }

        #endregion

        #region IEnumerable Members

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        #endregion

        public void CheckPositionInRangeOneBased(int pos)
        {
            //Debug.Assert(pos > 0, "Position must be 1 based");
            //Debug.Assert(pos <= NumPositions, "Position number is > number of positions");

            if ((pos <= 0) || (pos > NumPositions))
            {
                throw new ArgumentOutOfRangeException(string.Format("{0} is out of range for the PlateControl which has {1} positions. One based numbering is expected. ", pos.ToString(), NumPositions));
            }
        }

        public void CheckPositionInRangeZeroBased(int pos)
        {
            //Debug.Assert(pos >= 0, "Position must be 0 based");
            //Debug.Assert(pos < NumPositions, "Position number is >= number of positions, it should be zero based");

            if ((pos < 0) || (pos >= NumPositions))
            {
                throw new ArgumentOutOfRangeException(string.Format("{0} is out of range for the PlateControl which has {1} positions.  Zero based numbering is expected. ", pos.ToString(), NumPositions));
            }
        }

        public bool IsPlateClear()
        {
            foreach (LayoutPosEditor layoutPos in layoutPositions)
            {
                if (layoutPos.LayoutPos.IsUsed)
                    return false;
            }
            return true;
        }
        /// <summary>
        /// Enumerable for all LayoutPosEditors of the specified group and type (going across the plate)
        /// </summary>
        /// <param name="group"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public IEnumerable<LayoutPosEditor> GetPositionsOfGroupType(int group, int type)
        {
            foreach (LayoutPosEditor layoutPosEditor in OrderingAcross)
            {
                if (layoutPosEditor.LayoutPos.Equals(group, type))
                {
                    yield return layoutPosEditor;
                }
            }
        }

        public void ToggleFlagState(int pos)
        {
            CheckPositionInRangeOneBased(pos);
            int zPosition = pos - 1;
            this[zPosition].IsFlagged = !this[zPosition].IsFlagged;
        }

        public static string ToStringCsv(IEnumerable<int> i)
        {
            StringBuilder sb = new StringBuilder();
            i.ToList().ForEach(x => sb.Append(x.ToString() + ","));  // Note that in this context the comma symbol is always used (and should not be converted here to a specific regional)
            if (sb.Length > 0)
            {
                sb.Remove(sb.Length - 1, 1);
            }
            return sb.ToString();
        }

        public static int[] SplitCsvAsInt(string csv)
        {
            string[] items = csv.Split(',');
            var result = from item in items select int.Parse(item);
            return result.ToArray();
        }

        public string GetFlaggedPositionsCsv()
        {
            return ToStringCsv(GetFlaggedPositions());
        }

        public string GetFlaggedPositionsText()
        {
            int[] flaggedPositions = GetFlaggedPositions().ToArray();

            string flagUserText = GetPositionListAsUserText(flaggedPositions);

            if (flaggedPositions.Length > 1)
            {
                return string.Format(@"Positions {0} are flagged and will be excluded from calculations.", flagUserText);
            }
            if (flaggedPositions.Length == 1)
            {
                return string.Format(@"Position {0} is flagged and will be excluded from calculations.", flagUserText);
            }
            return string.Empty;
        }

        public string GetPositionListAsUserText(int[] positions)
        {
            StringBuilder sb = new StringBuilder();

            int numPositions = positions.Length;
            if (numPositions == 0)
            {
                return "";
            }

            sb.Append(GetPositionId(positions[0]));

            if (numPositions > 2)
            {
                for (int i = 1; i < numPositions - 1; i++)
                {
                    sb.Append(", " + GetPositionId(positions[i]));
                }
            }

            if (numPositions > 1)
            {
                sb.Append(" and " + GetPositionId(positions[numPositions - 1]));
            }
            return sb.ToString();
        }

        public void InitFlaggedPositionsFromCsv(string csv)
        {
            foreach (LayoutPosEditor layoutPosEditor in OrderingAcross)
            {
                layoutPosEditor.IsFlagged = false;
            }

            if (!string.IsNullOrEmpty(csv))
            {
                int[] flagged = SplitCsvAsInt(csv);
                foreach (var posToFlag in flagged)
                {
                    ToggleFlagState(posToFlag);
                }
            }
        }

        public IEnumerable<int> GetFlaggedPositions()
        {
            foreach (LayoutPosEditor layoutPosEditor in OrderingAcross)
            {
                if (layoutPosEditor.IsFlagged)
                {
                    yield return layoutPosEditor.LayoutPos.Id;
                }
            }
        }

        public bool AnyFlaggedPositions()
        {
            return (GetFlaggedPositions().FirstOrDefault() != 0);
        }
    }
}
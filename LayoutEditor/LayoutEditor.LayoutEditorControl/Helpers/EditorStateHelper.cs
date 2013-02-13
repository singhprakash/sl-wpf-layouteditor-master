using System;
using System.Collections.Generic;
using System.Linq;
using Layout;
using LayoutEditor.Enums;
using LayoutEditor.LayoutEditorControl.Models;
using LayoutEditor.Models;
using PlateControl2DSilverlight.PlateControlData;

namespace LayoutEditor.LayoutEditorControl.Helpers
{
    public sealed class EditorStateHelper : PropertyChangedBase
    {
        #region Fields and Properties
        private readonly LayoutEditorPopulation _layoutEditorPopulation;
        private readonly UserSettingsModel _userSettings;

        private LinkedList<SingleLayoutEditor> undoStack = new LinkedList<SingleLayoutEditor>();
        private LinkedList<SingleLayoutEditor> redoStack = new LinkedList<SingleLayoutEditor>();
        private List<int> erasableTypes;
        // This stores the current state of the editor - any changes to the editor should be made to this
        private SingleLayoutEditor _currentState;
        public SingleLayoutEditor CurrentState
        {
            get { return _currentState; }
            set
            {
                _currentState = value;
                NotifyCurrentStateChanged();
            }
        }
        public bool IsUndoAvailable
        {
            get { return this.undoStack.First != null; }
        }
        public bool IsRedoAvailable
        {
            get { return this.redoStack.First != null; }
        }
        private bool _isClearAvailable = true;
        public bool IsClearAvailable
        {
            get { return this._isClearAvailable; }
            set
            {
                if (value != _isClearAvailable)
                {
                    this._isClearAvailable = value;
                    NotifyPropertyChanged(() => IsClearAvailable);
                }
            }
        }
        private bool _isSaveAvailable = true;
        public bool IsSaveAvailable
        {
            get { return _isSaveAvailable; }
            set
            {
                if (value != _isSaveAvailable)
                {
                    _isSaveAvailable = value;
                    NotifyPropertyChanged(() => IsSaveAvailable);
                }
            }
        }
        #endregion

        #region Constructors
        public EditorStateHelper(LayoutEditorPopulation layoutEditorPopulation, UserSettingsModel userSettings)
        {
            _layoutEditorPopulation = layoutEditorPopulation;
            _userSettings = userSettings;
            if (_layoutEditorPopulation.EraseOnly)
            {
                erasableTypes = layoutEditorPopulation.GetErasableTypes();
            }
            ResetState();
        }
        #endregion

        #region Methods
        // Creates a SingleLayoutEditor from a SingleLayoutLight object
        // This is used when data is received from the server, it is converted to a form more suitable
        // for working with the PlateControl.
        // The main differences are that:
        // 1. A SingleLayoutLight only lists used wells, whereas a SingleLayoutEditor has an entry for every position
        public SingleLayoutEditor CreateSingleLayoutEditor(SingleLayoutLight singleLayoutLight, int width, int height, FillSettingsModel fillSettings)
        {
            SingleLayoutEditor singleLayoutEditor = new SingleLayoutEditor(width, height);
            foreach (LayoutPos layoutPos in singleLayoutLight.LayoutPositions)
            {
                int position = layoutPos.Id;
                singleLayoutEditor.CheckPositionInRangeOneBased(position);

                LayoutPosEditor layoutPosEditor = singleLayoutEditor[position - 1];
                ModifyLayoutPosEditorForPosition(layoutPos, ref layoutPosEditor, fillSettings);
            }
            return singleLayoutEditor;
        }
        public void Clear()
        {
            PushCurrentState();
            ResetState();
        }
        public void ClearAllFlags()
        {
            PushCurrentState();
            SingleLayoutEditor newState = CurrentState.Clone();

            // Remove all flags
            newState.OrderingAcross
                    .Where(x => (x.IsFlagged))
                    .ToList()
                    .ForEach(x => x.IsFlagged = false);
            CurrentState = newState;
        }
        // Adds the current state of the editor to the undo stack, call this before changing the layout
        public void PushCurrentState()
        {
            this.undoStack.AddFirst(CurrentState.Clone());
            NotifyPropertyChanged(() => IsUndoAvailable);
        }
        public void Undo()
        {
            if (this.undoStack.First == null)
                throw new InvalidOperationException("Undo stack is empty");

            this.redoStack.AddFirst(CurrentState.Clone());
            SingleLayoutEditor undoneState = this.undoStack.First.Value;
            CurrentState = undoneState;
            this.undoStack.RemoveFirst();

            NotifyPropertyChanged(() => IsUndoAvailable);
            NotifyPropertyChanged(() => IsRedoAvailable);
        }
        public void Duplicate()
        {
            this.undoStack.AddFirst(CurrentState.Clone());
            CurrentState = undoStack.First();

            NotifyPropertyChanged(() => IsRedoAvailable);
            NotifyPropertyChanged(() => IsUndoAvailable);
        }
        public void Redo()
        {
            if (this.redoStack.First == null)
                throw new InvalidOperationException("Redo stack is empty");

            this.undoStack.AddFirst(CurrentState.Clone());
            SingleLayoutEditor redoneState = this.redoStack.First.Value;
            // ApplyChangeToEditor(redoneState);
            this.redoStack.RemoveFirst();
            CurrentState = redoneState;

            NotifyPropertyChanged(() => IsRedoAvailable);
            NotifyPropertyChanged(() => IsUndoAvailable);
        }
        // Returns the new group number
        public int FillFirstAndLast(int pos1, int pos2, int typeId, int group, Direction fillDirection, int replicates, bool rectangleMode, RepDirection replicateDirection, FillSettingsModel fillSettings)
        {
            CurrentState.CheckPositionInRangeOneBased(pos1);
            CurrentState.CheckPositionInRangeOneBased(pos2);

            // Create a copy for the new state (this is necessary as changes to the layout are made in this way to avoid unnecessary updates)
            SingleLayoutEditor newState = CurrentState.Clone();
            if (pos1 == pos2)
            {
                FillPosition(newState.LayoutPositions[pos1 - 1], typeId, group, fillSettings);
                var numPositionsOfFilledGroupType = newState.GetPositionsOfGroupType(group, typeId).Count();
                if (numPositionsOfFilledGroupType == fillSettings.Replicates)
                {
                    if (group < fillSettings.MaxGroupNum)
                        group++;
                }
            }
            else
            {
                if (rectangleMode == true)
                {
                    //group = FillRectangleMode(pos1, pos2, typeId, group, fillDirection, replicates, replicateDirection, fillSettings, newState);
                    IEnumerable<LayoutPosEditor> fillEnumerable;
                    if (fillDirection == Direction.Across)
                        fillEnumerable = newState.GetEnumerableRectangleAcross(pos1, pos2);
                    else
                        fillEnumerable = newState.GetEnumerableRectangleDown(pos1, pos2);

                    int startCol = newState.GetColFromPos(pos1);
                    int endCol = newState.GetColFromPos(pos2);

                    int startRow = newState.GetRowFromPos(pos1);
                    int endRow = newState.GetRowFromPos(pos2);

                    int colWidth = Math.Abs(endCol - startCol) + 1;
                    int rowWidth = Math.Abs(endRow - startRow) + 1;

                    int replicateCount = 1;
                    int i = 1, j = 1;
                    foreach (LayoutPosEditor layoutPosEditor in fillEnumerable)
                    {
                        FillPosition(layoutPosEditor, typeId, group, fillSettings);
                        if (replicateDirection == RepDirection.ByCol && fillDirection == Direction.Down)
                        {
                            if (replicateCount == replicates || i % rowWidth == 0)
                            {
                                replicateCount = 1;
                                group++;
                            }
                            else
                                replicateCount++;
                            if (i % rowWidth == 0)
                                i = 1;
                            else
                                i++;
                        }
                        else if (replicateDirection == RepDirection.ByCol && fillDirection == Direction.Across)
                        {
                            if (i == colWidth)
                            {
                                i = 1;
                                if (j % replicates == 0)
                                {
                                    j = 1;
                                    group++;
                                }
                                else
                                {
                                    j++;
                                    group -= colWidth - 1;
                                }
                            }
                            else
                            {
                                i++;
                                group++;
                            }
                        }
                        else if (replicateDirection == RepDirection.ByRow && fillDirection == Direction.Across)
                        {
                            if (replicateCount == replicates || i % colWidth == 0)
                            {
                                replicateCount = 1;
                                group++;
                            }
                            else
                                replicateCount++;
                            if (i % colWidth == 0)
                                i = 1;
                            else
                                i++;
                        }
                        else if (replicateDirection == RepDirection.ByRow && fillDirection == Direction.Down)
                        {
                            if (i == rowWidth)
                            {
                                i = 1;
                                if (j % replicates == 0)
                                {
                                    j = 1;
                                    group++;
                                }
                                else
                                {
                                    j++;
                                    group -= rowWidth - 1;
                                }
                            }
                            else
                            {
                                i++;
                                group++;
                            }
                        }
                    }
                }
                else
                {
                    // Get the enumerable which is the fill ordering
                    IEnumerable<LayoutPosEditor> fillEnumerable;
                    if (fillDirection == Direction.Across)
                    {
                        fillEnumerable = newState.GetEnumerableAcross(pos1, pos2);
                    }
                    else
                    {
                        fillEnumerable = newState.GetEnumerableDown(pos1, pos2);
                    }

                    // Fill with the enumerable using the specified number of replicates
                    int replicateCount = 1;
                    foreach (LayoutPosEditor layoutPosEditor in fillEnumerable)
                    {
                        FillPosition(layoutPosEditor, typeId, group, fillSettings);

                        if (replicateCount == replicates)
                        {
                            replicateCount = 1;
                            group++;
                        }
                        else
                            replicateCount++;
                    }
                }
            }
            // Store the new state - this is necessary and applies only the changes between the previous state and the new state
            CurrentState = newState;
            return group;
        }
        public bool IsPositionUsed(int position)
        {
            CurrentState.CheckPositionInRangeOneBased(position);
            int zPosition = position - 1;
            return CurrentState[zPosition].LayoutPos.IsUsed;
        }
        public bool IsPositionErasable(int position)
        {
            // Unused is not erasable
            if (!IsPositionUsed(position))
                return false;
            // If EraseOnly is not selected then all types can be erased (because Fill mode is allowed so they can add them back)
            if (!_layoutEditorPopulation.EraseOnly)
                return true;
            if (erasableTypes.Count == 0)
                return false;

            CurrentState.CheckPositionInRangeOneBased(position);
            int zPosition = position - 1;
            LayoutPos layoutPos = CurrentState[zPosition].LayoutPos;
            return (erasableTypes.Contains(layoutPos.TypeId));
        }
        public void SetPositionAndGroupUnused(int position)
        {
            CurrentState.CheckPositionInRangeOneBased(position);
            int zPosition = position - 1;
            LayoutPos layoutPos = CurrentState[zPosition].LayoutPos;
            // If the position is already Unused then do nothing
            if (layoutPos.IsUsed)
            {
                // Create a copy for the new state (this is necessary as changes to the layout are made in this way to avoid unnecessary updates)
                SingleLayoutEditor newState = CurrentState.Clone();

                List<int> typeMatches = _layoutEditorPopulation.GetTypeMatches(layoutPos.TypeId);
                if (typeMatches == null)
                {
                    // No type matches so just erase all positions of the selected position's group and type
                    EraseGroup(newState, layoutPos.TypeId, layoutPos.Group);
                }
                else
                {
                    // Type matches, so erase all types in the list of the same group number
                    foreach (int type in typeMatches)
                        EraseGroup(newState, type, layoutPos.Group);
                }
                // Store the new state - this is necessary and applies only the changes between the previous state and the new state
                CurrentState = newState;
            }
        }
        public void ToggleFlagState(int pos)
        {
            SingleLayoutEditor newState = CurrentState.Clone();
            newState.ToggleFlagState(pos);
            CurrentState = newState;
        }

        private void ResetState()
        {
            CurrentState = new SingleLayoutEditor(_layoutEditorPopulation);
        }
        private void ModifyLayoutPosEditorForPosition(LayoutPos layoutPos, ref LayoutPosEditor layoutPosEditor, FillSettingsModel fillSettings)
        {
            layoutPosEditor.LayoutPos = layoutPos;
            SampleType sampleType = fillSettings.GetSampleTypeById(layoutPos.TypeId);

            string hoverText = string.Empty;
            if (layoutPos.IsUsed)
            {
                hoverText = string.Format("{0}{1}", sampleType.Name, layoutPos.Group);
            }
            layoutPosEditor.HoverText = hoverText;
            layoutPosEditor.Colour = ColourTransformer.GetColorFromName(sampleType.Colour);
        }
        // Sets all positions of the specified type/group and adjusts group numbers of type
        private static void EraseGroup(SingleLayoutEditor newState, int typeId, int groupNum)
        {
            // The following calls SetUnused on each position which matches the group and type 
            newState.OrderingAcross
                    .Where(x => (x.LayoutPos.Group == groupNum) && (x.LayoutPos.TypeId == typeId))
                    .ToList()
                    .ForEach(x => x.SetUnused());

            // Get all positions with a group number > this group (and equal type) and decrement
            newState.OrderingAcross.Select(x => x.LayoutPos)
                                   .Where(x => (x.Group > groupNum) && (x.TypeId == typeId))
                                   .ToList()
                                   .ForEach(x => x.Group--);
        }
        private LayoutPosEditor FillPosition(LayoutPosEditor layoutPosEditor, int typeId, int group, FillSettingsModel fillSettings)
        {
            LayoutPos layoutPos = layoutPosEditor.LayoutPos;
            layoutPos.TypeId = typeId;
            layoutPos.Group = group;
            ModifyLayoutPosEditorForPosition(layoutPos, ref layoutPosEditor, fillSettings);
            return layoutPosEditor;
        }
        private void NotifyCurrentStateChanged()
        {
            NotifyPropertyChanged(() => CurrentState);
            if (_userSettings.IsFlagMode)
            {
                IsClearAvailable = CurrentState.AnyFlaggedPositions();
                // Save is always available in Flag mode
                IsSaveAvailable = true;
                // This is because when viewing a previous run the flags might be different to the flags stored with the current assay
                // (i.e. the flags for the previous run might be different to those most recently saved)
                // Save will save the flags to the current assay
            }
            else
            {
                IsClearAvailable = !CurrentState.IsPlateClear();
                // Current cannot save if plate is empty
                IsSaveAvailable = IsClearAvailable;
            }
        }
        #endregion
    }
}
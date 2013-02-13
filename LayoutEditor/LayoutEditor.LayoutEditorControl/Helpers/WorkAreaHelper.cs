using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using Layout;
using LayoutEditor.Enums;
using LayoutEditor.LayoutEditorControl.Models;
using LayoutEditor.Models;
using PlateControl2DSilverlight;

namespace LayoutEditor.LayoutEditorControl.Helpers
{
    public delegate void UpdateTipMessageEventHandler(string message);
    public delegate void LoadUserLayoutEventHandler(LoadUserLayoutModel loadUserLayoutModel);
    public delegate void UpdateControlSettingsEventHandler(ControlSettingsModel controlSettings);
    public delegate void UpdateFillSettingsEventHandler(FillSettingsModel fillSettings);

    internal class WorkAreaHelper
    {
        #region Fields
        private PlateControl2D _plateControl;
        private UserSettingsModel _userSettings;
        private SingleLayoutEditor _singleLayoutEditorCachedState;
        private LayoutEditorPopulation _layoutEditorPopulation;
        private EditorStateHelper _editorStateHelper;
        #endregion

        #region Properties
        public ControlSettingsModel ControlSettings { get; private set; }
        public FillSettingsModel FillSettings { get; private set; }
        #endregion

        #region Events
        public event UpdateTipMessageEventHandler ShowTipMessageEvent;
        public event LoadUserLayoutEventHandler LoadUserLayoutEvent;
        public event UpdateControlSettingsEventHandler UpdateControlSettingsEvent;
        public event UpdateFillSettingsEventHandler UpdateFillSettingsEvent;
        #endregion

        #region Constructors
        public WorkAreaHelper(PlateControl2D plateControl)
        {
            _plateControl = plateControl;
        }
        #endregion

        #region Methods
        public void InitializePlateControl(LayoutEditorPopulation layoutEditorPopulation)
        {
            if (layoutEditorPopulation == null)
                return;
            if (Equals(_userSettings, null))
                throw new InvalidOperationException("Please bind the UserSettings firstly");

            _layoutEditorPopulation = layoutEditorPopulation;
            ControlSettings = new ControlSettingsModel();

            _plateControl.PosMouseCursor = Cursors.Arrow;
            _plateControl.SkipCheckForFontSizeRecalc = true;

            _plateControl.LocationMouseButtonUp += new PlateControl2DSilverlight.MouseEvents.LocationMouseButtonUpEventHandler(plateControl_LocationMouseButtonUp);
            _plateControl.LocationMouseButtonDown += new PlateControl2DSilverlight.MouseEvents.LocationMouseButtonDownEventHandler(plateControl_LocationMouseButtonDown);
            _plateControl.LocationMouseOver += new PlateControl2DSilverlight.MouseEvents.LocationMouseOverEventHandler(plateControl2D_LocationMouseOver);

            FillSettings = new FillSettingsModel(_userSettings) { GroupNum = 1, SelectedSampleTypeIndex = -1 };
            FillSettings.PropertyChanged += _fillSettings_PropertyChanged;

            FillSettings.SampleTypes = _layoutEditorPopulation.SampleTypes;
            FillSettings.SelectedSampleTypeIndex = FillSettings.SampleTypes.Count - 1;

            _editorStateHelper = new EditorStateHelper(_layoutEditorPopulation, _userSettings) { };
            _editorStateHelper.PropertyChanged += _editorStateHelper_PropertyChanged;

            // When using RackMode, force fill mode to be across (down doesn't make much sense in rack mode)
            if (_layoutEditorPopulation.RackMode)
            {
                FillSettings.FillDirection = Direction.Across;
                FillSettings.ShowNextTime = true;
            }
            // Fill mode is allowed if we are NOT in EraseOnly and we are NOT in flag mode
            ControlSettings.AllowFillMode = !_layoutEditorPopulation.EraseOnly && !_userSettings.IsFlagMode;
            ControlSettings.IsFlagMode = _userSettings.IsFlagMode;
            // Clear button is available unless in Erase only mode (although it is only enabled when there is something to clear).
            ControlSettings.AllowClearButton = !_layoutEditorPopulation.EraseOnly;
            // If Fill mode is not allowed then set SelectedSampleTypeIndex to -1 so ListBox has no items selected (i.e. it looks just like a legend display)
            if (!ControlSettings.AllowFillMode)
                FillSettings.SelectedSampleTypeIndex = -1;
            ControlSettings.SelectionCommand = ControlSettings.IsFlagMode ? SelectionCommand.Flag : SelectionCommand.Erase;

            if (LoadUserLayoutEvent != null)
            {
                var loadUserLayoutmodel = new LoadUserLayoutModel();
                loadUserLayoutmodel.UserSettings = _userSettings;
                loadUserLayoutmodel.IsFlagMode = ControlSettings.IsFlagMode;
                LoadUserLayoutEvent(loadUserLayoutmodel);
            }
            OnUpdateControlSettings();
        }
        public void OnUpdateUserLayout(SingleLayoutLight userLayout, string flaggedPositions)
        {
            // The UserLayout has changed, therefore convert this to a SingleLayoutEditor and update the EditorState
            var singleLayoutEditor = _editorStateHelper.CreateSingleLayoutEditor(userLayout,
                                                  _layoutEditorPopulation.Width,
                                                  _layoutEditorPopulation.Height,
                                                  FillSettings);
            // Apply flags to singleLayoutEditor
            if (ControlSettings.IsFlagMode)
                singleLayoutEditor.InitFlaggedPositionsFromCsv(flaggedPositions);
            FillSettings.MaxGroupNum = singleLayoutEditor.NumPositions;
            // Update the editor state
            _editorStateHelper.CurrentState = singleLayoutEditor;
        }
        public void ApplyUserSettings(UserSettingsModel userSettings)
        {
            _userSettings = userSettings;
            if (string.IsNullOrEmpty(_userSettings.UserId))
                throw new ArgumentException(ErrorHelper.UserIdErrorMessage);
            if (_userSettings.IsFlagMode)
            {
                UpdateTipMessage("Delete Flags");
                if (_userSettings.IsPreviousRunEdit)
                    UpdateTipMessage("Displayed flags are from previous analysis.  Save will store flags to your settings for this assay.");
            }
        }
        public void ApplySelectionCommand(SelectionCommand selectionCommand)
        {
            ControlSettings.SelectionCommand = selectionCommand;
            UpdateTipMessage(ControlSettings.SelectionCommand);
            // Setup the PlateControl selection mode accordingly
            switch (ControlSettings.SelectionCommand)
            {
                case SelectionCommand.Fill:
                    _plateControl.SelectionMode = PlateControl2DSilverlight.Enumerations.SelectingMode.FirstAndLast;
                    _plateControl.PosMouseCursor = Cursors.Hand;
                    break;
                case SelectionCommand.Erase:
                    _plateControl.SelectionMode = PlateControl2DSilverlight.Enumerations.SelectingMode.None;
                    _plateControl.PosMouseCursor = Cursors.Eraser;
                    break;
                case SelectionCommand.Flag:
                    _plateControl.SelectionMode = PlateControl2DSilverlight.Enumerations.SelectingMode.Single;
                    _plateControl.PosMouseCursor = Cursors.Arrow;
                    break;
            }
        }
        public void Clear()
        {
            if (ControlSettings.IsFlagMode)
            {
                _editorStateHelper.ClearAllFlags();
            }
            else
            {
                _editorStateHelper.Clear();
                // After a clear, switch to fill mode
                ControlSettings.SelectionCommand = SelectionCommand.Fill;
                OnUpdateControlSettings();
            }
        }
        public void UpdateFillSettings()
        {
            var childWindowFillSettings = new FillSettingsPopup();
            childWindowFillSettings.DataContext = FillSettings;
            childWindowFillSettings.ShowNonInteractive();
        }
        public void Undo()
        {
            _editorStateHelper.Undo();
        }
        public void Redo()
        {
            _editorStateHelper.Redo();
        }

        /// <summary>
        /// Updating LayoutControl settings (AllowFillMode, SelectionCommand, IsUndoAvailable, etc)
        /// </summary>
        private void OnUpdateControlSettings()
        {
            FieldsHelper.CopyProperties(ControlSettings, _editorStateHelper);
            if (UpdateControlSettingsEvent != null)
                UpdateControlSettingsEvent(ControlSettings);
        }
        private void UpdateTipMessage(string message)
        {
            if (ShowTipMessageEvent != null)
                ShowTipMessageEvent(message);
        }
        private void UpdateTipMessage(SelectionCommand selectionCommand)
        {
            switch (selectionCommand)
            {
                case SelectionCommand.Erase:
                    UpdateTipMessage("Select the sample groups to remove, i.e. those that were not read.");
                    break;
                case SelectionCommand.Fill:
                    UpdateTipMessage("Select a single position or drag the mouse to fill multiple positions.");
                    break;
                case SelectionCommand.Flag:
                    UpdateTipMessage("Click a position to flag it.");
                    break;
            }
        }
        private void UpdatePlateControlPosition(LayoutPosEditor layoutPosEditor)
        {
            uint position = (uint)layoutPosEditor.LayoutPos.Id;
            Debug.Assert(_plateControl.PositionsAcross > 0);
            Debug.Assert(_plateControl.PositionsDown > 0);

            _plateControl.SetPosHoverText(position, layoutPosEditor.HoverText);
            _plateControl.SetInnerColour(position, layoutPosEditor.Colour);
            _plateControl.SetPosIsFlagged(position, layoutPosEditor.IsFlagged);

            string positionData = "";
            if (layoutPosEditor.LayoutPos.IsUsed)
            {
                positionData = layoutPosEditor.LayoutPos.Group.ToString();
            }
            _plateControl.SetPointString(position, positionData);
        }
        private void plateControl2D_LocationMouseOver(PlateControl2DSilverlight.Enumerations.LocationType locationType, int iData)
        {
            if (locationType == PlateControl2DSilverlight.Enumerations.LocationType.Position)
                LocationMouseOver(iData);
            else
            {
                // Deal with the special case when the user move the mouse outside the area while dragging
                // e.g. Left click on hold mouse down on position b3 move mouse up (whilst holding down) 
                // Release mouse outside area
                // Move mouse back into area - (this mouse behaves as if the mouse is still down)
                LocationMouseOver(null);
            }
        }
        private void plateControl_LocationMouseButtonDown(PlateControl2DSilverlight.Enumerations.MouseButton mouseButton, PlateControl2DSilverlight.Enumerations.LocationType locationType, int iData)
        {
            if (mouseButton == PlateControl2DSilverlight.Enumerations.MouseButton.Left)
            {
                if (locationType == PlateControl2DSilverlight.Enumerations.LocationType.Position)
                    LocationMouseDown(iData);
                else
                    LocationMouseDown(null);
            }
        }
        private void plateControl_LocationMouseButtonUp(PlateControl2DSilverlight.Enumerations.MouseButton mouseButton, PlateControl2DSilverlight.Enumerations.LocationType locationType, int iData)
        {
            if (mouseButton == PlateControl2DSilverlight.Enumerations.MouseButton.Left)
            {
                if (locationType == PlateControl2DSilverlight.Enumerations.LocationType.Position)
                    LocationMouseUp(iData);
                else
                    LocationMouseUp(null);
            }
        }
        private void _editorStateHelper_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "CurrentState")
            {
                // The CurrentState property of the EditorState has changed, this means that the PlateControl needs redrawing for the new state
                // Use this to update the plate control
                ApplyChangeToEditor(((EditorStateHelper)sender).CurrentState);
            }
            OnUpdateControlSettings();
        }
        private void ApplyChangeToEditor(SingleLayoutEditor newState)
        {
            //Stopwatch stopWatch = DiagnosticHelpers.GetStartedStopWatch();
            if (_singleLayoutEditorCachedState != null)
            {
                Debug.Assert(newState.NumPositions == _singleLayoutEditorCachedState.NumPositions);
                Debug.Assert(newState.LayoutPositions.Count == _singleLayoutEditorCachedState.NumPositions);
                Debug.Assert(newState.LayoutPositions.Count == _singleLayoutEditorCachedState.LayoutPositions.Count);
            }
            else
            {
                // Only use batch mode if there is no cached state
                _plateControl.BatchMode = true;

                _plateControl.PositionsAcross = newState.Width;
                _plateControl.PositionsDown = newState.Height;
                _plateControl.PlateColour = Colors.White;
                _plateControl.HeaderColour = Colors.White;
            }
            // Only make changes that are visually different (if there is a previous state cached)
            // This is faster and does not require a Redraw or use of Batch mode
            bool update;
            for (int pos = 0; pos < newState.NumPositions; pos++)
            {
                update = true;
                if (_singleLayoutEditorCachedState != null)
                {
                    update = !_singleLayoutEditorCachedState[pos].IsVisuallyEqual(newState[pos]);
                }
                if (update)
                {
                    UpdatePlateControlPosition(newState[pos]);
                }
            }
            // End batch mode and use redraw if there was no previous cached state
            if (_singleLayoutEditorCachedState == null)
            {
                _plateControl.BatchMode = false;
                _plateControl.Redraw();
            }
            _singleLayoutEditorCachedState = newState;
        }
        private void _fillSettings_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (UpdateFillSettingsEvent != null)
                UpdateFillSettingsEvent(FillSettings);
        }
        private void FillSingle(int position)
        {
            FillFirstAndLast(position, position);
        }
        private void FillFirstAndLast(int first, int last)
        {
            previewMode = false;
            _editorStateHelper.PushCurrentState();
            int newNextGroupNum = _editorStateHelper.FillFirstAndLast(first, last,
                                        FillSettings.SelectedSampleType.Id,
                                        FillSettings.GroupNum,
                                        FillSettings.FillDirection,
                                        FillSettings.Replicates,
                                        FillSettings.RectangleMode,
                                        FillSettings.ReplicateDirection,
                                        FillSettings);
            // If not Unused then apply the new group number
            if (FillSettings.SelectedSampleType.Id != 1)
            {
                if (newNextGroupNum <= FillSettings.MaxGroupNum)
                    FillSettings.GroupNum = newNextGroupNum;
            }
        }
        private void FlagPosition(int iData)
        {
            _editorStateHelper.PushCurrentState();
            _editorStateHelper.ToggleFlagState(iData);
        }
        private void EraseForPosition(int position)
        {
            if (_editorStateHelper.IsPositionErasable(position))
            {
                // If the state has not yet been pushed store it now.
                // This can occur if the user attempts to erase an Unused group then moves to a used group.
                if (!this.statePushedForMove)
                {
                    _editorStateHelper.PushCurrentState();
                    this.statePushedForMove = true;
                }
                _editorStateHelper.SetPositionAndGroupUnused(position);
            }
            else
            {
                // The position is not erasable - so just do nothing
                // (There is no need to display an error message)
            }
        }

        #region MouseHandling
        bool mouseDown = false;
        private int clickFirstPosition = -1; // When a left click occurs on a position this is the first position it was left clicked onv
        private bool statePushedForMove;     // Used to deal with pushing state onto undo stack when erasing

        private void LocationMouseOver(int? data)
        {
            var isPositionErasable = false;
            if (data.HasValue)
            {
                switch (ControlSettings.SelectionCommand)
                {
                    case SelectionCommand.Erase:
                        // Set the cursor according to the type stored for this position
                        // Get the type from the control
                        if (this.mouseDown)
                            EraseForPosition(data.Value);
                        isPositionErasable = _editorStateHelper.IsPositionErasable(data.Value);
                        break;
                    case SelectionCommand.Flag:
                        if (_editorStateHelper.IsPositionUsed(data.Value))
                            isPositionErasable = false;
                        else
                        {
                            // Unfortunatey no support for blocked cursor in silverlight - could use a custom cursor perhaps
                            isPositionErasable = false;
                        }
                        break;
                }
            }
            else
            {
                // Deal with the special case when the user move the mouse outside the area whilst dragging
                // e.g. Left click on hold mouse down on position b3 move mouse up (whilst holding down) 
                // Release mouse outside area
                // Move mouse back into area - (this mouse behaves as if the mouse is still down)                
                this.mouseDown = false;
            }
            _plateControl.PosMouseCursor = isPositionErasable ? Cursors.Eraser : Cursors.Arrow;
        }
        private void LocationMouseDown(int? data)
        {
            if (data.HasValue)
            {
                switch (ControlSettings.SelectionCommand)
                {
                    case SelectionCommand.Flag:
                        this.clickFirstPosition = data.Value;
                        break;
                    case SelectionCommand.Fill:
                        this.clickFirstPosition = data.Value;
                        break;
                    case SelectionCommand.Erase:
                        // Store the current state because we are about to make a change - this is done here rather than in SetPositionAndGroupUnused
                        // because we want to undo the whole erase operation and not each individual removed group.
                        if (_editorStateHelper.IsPositionErasable(data.Value))
                        {
                            // The position is a used position, so store the state now before the changes is made
                            _editorStateHelper.PushCurrentState();
                            this.statePushedForMove = true;
                        }
                        else
                        {
                            // If the erase operation was started on an Unused group then do not store the state for undo yet (as they have not made any changes)
                            this.statePushedForMove = false;
                        }
                        EraseForPosition(data.Value);
                        break;
                }
            }
            this.mouseDown = true;
        }
        private void LocationMouseUp(int? data)
        {
            if (data.HasValue)
            {
                switch (ControlSettings.SelectionCommand)
                {
                    case SelectionCommand.Fill:
                        //keep the last position when mouse is up
                        this.clickLastPosition = data.Value;
                        if (this.clickFirstPosition != -1)
                        {
                            if (FillSettings.ShowNextTime)
                            {
                                //save the current direction and replicates
                                this.previewDirection = FillSettings.FillDirection;
                                this.previewReplicates = FillSettings.Replicates;
                                this.previewRectangleMode = FillSettings.RectangleMode;
                                this.previewReplicateDirection = FillSettings.ReplicateDirection;
                                this.previewGroupNum = FillSettings.GroupNum;
                                this.previewMode = true;

                                PreviewFillFirstAndLast();

                                var childWindowFillSettings = new FillSettingsPopup();
                                childWindowFillSettings.DataContext = FillSettings;
                                childWindowFillSettings.Closed += new EventHandler(FillSettingsDialog_Closed);
                                childWindowFillSettings.radioButtonAcross.Click += new RoutedEventHandler(radioButtonAcross_Click);
                                childWindowFillSettings.radioButtonDown.Click += new RoutedEventHandler(radioButtonDown_Click);
                                childWindowFillSettings.radioReplicateDirectionByCol.Click += new RoutedEventHandler(radioReplicateDirectionByCol_Click);
                                childWindowFillSettings.radioReplicateDirectionByRow.Click += new RoutedEventHandler(radioReplicateDirectionByRow_Click);
                                childWindowFillSettings.checkboxRectangleMode.Click += new RoutedEventHandler(checkboxRectangleMode_Click);
                                childWindowFillSettings.textBoxReplicates.TextChanged += new TextChangedEventHandler(textBoxReplicates_TextChanged);
                                childWindowFillSettings.textBoxGroupNum.TextChanged += new TextChangedEventHandler(textBoxGroupNum_TextChanged);
                                childWindowFillSettings.ShowInteractive();

                                return;
                            }
                            else
                            {
                                FillFirstAndLast(this.clickFirstPosition, data.Value);
                            }
                        }
                        break;
                    case SelectionCommand.Flag:
                        // This checks that mouse up is on the same position as mouse down (so user can cancel the flag by moving to outside the well on mouse up)
                        if (this.clickFirstPosition == data.Value)
                        {
                            if (!_editorStateHelper.IsPositionUsed(data.Value))
                                MessageBox.Show("Only positions with samples can be flagged.");
                            else
                                FlagPosition(data.Value);
                        }
                        break;
                }
                this.clickFirstPosition = -1;
            }
            this.mouseDown = false;
        }

        private Direction previewDirection;
        private int previewReplicates;
        private bool previewIsUndoAvailable;
        private bool previewRectangleMode;
        private RepDirection previewReplicateDirection;
        private int previewGroupNum;
        private bool previewMode;
        private int clickLastPosition = -1; // When a left click occurs on a position this is the last position it was left clicked on

        private void radioButtonDown_Click(object sender, RoutedEventArgs e)
        {
            this.previewDirection = Direction.Down;
            PreviewFillFirstAndLast();
        }

        private void radioButtonAcross_Click(object sender, RoutedEventArgs e)
        {
            this.previewDirection = Direction.Across;
            PreviewFillFirstAndLast();
        }

        private void radioReplicateDirectionByCol_Click(object sender, RoutedEventArgs e)
        {
            this.previewReplicateDirection = RepDirection.ByCol;
            PreviewFillFirstAndLast();
        }

        private void radioReplicateDirectionByRow_Click(object sender, RoutedEventArgs e)
        {
            this.previewReplicateDirection = RepDirection.ByRow;
            PreviewFillFirstAndLast();
        }

        private void checkboxRectangleMode_Click(object sender, RoutedEventArgs e)
        {
            var chkRectMode = (CheckBox)sender;
            if (chkRectMode.IsChecked == true)
                this.previewRectangleMode = true;
            else
                this.previewRectangleMode = false;
            PreviewFillFirstAndLast();
        }

        private void textBoxReplicates_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox txtReplicates = (TextBox)sender;
            if (!Validation.GetHasError(txtReplicates))
            {
                try
                {
                    this.previewReplicates = Convert.ToInt32(txtReplicates.Text);
                }
                catch (Exception)
                { }
                if (this.previewReplicates > 0 && this.previewReplicates <= FillSettings.MaxGroupNum)
                    PreviewFillFirstAndLast();
                else
                    MessageBox.Show("The number of replicates is invalid.");
            }
        }

        private void textBoxGroupNum_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (this.previewMode)
            {
                TextBox txtGroupNum = (TextBox)sender;
                if (!Validation.GetHasError(txtGroupNum))
                {
                    try
                    {
                        this.previewGroupNum = Convert.ToInt32(txtGroupNum.Text);
                    }
                    catch (Exception)
                    { }
                    if (this.previewGroupNum > 0 && this.previewGroupNum <= FillSettings.MaxGroupNum)
                        PreviewFillFirstAndLast();
                    else
                        MessageBox.Show("The group start number is invalid.");
                }
            }
        }

        public void PreviewFillFirstAndLast()
        {
            if (this.clickFirstPosition != -1 && this.clickLastPosition != -1)
            {
                if (_editorStateHelper.IsUndoAvailable && this.previewIsUndoAvailable)
                    _editorStateHelper.Undo();

                _editorStateHelper.PushCurrentState();

                _editorStateHelper.FillFirstAndLast(
                        this.clickFirstPosition,
                        this.clickLastPosition,
                        FillSettings.SelectedSampleType.Id,
                        this.previewGroupNum,
                        this.previewDirection,
                        this.previewReplicates,
                        this.previewRectangleMode,
                        this.previewReplicateDirection,
                        FillSettings);

                this.previewIsUndoAvailable = true;
            }
        }

        public void FillSettingsDialog_Closed(object sender, EventArgs e)
        {
            var dlg = (FillSettingsPopup)sender;
            bool? result = dlg.DialogResult;

            _editorStateHelper.Undo();

            if (result == true)
            {
                if (this.clickFirstPosition != -1 && this.clickLastPosition != -1)
                    FillFirstAndLast(this.clickFirstPosition, this.clickLastPosition);
            }

            this.mouseDown = false;
            this.previewIsUndoAvailable = false;
        }
        #endregion
        #endregion
    }
}
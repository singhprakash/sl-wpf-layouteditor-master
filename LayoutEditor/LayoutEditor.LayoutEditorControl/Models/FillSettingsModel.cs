using System;
using System.Collections.Generic;
using System.Linq;
using Layout;
using LayoutEditor.Enums;
using LayoutEditor.Models;

namespace LayoutEditor.LayoutEditorControl.Models
{
    public sealed class FillSettingsModel : PropertyChangedBase
    {
        #region Fields
        private readonly UserSettingsModel _userSettings;
        #endregion

        #region Properties
        private int _groupNum;
        public int GroupNum
        {
            get { return _groupNum; }
            set
            {
                if (_groupNum != value)
                {
                    if (value < 1)
                        throw new ArgumentException(string.Format("The group number must be >= 1."));
                    if (value > this._maxGroupNum)
                        throw new ArgumentException(string.Format("The group number is too high."));

                    _groupNum = value;
                    NotifyPropertyChanged(() => GroupNum);
                }
            }
        }

        private int _maxGroupNum = 1;
        public int MaxGroupNum
        {
            get { return _maxGroupNum; }
            set { _maxGroupNum = value; NotifyPropertyChanged(() => MaxGroupNum); }
        }

        private List<SampleType> _sampleTypes = new List<SampleType>();
        public List<SampleType> SampleTypes
        {
            get { return _sampleTypes; }
            set
            {
                if (_sampleTypes != value)
                {
                    _sampleTypes = value;
                    NotifyPropertyChanged(() => SampleTypes);
                }
            }
        }

        private int _selectedSampleTypeIndex;
        public int SelectedSampleTypeIndex
        {
            get { return _selectedSampleTypeIndex; }
            set
            {
                if (_selectedSampleTypeIndex != value)
                {
                    _selectedSampleTypeIndex = value;
                    //Whenever the SampleType changes, reset the group number
                    GroupNum = 1;
                    NotifyPropertyChanged(() => SelectedSampleTypeIndex);
                    NotifyPropertyChanged(() => SelectedSampleType);
                }
                _selectedSampleTypeIndex = value;
            }
        }

        public SampleType SelectedSampleType
        {
            get { return this._sampleTypes[this._selectedSampleTypeIndex]; }
        }

        public int Replicates
        {
            get { return _userSettings.Replicates; }
            set
            {
                if (value != _userSettings.Replicates)
                {
                    if (value <= 0)
                        throw new ArgumentException(string.Format("The number of replicates must be >= 1."));
                    if ((value > this._maxGroupNum) && (this._maxGroupNum > 0))
                        throw new ArgumentException(string.Format("The number of replicates number is too high."));

                    _userSettings.Replicates = value;
                    NotifyPropertyChanged(() => Replicates);
                }
            }
        }

        public Direction FillDirection
        {
            get { return _userSettings.FillDirection; }
            set
            {
                if (value != _userSettings.FillDirection)
                {
                    _userSettings.FillDirection = value;
                    NotifyPropertyChanged(() => FillDirection);
                }
            }
        }

        public bool FillDirectionIsAcross
        {
            get { return FillDirection == Direction.Across; }
            set
            {
                if (value == true)
                    FillDirection = Direction.Across;
                else
                    FillDirection = Direction.Down;
            }
        }

        public bool FillDirectionIsDown
        {
            get { return FillDirection == Direction.Down; }
            set
            {
                if (value == true)
                    FillDirection = Direction.Down;
                else
                    FillDirection = Direction.Across;
            }
        }

        public bool ReplicateDirectionIsRow
        {
            get { return ReplicateDirection == RepDirection.ByRow; }
            set
            {
                if (value == true)
                    ReplicateDirection = RepDirection.ByRow;
                else
                    ReplicateDirection = RepDirection.ByCol;
            }
        }

        public bool ReplicateDirectionIsColumn
        {
            get { return ReplicateDirection == RepDirection.ByCol; }
            set
            {
                if (value == true)
                    ReplicateDirection = RepDirection.ByCol;
                else
                    ReplicateDirection = RepDirection.ByRow;
            }
        }

        public SampleType GetSampleTypeById(int typeId)
        {
            var type = _sampleTypes.FirstOrDefault(x => x.Id == typeId);
            if (type == null)
                throw new ArgumentException(string.Format("TypeId {0} was not found in the this.fillSettings.SampleTypes (which contains {1}) sample types",
                    typeId,
                    this._sampleTypes.Count.ToString()));
            return type;
        }

        public bool ShowNextTime
        {
            get { return _userSettings.ShowNextTime; }
            set
            {
                if (value != _userSettings.ShowNextTime)
                {
                    _userSettings.ShowNextTime = value;
                    NotifyPropertyChanged(() => ShowNextTime);
                }
            }
        }

        public bool RectangleMode
        {
            get { return _userSettings.RectangleMode; }
            set
            {
                if (value != _userSettings.RectangleMode)
                {
                    _userSettings.RectangleMode = value;
                    NotifyPropertyChanged(() => RectangleMode);
                }
            }
        }

        public RepDirection ReplicateDirection
        {
            get { return _userSettings.ReplicateDirection; }
            set
            {
                if (value != _userSettings.ReplicateDirection)
                {
                    _userSettings.ReplicateDirection = value;
                    NotifyPropertyChanged(() => ReplicateDirection);
                }
            }
        }
        #endregion

        #region Constructors
        public FillSettingsModel(UserSettingsModel userSettings)
        {
            _userSettings = userSettings;
        }
        #endregion
    }
}
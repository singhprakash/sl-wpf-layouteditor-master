using LayoutEditor.Enums;

namespace LayoutEditor.Models
{
    public sealed class UserSettingsModel : ModelBase
    {
        #region Properties
        private long _associatedAssayId;
        public long AssociatedAssayId
        {
            get { return _associatedAssayId; }
            set { _associatedAssayId = value; NotifyPropertyChanged(() => AssociatedAssayId); }
        }

        private string _layoutId;
        public string LayoutId
        {
            get { return _layoutId; }
            set { _layoutId = value; NotifyPropertyChanged(() => LayoutId); }
        }

        private string _userId;
        public string UserId
        {
            get { return _userId; }
            set { _userId = value; NotifyPropertyChanged(() => UserId); }
        }

        private string _serviceAddress;
        public string ServiceAddress
        {
            get { return _serviceAddress; }
            set { _serviceAddress = value; NotifyPropertyChanged(() => ServiceAddress); }
        }

        private string _serverRoot;
        public string ServerRoot
        {
            get { return _serverRoot; }
            set { _serverRoot = value; NotifyPropertyChanged(() => ServerRoot); }
        }

        private bool _isFlagMode;
        public bool IsFlagMode
        {
            get { return _isFlagMode; }
            set { _isFlagMode = value; NotifyPropertyChanged(() => IsFlagMode); }
        }

        private bool _isPreviousRunEdit;
        public bool IsPreviousRunEdit
        {
            get { return _isPreviousRunEdit; }
            set { _isPreviousRunEdit = value; NotifyPropertyChanged(() => IsPreviousRunEdit); }
        }

        private string _resultsPathFormat;
        public string ResultsPathFormat
        {
            get { return _resultsPathFormat; }
            set { _resultsPathFormat = value; NotifyPropertyChanged(() => ResultsPathFormat); }
        }

        private string _previousRunId;
        public string PreviousRunId
        {
            get { return _previousRunId; }
            set { _previousRunId = value; NotifyPropertyChanged(() => PreviousRunId); }
        }

        private string _previousRunOriginator;
        public string PreviousRunOriginator
        {
            get { return _previousRunOriginator; }
            set { _previousRunOriginator = value; NotifyPropertyChanged(() => PreviousRunOriginator); }
        }

        private Direction _fillDirection;
        public Direction FillDirection
        {
            get { return _fillDirection; }
            set { _fillDirection = value; NotifyPropertyChanged(() => FillDirection); }
        }

        private int _replicates;
        public int Replicates
        {
            get { return _replicates; }
            set { _replicates = value; NotifyPropertyChanged(() => Replicates); }
        }

        private bool _showNextTime;
        public bool ShowNextTime
        {
            get { return _showNextTime; }
            set { _showNextTime = value; NotifyPropertyChanged(() => ShowNextTime); }
        }

        private bool _rectangleMode;
        public bool RectangleMode
        {
            get { return _rectangleMode; }
            set { _rectangleMode = value; NotifyPropertyChanged(() => RectangleMode); }
        }

        private RepDirection _replicateDirection;
        public RepDirection ReplicateDirection
        {
            get { return _replicateDirection; }
            set { _replicateDirection = value; NotifyPropertyChanged(() => ReplicateDirection); }
        }
        //Properties, which are not implemented INotifyPropertyChanged interface
        public bool IsMultiple { get; set; }
        public MultipleLayoutType MultipleLayout { get; set; }
        public string ContainerName { get; set; }
        #endregion
    }
}
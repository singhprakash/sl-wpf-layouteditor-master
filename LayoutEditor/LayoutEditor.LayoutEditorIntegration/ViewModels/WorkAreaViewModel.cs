using System.Collections.Generic;
using System.Diagnostics;
using Layout;
using LayoutEditor.Common.Enums;
using LayoutEditor.Common.Events;
using LayoutEditor.Common.Services;
using LayoutEditor.Common.ViewModels;
using LayoutEditor.LayoutEditorControl.Models;
using LayoutEditor.LayoutEditorIntegration.Views;
using LayoutEditor.Models;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.ServiceLocation;

namespace LayoutEditor.LayoutEditorIntegration.ViewModels
{
    public class WorkAreaViewModel : ViewModelBase
    {
        #region Fields
        private readonly ILayoutEditorPopulationService _layoutEditorPopulationService;
        private readonly IUserSettingsService _userSettingsService;
        //To Delete
        private readonly IUserLayoutService _userLayoutService;
        #endregion

        #region Properties
        public LayoutEditorPopulation LayoutEditorPopulation { get; private set; }
        public UserSettingsModel UserSettings { get { return _userSettingsService.UserSettings; } }
        public string LayoutEditorPopulationXML { get; private set; }
        public string UserLayoutXML { get; set; }
        public SingleLayoutEditor CurrentState { get; private set; }

        //To Delete
        private SelectionCommand selectionCommand;
        public SelectionCommand SelectionCommand
        {
            get { return this.selectionCommand; }
            set
            {
                if (value != this.selectionCommand)
                {
                    this.selectionCommand = value;
                    NotifyPropertyChanged(() => SelectionCommand);
                }
            }
        }
        public UpdateUserLayoutModel UpdatedUserLayout { get; set; }
        #endregion

        #region Commands
        public DelegateCommand<string> SetLayoutEditorPopulationXMLCommand { get; private set; }
        public DelegateCommand GetUserLayoutXMLCommand { get; private set; }
        public DelegateCommand<SingleLayoutEditor> SaveCommand { get; private set; }
        public DelegateCommand<SingleLayoutEditor> CurrentStateChangeCommand { get; private set; }

        //To Delete
        public DelegateCommand<LoadUserLayoutModel> LoadUserLayoutCommand { get; private set; }
        #endregion

        #region Constructors
        public WorkAreaViewModel(IEventAggregator eventAggregator)
            : base(eventAggregator)
        {
            _layoutEditorPopulationService = ServiceLocator.Current.GetInstance<ILayoutEditorPopulationService>();
            _userSettingsService = ServiceLocator.Current.GetInstance<IUserSettingsService>();

            GetUserLayoutXMLCommand = new DelegateCommand(OnGetUserLayoutXML);
            SetLayoutEditorPopulationXMLCommand = new DelegateCommand<string>(OnSetLayoutEditorPopulationXML);
            SaveCommand = new DelegateCommand<SingleLayoutEditor>(OnSaveAndClose);
            CurrentStateChangeCommand = new DelegateCommand<SingleLayoutEditor>(OnUpdateCurrentState);

            //To Delete
            _userLayoutService = ServiceLocator.Current.GetInstance<IUserLayoutService>();
            LoadUserLayoutCommand = new DelegateCommand<LoadUserLayoutModel>(OnLoadUserLayout);
            //End of To Delete

            EventsSubscribe();
            LoadData();
        }
        #endregion

        #region Methods
        public void OnMenuItemClick(MainMenuCommandTypes itemType)
        {
            switch (itemType)
            {
                case MainMenuCommandTypes.Setup:
                    OnSetupLayoutEditor(); break;
                default: return;
            }
        }
        public void OnGetUserLayoutXML()
        {
            if (CurrentState == null)
                UserLayoutXML = null;
            else
                UserLayoutXML = _userLayoutService.SerializeUserLayout(CurrentState);
            NotifyPropertyChanged(() => UserLayoutXML);
        }
        public void OnSetLayoutEditorPopulationXML(string data)
        {
            LayoutEditorPopulationXML = data;
            NotifyPropertyChanged(() => LayoutEditorPopulationXML);
            NotifyPropertyChanged(() => UserSettings);

            try
            {
                LayoutEditorPopulation = _layoutEditorPopulationService.LoadDataFromXML(data);
                NotifyPropertyChanged(() => LayoutEditorPopulation);
                //Load User Layout
                try
                {
                    _userLayoutService.DeserializeUserLayout(UserLayoutXML);
                }
                catch
                {
                    UserLayoutXML = string.Empty;
                    OnShowErrorMessage("Please input valid UserLayoutXML");
                }
            }
            catch
            {
                LayoutEditorPopulation = null;
                LayoutEditorPopulationXML = string.Empty;
                OnShowErrorMessage("Please input valid LayoutEditorPopulationXML");
                NotifyPropertyChanged(() => LayoutEditorPopulation);
            }
        }


        private void OnUpdateCurrentState(SingleLayoutEditor obj)
        {
            CurrentState = obj;
        }
        private void EventsSubscribe()
        {
            _eventAggregator.GetEvent<SelectMenuItemEvent>().Subscribe(OnMenuItemClick);
            //To Delete
            _eventAggregator.GetEvent<UserLayoutUpdateEvent>().Subscribe(OnUpdateUserLayout);
        }
        private void OnSaveAndClose(SingleLayoutEditor currentState)
        {
            OnShowErrorMessage("Save and Close...");
        }
        private void OnSetupLayoutEditor()
        {
            var popup = new SetupView();
            popup.DataContext = this;
            popup.Show();
        }

        //To Delete
        public void OnUpdateUserLayout(UserLayout obj)
        {
            UpdatedUserLayout = new UpdateUserLayoutModel()
            {
                UserLayout = obj.SingleLayoutLight,
                FlaggedPositions = _userLayoutService.GetFlaggedPositions()
            };
            NotifyPropertyChanged(() => UpdatedUserLayout);
        }

        private void ShowValidationError(List<Layout.ValidationError> errors)
        {
            var messageService = ServiceLocator.Current.GetInstance<IMessageService>();
            messageService.ShowLayoutValidationErrors(errors);
        }
        private void OnLoadUserLayout(LoadUserLayoutModel obj)
        {
            if (obj.IsFlagMode)
                LoadLayoutForFlagMode(obj.UserSettings);
            else
                LoadLayoutForEdit(obj.UserSettings);
        }
        private void LoadLayoutForFlagMode(UserSettingsModel userSettings)
        {
            // In Flag mode layout ID is either a guid or a single number to represent a fixed layout
            Debug.Assert(!string.IsNullOrEmpty(userSettings.UserId));
            Debug.Assert(!string.IsNullOrEmpty(userSettings.LayoutId));

            // If using a previous run which is from a different user (i.e. a support using looking at someone elses dat)
            // Then use the id of the actual originator
            if (!string.IsNullOrEmpty(userSettings.PreviousRunOriginator) && (userSettings.UserId != userSettings.PreviousRunOriginator))
                UserSettings.UserId = userSettings.PreviousRunOriginator;
            if (userSettings.LayoutId.Length == 1)
            {
                int layoutNum = int.Parse(userSettings.LayoutId);
                _userLayoutService.LoadFixedLayoutXmlWithFlagsFromService(userSettings.UserId, userSettings.AssociatedAssayId, layoutNum, userSettings.PreviousRunId);
            }
            else
                _userLayoutService.LoadUserLayoutWithFlagsXmlFromService(userSettings.AssociatedAssayId, userSettings.UserId, userSettings.LayoutId, userSettings.PreviousRunId);
        }
        private void LoadLayoutForEdit(UserSettingsModel userSettings)
        {
            // If a layout ID has been specified then load it now from the service
            if (!string.IsNullOrEmpty(userSettings.LayoutId))
            {
                Debug.Assert(!string.IsNullOrEmpty(userSettings.UserId));
                _userLayoutService.LoadUserLayoutXmlFromService(userSettings.UserId, userSettings.LayoutId);
                // If the user has selected to edit a layout which belongs to a previous run then we don not want to edit that layout as it will 
                // affect the previously stored run data.  Instead any changes made should be stored to a new layout.
                // To achieve this we reset the layout id, this will mean when the SaveUserLayoutToService is called the changes will be stored
                // to a new MLO, rather than overwrite the existing.
                if (userSettings.IsPreviousRunEdit)
                    userSettings.LayoutId = string.Empty;
            }
            else
            {
                // If no layout ID has specified we are creating a new layout
                // To save bothering the server just create it here first
                if (_userLayoutService.InitEmptyUserLayout(LayoutEditorPopulation))
                {
                    // If using an empty layout (no default layout) then fill is the default selection tool.
                    // However, EraseOnly as been set (which == !AllowFillMode) then there is a problem
                    SelectionCommand = SelectionCommand.Fill;
                }
                else
                {
                    // If using an default layout then set the default selection tool
                    SelectionCommand = userSettings.IsFlagMode ? SelectionCommand.Flag : SelectionCommand.Erase;
                }
            }
        }
        #endregion
    }
}
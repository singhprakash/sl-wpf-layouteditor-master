using System.Collections.Generic;
using System.Diagnostics;
using Layout;
using LayoutEditor.Common.Events;
using LayoutEditor.Common.Services;
using LayoutEditor.LayoutEditorControl.Models;
using LayoutEditor.Models;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.ServiceLocation;

namespace LayoutEditor.Common.ViewModels
{
    public sealed class WorkAreaViewModel : ViewModelBase
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
        public DelegateCommand<SingleLayoutEditor> SaveCommand { get; private set; }
        public DelegateCommand<SingleLayoutEditor> CurrentStateChangeCommand { get; private set; }
        //To Delete
        public DelegateCommand<LoadUserLayoutModel> LoadUserLayoutCommand { get; private set; }
        #endregion

        #region Constructors
        public WorkAreaViewModel(IEventAggregator eventAggregator, ILayoutEditorPopulationService layoutEditorPopulationService)
            : base(eventAggregator)
        {
            _layoutEditorPopulationService = layoutEditorPopulationService;
            _userSettingsService = ServiceLocator.Current.GetInstance<IUserSettingsService>();

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
        public void InitializePlateControl()
        {
            LayoutEditorPopulation = _layoutEditorPopulationService.LayoutEditorPopulation;
            
            NotifyPropertyChanged(() => UserSettings);
            NotifyPropertyChanged(() => LayoutEditorPopulation);
        }
        public override void LoadData()
        {
            base.LoadData();
            InitializePlateControl();
        }

        private void OnUpdateCurrentState(SingleLayoutEditor obj)
        {
            CurrentState = obj;
          
           
        }
        private void EventsSubscribe()
        {
            //To Delete
            _eventAggregator.GetEvent<UserLayoutUpdateEvent>().Subscribe(OnUpdateUserLayout);
        }
        private void OnSaveAndClose(SingleLayoutEditor currentState)
        {
            OnShowErrorMessage("Save and Close...");
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
        private void SaveAndClose()
        {
            OnShowErrorMessage("Save is not implemented yet...");
        }

        //private void ShowValidationError(List<Layout.ValidationError> errors)
        //{
        //    var messageService = ServiceLocator.Current.GetInstance<IMessageService>();
        //    messageService.ShowLayoutValidationErrors(errors);
        //}
        //private void SaveAndClose()
        //{
        //    // IMPORTANT Note it is important to note that Async operations are used to Save any changes to MyAssays servers, however
        //    // the Silverlight component should not be closed (with a call to InvokeJavaScript) until these asyn operations
        //    // are completed, therefor the Save services methods also require another function which is called to close Silverlight
        //    // only AFTER the async operations complete
        //    // This problem is apparent FireFox (and maybe other browsers) but does not occur in IE.
        //    if (Validate())
        //    {
        //        if (IsFlagMode)
        //        {
        //            string flaggedPositionNums = _editorStateHelper.CurrentState.GetFlaggedPositionsCsv();
        //            string flaggedPositionHtml = _editorStateHelper.CurrentState.GetFlaggedPositionsText();
        //            _userLayoutService.SaveFlagsToService(UserSettings.UserId, UserSettings.AssociatedAssayId, flaggedPositionNums, flaggedPositionHtml,
        //                proxy_SaveFlagsToServiceCompleted_SaveAndClose); // Note that proxy_SaveFlagsToServiceCompleted_SaveAndClose is called only AFTER SaveFlagsToService is completed
        //        }
        //        else
        //        {
        //            // Save and close - the service function must complete first before closing the modal
        //            // (otherwise the client will be updated before the server is ready)
        //            // Attached a second handler to close the AJAX popup modal
        //            _userLayoutService.SaveUserLayoutToService(UserSettings.UserId, UserSettings.LayoutId, UserSettings.AssociatedAssayId, _editorStateHelper.CurrentState,
        //                proxy_SaveUserLayoutCompleted_SaveAndClose); // Note that proxy_SaveUserLayoutCompleted_SaveAndClose is called only AFTER SaveUserLayoutToService is completed
        //        }
        //    }
        //}
        //void proxy_SaveFlagsToServiceCompleted_SaveAndClose(object sender, AsyncCompletedEventArgs e)
        //{
        //    if (e.Error == null) // Only close if it saved OK
        //    {
        //        string flaggedPositionHtml = _editorStateHelper.CurrentState.GetFlaggedPositionsText();
        //        JavaScriptBridge.InvokeJavaScriptOnOkFlagMode(flaggedPositionHtml);
        //    }
        //}
        //void proxy_SaveUserLayoutCompleted_SaveAndClose(object sender, SaveUserLayoutCompletedEventArgs e)
        //{
        //    if (e.Error == null) // Only close if it saved OK
        //    {
        //        if (Validate())
        //        {
        //            // The first time a new layout is saved a new layout ID is generated, this must update the field in the ViewModel
        //            // so that when the editor is closed the JavaScript will refresh the image.
        //            UserSettings.LayoutId = _userLayoutService.GetLayoutId();
        //        }
        //        string pathToPreviewPng = GetPathToPreviewPng();
        //        JavaScriptBridge.InvokeJavaScriptOnOk(pathToPreviewPng, UserSettings.LayoutId, _userLayoutService.GetTypeGroupCountCSV(), _userLayoutService.GetNumUsedWellsFirstPlate().ToString());
        //    }
        //}
        //private string GetPathToPreviewPng()
        //{
        //    string pathToPreviewPng;
        //    switch (UserSettings.ResultsPathFormat)
        //    {
        //        case "Local":
        //            pathToPreviewPng = string.Format("Results/{0}/MLOs/{1}.png", UserSettings.UserId, UserSettings.LayoutId);
        //            break;
        //        case "MyAssaysBlobAzure":
        //            pathToPreviewPng = string.Format(@"http://myassays.blob.core.windows.net/{0}-mlos/{1}.png", UserSettings.UserId, UserSettings.LayoutId);
        //            break;
        //        default:
        //            throw new ArgumentException(string.Format("The ResultsPathFormat {0} in initParams is not recognised", UserSettings.ResultsPathFormat));
        //    }
        //    return pathToPreviewPng;
        //}
        //private bool Validate()
        //{
        //    List<Layout.ValidationError> errors = LayoutValidation.Validate(CurrentState, LayoutEditorPopulation);
        //    if (errors.Count != 0)
        //    {
        //        ShowValidationError(errors);
        //        return false;
        //    }
        //    return true;
        //}
        #endregion
    }
}
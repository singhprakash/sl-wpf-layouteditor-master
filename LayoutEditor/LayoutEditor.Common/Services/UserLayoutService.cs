using System;
using System.ComponentModel;
using System.Diagnostics;
using System.ServiceModel;
using System.Text;
using Layout;
using LayoutEditor.Common.Events;
using LayoutEditor.Common.Helpers;
using LayoutEditor.DAL.ServiceReferenceLayouts;
using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.ServiceLocation;

namespace LayoutEditor.Common.Services
{
    public sealed class UserLayoutService : IUserLayoutService
    {
        #region Fields
        private readonly IMessageService _messageService;
        private readonly IUserSettingsService _userSettingsService;

        private string _serviceAddress { get { return _userSettingsService.UserSettings.ServiceAddress; } }
        // After an edit or new layout is created, this is the number of used well (on 1st plate) (provided by the service)
        private int _numUsedWellsFirstPlate;
        // After an edit or new layout is created, this is the CSV information of the type group count (provided by the service)
        private string _typeGroupCountCSV;
        // The id of the layout being edited
        private string _layoutId;
        private UserLayout _userLayout;
        public UserLayout UserLayout { get { return _userLayout; } }
        private string _flaggedPositions;
        #endregion

        #region Constructors
        public UserLayoutService()
        {
            _messageService = ServiceLocator.Current.GetInstance<IMessageService>();
            _userSettingsService = ServiceLocator.Current.GetInstance<IUserSettingsService>();
        }
        #endregion

        #region Methods
        // Returns true if an empty layout is used
        // Returns false if a default layout has been used
        public bool InitEmptyUserLayout(LayoutEditorPopulation layoutEditorPopulation)
        {
            _userLayout = UserLayout.Create(layoutEditorPopulation.Width, layoutEditorPopulation.Height, layoutEditorPopulation.SampleTypes);
            // If there is a default section defined then setup the user layout from this
            if (!string.IsNullOrEmpty(layoutEditorPopulation.Default))
            {
                _userLayout.InitFromCSVStringAllPositions(layoutEditorPopulation.Default, layoutEditorPopulation.Width, layoutEditorPopulation.Height);
                OnUpdateUserLayout();
                return false;
            }
            OnUpdateUserLayout();
            return true;
        }
        public string SerializeUserLayout(SingleLayoutEditor singleLayoutEditor)
        {
            UserLayout userLayout = CreateUserLayoutFromState(singleLayoutEditor);
            var stringBuilder = new StringBuilder();
            XmlHelpers.SerializeObjectAsXmlToStringBuilder(userLayout, stringBuilder);
            return stringBuilder.ToString();
        }
        public ServiceLayoutsClient SaveUserLayoutToService(string userId, string layoutId, long associatedAssayId, SingleLayoutEditor singleLayoutEditor, EventHandler<SaveUserLayoutCompletedEventArgs> proxy_SaveLayoutToServiceCompleted)
        {
            var result = SerializeUserLayout(singleLayoutEditor);
            ServiceLayoutsClient proxy = CreateServiceLayoutsClientProxy();

            proxy.SaveUserLayoutCompleted += new EventHandler<SaveUserLayoutCompletedEventArgs>(proxy_SaveUserLayoutCompleted);
            if (proxy_SaveLayoutToServiceCompleted != null)
                proxy.SaveUserLayoutCompleted += proxy_SaveLayoutToServiceCompleted;

            OnUpdateBusyStatus(true);
            proxy.SaveUserLayoutAsync(userId, layoutId, result, associatedAssayId);
            return proxy;
        }
        public void SaveFlagsToService(string userId, long assayId, string flaggedPositionNums, string flaggedPositionHtml, EventHandler<AsyncCompletedEventArgs> proxy_SaveFlagsToServiceCompleted)
        {
            ServiceLayoutsClient proxy = CreateServiceLayoutsClientProxy();
            proxy.SaveUserFlagsCompleted += new EventHandler<AsyncCompletedEventArgs>(proxy_SaveUserFlagsCompleted);
            if (proxy_SaveFlagsToServiceCompleted != null)
                proxy.SaveUserFlagsCompleted += proxy_SaveFlagsToServiceCompleted;
            OnUpdateBusyStatus(true);
            proxy.SaveUserFlagsAsync(userId, assayId, flaggedPositionNums, flaggedPositionHtml);
        }
        public void LoadUserLayoutXmlFromService(string userId, string layoutId)
        {
            this._layoutId = layoutId;
            ServiceLayoutsClient proxy = CreateServiceLayoutsClientProxy();
            proxy.GetUserLayoutCompleted += new EventHandler<GetUserLayoutCompletedEventArgs>(proxy_GetUserLayoutCompleted);
            OnUpdateBusyStatus(true);
            proxy.GetUserLayoutAsync(userId, layoutId);
        }
        public void LoadUserLayoutWithFlagsXmlFromService(long assayId, string userId, string layoutId, string previousRunId)
        {
            this._layoutId = layoutId;
            ServiceLayoutsClient proxy = CreateServiceLayoutsClientProxy();
            proxy.GetUserLayoutWithFlagsCompleted += new EventHandler<GetUserLayoutWithFlagsCompletedEventArgs>(proxy_GetUserLayoutWithFlagsCompleted);
            OnUpdateBusyStatus(true);
            proxy.GetUserLayoutWithFlagsAsync(userId, layoutId, assayId, previousRunId);
        }
        public void LoadFixedLayoutXmlWithFlagsFromService(string userId, long assayId, int layoutNum, string previousRunId)
        {
            this._layoutId = string.Concat("Fixed: ", layoutNum);
            ServiceLayoutsClient proxy = CreateServiceLayoutsClientProxy();
            proxy.GetFixedLayoutWithFlagsCompleted += new EventHandler<GetFixedLayoutWithFlagsCompletedEventArgs>(proxy_GetFixedLayoutWithFlagsCompleted);
            OnUpdateBusyStatus(true);
            proxy.GetFixedLayoutWithFlagsAsync(userId, layoutNum, assayId, previousRunId);
        }
        public int GetNumUsedWellsFirstPlate() { return _numUsedWellsFirstPlate; }
        public string GetTypeGroupCountCSV() { return _typeGroupCountCSV; }
        public string GetLayoutId() { return _layoutId; }
        public string GetFlaggedPositions() { return _flaggedPositions; }

        private void OnUpdateUserLayout()
        {
            var eventAggregator = ServiceLocator.Current.GetInstance<IEventAggregator>();
            eventAggregator.GetEvent<UserLayoutUpdateEvent>().Publish(_userLayout);
        }
        private void OnUpdateBusyStatus(bool isBusy)
        {
            var eventAggregator = ServiceLocator.Current.GetInstance<IEventAggregator>();
            eventAggregator.GetEvent<BusyStatusUpdateEvent>().Publish(isBusy);
        }
        private ServiceLayoutsClient CreateServiceLayoutsClientProxy()
        {
            var proxy = new ServiceLayoutsClient();

            //Use the service address specified in the Silverlight initparams
            Debug.Assert(!string.IsNullOrEmpty(this._serviceAddress));
            var address = new EndpointAddress(this._serviceAddress);
            proxy.Endpoint.Address = address;
            return proxy;
        }
        public UserLayout CreateUserLayoutFromState(SingleLayoutEditor singleLayoutEditor)
        {
            //Uses a shallow copy
            UserLayout userLayout = this._userLayout.Clone();
            userLayout.SingleLayoutLight = new SingleLayoutLight(singleLayoutEditor);
            return userLayout;
        }
        private void proxy_SaveUserLayoutCompleted(object sender, SaveUserLayoutCompletedEventArgs e)
        {
            OnUpdateBusyStatus(false);
            if (e.Error != null)
            {
                _messageService.ShowError(e.Error.ToString());
                _messageService.ShowError(ErrorHelper.SaveLayoutErrorMessage);
            }
            else
            {
                if (!string.IsNullOrEmpty(e.Result))
                {
                    this._layoutId = e.Result;
                    this._typeGroupCountCSV = e.typeGroupCountCSV;
                    this._numUsedWellsFirstPlate = e.numUsedWellsFirstPlate;
                }
            }
        }
        private void proxy_SaveUserFlagsCompleted(object sender, AsyncCompletedEventArgs e)
        {
            OnUpdateBusyStatus(false);
            if (e.Error != null)
            {
                _messageService.ShowError(e.Error.ToString());
                _messageService.ShowError(ErrorHelper.SaveFlagsErrorMessage);
            }
        }
        private void proxy_GetUserLayoutCompleted(object sender, GetUserLayoutCompletedEventArgs e)
        {
            DeserializeUserLayout(e.Result);
        }
        private void proxy_GetUserLayoutWithFlagsCompleted(object sender, GetUserLayoutWithFlagsCompletedEventArgs e)
        {
            // Must set flags first as it is processed in UserLayoutChanged();
            _flaggedPositions = e.flags;
            DeserializeUserLayout(e.Result);
        }
        private void proxy_GetFixedLayoutWithFlagsCompleted(object sender, GetFixedLayoutWithFlagsCompletedEventArgs e)
        {
            // Must set flags first as it is processed in UserLayoutChanged();
            _flaggedPositions = e.flags;
            DeserializeUserLayout(e.Result);
        }
        public void DeserializeUserLayout(string result)
        {
            if (!string.IsNullOrEmpty(result))
            {
                _userLayout = XmlHelpers.DeserializeXmlString(result, typeof(UserLayout)) as UserLayout;
                OnUpdateUserLayout();
            }
            OnUpdateBusyStatus(false);
        }
        #endregion
    }

    public interface IUserLayoutService
    {
        string GetFlaggedPositions();
        string GetLayoutId();
        int GetNumUsedWellsFirstPlate();
        string GetTypeGroupCountCSV();
        UserLayout UserLayout { get; }
        string SerializeUserLayout(SingleLayoutEditor singleLayoutEditor);
        UserLayout CreateUserLayoutFromState(SingleLayoutEditor singleLayoutEditor);
        void DeserializeUserLayout(string result);
        bool InitEmptyUserLayout(Layout.LayoutEditorPopulation layoutEditorPopulation);
        void LoadFixedLayoutXmlWithFlagsFromService(string userId, long assayId, int layoutNum, string previousRunId);
        void LoadUserLayoutWithFlagsXmlFromService(long assayId, string userId, string layoutId, string previousRunId);
        void LoadUserLayoutXmlFromService(string userId, string layoutId);
        void SaveFlagsToService(string userId, long assayId, string flaggedPositionNums, string flaggedPositionHtml, EventHandler<System.ComponentModel.AsyncCompletedEventArgs> proxy_SaveFlagsToServiceCompleted);
        ServiceLayoutsClient SaveUserLayoutToService(string userId, string layoutId, long associatedAssayId, Layout.SingleLayoutEditor singleLayoutEditor, EventHandler<SaveUserLayoutCompletedEventArgs> proxy_SaveLayoutToServiceCompleted);
    }
}
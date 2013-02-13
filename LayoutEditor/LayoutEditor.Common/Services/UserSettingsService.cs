using System;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Windows;
using LayoutEditor.Enums;
using LayoutEditor.Models;

namespace LayoutEditor.Common.Services
{
    public sealed class UserSettingsService : IUserSettingsService
    {
        #region Fields
        private UserSettingsModel _userSettings;
        public UserSettingsModel UserSettings
        {
            get { return _userSettings; }
            private set
            {
                _userSettings = value;
                if (_userSettings != null)
                    _userSettings.PropertyChanged += _userSettings_PropertyChanged;
            }
        }

        private readonly IsolatedStorageSettings _settingsStorage;
        #endregion

        #region Constructors
        public UserSettingsService()
        {
            _settingsStorage = IsolatedStorageSettings.ApplicationSettings;
        }
        #endregion

        #region Methods
        public void FillSettings(StartupEventArgs e)
        {
            var tempSettings = GetSettingsFromApp(e);
            if (!_settingsStorage.Contains("UserId") || (string)GetSettingByKey("UserId") != tempSettings.UserId)
            {
                UserSettings = tempSettings;
                UpdateSettingsInStorage(UserSettings);
            }
            else
                UserSettings = GetSettingsFromStorage();
        }
        public void UpdateSettingByKey(string key, object value)
        {
            if (_settingsStorage.Contains(key))
                _settingsStorage[key] = value;
            else
                _settingsStorage.Add(key, value);
        }
        public object GetSettingByKey(string key)
        {
            if (_settingsStorage.Contains(key))
                return _settingsStorage[key];
            return null;
        }
        private UserSettingsModel GetSettingsFromStorage()
        {
            var userSettings = new UserSettingsModel();
            var properties = userSettings.GetType().GetProperties();
            foreach (var item in properties)
                if (_settingsStorage.Contains(item.Name))
                    item.SetValue(userSettings, _settingsStorage[item.Name], null);
            if (!_settingsStorage.Contains("ShowNextTime"))
                userSettings.ShowNextTime = true;
            return userSettings;
        }
        private UserSettingsModel GetSettingsFromApp(StartupEventArgs e)
        {
            var userSettings = new UserSettingsModel();
            if (e.InitParams.ContainsKey("LayoutId"))
                userSettings.LayoutId = e.InitParams["LayoutId"];

            if (e.InitParams.ContainsKey("UserId"))
                userSettings.UserId = e.InitParams["UserId"];
            else
                userSettings.UserId = "0";

            if (e.InitParams.ContainsKey("ServiceAddress"))
            {
                userSettings.ServiceAddress = e.InitParams["ServiceAddress"];
                string serviceName = "ServiceLayouts.svc";
                if (!userSettings.ServiceAddress.EndsWith(serviceName))
                    throw new ArgumentException(string.Format("Service name is not expected, {0} is expected, however it is ", serviceName, userSettings.ServiceAddress));
                userSettings.ServerRoot = userSettings.ServiceAddress.Replace(serviceName, "");
            }

            if (e.InitParams.ContainsKey("AssociatedAssayId"))
                userSettings.AssociatedAssayId = long.Parse(e.InitParams["AssociatedAssayId"]);

            if (e.InitParams.ContainsKey("IsPreviousRunEdit"))
                userSettings.IsPreviousRunEdit = bool.Parse(e.InitParams["IsPreviousRunEdit"]);

            if (userSettings.IsPreviousRunEdit)
            {
                if (e.InitParams.ContainsKey("PreviousRunId"))
                    userSettings.PreviousRunId = e.InitParams["PreviousRunId"];
                if (e.InitParams.ContainsKey("PreviousRunOriginator"))
                    userSettings.PreviousRunOriginator = e.InitParams["PreviousRunOriginator"];
            }
            else
            {
                // Not a previous run
                userSettings.PreviousRunOriginator = userSettings.PreviousRunId = "";
            }

            if (e.InitParams.ContainsKey("IsFlagMode"))
                userSettings.IsFlagMode = bool.Parse(e.InitParams["IsFlagMode"]);

            if (e.InitParams.ContainsKey("ResultsPathFormat"))
                userSettings.ResultsPathFormat = e.InitParams["ResultsPathFormat"];
            else
            {
                // For MyAssays 1.0 (on local or Amazon EC2)
                userSettings.ResultsPathFormat = "Local";
            }

            // Setup the UserSettings Key/Value pairs (if they have not been setup already)
            userSettings.FillDirection = Direction.Down;
            userSettings.Replicates = 1;
            userSettings.RectangleMode = false;
            userSettings.ReplicateDirection = RepDirection.ByRow;
            userSettings.ShowNextTime = true;
            return userSettings;
        }
        private void UpdateSettingsInStorage(UserSettingsModel userSettings)
        {
            if (userSettings == null)
            {
                _settingsStorage.Clear();
                return;
            }
            var properties = userSettings.GetType().GetProperties();
            foreach (var item in properties)
                if (!_settingsStorage.Contains(item.Name))
                    _settingsStorage.Add(item.Name, item.GetValue(userSettings, null));
                else
                    _settingsStorage[item.Name] = item.GetValue(userSettings, null);
        }
        void _userSettings_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            var userSettings = sender as UserSettingsModel;
            if (userSettings != null && !string.IsNullOrEmpty(e.PropertyName))
            {
                var property = userSettings.GetType().GetProperties().FirstOrDefault(x => x.Name == e.PropertyName);
                if (property != null)
                    UpdateSettingByKey(e.PropertyName, property.GetValue(userSettings, null));
            }
        }
        #endregion
    }

    public interface IUserSettingsService
    {
        UserSettingsModel UserSettings { get; }
        void FillSettings(StartupEventArgs e);
        void UpdateSettingByKey(string key, object value);
        object GetSettingByKey(string key);
    }
}
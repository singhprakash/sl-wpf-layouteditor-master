using System;
using System.Diagnostics;
using Layout;
using LayoutEditor.Common.Events;
using LayoutEditor.Common.Helpers;
using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.ServiceLocation;

namespace LayoutEditor.Common.Services
{
    public sealed class LayoutEditorPopulationService : ILayoutEditorPopulationService
    {
        #region Fields
        private LayoutEditorPopulation _layoutEditorPopulation;
        public LayoutEditorPopulation LayoutEditorPopulation { get { return _layoutEditorPopulation; } }
        #endregion

        #region Methods
        public void LoadData(Action<LayoutEditorPopulation> result = null)
        {
            //Get Json for LayoutEditorPopulation from page (from JavaScript)
            string layoutEditorPopulationJson = JavaScriptBridge.InvokeJavaScriptGetJsonLPE();
            if (string.IsNullOrEmpty(layoutEditorPopulationJson))
                throw new InvalidOperationException(ErrorHelper.LayoutPopulationEditorErrorMessage);

            var resultObject = LoadFromJson(layoutEditorPopulationJson);
            if (result != null)
                result(resultObject);
        }
        public LayoutEditorPopulation LoadDataFromXML(string xml)
        {
            Debug.Assert(!string.IsNullOrEmpty(xml));
            _layoutEditorPopulation = XmlHelpers.DeserializeXmlString(xml, typeof(LayoutEditorPopulation)) as LayoutEditorPopulation;

            var userSettings = ServiceLocator.Current.GetInstance<UserSettingsService>();
            userSettings.UserSettings.IsMultiple = _layoutEditorPopulation.IsMultiple;
            userSettings.UserSettings.MultipleLayout = _layoutEditorPopulation.GetMultipleLayoutEnum();
            userSettings.UserSettings.ContainerName = _layoutEditorPopulation.ContainerName;

            var eventAggregator = ServiceLocator.Current.GetInstance<IEventAggregator>();
            return _layoutEditorPopulation;
        }
        private LayoutEditorPopulation LoadFromJson(string json)
        {
            Debug.Assert(!string.IsNullOrEmpty(json));
            _layoutEditorPopulation = JsonHelpers.Deserialize(json, typeof(LayoutEditorPopulation)) as LayoutEditorPopulation;

            var userSettings = ServiceLocator.Current.GetInstance<UserSettingsService>();
            userSettings.UserSettings.IsMultiple = _layoutEditorPopulation.IsMultiple;
            userSettings.UserSettings.MultipleLayout = _layoutEditorPopulation.GetMultipleLayoutEnum();
            userSettings.UserSettings.ContainerName = _layoutEditorPopulation.ContainerName;

            var eventAggregator = ServiceLocator.Current.GetInstance<IEventAggregator>();
            return _layoutEditorPopulation;
        }
        public int GetNumPositions()
        {
            return _layoutEditorPopulation == null ? -1 : _layoutEditorPopulation.Width * _layoutEditorPopulation.Height;
        }
        #endregion
    }

    public interface ILayoutEditorPopulationService
    {
        void LoadData(Action<LayoutEditorPopulation> result = null);
        int GetNumPositions();
        LayoutEditorPopulation LayoutEditorPopulation { get; }
        LayoutEditorPopulation LoadDataFromXML(string xml);
    }
}
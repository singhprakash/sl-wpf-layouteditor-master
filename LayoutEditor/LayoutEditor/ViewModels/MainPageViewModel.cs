using LayoutEditor.Common.Events;
using LayoutEditor.Common.Services;
using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.ServiceLocation;

namespace LayoutEditor.Common.ViewModels
{
    public sealed class MainPageViewModel : ViewModelBase
    {
        #region Fields
        private readonly ILayoutEditorPopulationService _layoutEditorPopulationService;
        #endregion

        #region Properties
        public bool IsBusy { get; private set; }
        public ViewModelBase Content { get; private set; }
        #endregion

        #region Constructors
        public MainPageViewModel(IEventAggregator eventAggregator)
            : base(eventAggregator)
        {
            _layoutEditorPopulationService = ServiceLocator.Current.GetInstance<ILayoutEditorPopulationService>();
            EventsSubscribe();
        }
        #endregion

        #region Methods
        private void EventsSubscribe()
        {
            _eventAggregator.GetEvent<BusyStatusUpdateEvent>().Subscribe(OnBusyStatusUpdate);
        }
        public override void LoadData()
        {
            OnBusyStatusUpdate(true);

            _layoutEditorPopulationService.LoadData(result =>
            {
                Content = new WorkAreaViewModel(_eventAggregator, _layoutEditorPopulationService);
                OnBusyStatusUpdate(false);
            });

        }

        public void OnBusyStatusUpdate(bool status)
        {
            IsBusy = status;
            NotifyPropertyChanged(() => IsBusy);
        }
        #endregion
    }
}
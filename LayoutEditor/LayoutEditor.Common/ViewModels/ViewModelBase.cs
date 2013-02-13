using LayoutEditor.Common.Services;
using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.ServiceLocation;

namespace LayoutEditor.Common.ViewModels
{
    public abstract class ViewModelBase : PropertyChangedBase
    {
        #region Properties
        protected readonly IEventAggregator _eventAggregator;
        #endregion

        #region Constructors
        public ViewModelBase(IEventAggregator eventAggregator)
            : base()
        {
            _eventAggregator = eventAggregator;
        }

        #endregion

        #region Methods
        public virtual void LoadData() { }

        protected virtual void OnShowErrorMessage(string errorMessage)
        {
            var messageService = ServiceLocator.Current.GetInstance<IMessageService>();
            messageService.ShowError(errorMessage);
        }
        #endregion
    }
}
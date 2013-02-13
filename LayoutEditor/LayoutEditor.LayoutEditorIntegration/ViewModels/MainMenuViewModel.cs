using System;
using LayoutEditor.Common.Enums;
using LayoutEditor.Common.Events;
using LayoutEditor.Common.ViewModels;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Events;

namespace LayoutEditor.LayoutEditorIntegration.ViewModels
{
    public class MainMenuViewModel : ViewModelBase
    {
        #region Commands
        public DelegateCommand<object> ClickCommand { get; private set; }
        #endregion

        #region Constructors
        public MainMenuViewModel(IEventAggregator eventAggregator)
            : base(eventAggregator)
        {
            ClickCommand = new DelegateCommand<object>(OnClick);
        }
        #endregion

        #region Methods
        private void OnClick(object param)
        {
            if (Equals(param, null))
                throw new InvalidCastException();
            var selectedItem = Enum.Parse(typeof(MainMenuCommandTypes), param.ToString(), true);
            _eventAggregator.GetEvent<SelectMenuItemEvent>().Publish((MainMenuCommandTypes)selectedItem);
        }
        #endregion
    }
}
using System.ComponentModel;
using System.Windows.Controls;
using LayoutEditor.LayoutEditorIntegration.ViewModels;
using Microsoft.Practices.ServiceLocation;

namespace LayoutEditor.LayoutEditorIntegration.Views
{
    public partial class MainMenuView : UserControl
    {
        public MainMenuViewModel ViewModel
        {
            get
            {
                return DataContext as MainMenuViewModel;
            }
            set
            {
                DataContext = value;
            }
        }

        public MainMenuView()
        {
            InitializeComponent();
            if (!DesignerProperties.GetIsInDesignMode(this))
                ViewModel = ServiceLocator.Current.GetInstance<MainMenuViewModel>();
        }
    }
}
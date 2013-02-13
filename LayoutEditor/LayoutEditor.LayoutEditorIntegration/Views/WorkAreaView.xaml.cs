using System.ComponentModel;
using System.Windows.Controls;
using LayoutEditor.LayoutEditorIntegration.ViewModels;
using Microsoft.Practices.ServiceLocation;

namespace LayoutEditor.LayoutEditorIntegration.Views
{
    public partial class WorkAreaView : UserControl
    {
        public WorkAreaViewModel ViewModel
        {
            get
            {
                return DataContext as WorkAreaViewModel;
            }
            set
            {
                DataContext = value;
            }
        }

        public WorkAreaView()
        {
            InitializeComponent();
            if (!DesignerProperties.GetIsInDesignMode(this))
                ViewModel = ServiceLocator.Current.GetInstance<WorkAreaViewModel>();
        }
    }
}
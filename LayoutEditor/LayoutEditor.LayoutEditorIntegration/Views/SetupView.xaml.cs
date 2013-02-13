using System.Windows;
using System.Windows.Controls;

namespace LayoutEditor.LayoutEditorIntegration.Views
{
    public partial class SetupView : ChildWindow
    {
        public SetupView()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }
    }
}
using System.Windows;
using System.Windows.Controls;

namespace LayoutEditor.Common.Controls
{
    public partial class ValidationPopup : ChildWindow
    {
        public ValidationPopup()
        {
            InitializeComponent();
        }

        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }
    }
}
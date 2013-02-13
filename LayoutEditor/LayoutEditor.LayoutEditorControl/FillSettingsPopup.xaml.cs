using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using LayoutEditor.LayoutEditorControl.Models;

namespace LayoutEditor.LayoutEditorControl
{
    public partial class FillSettingsPopup : ChildWindow
    {
        public FillSettingsPopup()
        {
            InitializeComponent();
        }

        // This is a Child window with OK/Cancel buttons so binding is done explicitly and only when OK is clicked.
        void BindControls()
        {
            BindingExpression expressionTextBox = textBoxReplicates.GetBindingExpression(TextBox.TextProperty);
            expressionTextBox.UpdateSource();

            BindingExpression expressionTextBoxGroupNum = textBoxGroupNum.GetBindingExpression(TextBox.TextProperty);
            expressionTextBoxGroupNum.UpdateSource();

            BindingExpression expressionRadioButtonAcross = radioButtonAcross.GetBindingExpression(RadioButton.IsCheckedProperty);
            expressionRadioButtonAcross.UpdateSource();

            BindingExpression expressionRadioButtonDown = radioButtonDown.GetBindingExpression(RadioButton.IsCheckedProperty);
            expressionRadioButtonDown.UpdateSource();

            BindingExpression expressionCheckboxShowNextTime = checkboxShowNextTime.GetBindingExpression(CheckBox.IsCheckedProperty);
            expressionCheckboxShowNextTime.UpdateSource();

            BindingExpression expressionCheckboxRectangleMode = checkboxRectangleMode.GetBindingExpression(CheckBox.IsCheckedProperty);
            expressionCheckboxRectangleMode.UpdateSource();

            BindingExpression expressionRadioButtonByRow = radioReplicateDirectionByRow.GetBindingExpression(RadioButton.IsCheckedProperty);
            expressionRadioButtonByRow.UpdateSource();

            BindingExpression expressionRadioButtonByCol = radioReplicateDirectionByCol.GetBindingExpression(RadioButton.IsCheckedProperty);
            expressionRadioButtonByCol.UpdateSource();
        }


        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            BindControls();

            if (Validation.GetHasError(textBoxReplicates))
            {
                return;
            }

            this.DialogResult = true;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }

        private void ResetButton_Click(object sender, RoutedEventArgs e)
        {
            this.textBoxGroupNum.Text = "1";
        }

        private void checkboxRectangleMode_Click(object sender, RoutedEventArgs e)
        {
            if (this.checkboxRectangleMode.IsChecked == true)
            {
                /*
                this.descRepDirection.Visibility = System.Windows.Visibility.Visible;
                this.radioReplicateDirectionByRow.Visibility = System.Windows.Visibility.Visible;
                this.radioReplicateDirectionByCol.Visibility = System.Windows.Visibility.Visible;
                 * */
                this.LayoutRoot.RowDefinitions[4].MaxHeight = 32;
                if (this.LayoutRoot.RowDefinitions[0].MaxHeight == 0)
                {
                    this.Height = 238;
                }
                else
                {
                    this.Height = 270;
                }
            }
            else
            {
                /*
                this.descRepDirection.Visibility = System.Windows.Visibility.Collapsed;
                this.radioReplicateDirectionByRow.Visibility = System.Windows.Visibility.Collapsed;
                this.radioReplicateDirectionByCol.Visibility = System.Windows.Visibility.Collapsed;
                 * */
                this.LayoutRoot.RowDefinitions[4].MaxHeight = 0;
                if (this.LayoutRoot.RowDefinitions[0].MaxHeight == 0)
                {
                    this.Height = 206;
                }
                else
                {
                    this.Height = 238;
                }
            }
        }

        private void Resize()
        {
            var fillSettings = (FillSettingsModel)this.DataContext;

            if (fillSettings.RectangleMode == true)
            {
                this.LayoutRoot.RowDefinitions[4].MaxHeight = 32;
                if (this.LayoutRoot.RowDefinitions[0].MaxHeight == 0)
                {
                    this.Height = 238;
                }
                else
                {
                    this.Height = 270;
                }
            }
            else
            {
                this.LayoutRoot.RowDefinitions[4].MaxHeight = 0;
                if (this.LayoutRoot.RowDefinitions[0].MaxHeight == 0)
                {
                    this.Height = 206;
                }
                else
                {
                    this.Height = 238;
                }
            }
        }

        public void ShowNonInteractive()
        {
            this.LayoutRoot.RowDefinitions[0].MaxHeight = 0;
            //this.Height = 238;
            this.Show();
            this.Resize();
        }

        public void ShowInteractive()
        {
            this.Show();
            this.Resize();
        }
    }
}
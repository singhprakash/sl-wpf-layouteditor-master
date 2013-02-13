using System;
using System.Windows;
using System.Windows.Data;

namespace LayoutEditor.LayoutEditorIntegration.Converters
{
    public class VisibilityConverter : IValueConverter
    {
        #region IValueConverter Members
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            // Support Visibility type
            if (targetType == typeof(System.Windows.Visibility))
            {
                if (!Equals(value, null)) return Visibility.Visible;
                return Visibility.Collapsed;
            }
            return DependencyProperty.UnsetValue;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
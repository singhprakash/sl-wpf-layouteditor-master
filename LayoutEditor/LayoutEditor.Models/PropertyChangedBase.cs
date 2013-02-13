using System;
using System.ComponentModel;
using System.Linq.Expressions;

namespace LayoutEditor
{
    public abstract class PropertyChangedBase : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged Members
        public event PropertyChangedEventHandler PropertyChanged;

        protected void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        protected void NotifyPropertyChanged<T>(Expression<Func<T>> property)
        {
            NotifyPropertyChanged(GetPropertyName<T>(property));
        }

        protected string GetPropertyName<T>(Expression<Func<T>> property)
        {
            var expression = property.Body as MemberExpression;
            return expression.Member.Name;
        }
        #endregion
    }
}
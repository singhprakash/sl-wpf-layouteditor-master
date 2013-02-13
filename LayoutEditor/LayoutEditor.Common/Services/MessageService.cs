using System.Collections.Generic;
using System.Windows;
using Layout;
using LayoutEditor.Common.Controls;

namespace LayoutEditor.Common.Services
{
    public sealed class MessageService : IMessageService
    {
        public void Show(string message)
        {
            MessageBox.Show(message);
        }

        public bool ShowQuestion(string question)
        {
            return MessageBox.Show(question, "Question", MessageBoxButton.OKCancel) == MessageBoxResult.OK;
        }

        public void ShowError(string errorMessage)
        {
            MessageBox.Show(errorMessage, "Error", MessageBoxButton.OK);
        }

        public void ShowLayoutValidationErrors(IEnumerable<ValidationError> errors)
        {
            var childWindowLayoutValidation = new ValidationPopup();
            childWindowLayoutValidation.DataContext = errors;
            childWindowLayoutValidation.Show();
        }
    }

    public interface IMessageService
    {
        void Show(string message);
        bool ShowQuestion(string question);
        void ShowError(string errorMessage);
        void ShowLayoutValidationErrors(IEnumerable<ValidationError> errors);
    }
}
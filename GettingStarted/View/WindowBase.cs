using System;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using GettingStarted.Data;

namespace GettingStarted.View
{
    public class WindowBase : Window
    {
        private readonly RelayCommand<object> closeCommand;

        public WindowBase()
        {
            this.closeCommand = new RelayCommand<object>(this.CloseCommand_Execute);
        }

        public RelayCommand<object> CloseCommand
        {
            get
            {
                return this.closeCommand;
            }
        }

        private static bool IsValid(DependencyObject obj)
        {
            return !System.Windows.Controls.Validation.GetHasError(obj) &&
                LogicalTreeHelper.GetChildren(obj)
                .OfType<DependencyObject>()
                .All(child => IsValid(child));
        }

        private void CloseCommand_Execute(object param)
        {
            this.Close();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            e.Cancel = !IsValid(this);
        }
    }
}

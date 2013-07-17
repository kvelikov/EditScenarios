using System;
using System.Linq;
using System.Windows.Input;

namespace GettingStarted.Data
{
    public class RelayCommand<T> : ICommand
    {
        public event EventHandler CanExecuteChanged
        {
            add
            {
                CommandManager.RequerySuggested += value;
            }
            remove
            {
                CommandManager.RequerySuggested += value;
            }
        }

        private readonly Predicate<T> canExecute;
        private readonly Action<T> executeAction;

        public RelayCommand(Action<T> executeAction, Predicate<T> canExecute = null)
        {
            this.executeAction = executeAction;
            this.canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            if (this.canExecute != null)
                return this.canExecute((T)parameter);

            return true;
        }

        public void Execute(object parameter)
        {
            if (this.executeAction != null && this.CanExecute(parameter))
                this.executeAction((T)parameter);
        }
    }
}

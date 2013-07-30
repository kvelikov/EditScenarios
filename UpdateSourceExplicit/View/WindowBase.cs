using System;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using UpdateSourceExplicit.Data;

namespace UpdateSourceExplicit.View
{
    public class WindowBase : Window
    {
        private readonly RelayCommand<object> saveCommand;
        private readonly RelayCommand<object> cancelCommand;

        public WindowBase()
        {
            this.saveCommand = new RelayCommand<object>(this.SaveCommand_Execute);
            this.cancelCommand = new RelayCommand<object>(this.CloseCommand_Execute);
        }

        public IDataErrorInfo Element
        {
            get;
            set;
        }

        public RelayCommand<object> SaveCommand
        {
            get
            {
                return this.saveCommand;
            }
        }

        public RelayCommand<object> CancelCommand
        {
            get
            {
                return this.cancelCommand;
            }
        }

        protected virtual void Save()
        {
        }

        protected virtual bool Validate()
        {
            return true;
        }

        private void SaveCommand_Execute(object param)
        {
            if (this.Validate())
            {
                this.Save();
                this.DialogResult = true;
                this.Close();
            }
        }

        private void CloseCommand_Execute(object param)
        {
            this.DialogResult = false;
            this.Close();
        }
    }
}

using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using UpdateSourceExplicit.ViewModel;

namespace UpdateSourceExplicit.View
{
    public partial class EditEmployeeWindow : WindowBase
    {
        private readonly EditEmployeeViewModel viewModel;

        public EditEmployeeWindow(EditEmployeeViewModel viewModel)
        {
            this.viewModel = viewModel;
            this.DataContext = this.viewModel;

            InitializeComponent();
        }

        protected override void Save()
        {
            this.tbName.GetBindingExpression(TextBox.TextProperty).UpdateSource();
            this.tbAge.GetBindingExpression(TextBox.TextProperty).UpdateSource();
        }

        protected override bool Validate()
        {
            bool isValid = true;
            isValid &= this.tbName.GetBindingExpression(TextBox.TextProperty).ValidateWithoutUpdate();
            isValid &= this.tbAge.GetBindingExpression(TextBox.TextProperty).ValidateWithoutUpdate();

            return isValid;
        }
    }
}

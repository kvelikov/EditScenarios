using System;
using System.Linq;
using UpdateSourceExplicit.Data;
using UpdateSourceExplicit.View;
using UpdateSourceExplicit.Model;

namespace UpdateSourceExplicit.ViewModel
{
    public class EditEmployeeViewModel : ViewModelBase
    {
        private Employee employee;

        public EditEmployeeViewModel(Employee employee)
        {
            this.employee = employee;
        }

        public Employee Employee
        {
            get
            {
                return this.employee;
            }
        }
    }
}

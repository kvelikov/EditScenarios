﻿using System;
using System.Linq;
using GettingStarted.Model;

namespace GettingStarted.ViewModel
{
    public class EditEmployeeViewModel : ViewModelBase
    {
        private readonly Employee employee;

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

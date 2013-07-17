using System;
using System.Collections.Generic;
using System.Linq;
using GettingStarted.Data;
using GettingStarted.Model;

namespace GettingStarted.ViewModel
{
    public class MainWindowViewModel : ViewModelBase
    {
        private readonly EmployeeCollection employees;

        public MainWindowViewModel()
        {
            List<Employee> listEmployees = new List<Employee>();
            listEmployees.Add(new Employee("Peter", 22));
            listEmployees.Add(new Employee("George", 18));
            listEmployees.Add(new Employee("Todor", 26));
            listEmployees.Add(new Employee("Peter 1", 22));
            listEmployees.Add(new Employee("George 1", 18));
            listEmployees.Add(new Employee("Todor 1", 26));
            listEmployees.Add(new Employee("Peter 2", 22));
            listEmployees.Add(new Employee("George 2", 18));
            listEmployees.Add(new Employee("Todor 2", 26));
            listEmployees.Add(new Employee("Peter 3", 22));
            listEmployees.Add(new Employee("George 3", 18));
            listEmployees.Add(new Employee("Todor 3", 26));

            this.employees = new EmployeeCollection(listEmployees);
        }

        public EmployeeCollection Employees
        {
            get
            {
                return this.employees;
            }
        }
    }
}

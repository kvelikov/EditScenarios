using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using GettingStarted.Model;
using GettingStarted.View;
using GettingStarted.ViewModel;

namespace GettingStarted.Data
{
    public class EmployeeCollection : IEnumerable<Employee>, INotifyCollectionChanged, INotifyPropertyChanged
    {
        private readonly RelayCommand<object> addCommand;
        private readonly RelayCommand<object> editCommand;
        private readonly RelayCommand<object> deleteCommand;

        private readonly List<Employee> store;

        private int selectedIndex;
        private Employee selectedItem;

        public EmployeeCollection(IEnumerable<Employee> initialData)
		{
            this.store = new List<Employee>(initialData);
			this.selectedIndex = -1;
            this.addCommand = new RelayCommand<object>(this.AddCommand_Execute);
            this.editCommand = new RelayCommand<object>(this.EditCommand_Execute, this.EditCommand_CanExecute);
            this.deleteCommand = new RelayCommand<object>(this.DeleteCommand_Execute, this.DeleteCommand_CanExecute);
		}

        public int Count
        {
            get
            {
                return this.store.Count;
            }
        }

		public int SelectedIndex
		{
			get
			{
				return this.selectedIndex;
			}
			set
			{
				if (this.selectedIndex != value)
				{
					if (value < this.Count && value >= 0)
					{
						this.selectedIndex = value;
						this.selectedItem = this.store[this.selectedIndex];
						this.OnSelectionChanged();
					}
					else
					{
                        this.ClearSelection();
					}
				}
			}
		}

		public Employee SelectedItem
		{
			get
			{
				return this.selectedItem;
			}
			set
			{
				if (this.selectedItem != value)
				{
					if (value != null || this.Contains(value))
					{
						this.selectedItem = value;
						this.selectedIndex = this.store.IndexOf(this.selectedItem);
						this.OnSelectionChanged();
					}
					else
					{
                        this.ClearSelection();
					}
				}
			}
		}

        public RelayCommand<object> AddCommand
        {
            get
            {
                return this.addCommand;
            }
        }

        public RelayCommand<object> EditCommand
        {
            get
            {
                return this.editCommand;
            }
        }

        public RelayCommand<object> DeleteCommand
        {
            get
            {
                return this.deleteCommand;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public event NotifyCollectionChangedEventHandler CollectionChanged;

        public event EventHandler SelectionChanged;

        public IEnumerator<Employee> GetEnumerator()
        {
            return this.store.GetEnumerator();
        }

        public void AddAndEditNew()
        {
            Employee employee = new Employee();
            EditEmployeeWindow editWindow = new EditEmployeeWindow();
            editWindow.DataContext = new EditEmployeeViewModel(employee);
            editWindow.ShowDialog();
            this.store.Add(employee);
            this.OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Add, employee));
        }

        public void EditSelected()
        {
            EditEmployeeWindow editWindow = new EditEmployeeWindow();
            editWindow.DataContext = new EditEmployeeViewModel(this.SelectedItem);
            editWindow.ShowDialog();
        }

        public void DeleteSelected()
        {
            Employee element = this.SelectedItem;
            int index = this.SelectedIndex;
            this.store.Remove(element);
            this.SelectedItem = null;
            this.OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Remove, element, index));
        }

        protected void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        protected void OnCollectionChanged(NotifyCollectionChangedEventArgs args)
        {
            if (this.CollectionChanged != null)
            {
                this.CollectionChanged(this, args);
            }
        }

		protected virtual void OnSelectionChanged()
		{
			this.OnPropertyChanged("SelectedItem");
			this.OnPropertyChanged("SelectedIndex");
			if (this.SelectionChanged != null)
			{
				this.SelectionChanged(this, EventArgs.Empty);
			}
		}

        private void ClearSelection()
        {
            this.selectedItem = null;
            this.selectedIndex = -1;
            this.OnSelectionChanged();
        }

        private void AddCommand_Execute(object param)
        {
            this.AddAndEditNew();
        }

        private void EditCommand_Execute(object param)
        {
            this.EditSelected();
        }

        private bool EditCommand_CanExecute(object param)
        {
            return this.SelectedItem != null;
        }

        private void DeleteCommand_Execute(object param)
        {
            this.DeleteSelected();
        }

        private bool DeleteCommand_CanExecute(object param)
        {
            return this.SelectedItem != null;
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.store.GetEnumerator();
        }
    }
}

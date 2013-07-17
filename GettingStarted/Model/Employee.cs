using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace GettingStarted.Model
{
    // This class can be auto generated.
    public partial class Employee : INotifyPropertyChanged
    {
        private string name;
        private int age;

        // For test use only.
        internal Employee(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public Employee()
        {
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [Required]
        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (this.name != value)
                {
                    this.name = value;
                    OnPropertyChanged("Name");
                }
            }
        }

        public int Age
        {
            get
            {
                return this.age;
            }
            set
            {
                if (this.age != value)
                {
                    this.age = value;
                    OnPropertyChanged("Age");
                }
            }
        }

        protected void OnPropertyChanged(string propertyName)
        {
            if (this.PropertyChanged != null)
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}

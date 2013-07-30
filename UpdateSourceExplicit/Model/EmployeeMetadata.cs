using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace UpdateSourceExplicit.Model
{
    [MetadataType(typeof(Employee.Metadata))]
    public partial class Employee : MetadataBase
    {
        static Employee()
        {
            TypeDescriptor.AddProviderTransparent(new AssociatedMetadataTypeTypeDescriptionProvider(typeof(Employee), typeof(Metadata)), typeof(Employee));
        }

        private sealed class Metadata
        {
            [Required]
            public string Name
            {
                get;
                set;
            }

            public int Age
            {
                get;
                set;
            }
        }
    }
}

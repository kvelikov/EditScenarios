using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace GettingStarted.Model
{
    [MetadataType(typeof(Employee.Metadata))]
    public partial class Employee : MetadataBase
    {
        static Employee()
        {
            TypeDescriptor.AddProviderTransparent(new AssociatedMetadataTypeTypeDescriptionProvider(typeof(Employee), typeof(Metadata)), typeof(Metadata));
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

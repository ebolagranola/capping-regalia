//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Regalia.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Faculty
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Faculty()
        {
            this.Orders = new HashSet<Order>();
        }
    
        public string Email { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Department { get; set; }
        public string CapSize { get; set; }
        public string College { get; set; }
        public string Degree { get; set; }
        public string Discipline { get; set; }
        public Nullable<int> HeightFeet { get; set; }
        public Nullable<int> HeightInches { get; set; }
        public Nullable<int> Weight { get; set; }
        public Nullable<bool> IsAdmin { get; set; }
        public Nullable<bool> IsFaculty { get; set; }
        public Nullable<System.DateTime> AuthDate { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Order> Orders { get; set; }
    }
}

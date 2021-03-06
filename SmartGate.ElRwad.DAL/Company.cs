//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SmartGate.ElRwad.DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class Company
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Company()
        {
            this.Branches = new HashSet<Branch>();
        }
    
        public int Company_ID { get; set; }
        public string Company_Code { get; set; }
        public string Company_A_Name { get; set; }
        public string Company_E_Name { get; set; }
        public byte[] Small_Image { get; set; }
        public byte[] Back_Image { get; set; }
        public string Company_Notes { get; set; }
        public Nullable<int> Manager_ID { get; set; }
        public Nullable<int> User_ID { get; set; }
        public Nullable<System.DateTime> Last_Update { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Branch> Branches { get; set; }
        public virtual Employee Employee { get; set; }
    }
}

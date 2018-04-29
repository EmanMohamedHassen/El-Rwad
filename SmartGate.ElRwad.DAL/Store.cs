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
    
    public partial class Store
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Store()
        {
            this.AddingPermissions = new HashSet<AddingPermission>();
            this.ExportMains = new HashSet<ExportMain>();
            this.ExportMains1 = new HashSet<ExportMain>();
            this.MovementPermissions = new HashSet<MovementPermission>();
            this.MovementPermissions1 = new HashSet<MovementPermission>();
            this.Storing_Master = new HashSet<Storing_Master>();
        }
    
        public int Id { get; set; }
        public string Address { get; set; }
        public Nullable<int> RegionId { get; set; }
        public Nullable<int> CityId { get; set; }
        public string Phone { get; set; }
        public Nullable<int> StoreManagerId { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AddingPermission> AddingPermissions { get; set; }
        public virtual City City { get; set; }
        public virtual Employee Employee { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ExportMain> ExportMains { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ExportMain> ExportMains1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MovementPermission> MovementPermissions { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MovementPermission> MovementPermissions1 { get; set; }
        public virtual Region Region { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Storing_Master> Storing_Master { get; set; }
    }
}

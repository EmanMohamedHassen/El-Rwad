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
    
    public partial class Storing_Details
    {
        public int Id { get; set; }
        public string VIN { get; set; }
        public string PlateNo { get; set; }
        public string MotorNo { get; set; }
        public Nullable<int> DesiredCategoryId { get; set; }
        public Nullable<int> UserId { get; set; }
        public Nullable<int> Storing_Master_Id { get; set; }
        public Nullable<int> PurchaseOrderDetail_Id { get; set; }
    
        public virtual Storing_Master Storing_Master { get; set; }
        public virtual User User { get; set; }
        public virtual PurchaseOrderDetail PurchaseOrderDetail { get; set; }
    }
}

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
    
    public partial class PurchaseOrder_Accessories
    {
        public int Id { get; set; }
        public int SallesorderDetailsId { get; set; }
        public int Accessories_Id { get; set; }
        public Nullable<int> PurchaseOrder_Id { get; set; }
    
        public virtual Accessory Accessory { get; set; }
        public virtual purchaseOrder purchaseOrder { get; set; }
        public virtual SellOrder_Details SellOrder_Details { get; set; }
    }
}

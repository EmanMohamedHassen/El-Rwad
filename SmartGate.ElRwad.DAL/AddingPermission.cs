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
    
    public partial class AddingPermission
    {
        public int id { get; set; }
        public int userId { get; set; }
        public int carId { get; set; }
        public int purchaseOrderId { get; set; }
        public int indoresmentNo { get; set; }
        public int storeId { get; set; }
        public System.DateTime date { get; set; }
    
        public virtual Car Car { get; set; }
        public virtual purchaseOrder purchaseOrder { get; set; }
        public virtual Store Store { get; set; }
        public virtual User User { get; set; }
    }
}
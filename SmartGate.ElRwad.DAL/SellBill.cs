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
    
    public partial class SellBill
    {
        public int Id { get; set; }
        public Nullable<int> WithdrawpermId { get; set; }
    
        public virtual WithdrawPerm WithdrawPerm { get; set; }
    }
}

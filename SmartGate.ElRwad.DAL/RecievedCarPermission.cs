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
    
    public partial class RecievedCarPermission
    {
        public int id { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public Nullable<int> MovementID { get; set; }
        public Nullable<int> IndrosmentNumber { get; set; }
    
        public virtual MovementPermission MovementPermission { get; set; }
    }
}

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
    
    public partial class Shift
    {
        public int Id { get; set; }
        public Nullable<int> YearId { get; set; }
        public Nullable<System.DateTime> FromDate { get; set; }
        public Nullable<System.DateTime> ToDate { get; set; }
        public Nullable<int> FromMinute { get; set; }
        public Nullable<int> ToMinute { get; set; }
        public Nullable<int> FromHour { get; set; }
        public Nullable<int> ToHour { get; set; }
    
        public virtual Proj_Year Proj_Year { get; set; }
    }
}
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
    
    public partial class ShiftDetail
    {
        public int ShDetailId { get; set; }
        public int ShiftId { get; set; }
        public int DayNumber { get; set; }
        public System.DateTime Entrance { get; set; }
        public System.DateTime Exit { get; set; }
        public bool HasOverTime { get; set; }
        public System.DateTime OverTimeStart { get; set; }
        public double OverTime { get; set; }
    }
}

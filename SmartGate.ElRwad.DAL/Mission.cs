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
    
    public partial class Mission
    {
        public int Mission_ID { get; set; }
        public Nullable<int> Emp_ID { get; set; }
        public Nullable<byte> Month { get; set; }
        public Nullable<int> Year { get; set; }
        public string Mission_Causes { get; set; }
        public Nullable<System.DateTime> Mission_Date { get; set; }
        public Nullable<bool> Approv { get; set; }
        public Nullable<System.DateTime> Approv_Date { get; set; }
        public Nullable<int> From_Hour { get; set; }
        public Nullable<int> From_Minute { get; set; }
        public Nullable<int> To_Hour { get; set; }
        public Nullable<int> To_Minute { get; set; }
        public Nullable<int> User_ID { get; set; }
        public Nullable<System.DateTime> Update_Date { get; set; }
        public Nullable<int> ManagerID { get; set; }
    
        public virtual Employee Employee { get; set; }
        public virtual Employee Employee1 { get; set; }
        public virtual Proj_Month Proj_Month { get; set; }
        public virtual Proj_Year Proj_Year { get; set; }
        public virtual User User { get; set; }
    }
}
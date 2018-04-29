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
    
    public partial class Vacations_Orders
    {
        public int Order_ID { get; set; }
        public Nullable<System.DateTime> Order_Date { get; set; }
        public Nullable<int> VacationType_ID { get; set; }
        public Nullable<int> Employee_ID { get; set; }
        public Nullable<System.DateTime> From_Date { get; set; }
        public Nullable<System.DateTime> To_Date { get; set; }
        public Nullable<byte> Month_ID { get; set; }
        public Nullable<int> Year_ID { get; set; }
        public string Vacation_Notes { get; set; }
        public Nullable<byte> count { get; set; }
        public int User_ID { get; set; }
        public Nullable<System.DateTime> Last_Update { get; set; }
        public Nullable<int> Responsible_Employee_ID { get; set; }
        public Nullable<System.DateTime> Acceptance_Date { get; set; }
        public Nullable<int> AccpetedBy_ID { get; set; }
        public Nullable<int> OrderStatusId { get; set; }
    
        public virtual Employee Employee { get; set; }
        public virtual OrderStatu OrderStatu { get; set; }
        public virtual Proj_Month Proj_Month { get; set; }
        public virtual Proj_Year Proj_Year { get; set; }
        public virtual User User { get; set; }
        public virtual User User1 { get; set; }
        public virtual User User2 { get; set; }
        public virtual Vacations_Types Vacations_Types { get; set; }
    }
}

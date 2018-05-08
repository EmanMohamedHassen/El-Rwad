using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartGate.ElRwad.DAL;

namespace SmartGate.ElRwad.ViewModel.HR
{
   public class DeductionVM
    {
        public int Id { get; set; }
        public byte? Month { get; set; }
        public int? Year { get; set; }
        public string Date { get; set; }
        public int? EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeCode { get; set; }
        public double? DayCount { get; set; }
        public string Reason { get; set; }
        public string HRApprove { get; set; }
        public int? UserId { get; set; }
        public string LastUpdate { get; set; }
        public int? ManagerId { get; set; }
        public string ManagerName { get; set; }
    }
    public class DeductionPostVM
    {
        public int Id { get; set; }
        public byte? Month { get; set; }
        public int? Year { get; set; }
        public DateTime Date { get; set; }
        public int? EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public string EmployeeCode { get; set; }
        public double? DayCount { get; set; }
        public string Reason { get; set; }
        public string HRApprove { get; set; }
        public int? UserId { get; set; }
        public string LastUpdate { get; set; }
        public int? ManagerId { get; set; }
        public string ManagerName { get; set; }
    }

}

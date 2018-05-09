using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartGate.ElRwad.ViewModel.HR
{
   public class PermAbsentVM
    {
        public int permAbsId { get; set; }
        public string orderDate { get; set; }
        public int orderStatusId { get; set; }
        public string orderStatusName { get; set; }
        public string fromDate { get; set; }
        public string toDate { get; set; }
        public int? empId { get; set; }
        public string empName { get; set; }
        public byte? monthId { get; set; }
        public int? yearId { get; set; }
        public string approvDate { get; set; }
        public int? approvEmp { get; set; }
        public int? userId { get; set; }
        public string lastUpdate { get; set; }
        public string permAbsCauses { get; set; }
        public byte? count { get; set; }
    }
    public class PermAbsentForManagerVM
    {
        public int managerId { get; set; }
        public int month { get; set; }
        public int year { get; set; }
    }
    public class PermAbsentForHrVM
    {
        public int month { get; set; }
        public int year { get; set; }
    }
    public class PermAbsentPVM
    {
        public int permAbsId { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime fromDate { get; set; }
        public DateTime toDate { get; set; }
        public int? empId { get; set; }
        public byte? monthId { get; set; }
        public int? yearId { get; set; }
        public int? userId { get; set; }
        public string permAbsCauses { get; set; }
        public byte? count { get; set; }
    }
    public class PermAbsByVM
    {
        public int permAbsId { get; set; }
        public int OrderStatusId { get; set; }
        public int userId { get; set; }
    }
}

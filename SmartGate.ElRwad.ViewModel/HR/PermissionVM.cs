using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartGate.ElRwad.ViewModel.HR
{
   public class PermissionVM
    {
        public int orderId { get; set; }
        public string orderDate { get; set; }
        public int? leaveTypeId { get; set; }
        public string  leaveTypeName{ get; set; }
        public double? leaveHours { get; set; }
        public int? employeeId { get; set; }
        public string empCode { get; set; }
        public int orderStatusId { get; set; }
        public string orderStatusName { get; set; }
        public string employeeName { get; set; }
        public int? acceptedById { get; set; }
        public int? fromHour { get; set; }
        public int? fromMinute { get; set; }
        public int? toHour { get; set; }
        public int? toMinute { get; set; }
        public string permissionCause { get; set; }
        public string dayOrNight { get; set; }
        public string approveDate { get; set; }
        public int? userId { get; set; }
        public string lastUpdate { get; set; }
        public byte? month { get; set; }
        public int? year { get; set; }

    }
    public class returnVacationsDataVM
    {
        public int orderId { get; set; }
        public string orderDate { get; set; }
        public int? orderStatusId { get; set; }
        public int? leaveTypeId { get; set; }
        public string leaveTypeName { get; set; }
        public double? leaveHours { get; set; }
        public int? employeeId { get; set; }
        public string empCode { get; set; }
        public string empJob { get; set; }
        public string employeeName { get; set; }
        public int? acceptedById { get; set; }
        public int? fromHour { get; set; }
        public int? fromMinute { get; set; }
        public int? toHour { get; set; }
        public int? toMinute { get; set; }
        public string permissionCause { get; set; }
        public string dayOrNight { get; set; }
        public string approveDate { get; set; }
        public int? userId { get; set; }
        public string lastUpdate { get; set; }
        public byte? month { get; set; }
        public int? year { get; set; }
    }
    //permission post and put View Model
    public class PermissionPVM
    {
        public int orderId { get; set; }
        public DateTime orderDate { get; set; }
        public int? leaveTypeId { get; set; }
        public int? empId { get; set; }
        public int fromHour { get; set; }
        public int fromMinute { get; set; }
        public int toHour { get; set; }
        public int toMinute { get; set; }
        public string permissionCause { get; set; }
        public bool? dayOrNight { get; set; }
        public int? userId { get; set; }
        public byte? month { get; set; }
        public int? year { get; set; }

    }


    public class putPermission
    {
        public int permissionId { get; set; }
        public int OrderStatusId { get; set; }
        public int userId { get; set; }
    }

   
}

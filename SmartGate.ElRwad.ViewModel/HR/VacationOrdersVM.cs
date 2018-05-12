using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartGate.ElRwad.ViewModel.HR
{
   public class VacationOrdersVM
    {
        public int orderId { get; set; }
        public string orderDate { get; set; }
        public int? vacationTypeId { get; set; }
        public string vacationName { get; set; }
        public int? employeeId { get; set; }
        public string employeeName { get; set; }
        public string employeeCode { get; set; }
        public string employeeJob { get; set; }
        public string fromdate { get; set; }
        public string toDate { get; set; }
        public int? responsibleEmpId { get; set; }
        public int? orderStatusId { get; set; }
        public string orderstatusAr { get; set; }
        public string orderstatusEn { get; set; }
        public string acceptedDate { get; set; }
        public int? acceptedById { get; set; }
        public int? monthId { get; set; }
        public int? yearId { get; set; }
        public string vacationNotes { get; set; }
        public int? count { get; set; }
        public int? userId { get; set; }
        public string lastUpdate { get; set; }
    }
    public class VacationOrderPVM
    {
        public int vacationId { get; set; }
        public int vacationTypeId { get; set; }
        public int employeeId { get; set; }
        public DateTime fromDate { get; set; }
        public DateTime toDate { get; set; }
        public byte? monthId { get; set; }
        public int yearId { get; set; }
        public string vacationNotes { get; set; }
        public int userId { get; set; }
    }
    public class putVacationVM
    {
        public int vacationId { get; set; }
        public int? orderStatusId { get; set; }
        public int userId { get; set; }
    }
    public class retriveVacation
    {
        public int sum { get; set; }
        public int remainedDays { get; set; }
        public string vacationType { get; set; }
        public int maxDays { get; set; }


    }
}

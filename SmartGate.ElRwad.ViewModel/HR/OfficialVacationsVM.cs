using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartGate.ElRwad.ViewModel.HR
{
   public class OfficialVacationsVM
    {
        public int vacationId { get; set; }
        public int year { get; set; }
        public string fromDate { get; set; }
        public string toDate { get; set; }
        public bool? forEmpType { get; set; }
        public int? empTypeId { get; set; }
        public string empTypeName { get; set; }
        public string description { get; set; }
        public int? userId { get; set; }
        public string lastUpdate { get; set; }
    }
    public class OfficialVacationsPVM
    {
        public int vacationId { get; set; }
        public int year { get; set; }
        public DateTime fromDate { get; set; }
        public DateTime toDate { get; set; }
        public bool? forEmpType { get; set; }
        public int? empTypeId { get; set; }
        public string description { get; set; }
        public int? userId { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartGate.ElRwad.ViewModel.HR
{
   public class VacationTypeVM
    {
        public int vacationTypeId { get; set; }
        public string vacationTypeNameAr { get; set; }
        public string vacationTypeNameEn { get; set; }
        public int? vacationTypeMaxDays { get; set; }
        public string vacationTypePrintWithReports { get; set; }
        public int? vacationTypeMonthMaxTimes { get; set; }
        public int? vacationTypeRegMaxMonth { get; set; }
        public string vacationTypeWithPeriod { get; set; }
        public string vacationTypeFromDate { get; set; }
        public string vacationTypeToDate { get; set; }
        public string vacationTypeForEmpType { get; set; }
        public int? vacationTypeEmpType { get; set; }
        public string vacationTypeNotes { get; set; }
        public int? vacationTypeUserId { get; set; }
        public string vacationTypeLastUpdate { get; set; }
    }
    public class vacationTypeCVM
    {
        public int vacationTypeId { get; set; }
        public string vacationTypeNameAr { get; set; }
        public string vacationTypeNameEn { get; set; }
    }
    public class VacationTypePVM
    {
        public int vacationTypeId { get; set; }
        public string vacationTypeNameAr { get; set; }
        public string vacationTypeNameEn { get; set; }
        public int? vacationTypeMaxDays { get; set; }
        public bool? vacationTypePrintWithReports { get; set; }
        public int? vacationTypeMonthMaxTimes { get; set; }
        public int? vacationTypeRegMaxMonth { get; set; }
        public bool? vacationTypeWithPeriod { get; set; }
        public DateTime vacationTypeFromDate { get; set; }
        public DateTime vacationTypeToDate { get; set; }
        public bool? vacationTypeForEmpType { get; set; }
        public int? vacationTypeEmpType { get; set; }
        public string vacationTypeNotes { get; set; }
        public int? vacationTypeUserId { get; set; }
    }
}

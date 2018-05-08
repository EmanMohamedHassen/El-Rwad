using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartGate.ElRwad.ViewModel.HR
{
   public class EmployeeVM
    {
        public int empId { get; set; }
        public string empPrintCode { get; set; }
        public string fullName { get; set; }
        public string phone { get; set; }
        public string mobile { get; set; }
        public int? departmentId { get; set; }
        public string departmentAr { get; set; }
        public string departmentEn { get; set; }
        public int? managerId { get; set; }
        public string managerName { get; set; }
        public string ssn { get; set; }
        public string birthDate { get; set; }
        public int? cityId { get; set; }
        public string cityName { get; set; }
        public int? jobId { get; set; }
        public string jobName { get; set; }
        public int? categoryId { get; set; }
        public string categoryName { get; set; }
        public string address { get; set; }
        public string email { get; set; }
        public int? imageId { get; set; }
        public int? branchId { get; set; }
        public string branchName { get; set; }
        public string sex { get; set; }
        public string assignmentDate { get; set; }
        public string leaveReason { get; set; }
        public string insurance_Number { get; set; }
        public string isInsurance { get; set; }
        public double basicSalary { get; set; }
        public double insuranceSalary { get; set; }
        public double variableSalary { get; set; }
        public string isActive { get; set; }
        public int? userId { get; set; }
        public int? lastUserId { get; set; }
        public string lastUpdate { get; set; }
        public string leaveDate { get; set; }
        public string insuranceDate { get; set; }
        public string healthcheckDate { get; set; }
        public string insuranceEndDate { get; set; }
        public int? deputationId { get; set; }
        public string deputationName { get; set; }
        public int weekEndDay { get; set; }
        public int? shiftId { get; set; }
        public double? yearlySPInsuranceBasic { get; set; }
        public double? yearlySPInsuranceAdditional { get; set; }
        public int qualificationTypeId { get; set; }
        public string qualificationType { get; set; }
        public string qualify { get; set; }
        public int? universityId { get; set; }
        public int? facultyId { get; set; }
        public int? specialityId { get; set; }
        public int? gradYear { get; set; }
        public string gradProj { get; set; }
        public string totalGrad { get; set; }
        public string notes { get; set; }
    }
    public class EmployeePostVM
    {
        public string empPrintCode { get; set; }
        public string fullName { get; set; }
        public string phone { get; set; }
        public string mobile { get; set; }
        public string ssn { get; set; }
        public DateTime birthDate { get; set; }
        public int? cityId { get; set; }
        public string address { get; set; }
        public string email { get; set; }
        public int? branchId { get; set; }
        public int? jobId { get; set; }
        public string sex { get; set; }
        public int? categoryId { get; set; }
        public DateTime assignmentDate { get; set; }
        public string insurance_Number { get; set; }
        public string isInsurance { get; set; }
        public double basicSalary { get; set; }
        public double insuranceSalary { get; set; }
        public double variableSalary { get; set; }
        public int? userId { get; set; }
        public DateTime insuranceDate { get; set; }
        public DateTime healthcheckDate { get; set; }
        public DateTime insuranceEndDate { get; set; }
        public int? deputationId { get; set; }
        public int weekEndDay { get; set; }
        public int? shiftId { get; set; }
        public double? yearlySPInsuranceBasic { get; set; }
        public double? yearlySPInsuranceAdditional { get; set; }
        public int qualificationTypeId { get; set; }
        public string qualify { get; set; }
        public int? universityId { get; set; }
        public int? facultyId { get; set; }
        public int? specialityId { get; set; }
        public int? gradYear { get; set; }
        public string gradProj { get; set; }
        public string totalGrad { get; set; }
        public string notes { get; set; }
        public int? imageId { get; set; }  
    }
}

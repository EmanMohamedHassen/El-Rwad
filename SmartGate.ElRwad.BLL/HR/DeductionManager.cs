using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartGate.ElRwad.ViewModel;
using SmartGate.ElRwad.DAL;

namespace SmartGate.ElRwad.BLL.HR
{
   public class DeductionManager
    {
        private elRwadEntities db = new elRwadEntities();


        public dynamic GetAllDeductions()
        {
            var deduction = db.HR_Employee_Deductions.Select(s => new
            {

                deductionId = s.Deduction_ID,
                month = s.Month,
                year = s.Year,
                deductionDate = s.Deduction_Date.Value.Year.ToString() + "-" + s.Deduction_Date.Value.Month.ToString() + "-" + s.Deduction_Date.Value.Day.ToString(),
                employeeId = s.Employee_ID,
                empName = s.Employee.FullName,
                empPrintCode = s.Employee.Employee_Code,
                deducDayCount = s.DeducDay_Count,
                reason = s.Reason,
                hrApprov = s.HrApprov.ToString(),
                userId = s.User_ID,
                lastUpdate = s.Last_Update.Value.Year.ToString() + "-" + s.Last_Update.Value.Month.ToString() + "-" + s.Last_Update.Value.Day.ToString(),
                managerId = s.ManagerID,
                managerName = s.Employee1.FullName

            }).ToList();
            return deduction;
        }
        [HttpGet]
        public dynamic GetDeductionsForHr(byte monthID, int yearID)
        {
            var deduction = db.HR_Employee_Deductions.Where(e => e.Month == monthID && e.Year == yearID && e.HrApprov == null).Select(s => new
            {

                deductionId = s.Deduction_ID,
                month = s.Month,
                year = s.Year,
                deductionDate = s.Deduction_Date.Value.Year.ToString() + "-" + s.Deduction_Date.Value.Month.ToString() + "-" + s.Deduction_Date.Value.Day.ToString(),
                employeeId = s.Employee_ID,
                empName = s.Employee.FullName,
                empPrintCode = s.Employee.Employee_Code,
                deducDayCount = s.DeducDay_Count,
                reason = s.Reason,
                hrApprov = s.HrApprov.ToString(),
                userId = s.User_ID,
                lastUpdate = s.Last_Update.Value.Year.ToString() + "-" + s.Last_Update.Value.Month.ToString() + "-" + s.Last_Update.Value.Day.ToString(),
                managerId = s.ManagerID,
                managerName = s.Employee1.FullName

            }).ToList();
            return deduction;
        }


        [HttpGet]
        public dynamic GetDeductionsForHr()
        {
            var deduction = db.HR_Employee_Deductions.Where(e => e.HrApprov == null).Select(s => new
            {

                deductionId = s.Deduction_ID,
                month = s.Month,
                year = s.Year,
                deductionDate = s.Deduction_Date.Value.Year.ToString() + "-" + s.Deduction_Date.Value.Month.ToString() + "-" + s.Deduction_Date.Value.Day.ToString(),
                employeeId = s.Employee_ID,
                empName = s.Employee.FullName,
                empPrintCode = s.Employee.Employee_Code,
                deducDayCount = s.DeducDay_Count,
                reason = s.Reason,
                hrApprov = s.HrApprov.ToString(),
                userId = s.User_ID,
                lastUpdate = s.Last_Update.Value.Year.ToString() + "-" + s.Last_Update.Value.Month.ToString() + "-" + s.Last_Update.Value.Day.ToString(),
                managerId = s.ManagerID,
                managerName = s.Employee1.FullName

            }).ToList();
            return deduction;
        }

        [HttpGet]
        public dynamic GetDeductions(byte monthID, int yearID)
        {
            var deduction = db.HR_Employee_Deductions.Where(s => s.Month == monthID && s.Year == yearID && s.HrApprov == true).Select(s => new
            {

                deductionId = s.Deduction_ID,
                month = s.Month,
                year = s.Year,
                deductionDate = s.Deduction_Date.Value.Year.ToString() + "-" + s.Deduction_Date.Value.Month.ToString() + "-" + s.Deduction_Date.Value.Day.ToString(),
                employeeId = s.Employee_ID,
                empName = s.Employee.FullName,
                empPrintCode = s.Employee.Employee_Code,
                deducDayCount = s.DeducDay_Count,
                reason = s.Reason,
                hrApprov = s.HrApprov.ToString(),
                userId = s.User_ID,
                lastUpdate = s.Last_Update.Value.Year.ToString() + "-" + s.Last_Update.Value.Month.ToString() + "-" + s.Last_Update.Value.Day.ToString(),
                managerId = s.ManagerID,
                managerName = s.Employee1.FullName

            }).ToList();
            return deduction;
        }
        [HttpGet]

        public dynamic GetDeductionById(int deductionId)
        {
            try
            {
                var s = db.HR_Employee_Deductions.Where(e => e.Deduction_ID == deductionId).FirstOrDefault();
                if (s != null)
                {
                    return new
                    {
                        deductionId = s.Deduction_ID,
                        month = s.Month,
                        year = s.Year,
                        deductionDate = s.Deduction_Date.Value.ToString("yyyy-MM-dd"),
                        employeeId = s.Employee_ID,
                        empName = s.Employee.FullName,
                        empPrintCode = s.Employee.Employee_Code,
                        deducDayCount = s.DeducDay_Count,
                        reason = s.Reason,
                        hrApprov = s.HrApprov.ToString(),
                        userId = s.User_ID,
                        lastUpdate = s.Last_Update.Value.ToString("yyyy-MM-dd"),
                        managerId = s.ManagerID,
                        managerName = s.Employee1.FullName
                    };
                }
                else
                {
                    return new
                    {
                        Id = 0
                    };
                }

            }
            catch (Exception ex)
            {
                return new
                {
                    result = new
                    {
                        Id = 0
                    }
                };
            }
        }
        [HttpGet]

        public dynamic GetDeductionByDate(DateTime fromDate, DateTime toDate)
        {
            try
            {
                var deduction = db.HR_Employee_Deductions.Where(e => e.Deduction_Date >= fromDate.Date && e.Deduction_Date <= toDate.Date && e.HrApprov == true).Select(s => new
                {
                    deductionId = s.Deduction_ID,
                    month = s.Month,
                    year = s.Year,
                    deductionDate = s.Deduction_Date.Value.Year.ToString() + "-" + s.Deduction_Date.Value.Month.ToString() + "-" + s.Deduction_Date.Value.Day.ToString(),
                    employeeId = s.Employee_ID,
                    empName = s.Employee.FullName,
                    empPrintCode = s.Employee.Employee_Code,
                    deducDayCount = s.DeducDay_Count,
                    reason = s.Reason,
                    hrApprov = s.HrApprov.ToString(),
                    userId = s.User_ID,
                    lastUpdate = s.Last_Update.Value.Year.ToString() + "-" + s.Last_Update.Value.Month.ToString() + "-" + s.Last_Update.Value.Day.ToString(),
                    managerId = s.ManagerID,
                    managerName = s.Employee1.FullName

                }).ToList();
                return deduction;

            }
            catch (Exception ex)
            {
                return new
                {
                    result = new
                    {
                        Id = 0
                    }
                };
            }
        }
        [HttpGet]

        public dynamic GetDeductionByDateAndEmpId(int empId, DateTime fromDate, DateTime toDate)
        {
            try
            {
                var deduction = db.HR_Employee_Deductions.Where(e => e.Employee_ID == empId && e.Deduction_Date >= fromDate.Date && e.Deduction_Date <= toDate.Date && e.HrApprov == true).Select(s => new
                {
                    deductionId = s.Deduction_ID,
                    month = s.Month,
                    year = s.Year,
                    deductionDate = s.Deduction_Date.Value.Year.ToString() + "-" + s.Deduction_Date.Value.Month.ToString() + "-" + s.Deduction_Date.Value.Day.ToString(),
                    employeeId = s.Employee_ID,
                    empName = s.Employee.FullName,
                    empPrintCode = s.Employee.Employee_Code,
                    deducDayCount = s.DeducDay_Count,
                    reason = s.Reason,
                    hrApprov = s.HrApprov.ToString(),
                    userId = s.User_ID,
                    lastUpdate = s.Last_Update.Value.Year.ToString() + "-" + s.Last_Update.Value.Month.ToString() + "-" + s.Last_Update.Value.Day.ToString(),
                    managerId = s.ManagerID,
                    managerName = s.Employee1.FullName

                }).ToList();
                return deduction;

            }
            catch (Exception ex)
            {
                return new
                {
                    result = new
                    {
                        Id = 0
                    }
                };
            }
        }
        [HttpGet]

        public dynamic GetDeductionByDateAndDepartmentId(int depId, DateTime fromDate, DateTime toDate)
        {
            try
            {
                var deduction = db.HR_Employee_Deductions.Where(e => e.Employee.Job.Department_ID == depId && e.Deduction_Date >= fromDate.Date && e.Deduction_Date <= toDate.Date && e.HrApprov == true).Select(s => new
                {
                    deductionId = s.Deduction_ID,
                    month = s.Month,
                    year = s.Year,
                    deductionDate = s.Deduction_Date.Value.Year.ToString() + "-" + s.Deduction_Date.Value.Month.ToString() + "-" + s.Deduction_Date.Value.Day.ToString(),
                    employeeId = s.Employee_ID,
                    empName = s.Employee.FullName,
                    empPrintCode = s.Employee.Employee_Code,
                    deducDayCount = s.DeducDay_Count,
                    reason = s.Reason,
                    hrApprov = s.HrApprov.ToString(),
                    userId = s.User_ID,
                    lastUpdate = s.Last_Update.Value.Year.ToString() + "-" + s.Last_Update.Value.Month.ToString() + "-" + s.Last_Update.Value.Day.ToString(),
                    managerId = s.ManagerID,
                    managerName = s.Employee1.FullName

                }).ToList();
                return deduction;

            }
            catch (Exception ex)
            {
                return new
                {
                    result = new
                    {
                        Id = 0
                    }
                };
            }
        }
        [HttpGet]

        public dynamic GetDeductionByDateAndCategory(int depId, DateTime fromDate, DateTime toDate)
        {
            try
            {
                var deduction = db.HR_Employee_Deductions.Where(e => e.Employee.Job.Department_ID == depId && e.Deduction_Date >= fromDate.Date && e.Deduction_Date <= toDate.Date && e.HrApprov == true)
                    .Select(s => new
                    {
                        deductionId = s.Deduction_ID,
                        month = s.Month,
                        year = s.Year,
                        deductionDate = s.Deduction_Date.Value.Year.ToString() + "-" + s.Deduction_Date.Value.Month.ToString() + "-" + s.Deduction_Date.Value.Day.ToString(),
                        employeeId = s.Employee_ID,
                        empName = s.Employee.FullName,
                        empPrintCode = s.Employee.Employee_Code,
                        deducDayCount = s.DeducDay_Count,
                        reason = s.Reason,
                        hrApprov = s.HrApprov.ToString(),
                        userId = s.User_ID,
                        lastUpdate = s.Last_Update.Value.Year.ToString() + "-" + s.Last_Update.Value.Month.ToString() + "-" + s.Last_Update.Value.Day.ToString(),
                        managerId = s.ManagerID,
                        managerName = s.Employee1.FullName

                    }).ToList();
                return deduction;

            }
            catch (Exception ex)
            {
                return new
                {
                    result = new
                    {
                        Id = 0
                    }
                };
            }
        }


        //[HttpGet]

        //public dynamic GetDeductionByDateAndDepartmentId(int empId, int depId, DateTime fromDate, DateTime toDate)
        //{
        //    try
        //    {
        //        var deduction = db.HR_Employee_Deductions.Where(e => e.Employee_ID == empId 
        //        && e.Employee.Job.Department_ID == depId && e.Deduction_Date.Value.Date >= fromDate.Date 
        //        && e.Deduction_Date.Value.Date <= toDate.Date).Select(s => new
        //        {
        //            deductionId = s.Deduction_ID,
        //            month = s.Month,
        //            year = s.Year,
        //            deductionDate = s.Deduction_Date,
        //            employeeId = s.Employee_ID,
        //            empName = s.Employee.FullName,
        //            empPrintCode = s.Employee.Employee_Code,
        //            deducDayCount = s.DeducDay_Count,
        //            reason = s.Reason,
        //            userId = s.User_ID,
        //            lastUpdate = s.Last_Update,
        //            managerId = s.ManagerID

        //        }).ToList();
        //        return deduction;

        //    }
        //    catch (Exception ex)
        //    {
        //        return new
        //        {
        //            result = new
        //            {
        //                Id = 0
        //            }
        //        };
        //    }
        //}

        [HttpPost]
        public dynamic PostDeduction(
            DateTime deductionDate,
            byte month,
            int year,
            int managerId,
            int employeeId,
            int deducDayCount,
            string reason,
            int userId
            )
        {
            var deduction = db.HR_Employee_Deductions.Add(new HR_Employee_Deductions
            {
                Deduction_Date = deductionDate,
                Month = month,
                Year = year,
                ManagerID = managerId,
                Employee_ID = employeeId,
                HrApprov = null,
                DeducDay_Count = deducDayCount,
                Reason = reason,
                User_ID = userId,
                Last_Update = DateTime.Now


            });
            var result = db.SaveChanges() > 0 ? true : false;
            return new
            {
                result = result,
                deduction = deduction.Deduction_ID
            };
        }
        [HttpPut]
        [AcceptVerbs("GET", "POST")]
        public dynamic PutDeduction(int deductionId,
            DateTime deductionDate,
            byte month,
            int year,
            int managerId,
            int employeeId,
            int deducDayCount,
            string reason,
            int userId
            )
        {
            var deduction = db.HR_Employee_Deductions.Find(deductionId);
            deduction.Month = month;
            deduction.Year = year;
            deduction.Deduction_Date = deductionDate;
            deduction.Employee_ID = employeeId;
            deduction.DeducDay_Count = deducDayCount;
            deduction.Reason = reason;
            deduction.HrApprov = null;
            deduction.User_ID = userId;
            deduction.Last_Update = DateTime.Now;
            deduction.ManagerID = managerId;
            var result = db.SaveChanges() > 0 ? true : false;
            return new
            {
                result = result
            };
        }

        [HttpPut]
        [AcceptVerbs("GET", "POST")]
        public dynamic PutDeductionForApprov(int deductionId,
            bool hrApprov,
            int userId
            )
        {
            var deduction = db.HR_Employee_Deductions.Find(deductionId);

            deduction.HrApprov = hrApprov;
            deduction.User_ID = userId;
            deduction.Last_Update = DateTime.Now;

            var result = db.SaveChanges() > 0 ? true : false;
            return new
            {
                result = result
            };
        }


        [HttpDelete]
        [AcceptVerbs("GET", "POST")]
        public dynamic DeleteDeduction(int deductionId)
        {
            var deduction = db.HR_Employee_Deductions.Where(s => s.Deduction_ID == deductionId).FirstOrDefault();
            db.HR_Employee_Deductions.Remove(deduction);
            var result = db.SaveChanges() > 0 ? true : false;
            return new
            {
                result = result
            };

        }
        [HttpGet]
        private dynamic DeductionExists(int deductionId)
        {
            var deduction = db.HR_Employee_Deductions.Count(s => s.Deduction_ID == deductionId) > 0 ? true : false;
            return new
            {
                deduction = deduction
            };
        }



    }
}

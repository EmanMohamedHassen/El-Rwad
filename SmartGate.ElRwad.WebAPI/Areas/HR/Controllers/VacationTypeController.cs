using SmartGate.ElRwad.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SmartGate.ElRwad.WebAPI.Areas.HR.Controllers
{
    public class VacationTypeController : ApiController
    {
        private elRwadEntities db = new elRwadEntities();
        [HttpGet]
        public dynamic GetVacationType()
        {
            var vacationType = db.Vacations_Types.Select(s => new
            {
                vacationTypeId = s.VacationType_ID,
                vacationTypeNameAr = s.Type_Name,
                vacationTypeNameEn = s.Type_Name_EN,
                vacationTypeMaxDays = s.Max_Days,
                vacationTypePrintWithReports = s.Print_With_Reports.ToString(),
                vacationTypeMonthMaxTimes = s.Month_Max_Times,
                vacationTypeRegMaxMonth = s.Reg_Max_Month,
                vacationTypeWithPeriod = s.With_Period.ToString(),
                vacationTypeFromDate = s.From_Date.Value.Year.ToString() + "-" + s.From_Date.Value.Month.ToString() + "-" + s.From_Date.Value.Day.ToString(),
                vacationTypeToDate = s.To_Date.Value.Year.ToString() + "-" + s.To_Date.Value.Month.ToString() + "-" + s.To_Date.Value.Day.ToString(),
                vacationTypeForEmpType = s.For_Emp_Type.ToString(),
                vacationTypeEmpType = s.Emp_Type,
                vacationTypeNotes = s.Notes,
                vacationTypeUserId = s.User_ID,

                vacationTypeLastUpdate = s.Last_Update.Value.Year.ToString() + "-" + s.Last_Update.Value.Month.ToString() + "-" + s.Last_Update.Value.Day.ToString()

            }).ToList();
            return vacationType;
        }
        [HttpGet]

        public dynamic GetVacationTypeById(int vacationTypeId)
        {
            try
            {
                var s = db.Vacations_Types.Where(e => e.VacationType_ID == vacationTypeId).FirstOrDefault();
                if (s != null)
                {
                    return new
                    {
                        //vacationTypeId = s.VacationType_ID,
                        vacationTypeNameAr = s.Type_Name,
                        vactionTypeNameEn = s.Type_Name_EN,
                        vacationTypeMaxDays = s.Max_Days,
                        vacationTypePrintWithReports = s.Print_With_Reports.ToString(),
                        vacationTypeMonthMaxTimes = s.Month_Max_Times,
                        vacationTypeRegMaxMonth = s.Reg_Max_Month,
                        vacationTypeWithPeriod = s.With_Period.ToString(),
                        vacationTypeFromDate = s.From_Date.Value.Year.ToString() + "-" + s.From_Date.Value.Month.ToString() + "-" + s.From_Date.Value.Day.ToString(),
                        vacationTypeToDate = s.To_Date.Value.Year.ToString() + "-" + s.To_Date.Value.Month.ToString() + "-" + s.To_Date.Value.Day.ToString(),
                        vacationTypeForEmpType = s.For_Emp_Type.ToString(),
                        vacationTypeEmpType = s.Emp_Type,
                        vacationTypeNotes = s.Notes,
                        vacationTypeUserId = s.User_ID,
                        vacationTypeLastUpdate = s.Last_Update.Value.Year.ToString() + "-" + s.Last_Update.Value.Month.ToString() + "-" + s.Last_Update.Value.Day.ToString()

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


        public dynamic GetVacationTypeByCategoryId(int CategoryId) //to get all vacations types which available to this employee and him category
        {
            try
            {
                var vacationTypes = db.Vacations_Types.Where(e => e.For_Emp_Type == false || (e.For_Emp_Type == true && e.Emp_Type == CategoryId)).Select(s => new
                {
                    vacationTypeId = s.VacationType_ID,
                    //vacationTypecod = s.Type_Code,
                    vacationTypename = s.Type_Name,
                    vactionTypeNameEn = s.Type_Name_EN,
                    // vacationTypeMaxDays = s.Max_Days,
                    //vacationTypePrintWithReports = s.Print_With_Reports,  
                    //vacationTypeMonthMaxTimes = s.Month_Max_Times,
                    //vacationTypeRegMaxMonth = s.Reg_Max_Month,
                    //vacationTypeWithPeriod = s.With_Period,
                    // vacationTypeFromDate = s.From_Date,
                    // vacationTypeToDate = s.To_Date,
                    // vacationTypeForNewYear = s.For_NewYear,
                    // vacationTypeForEmpType = s.For_Emp_Type,
                    // vacationTypeEmpType = s.Emp_Type,
                    //vacationTypeNotes = s.Notes,
                    //vacationTypeUserId = s.User_ID,
                    //vacationTypeLastUpdate = s.Last_Update

                }).ToList();
                return vacationTypes;
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

        [HttpPost]
        public dynamic PostVacationType(
            string vacationTypeNameAr,
            string vacationTypeNameEn,
            int vacationTypeMaxDays,
            bool vacationTypePrintWithReports,
            int vacationTypeMonthMaxTimes,
            int vacationTypeRegMaxMonth,
            bool vacationTypeWithPeriod,
            DateTime vacationTypeFromDate,
            DateTime vacationTypeToDate,
            bool vacationTypeForEmpType,
            int vacationTypeEmpType,
            string vacationTypeNotes,
            int UserId

            )
        {


            var vacationType = db.Vacations_Types.Add(new Vacations_Types
            {
                Type_Name = vacationTypeNameAr,//؟؟
                Type_Name_EN = vacationTypeNameEn,
                Max_Days = vacationTypeMaxDays,  //اقصى عدد ايام اجازة النوع ده فى السنة
                Print_With_Reports = vacationTypePrintWithReports,  //تقرير رصيد الاجازات هيدخل فى التقرير بتاع اجازات الموظف ولا لا
                Month_Max_Times = vacationTypeMonthMaxTimes, //اقصى عدد ايام اجازة النوع ده فى الشهر
                Reg_Max_Month = vacationTypeRegMaxMonth,
                With_Period = vacationTypeWithPeriod,//ترتبط بفترة زمنية 
                From_Date = vacationTypeFromDate,//فترة زمنية من
                To_Date = vacationTypeToDate,//فترة زمنية الى
                For_Emp_Type = vacationTypeForEmpType,
                Emp_Type = vacationTypeEmpType,
                Notes = vacationTypeNotes,
                User_ID = UserId,
                Last_Update = DateTime.Now
            });
            var result = db.SaveChanges() > 0 ? true : false;
            return new
            {
                result = result,
                vacationTypeId = vacationType.VacationType_ID
            };
        }

        [HttpPut]
        [AcceptVerbs("GET", "POST")]
        public dynamic PutVacationType(
            int vacationTypeId,
            string vacationTypeNameAr,
            string vacationTypeNameEn,
            int vacationTypeMaxDays,
            bool vacationTypePrintWithReports,
            int vacationTypeMonthMaxTimes,
            int vacationTypeRegMaxMonth,
            bool vacationTypeWithPeriod,
            DateTime vacationTypeFromDate,
            DateTime vacationTypeToDate,
            bool vacationTypeForEmpType,
            int vacationTypeEmpType,
            string vacationTypeNotes,
            int UserId
            )

        {
            var vacationType = db.Vacations_Types.Find(vacationTypeId);
            vacationType.Type_Name = vacationTypeNameAr;
            vacationType.Type_Name_EN = vacationTypeNameEn;
            vacationType.Max_Days = vacationTypeMaxDays;
            vacationType.Print_With_Reports = vacationTypePrintWithReports;
            vacationType.Month_Max_Times = vacationTypeMonthMaxTimes;
            vacationType.Reg_Max_Month = vacationTypeRegMaxMonth;
            vacationType.With_Period = vacationTypeWithPeriod;
            vacationType.From_Date = vacationTypeFromDate;
            vacationType.To_Date = vacationTypeToDate;
            vacationType.For_Emp_Type = vacationTypeForEmpType;
            vacationType.Emp_Type = vacationTypeEmpType;
            vacationType.Notes = vacationTypeNotes;
            vacationType.User_ID = UserId;
            vacationType.Last_Update = DateTime.Now;


            var result = db.SaveChanges() > 0 ? true : false;
            return new
            {
                result = result
            };

        }

        [HttpDelete]
        [AcceptVerbs("GET", "POST")]
        public dynamic DeleteVacationType(int vacationTypeId)
        {
            var vacationType = db.Vacations_Types.Where(s => s.VacationType_ID == vacationTypeId).FirstOrDefault();
            db.Vacations_Types.Remove(vacationType);
            var result = db.SaveChanges() > 0 ? true : false;
            return new
            {
                result = result
            };
        }

        [HttpGet]
        private dynamic VacationTypeExists(int vacationTypeId)
        {
            var vacationType = db.Vacations_Types.Count(s => s.VacationType_ID == vacationTypeId) > 0 ? true : false;
            return new
            {
                vacationType = vacationType
            };
        }





    }
}

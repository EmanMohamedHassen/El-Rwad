using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartGate.ElRwad.ViewModel.HR;
using SmartGate.ElRwad.DAL;


namespace SmartGate.ElRwad.BLL.HR
{
   public class VacationTypeManager
    {
        private static VacationTypeManager instance;
        public static VacationTypeManager Instance { get { return instance; } }
        static VacationTypeManager()
        {
            instance = new VacationTypeManager();
        }
            private elRwadEntities db = new elRwadEntities();
            public dynamic GetVacationType()
            {
                List<VacationTypeVM> vacationType = db.Vacations_Types.Select(s => new VacationTypeVM
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

            public dynamic GetVacationTypeById(int vacationTypeId)
            {
                try
                {
                    var s = db.Vacations_Types.Where(e => e.VacationType_ID == vacationTypeId).FirstOrDefault();
                    if (s != null)
                    {
                        return new VacationTypeVM
                        {
                            //vacationTypeId = s.VacationType_ID,
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
                return ex.Message;
                }
            }
            public dynamic GetVacationTypeByCategoryId(int CategoryId) //to get all vacations types which available to this employee and him category
            {
                try
                {
                    List<vacationTypeCVM> vacationTypes = db.Vacations_Types.Where(e => e.For_Emp_Type == false || (e.For_Emp_Type == true && e.Emp_Type == CategoryId)).Select(s => new vacationTypeCVM
                    {
                        vacationTypeId = s.VacationType_ID,
                        vacationTypeNameAr = s.Type_Name,
                        vacationTypeNameEn = s.Type_Name_EN,
                   

                    }).ToList();
                    return vacationTypes;
                }
                catch (Exception ex)
                {
                return ex.Message;
                }
            }

            public dynamic PostVacationType(VacationTypePVM v)
            {
                var vacationType = db.Vacations_Types.Add(new Vacations_Types
                {
                    Type_Name = v.vacationTypeNameAr,//؟؟
                    Type_Name_EN = v.vacationTypeNameEn,
                    Max_Days = v.vacationTypeMaxDays,  //اقصى عدد ايام اجازة النوع ده فى السنة
                    Print_With_Reports = v.vacationTypePrintWithReports,  //تقرير رصيد الاجازات هيدخل فى التقرير بتاع اجازات الموظف ولا لا
                    Month_Max_Times = v.vacationTypeMonthMaxTimes, //اقصى عدد ايام اجازة النوع ده فى الشهر
                    Reg_Max_Month = v.vacationTypeRegMaxMonth,
                    With_Period = v.vacationTypeWithPeriod,//ترتبط بفترة زمنية 
                    From_Date = v.vacationTypeFromDate,//فترة زمنية من
                    To_Date = v.vacationTypeToDate,//فترة زمنية الى
                    For_Emp_Type = v.vacationTypeForEmpType,
                    Emp_Type = v.vacationTypeEmpType,
                    Notes = v.vacationTypeNotes,
                    User_ID = v.vacationTypeUserId,
                    Last_Update = DateTime.Now
                });
                var result = db.SaveChanges() > 0 ? true : false;
                return new
                {
                    result = result,
                    vacationTypeId = vacationType.VacationType_ID
                };
            }

            public dynamic PutVacationType(VacationTypePVM v)

            {
                var vacationType = db.Vacations_Types.Find(v.vacationTypeId);
                vacationType.Type_Name = v.vacationTypeNameAr;
                vacationType.Type_Name_EN = v.vacationTypeNameEn;
                vacationType.Max_Days = v.vacationTypeMaxDays;
                vacationType.Print_With_Reports = v.vacationTypePrintWithReports;
                vacationType.Month_Max_Times = v.vacationTypeMonthMaxTimes;
                vacationType.Reg_Max_Month = v.vacationTypeRegMaxMonth;
                vacationType.With_Period = v.vacationTypeWithPeriod;
                vacationType.From_Date = v.vacationTypeFromDate;
                vacationType.To_Date = v.vacationTypeToDate;
                vacationType.For_Emp_Type = v.vacationTypeForEmpType;
                vacationType.Emp_Type = v.vacationTypeEmpType;
                vacationType.Notes = v.vacationTypeNotes;
                vacationType.User_ID = v.vacationTypeUserId;
                vacationType.Last_Update = DateTime.Now;


                var result = db.SaveChanges() > 0 ? true : false;
                return new
                {
                    result = result
                };

            }


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


            public dynamic VacationTypeExists(int vacationTypeId)
            {
                var vacationType = db.Vacations_Types.Count(s => s.VacationType_ID == vacationTypeId) > 0 ? true : false;
                return new
                {
                    vacationType = vacationType
                };
            }





        }
    }


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartGate.ElRwad.ViewModel.HR;
using SmartGate.ElRwad.DAL;
namespace SmartGate.ElRwad.BLL.HR
{
   public class OfficialVacationsManager
    {
        private static OfficialVacationsManager instance;
        public static OfficialVacationsManager Instance { get { return instance; } }
        static OfficialVacationsManager()
        {
            instance = new OfficialVacationsManager();
        }
            private elRwadEntities db = new elRwadEntities();
            public dynamic GetOfficialVacations()
            {
                List<OfficialVacationsVM> officialVacatios = db.Official_Vacation.Select(s => new OfficialVacationsVM
                {
                    vacationId = s.VacationID,
                    year = s.Year,
                    fromDate = s.FromDate.Value.Year.ToString() + "-" + s.FromDate.Value.Month.ToString() + "-" + s.FromDate.Value.Day.ToString(),
                    toDate = s.ToDate.Value.Year.ToString() + "-" + s.ToDate.Value.Month.ToString() + "-" + s.ToDate.Value.Day.ToString(),
                    forEmpType = s.For_EmpTyp,
                    empTypeId = s.EmpTyp_ID,
                    empTypeName = s.Employees_Categories.Category_Code,
                    description = s.Description,
                    userId = s.UserId,
                    lastUpdate = s.LastUpdate.Value.Year.ToString() + "-" + s.LastUpdate.Value.Month.ToString() + "-" + s.LastUpdate.Value.Day.ToString()
                }).ToList();
                return officialVacatios;
            }

            public dynamic GetOfficialVacationById(int vacationId)
            {
                try
                {
                    var s = db.Official_Vacation.Where(e => e.VacationID == vacationId).FirstOrDefault();
                    if (s != null)
                    {
                        return new OfficialVacationsVM
                        {
                            // orderId = s.Order_ID,
                            year = s.Year,
                            fromDate = s.FromDate.Value.ToString("yyyy-MM-dd"),
                            toDate = s.ToDate.Value.ToString("yyyy-MM-dd"),
                            forEmpType = s.For_EmpTyp,
                            empTypeId = s.EmpTyp_ID,
                            empTypeName = s.Employees_Categories.Category_Code,
                            description = s.Description,
                            userId = s.UserId,
                            lastUpdate = s.LastUpdate.Value.ToString("yyyy-MM-dd")
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

            public dynamic GetOfficialVacationByDate(DateTime fromDate, DateTime toDate)
            {
                try
                {
                    List<OfficialVacationsVM> officialVacatios = db.Official_Vacation.Where(e => e.FromDate >= fromDate.Date && e.ToDate <= toDate.Date).Select(s => new OfficialVacationsVM
                    {
                        // orderId = s.Order_ID,
                        year = s.Year,
                        fromDate = s.FromDate.Value.Year.ToString() + "-" + s.FromDate.Value.Month.ToString() + "-" + s.FromDate.Value.Day.ToString(),
                        toDate = s.ToDate.Value.Year.ToString() + "-" + s.ToDate.Value.Month.ToString() + "-" + s.ToDate.Value.Day.ToString(),
                        forEmpType = s.For_EmpTyp,
                        empTypeId = s.EmpTyp_ID,
                        empTypeName = s.Employees_Categories.Category_Code,
                        description = s.Description,
                        userId = s.UserId,
                        lastUpdate = s.LastUpdate.Value.Year.ToString() + "-" + s.LastUpdate.Value.Month.ToString() + "-" + s.LastUpdate.Value.Day.ToString()
                    }).ToList();
                    return officialVacatios;
                }
                catch (Exception ex)
                {
                return ex.Message;
                }
            }


            public dynamic GetOfficialVacationByEmpTypeId(int empTypeId)
            {
                try
                {
                    List<OfficialVacationsVM> officialVacatios = db.Official_Vacation.Where(e => e.EmpTyp_ID == empTypeId).Select(s => new OfficialVacationsVM
                    {
                        // orderId = s.Order_ID,
                        year = s.Year,
                        fromDate = s.FromDate.Value.Year.ToString() + "-" + s.FromDate.Value.Month.ToString() + "-" + s.FromDate.Value.Day.ToString(),
                        toDate = s.ToDate.Value.Year.ToString() + "-" + s.ToDate.Value.Month.ToString() + "-" + s.ToDate.Value.Day.ToString(),
                        forEmpType = s.For_EmpTyp,
                        empTypeId = s.EmpTyp_ID,
                        empTypeName = s.Employees_Categories.Category_Code,
                        description = s.Description,
                        userId = s.UserId,
                        lastUpdate = s.LastUpdate.Value.Year.ToString() + "-" + s.LastUpdate.Value.Month.ToString() + "-" + s.LastUpdate.Value.Day.ToString()
                    }).ToList();
                    return officialVacatios;
                }
                catch (Exception ex)
                {
                return ex.Message;
                }
            }


            public dynamic PostOfficialVacation(OfficialVacationsPVM v)
            {


                var officialVacation = db.Official_Vacation.Add(new Official_Vacation
                {
                    FromDate = v.fromDate,
                    ToDate = v.toDate,
                    For_EmpTyp = v.forEmpType,
                    EmpTyp_ID = v.empTypeId,
                    Description = v.description,
                    UserId = v.userId,
                    LastUpdate = DateTime.Now,
                    Year = v.year
                    

                });
                var result = db.SaveChanges() > 0 ? true : false;
                return new
                {
                    result = result,
                    officialVacation = officialVacation.VacationID
                };
            }
            public dynamic PutOfficialVacation(OfficialVacationsPVM v)
            {
                var officialVacation = db.Official_Vacation.Find(v.vacationId);
                int vacationDateYear = v.fromDate.Year;
                officialVacation.FromDate = v.fromDate;
                officialVacation.ToDate = v.toDate;
                officialVacation.For_EmpTyp = v.forEmpType;
                officialVacation.EmpTyp_ID = v.empTypeId;
                officialVacation.Description = v.description;
                officialVacation.UserId = v.userId;
                officialVacation.LastUpdate = DateTime.Now;
                officialVacation.Year = v.year;


                var result = db.SaveChanges() > 0 ? true : false;
                return new
                {
                    result = result
                };
            }
            public dynamic DeleteOfficialVacation(int vacationId)
            {
                var OfficialVacation = db.Official_Vacation.Where(s => s.VacationID == vacationId).FirstOrDefault();
                db.Official_Vacation.Remove(OfficialVacation);
                var result = db.SaveChanges() > 0 ? true : false;
                return new
                {
                    result = result
                };
            }
            public dynamic OfficialVacationExists(int vacationId)
            {
                var OfficialVacation = db.Official_Vacation.Count(s => s.VacationID == vacationId) > 0 ? true : false;
                return new
                {
                    OfficialVacation = OfficialVacation
                };
            }


        }
    }



using SmartGate.ElRwad.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SmartGate.ElRwad.WebAPI.Areas.HR.Controllers
{
    public class OfficialVacationsController : ApiController
    {
        private elRwadEntities db = new elRwadEntities();



        [HttpGet]
        public dynamic GetOfficialVacations()
        {
            var officialVacatios = db.Official_Vacation.Select(s => new
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


        [HttpGet]

        public dynamic GetOfficialVacationById(int vacationId)
        {
            try
            {
                var s = db.Official_Vacation.Where(e => e.VacationID == vacationId).FirstOrDefault();
                if (s != null)
                {
                    return new
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
        public dynamic GetOfficialVacationByDate(DateTime fromDate, DateTime toDate)
        {
            try
            {
                var officialVacatios = db.Official_Vacation.Where(e => e.FromDate >= fromDate.Date && e.ToDate <= toDate.Date).Select(s => new
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
        public dynamic GetOfficialVacationByEmpTypeId(int empTypeId)
        {
            try
            {
                var officialVacatios = db.Official_Vacation.Where(e => e.EmpTyp_ID == empTypeId).Select(s => new
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
        public dynamic PostOfficialVacation(

            DateTime fromDate,
            DateTime toDate,
            bool forEmpType,
            int empTypeId,
            int year,
            string description,
            int userId

            )
        {


            var officialVacation = db.Official_Vacation.Add(new Official_Vacation
            {
                FromDate = fromDate,
                ToDate = toDate,
                For_EmpTyp = forEmpType,
                EmpTyp_ID = empTypeId,
                //Title=title,
                Description = description,
                UserId = userId,
                LastUpdate = DateTime.Now,
                Year = year


            });
            var result = db.SaveChanges() > 0 ? true : false;
            return new
            {
                result = result,
                officialVacation = officialVacation.VacationID
            };
        }
        [HttpPut]
        [AcceptVerbs("GET", "POST")]
        public dynamic PutOfficialVacation(
            int vacationId,
            DateTime fromDate,
            DateTime toDate,
            // string title,
            bool forEmpType,
            int empTypeId,
            string description,
            int userId,
            int year
            )
        {
            var officialVacation = db.Official_Vacation.Find(vacationId);
            int vacationDateYear = fromDate.Year;

            officialVacation.FromDate = fromDate;
            officialVacation.ToDate = toDate;
            officialVacation.For_EmpTyp = forEmpType;
            officialVacation.EmpTyp_ID = empTypeId;
            //officialVacation.Title = title;
            officialVacation.Description = description;
            officialVacation.UserId = userId;
            officialVacation.LastUpdate = DateTime.Now;
            officialVacation.Year = year;


            var result = db.SaveChanges() > 0 ? true : false;
            return new
            {
                result = result
            };
        }
        [HttpDelete]
        [AcceptVerbs("GET", "POST")]
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
        [HttpGet]
        private dynamic OfficialVacationExists(int vacationId)
        {
            var OfficialVacation = db.Official_Vacation.Count(s => s.VacationID == vacationId) > 0 ? true : false;
            return new
            {
                OfficialVacation = OfficialVacation
            };
        }


    }
}

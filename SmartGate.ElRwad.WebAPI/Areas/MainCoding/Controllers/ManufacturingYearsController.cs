using SmartGate.ElRwad.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SmartGate.ElRwad.WebAPI.Areas.MainCoding.Controllers
{
    public class ManufacturingYearsController : ApiController
    {
        private elRwadEntities db = new elRwadEntities();


        /// <summary>
        /// get all years
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public dynamic GetAllYears()
        {
            var years = db.ManufacturingYears.Select(s => new
            {
                yearId = s.Id,
                year = s.Year
            }).ToList();
            return years;
        }

        /// <summary>
        /// get year by id
        /// </summary>
        /// <param name="yearId"></param>
        /// <returns></returns>
        [HttpGet]
        public dynamic GetYearById(int yearId)
        {
            try
            {
                var year = db.ManufacturingYears.Where(e => e.Id == yearId).FirstOrDefault();
                if (year != null)
                {
                    return new
                    {
                        yearId = year.Id,
                        year = year.Year
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

        /// <summary>
        /// add new manufacturing year
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        [HttpPost]
        public dynamic PostYear(int year)
        {
            db.ManufacturingYears.Add(new ManufacturingYear
            {
                Year = year

            });
            var result = db.SaveChanges() > 0 ? true : false;
            return new
            {
                result = result
            };
        }

        /// <summary>
        /// update manufacturing year
        /// </summary>
        /// <param name="yearId"></param>
        /// <param name="year"></param>
        /// <returns></returns>
        [HttpPut]
        [AcceptVerbs("GET", "POST")]
        public dynamic PutYears(int yearId, int year)
        {
            var manufacturingYear = db.ManufacturingYears.Find(yearId);

            manufacturingYear.Year = year;
            var result = db.SaveChanges() > 0 ? true : false;
            return new
            {
                result = result
            };
        }
        /// <summary>
        /// delete manufacturing year
        /// </summary>
        /// <param name="yearId"></param>
        /// <returns></returns>
        [HttpDelete]
        [AcceptVerbs("GET", "POST")]
        public dynamic DeleteYear(int yearId)
        {
            var year = db.ManufacturingYears.Where(s => s.Id == yearId).FirstOrDefault();
            db.ManufacturingYears.Remove(year);
            var result = db.SaveChanges() > 0 ? true : false;
            return new
            {
                result = result
            };
        }


    }
}

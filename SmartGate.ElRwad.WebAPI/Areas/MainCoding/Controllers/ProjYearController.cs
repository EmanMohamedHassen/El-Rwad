using SmartGate.ElRwad.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SmartGate.ElRwad.WebAPI.Areas.MainCoding.Controllers
{
    public class ProjYearController : ApiController
    {

        private elRwadEntities db = new elRwadEntities();

        [HttpGet]
        public dynamic GetYear()
        {
            var year = db.Proj_Year.Select(s => new
            {
                yearId = s.ProjYear_ID,
                yearName = s.ProjYear_Name
            }).ToList();
            return year;
        }

        [HttpGet]
        public dynamic GetYearById(int yearId)
        {
            try
            {
                var s = db.Proj_Year.Where(e => e.ProjYear_ID == yearId).FirstOrDefault();
                if (s != null)
                {
                    return new
                    {
                        yearName = s.ProjYear_Name
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
        [HttpPost]
        public dynamic PostYearId(
            int yearId,
            string yearName
            )
        {
            var year = db.Proj_Year.Add(new Proj_Year
            {
                ProjYear_ID = yearId,
                ProjYear_Name = yearName
            });
            var result = db.SaveChanges() > 0 ? true : false;
            return new
            {
                result = result,
                yearId = year.ProjYear_ID
            };
        }
        [HttpPut]
        [AcceptVerbs("GET", "POST")]
        public dynamic PutYear(
            int yearId,
            int yearNewId,
           string yearName

            )
        {
            var year = db.Proj_Year.Find(yearId);
            year.ProjYear_ID = yearNewId;
            year.ProjYear_Name = yearName;

            var result = db.SaveChanges() > 0 ? true : false;
            return new
            {
                result = result
            };
        }
        [HttpDelete]
        [AcceptVerbs("GET", "POST")]
        public dynamic DeleteYear(int yearId)
        {
            var year = db.Proj_Year.Where(s => s.ProjYear_ID == yearId).FirstOrDefault();
            db.Proj_Year.Remove(year);
            var result = db.SaveChanges() > 0 ? true : false;
            return new
            {
                result = result
            };
        }
        [HttpGet]
        private dynamic yearExists(int yearId)
        {
            var year = db.Proj_Year.Count(s => s.ProjYear_ID == yearId) > 0 ? true : false;
            return new
            {
                year = year
            };
        }


    }
}

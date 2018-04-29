using SmartGate.ElRwad.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SmartGate.ElRwad.WebAPI.Areas.MainCoding.Controllers
{
    public class DaysController : ApiController
    {
        private elRwadEntities db = new elRwadEntities();

        [HttpGet]
        public dynamic GetAllDays()
        {
            var days = db.Days.Select(s => new
            {
                id = s.Id,
                nameAr = s.NameAr,
                nameEn = s.NAmeEn,
            }).ToList();
            return days;

        }
        [HttpGet]
        public dynamic GetDayById(int id)
        {
            try
            {
                var days = db.Days.Where(e => e.Id == id).FirstOrDefault();
                if (days != null)
                {
                    return new
                    {
                        nameAr = days.NameAr,
                        nameEn = days.NAmeEn
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
        public dynamic PostDay(string nameAr, string nameEn)
        {
            var day = db.Days.Add(new Day
            {
                NameAr = nameAr,
                NAmeEn = nameEn

            });
            var result = db.SaveChanges() > 0 ? true : false;
            return new
            {
                result = result,
                dayId = day.Id
            };

        }
        [HttpPut]
        [AcceptVerbs("GET", "POST")]
        public dynamic PutDay(int id, string nameAr, string nameEn)
        {
            var day = db.Days.Find(id);
            day.NameAr = nameAr;
            day.NAmeEn = nameEn;
            var result = db.SaveChanges() > 0 ? true : false;
            return new
            {
                result = result
            };
        }
        [HttpDelete]
        [AcceptVerbs("GET", "POST")]
        public dynamic DeleteDay(int id)
        {
            var day = db.Days.Where(e => e.Id == id).FirstOrDefault();

            db.Days.Remove(day);

            var result = db.SaveChanges() > 0 ? true : false;
            return new
            {
                result = result
            };

        }


    }
}

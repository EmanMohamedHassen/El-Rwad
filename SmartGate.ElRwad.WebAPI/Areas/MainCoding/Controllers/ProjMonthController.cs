using SmartGate.ElRwad.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SmartGate.ElRwad.WebAPI.Areas.MainCoding.Controllers
{
    public class ProjMonthController : ApiController
    {
        private elRwadEntities db = new elRwadEntities();

        [HttpGet]
        public dynamic GetMonth()
        {
            var month = db.Proj_Month.Select(s => new
            {
                monthId = s.Month_ID,
                monthName = s.Month_Name,
                monthNameEn = s.Month_Name_EN
            }).ToList();
            return month;
        }

        [HttpGet]
        public dynamic GetMonthById(int monthId)
        {
            try
            {
                var s = db.Proj_Month.Where(e => e.Month_ID == monthId).FirstOrDefault();
                if (s != null)
                {
                    return new
                    {
                        //monthId = s.Month_ID,
                        monthName = s.Month_Name,
                        monthNameEn = s.Month_Name_EN

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
        public dynamic PostMonth(
            byte monthId,
            string monthName,
            string monthNameEn
            )
        {
            var month = db.Proj_Month.Add(new Proj_Month
            {
                Month_ID = monthId,
                Month_Name = monthName,
                Month_Name_EN = monthNameEn

            });
            var result = db.SaveChanges() > 0 ? true : false;
            return new
            {
                result = result,
                monthId = month.Month_ID
            };
        }
        [HttpPut]
        [AcceptVerbs("GET", "POST")]
        public dynamic PutMonth(
           byte monthId,
           string monthName,
           string monthNameEn


            )
        {
            var month = db.Proj_Month.Find(monthId);
            month.Month_ID = monthId;
            month.Month_Name = monthName;
            month.Month_Name_EN = monthNameEn;
            var result = db.SaveChanges() > 0 ? true : false;
            return new
            {
                result = result
            };
        }
        [HttpDelete]
        [AcceptVerbs("GET", "POST")]
        public dynamic DeleteMonth(byte monthId)
        {
            var month = db.Proj_Month.Where(s => s.Month_ID == monthId).FirstOrDefault();
            db.Proj_Month.Remove(month);
            var result = db.SaveChanges() > 0 ? true : false;
            return new
            {
                result = result
            };
        }
        [HttpGet]
        private dynamic monthExists(byte monthId)
        {
            var month = db.Proj_Month.Count(s => s.Month_ID == monthId) > 0 ? true : false;
            return new
            {
                month = month
            };
        }


    }
}

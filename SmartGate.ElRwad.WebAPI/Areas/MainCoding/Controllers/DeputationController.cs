using SmartGate.ElRwad.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SmartGate.ElRwad.WebAPI.Areas.MainCoding.Controllers
{
    public class DeputationController : ApiController
    {
        private elRwadEntities db = new elRwadEntities();

        [HttpGet]
        public dynamic GetDeputations()
        {
            var deputation = db.Deputations.Select(s => new
            {
                deputationId = s.Deputations_ID,
                deputationNameAr = s.Title,
                deputationNameEn = s.Tittle_EN
            }).ToList();
            return deputation;

        }
        [HttpGet]
        public dynamic GetDeputationById(int deputationId)
        {
            try
            {
                var s = db.Deputations.Where(e => e.Deputations_ID == deputationId).FirstOrDefault();
                if (s != null)
                {
                    return new
                    {
                        deputationNameAr = s.Title,
                        deputationNameEn = s.Tittle_EN
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
        public dynamic PostDeputation(string deputationNameAr, string deputationNameEn)
        {
            var deputation = db.Deputations.Add(new Deputation
            {
                Title = deputationNameAr,
                Tittle_EN = deputationNameEn

            });
            var result = db.SaveChanges() > 0 ? true : false;
            return new
            {
                result = result,
                deputationId = deputation.Deputations_ID
            };
        }

        [HttpPut]
        [AcceptVerbs("GET", "POST")]
        public dynamic PutDeputation(int deputationId, string deputationNameAr, string deputationNameEn)
        {
            var deputation = db.Deputations.Find(deputationId);
            deputation.Title = deputationNameAr;
            deputation.Tittle_EN = deputationNameEn;

            var result = db.SaveChanges() > 0 ? true : false;
            return new
            {
                result = result
            };
        }

        [HttpDelete]
        [AcceptVerbs("GET", "POST")]
        public dynamic DeleteDeputation(int deputationId)
        {
            var deputation = db.Deputations.Where(s => s.Deputations_ID == deputationId).FirstOrDefault();
            db.Deputations.Remove(deputation);
            var result = db.SaveChanges() > 0 ? true : false;
            return new
            {
                result = result
            };

        }
        [HttpGet]
        public dynamic DeputationExists(int deputationId)
        {
            var deputation = db.Deputations.Count(s => s.Deputations_ID == deputationId) > 0 ? true : false;
            return new
            {
                deputation = deputation
            };
        }








    }
}

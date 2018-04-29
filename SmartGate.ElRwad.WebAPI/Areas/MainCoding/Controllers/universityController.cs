using SmartGate.ElRwad.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SmartGate.ElRwad.WebAPI.Areas.MainCoding.Controllers
{
    public class universityController : ApiController
    {


        private elRwadEntities db = new elRwadEntities();

        [HttpGet]
        public dynamic GetUniversity()
        {
            var university = db.Universities.Select(s => new
            {
                universityId = s.University_ID,
                universityArName = s.University_A_Name,
                universityEnName = s.University_E_Name,
                universityNotes = s.Notes

            }).ToList();
            return university;
        }
        [HttpGet]
        public dynamic GetUniversityById(int universityId)
        {
            try
            {
                var s = db.Universities.Where(e => e.University_ID == universityId).FirstOrDefault();
                if (s != null)
                {
                    return new
                    {

                        universityId = s.University_ID,

                        universityArName = s.University_A_Name,
                        universityEnName = s.University_E_Name,
                        universityNotes = s.Notes

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
        public dynamic PostUniversity(

            string universityArName,
            string universityEnName,
            string universityNotes

            )
        {
            var university = db.Universities.Add(new University
            {

                University_A_Name = universityArName,
                University_E_Name = universityEnName,
                Notes = universityNotes



            });
            var result = db.SaveChanges() > 0 ? true : false;
            return new
            {
                result = result,
                universityId = university.University_ID
            };
        }
        [HttpPut]
        [AcceptVerbs("GET", "POST")]
        public dynamic PutUniversity(
            int universityId,
            string universityArName,
            string universityEnName,
            string universityNotes


            )
        {
            var university = db.Universities.Find(universityId);

            university.University_A_Name = universityArName;
            university.University_E_Name = universityEnName;
            university.Notes = universityNotes;


            var result = db.SaveChanges() > 0 ? true : false;
            return new
            {
                result = result
            };
        }
        [HttpDelete]
        [AcceptVerbs("GET", "POST")]
        public dynamic DeleteUniversity(int universityId)
        {
            var university = db.Universities.Where(s => s.University_ID == universityId).FirstOrDefault();
            db.Universities.Remove(university);
            var result = db.SaveChanges() > 0 ? true : false;
            return new
            {
                result = result
            };
        }
        [HttpGet]
        private dynamic universityExists(int universityId)
        {
            var university = db.Universities.Count(s => s.University_ID == universityId) > 0 ? true : false;
            return new
            {
                university = university
            };
        }




    }
}

using SmartGate.ElRwad.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SmartGate.ElRwad.WebAPI.Areas.MainCoding.Controllers
{
    public class FacultyController : ApiController
    {
        private elRwadEntities db = new elRwadEntities();
        [HttpGet]
        public dynamic GetFaculties()
        {
            var faculty = db.Faculties.Select(s => new
            {
                facultyId = s.Faculty_ID,
                facultyArName = s.Faculty_A_Name,
                facultyEnName = s.Faculty_E_Name,
                facultyNotes = s.Faculty_Notes
            }).ToList();
            return faculty;
        }
        [HttpGet]
        public dynamic GetFacultyById(int facultyId)
        {
            try
            {
                var s = db.Faculties.Where(e => e.Faculty_ID == facultyId).FirstOrDefault();
                if (s != null)
                {
                    return new
                    {
                        facultyId = s.Faculty_ID,

                        facultyArName = s.Faculty_A_Name,
                        facultyEnName = s.Faculty_E_Name,
                        facultyNotes = s.Faculty_Notes

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
        public dynamic PostFaculty(
            string facultyArName,
            string facultyEnName,
            string facultyNotes
            )
        {
            var faculty = db.Faculties.Add(new Faculty
            {
                Faculty_A_Name = facultyArName,
                Faculty_E_Name = facultyEnName,
                Faculty_Notes = facultyNotes



            });
            var result = db.SaveChanges() > 0 ? true : false;
            return new
            {
                result = result,
                facultyId = faculty.Faculty_ID
            };
        }
        [HttpPut]
        [AcceptVerbs("GET", "POST")]
        public dynamic PutFaculty(
            int facultyId,
            string facultyArName,
            string facultyEnName,
            string facultyNotes
            )
        {
            var faculty = db.Faculties.Find(facultyId);
            faculty.Faculty_A_Name = facultyArName;
            faculty.Faculty_E_Name = facultyEnName;
            faculty.Faculty_Notes = facultyNotes;

            var result = db.SaveChanges() > 0 ? true : false;
            return new
            {
                result = result
            };
        }
        [HttpDelete]
        [AcceptVerbs("GET", "POST")]
        public dynamic DeleteFaculty(int facultyId)
        {
            var faculty = db.Faculties.Where(s => s.Faculty_ID == facultyId).FirstOrDefault();
            db.Faculties.Remove(faculty);
            var result = db.SaveChanges() > 0 ? true : false;
            return new
            {
                result = result
            };
        }
        [HttpGet]
        private dynamic facultyExists(int facultyId)
        {
            var faculty = db.Faculties.Count(s => s.Faculty_ID == facultyId) > 0 ? true : false;
            return new
            {
                faculty = faculty
            };
        }




    }
}

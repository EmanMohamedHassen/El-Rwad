using SmartGate.ElRwad.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SmartGate.ElRwad.BLL;
using SmartGate.ElRwad.ViewModel;

namespace SmartGate.ElRwad.WebAPI.Areas.MainCoding.Controllers
{
    public class FacultyController : ApiController
    {
        private elRwadEntities db = new elRwadEntities();
        [HttpGet]
        public dynamic GetFaculties()
        {
          return FacultyManager.Instance.GetFaculties();
        }
        [HttpGet]
        public dynamic GetFacultyById(int facultyId)
        {
            return FacultyManager.Instance.GetFacultyById(facultyId);
        }

        [HttpPost]
        public dynamic PostFaculty(
            string facultyArName,
            string facultyEnName,
            string facultyNotes
            )
        {

            return FacultyManager.Instance.PostFaculty(facultyArName, facultyEnName, facultyNotes);
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
            //FacultyVM object = new FacultyVM
            //{
            //    Faculty_ID = facultyId,
            //    Faculty_A_Name = facultyArName,
            //    Faculty_E_Name = facultyEnName,
            //    Faculty_Notes = facultyNotes
            //};
            return FacultyManager.Instance.PutFaculty(facultyId, facultyArName, facultyEnName, facultyNotes);
        }
        [HttpDelete]
        [AcceptVerbs("GET", "POST")]
        public dynamic DeleteFaculty(int facultyId)
        {
            return FacultyManager.Instance.DeleteFaculty(facultyId);
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

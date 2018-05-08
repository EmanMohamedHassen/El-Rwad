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
    public class SpecialtiesController : ApiController
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public dynamic GetSpecialties()
        {
            return SpecialtiesManager.Instance.GetSpecialties();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="specialtiesId"></param>
        /// <returns></returns>
        [HttpGet]
        public dynamic GetSpecialtyById(int specialtiesId)
        {
            return SpecialtiesManager.Instance.GetSpecialtyById(specialtiesId);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="facultyId"></param>
        /// <returns></returns>
        [HttpGet]
        //get speciality by faculty
        public dynamic GetSpecialtyByFacultyId(int facultyId)
        {
            return SpecialtiesManager.Instance.GetSpecialtyByFacultyId(facultyId);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="specialtyArName"></param>
        /// <param name="specialtyEnName"></param>
        /// <param name="specialtyNotes"></param>
        /// <returns></returns>
        [HttpPost]
        public dynamic PostSpecialty(SpecialtiesVM s )
        {
            return SpecialtiesManager.Instance.PostSpecialty(s);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="specialtiesId"></param>
        /// <param name="specialtyArName"></param>
        /// <param name="specialtyEnName"></param>
        /// <param name="specialtyNotes"></param>
        /// <returns></returns>
        [HttpPut]
        [AcceptVerbs("GET", "POST")]
        public dynamic PutSpecialty(SpecialtiesVM s)
        {
            return SpecialtiesManager.Instance.PutSpecialty(s);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="specialtiesId"></param>
        /// <returns></returns>
        [HttpDelete]
        [AcceptVerbs("GET", "POST")]
        public dynamic DeleteSpecialty(int specialtiesId)
        {
            return SpecialtiesManager.Instance.DeleteSpecialty(specialtiesId);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="specialtiesId"></param>
        /// <returns></returns>
        [HttpGet]
        private dynamic specialtiesExists(int specialtiesId)
        {
            return SpecialtiesManager.Instance.specialtiesExists(specialtiesId);
        }




    }
}

using SmartGate.ElRwad.BLL;
using SmartGate.ElRwad.DAL;
using SmartGate.ElRwad.ViewModel;
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
            
            return UniversityManager.Instance.GetUniversity();
        }
        [HttpGet]
        public dynamic GetUniversityById(int universityId)
        {
            try
            {
                return UniversityManager.Instance.GetUniversityById(universityId);
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        [HttpPost]
        public dynamic PostUniversity(  UniversityVM university )
        {
            return UniversityManager.Instance.PostUniversity(university);
        }

        [HttpPut]
        [AcceptVerbs("GET", "POST")]
        public dynamic PutUniversity( UniversityVM university )
        {
            return UniversityManager.Instance.PutUniversity(university);
        }
        [HttpDelete]
        [AcceptVerbs("GET", "POST")]
        public dynamic DeleteUniversity(int universityId)
        {
            return UniversityManager.Instance.DeleteUniversity(universityId);
        }
        [HttpGet]
        private dynamic universityExists(int universityId)
        {
            return UniversityManager.Instance.universityExists(universityId);
        }




    }
}

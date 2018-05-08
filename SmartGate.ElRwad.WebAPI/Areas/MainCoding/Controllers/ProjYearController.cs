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
    public class ProjYearController : ApiController
    {

        private elRwadEntities db = new elRwadEntities();

        [HttpGet]
        public dynamic GetYear()
        {
            return YearManager.Instance.GetYear();
        }

        [HttpGet]
        public dynamic GetYearById(int yearId)
        {
            return YearManager.Instance.GetYearById(yearId);
        }
        [HttpPost]
        public dynamic PostYearId(YearVM y)
        {
            return YearManager.Instance.PostYearId(y);
        }

        [HttpPut]
        public dynamic PutYear(PutYearVM y)
        {
            return YearManager.Instance.PutYear(y);
        }

        [HttpDelete]
        public dynamic DeleteYear(int yearId)
        {
            return YearManager.Instance.DeleteYear(yearId);
        }
        [HttpGet]
        public dynamic yearExists(int yearId)
        {
            return YearManager.Instance.yearExists(yearId);
        }


    }
}

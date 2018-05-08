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
    public class ManufacturingYearsController : ApiController
    {
        private elRwadEntities db = new elRwadEntities();


        /// <summary>
        /// get all years
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public dynamic GetAllYears()
        {
            return ManufacturingYearManager.Instance.GetAllYears();
        }

        /// <summary>
        /// get year by id
        /// </summary>
        /// <param name="yearId"></param>
        /// <returns></returns>
        [HttpGet]
        public dynamic GetYearById(int yearId)
        {
            return ManufacturingYearManager.Instance.GetYearById(yearId);
        }

        /// <summary>
        /// add new manufacturing year
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        [HttpPost]
        public dynamic PostYear(int year)
        {
            return ManufacturingYearManager.Instance.GetYearById(year);
        }

        /// <summary>
        /// update manufacturing year
        /// </summary>
        /// <param name="yearId"></param>
        /// <param name="year"></param>
        /// <returns></returns>
        [HttpPut]
        [AcceptVerbs("GET", "POST")]
        public dynamic PutYears(ManufacturingYearVM year)
        {
            return ManufacturingYearManager.Instance.PutYears(year);
        }
        /// <summary>
        /// delete manufacturing year
        /// </summary>
        /// <param name="yearId"></param>
        /// <returns></returns>
        [HttpDelete]
        [AcceptVerbs("GET", "POST")]
        public dynamic DeleteYear(int yearId)
        {
            return ManufacturingYearManager.Instance.DeleteYear(yearId);
        }


    }
}

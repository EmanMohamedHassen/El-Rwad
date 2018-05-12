using SmartGate.ElRwad.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SmartGate.ElRwad.BLL.HR;
using SmartGate.ElRwad.ViewModel.HR;
namespace SmartGate.ElRwad.WebAPI.Areas.HR.Controllers
{
    public class OfficialVacationsController : ApiController
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public dynamic GetOfficialVacations()
        {
            return OfficialVacationsManager.Instance.GetOfficialVacations();

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="vacationId"></param>
        /// <returns></returns>
        [HttpGet]

        public dynamic GetOfficialVacationById(int vacationId)
        {
            return OfficialVacationsManager.Instance.GetOfficialVacationById(vacationId);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fromDate"></param>
        /// <param name="toDate"></param>
        /// <returns></returns>
        [HttpGet]
        public dynamic GetOfficialVacationByDate(DateTime fromDate, DateTime toDate)
        {
            return OfficialVacationsManager.Instance.GetOfficialVacationByDate(fromDate, toDate);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="empTypeId"></param>
        /// <returns></returns>
        [HttpGet]
        public dynamic GetOfficialVacationByEmpTypeId(int empTypeId)
        {
            return OfficialVacationsManager.Instance.GetOfficialVacationByEmpTypeId(empTypeId);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        [HttpPost]
        public dynamic PostOfficialVacation(OfficialVacationsPVM v)
        {
            return OfficialVacationsManager.Instance.PostOfficialVacation(v);
        }

        [HttpPut]
        [AcceptVerbs("GET", "POST")]
        public dynamic PutOfficialVacation(OfficialVacationsPVM v)
        {
            return OfficialVacationsManager.Instance.PutOfficialVacation(v);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="vacationId"></param>
        /// <returns></returns>
        [HttpDelete]
        [AcceptVerbs("GET", "POST")]
        public dynamic DeleteOfficialVacation(int vacationId)
        {
            return OfficialVacationsManager.Instance.DeleteOfficialVacation(vacationId);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="vacationId"></param>
        /// <returns></returns>
        [HttpGet]
        private dynamic OfficialVacationExists(int vacationId)
        {
            return OfficialVacationsManager.Instance.OfficialVacationExists(vacationId);
        }


    }
}

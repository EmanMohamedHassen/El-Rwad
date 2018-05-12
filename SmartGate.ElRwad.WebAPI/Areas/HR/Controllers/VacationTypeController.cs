using SmartGate.ElRwad.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SmartGate.ElRwad.ViewModel.HR;
using SmartGate.ElRwad.BLL.HR;

namespace SmartGate.ElRwad.WebAPI.Areas.HR.Controllers
{
    public class VacationTypeController : ApiController
    {
        /// <summary>
        /// get vacation type
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public dynamic GetVacationType()
        {
            return VacationTypeManager.Instance.GetVacationType();
        }
        /// <summary>
        /// get vacation by id
        /// </summary>
        /// <param name="vacationTypeId"></param>
        /// <returns></returns>
        [HttpGet]

        public dynamic GetVacationTypeById(int vacationTypeId)
        {
            return VacationTypeManager.Instance.GetVacationTypeById(vacationTypeId);
        }
        /// <summary>
        /// get vacation by category id
        /// </summary>
        /// <param name="CategoryId"></param>
        /// <returns></returns>
        [HttpGet]


        public dynamic GetVacationTypeByCategoryId(int CategoryId) //to get all vacations types which available to this employee and him category
        {
            return VacationTypeManager.Instance.GetVacationTypeByCategoryId(CategoryId);
        }
        /// <summary>
        /// add vacation
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        [HttpPost]
        public dynamic PostVacationType(VacationTypePVM v)
        {
            return VacationTypeManager.Instance.PostVacationType(v);
        }
        /// <summary>
        /// edit vacation
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        [HttpPut]
        [AcceptVerbs("GET", "POST")]
        public dynamic PutVacationType(VacationTypePVM v)

        {
            return VacationTypeManager.Instance.PutVacationType(v);

        }
        /// <summary>
        /// delete vacation
        /// </summary>
        /// <param name="vacationTypeId"></param>
        /// <returns></returns>
        [HttpDelete]
        [AcceptVerbs("GET", "POST")]
        public dynamic DeleteVacationType(int vacationTypeId)
        {
            return VacationTypeManager.Instance.DeleteVacationType(vacationTypeId);
        }
        /// <summary>
        /// check vacation exists
        /// </summary>
        /// <param name="vacationTypeId"></param>
        /// <returns></returns>
        [HttpGet]
        private dynamic VacationTypeExists(int vacationTypeId)
        {
            return VacationTypeManager.Instance.VacationTypeExists(vacationTypeId);
        }





    }
}

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
    public class InsuranceCompaniesController : ApiController
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>

        public dynamic GetAllinsurComponies()
        {
            return InsuranceCompaniesManager.Instance.GetAllinsurComponies();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="InsurcompanyId"></param>
        /// <returns></returns>
        public dynamic GetInsurCompanyById(int InsurcompanyId)
        {
            return InsuranceCompaniesManager.Instance.GetInsurCompanyById(InsurcompanyId);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="companyNameA"></param>
        /// <param name="companyNameE"></param>
        /// <returns></returns>
        public dynamic PostInsurCompany(InsuranceCompanyVM i)
        {
            return InsuranceCompaniesManager.Instance.PostInsurCompany(i);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="InsurcompanyId"></param>
        /// <param name="companyNameA"></param>
        /// <param name="companyNameE"></param>
        /// <returns></returns>
        [HttpPut]
        [AcceptVerbs("GET", "POST")]

        public dynamic PutInsurCompany(InsuranceCompanyVM i)
        {
            return InsuranceCompaniesManager.Instance.PutInsurCompany(i);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="InsurcompanyId"></param>
        /// <returns></returns>
        [HttpDelete]
        [AcceptVerbs("GET", "POST")]
        public dynamic DeleteInsurCompany(int InsurcompanyId)
        {
            return InsuranceCompaniesManager.Instance.DeleteInsurCompany(InsurcompanyId);
        }



    }
}

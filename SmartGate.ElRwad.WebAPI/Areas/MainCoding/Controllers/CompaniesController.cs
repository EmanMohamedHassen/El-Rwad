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
    public class CompaniesController : ApiController
    {
        private elRwadEntities db = new elRwadEntities();

        [HttpGet]
        public dynamic GetAllCompanies()
        {
            return CompaniesManager.Instance.GetAllCompanies();
        }

        [HttpGet]
        public dynamic GetCompanyId(int companyId)
        {
            return CompaniesManager.Instance.GetCompanyId(companyId);
        }



        [HttpPost]
        public dynamic PostCompany(CompaniesVM co)
        {
            return CompaniesManager.Instance.PostCompany(co);
        }

        [AcceptVerbs("GET", "POST")]
        [HttpPut]
        public dynamic PutCompany(CompaniesVM co)
        {
            return CompaniesManager.Instance.PutCompany(co);
        }
        [AcceptVerbs("GET", "POST")]
        [HttpDelete]
        public dynamic DeleteCompany(int companyId)
        {
            return CompaniesManager.Instance.DeleteCompany(companyId);
        }


    }
}

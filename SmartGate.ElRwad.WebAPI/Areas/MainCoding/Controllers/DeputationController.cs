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
    public class DeputationController : ApiController
    {
        private elRwadEntities db = new elRwadEntities();

        [HttpGet]
        public dynamic GetDeputations()
        {
            
            return DeputationManager.Instance.GetDeputations();

        }
        [HttpGet]
        public dynamic GetDeputationById(int deputationId)
        {
            return DeputationManager.Instance.GetDeputationById(deputationId);
        }
        [HttpPost]
        public dynamic PostDeputation(DeputationVM deputation)
        {
            return DeputationManager.Instance.PostDeputation(deputation);
        }

        [HttpPut]
        [AcceptVerbs("GET", "POST")]
        public dynamic PutDeputation(DeputationVM deputation)
        {
            return DeputationManager.Instance.PutDeputation(deputation);
        }

        [HttpDelete]
        [AcceptVerbs("GET", "POST")]
        public dynamic DeleteDeputation(int deputationId)
        {
            return DeputationManager.Instance.DeleteDeputation(deputationId);

        }
        [HttpGet]
        public dynamic DeputationExists(int deputationId)
        {
            return DeputationManager.Instance.DeputationExists(deputationId);
        }








    }
}

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
    public class BranchesController : ApiController
    {
        private elRwadEntities db = new elRwadEntities();
        [HttpGet]
        public dynamic GetBranches()
        {
            return BranchesManager.Instance.GetBranches();
        }
        [HttpGet]
        public dynamic GetBranchById(int branchId)
        {
            return BranchesManager.Instance.GetBranchById(branchId);
        }

        [HttpPost]
        public dynamic PostBranch(BranchesVM b )
        {
            
            return BranchesManager.Instance.PostBranch(b);
        }
        [HttpPut]
        [AcceptVerbs("GET", "POST")]
        public dynamic PutBranch(BranchesVM b)
        {
            return BranchesManager.Instance.PutBranch(b);
        }
        [HttpDelete]
        [AcceptVerbs("GET", "POST")]
        public dynamic DeleteBranch(int branchId)
        {
            return BranchesManager.Instance.DeleteBranch(branchId);
        }
        [HttpGet]
        private dynamic branchExists(int branchId)
        {
            return BranchesManager.Instance.branchExists(branchId);
        }




    }
}

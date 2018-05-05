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
        public dynamic PostBranch(
            int companyId,
            string branchArName,
            string branchEnName,
            string branchLocation,
            string branchDescription,
            string branchImage,
            int managerId,
            int userId

            )
        {
            BranchesVM b = new BranchesVM();
            b.CompanyId = companyId;
            b.BranchName_A = branchArName;
            b.BranchNameE = branchEnName;
            b.BranchLocation = branchLocation;
            b.BranchDescription = branchDescription;
            b.BranchImage = branchImage;
            b.ManagerId = managerId;
            b.UserId = userId;

            return BranchesManager.Instance.PostBranch(b);
        }
        [HttpPut]
        [AcceptVerbs("GET", "POST")]
        public dynamic PutBranch(
            int branchId,
            int companyId,
            string branchArName,
            string branchEnName,
            string branchLocation,
            string branchDescription,
            string branchImage,
            int managerId,
            int userId

            )
        {
            BranchesVM b = new BranchesVM();
            b.Id = branchId;
            b.CompanyId = companyId;
            b.BranchName_A = branchArName;
            b.BranchNameE = branchEnName;
            b.BranchLocation = branchLocation;
            b.BranchDescription = branchDescription;
            b.BranchImage = branchImage;
            b.ManagerId = managerId;
            b.UserId = userId;

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

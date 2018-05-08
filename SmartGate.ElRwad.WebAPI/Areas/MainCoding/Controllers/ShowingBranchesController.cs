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
    public class ShowingBranchesController : ApiController
    {
        /// <summary>
        /// get all Showing branches
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public dynamic GetShowingBranches()
        {
            return ShowingBranchesManager.Instance.GetShowingBranches();
        }

        /// <summary>
        /// get showing branch by id
        /// </summary>
        /// <param name="showingBranchId"></param>
        /// <returns></returns>
        [HttpGet]
        public dynamic GetShowingBranchById(int showingBranchId)
        {
            return ShowingBranchesManager.Instance.GetShowingBranchById(showingBranchId);
        }

        /// <summary>
        /// to add new Showing branch
        /// </summary>
        /// <param name="showingBranchArName"></param>
        /// <param name="showingBranchEnName"></param>
        /// <param name="showingBranchLocation"></param>
        /// <param name="showingBranchRegionId"></param>
        /// <param name="showingBranchCityId"></param>
        /// <returns></returns>
        [HttpPost]
        public dynamic PostShowingBranch(ShowingBranchesVM b)
        {
            return ShowingBranchesManager.Instance.PostShowingBranch(b);
        }

        /// <summary>
        /// to update showing branch
        /// </summary>
        /// <param name="showingBranchId"></param>
        /// <param name="showingBranchArName"></param>
        /// <param name="showingBranchEnName"></param>
        /// <param name="showingBranchLocation"></param>
        /// <param name="showingBranchRegionId"></param>
        /// <param name="showingBranchCityId"></param>
        /// <returns></returns>
        [HttpPut]
        [AcceptVerbs("GET", "POST")]
        public dynamic PutShowingBranch(ShowingBranchesVM b)
        {
            return ShowingBranchesManager.Instance.PutShowingBranch(b);
        }

        /// <summary>
        /// to delete showing branch
        /// </summary>
        /// <param name="showingBranchId"></param>
        /// <returns></returns>
        [HttpDelete]
        [AcceptVerbs("GET", "POST")]
        public dynamic DeleteShowingBranch(int showingBranchId)
        {
            return ShowingBranchesManager.Instance.DeleteShowingBranch(showingBranchId);
        }



    }
}

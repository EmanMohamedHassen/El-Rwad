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
    public class JobCategoryController : ApiController
    {

        //Get all job Categories
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public dynamic GetJobCategories()
        {
            return JobCategoryManager.Instance.GetJobCategories();
        }

        /// <summary>
        /// Get job Category by Id
        /// </summary>
        /// <param name="jobCategoryId"></param>
        /// <returns></returns>

        [HttpGet]
        public dynamic GetJobCategoryById(int jobCategoryId)
        {
            return JobCategoryManager.Instance.GetJobCategoryById(jobCategoryId);
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="jobCategoryAr"></param>
        /// <param name="jobCategoryEn"></param>
        /// <param name="description"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        //Add new job Category
        [HttpPost]
        public dynamic PostJobCategory(jobCategoryVM j)
        {
            return JobCategoryManager.Instance.PostJobCategory(j);
        }


        //update job category
        /// <summary>
        /// 
        /// </summary>
        /// <param name="jobCategoryId"></param>
        /// <param name="jobCategoryAr"></param>
        /// <param name="jobCategoryEn"></param>
        /// <param name="description"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpPut]
        [AcceptVerbs("GET", "POST")]
        public dynamic PutJobCategory(jobCategoryVM j)
        {
            return JobCategoryManager.Instance.PutJobCategory(j);
        }

        //to delete job category
        /// <summary>
        /// 
        /// </summary>
        /// <param name="jobCategoryId"></param>
        /// <returns></returns>
        [HttpDelete]
        [AcceptVerbs("GET", "POST")]

        public dynamic DeleteJobCategory(int jobCategoryId)
        {
            return JobCategoryManager.Instance.DeleteJobCategory(jobCategoryId);
        }


    }
}

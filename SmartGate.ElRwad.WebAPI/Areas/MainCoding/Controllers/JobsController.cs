using SmartGate.ElRwad.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SmartGate.ElRwad.ViewModel;
using SmartGate.ElRwad.BLL;

namespace SmartGate.ElRwad.WebAPI.Areas.MainCoding.Controllers
{
    public class JobsController : ApiController
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public dynamic GetJobs()
        {
            return JobManager.Instance.GetJobs();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="jobId"></param>
        /// <returns></returns>
        [HttpGet]
        public dynamic GetJobById(int jobId)
        {
            return JobManager.Instance.GetJobById(jobId);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="departmentId"></param>
        /// <returns></returns>
        [HttpGet]
        public dynamic GetJobByDepartmentId(int departmentId)
        {
            return JobManager.Instance.GetJobByDepartmentId(departmentId);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="jobArTitle"></param>
        /// <param name="jobEnTitle"></param>
        /// <param name="departmentId"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpPost]
        public dynamic PostJob(JobVM j)
        {
            return JobManager.Instance.PostJob(j);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="jobId"></param>
        /// <param name="jobArTitle"></param>
        /// <param name="jobEnTitle"></param>
        /// <param name="departmentId"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        [AcceptVerbs("GET", "POST")]
        [HttpPut]

        public dynamic PutJob(JobVM j)
        {
            return JobManager.Instance.PutJob(j);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="jobId"></param>
        /// <returns></returns>
        [AcceptVerbs("GET", "POST")]
        [HttpDelete]
        public dynamic DeleteJob(int jobId)
        {
            return JobManager.Instance.DeleteJob(jobId);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="jobId"></param>
        /// <returns></returns>
        [HttpGet]
        private dynamic jobExists(int jobId)
        {
            return JobManager.Instance.jobExists(jobId);
        }

    }
}

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
    public class DepartmentController : ApiController
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public dynamic GetDepartment()
        {
            return DepartmentManager.Instance.GetDepartment();

            }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="departmentId"></param>
        /// <returns></returns>
        [HttpGet]
        public dynamic GetDepartmentById(int departmentId)
        {
            return DepartmentManager.Instance.GetDepartmentById(departmentId);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="branchId"></param>
        /// <returns></returns>
        [HttpGet]
        public dynamic GetDepartmentByBranchId(int branchId)
        {
            return DepartmentManager.Instance.GetDepartmentByBranchId(branchId);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="departmentBranchId"></param>
        /// <param name="departmentAName"></param>
        /// <param name="departmentEName"></param>
        /// <param name="departmentDescription"></param>
        /// <param name="departmentManagerId"></param>
        /// <param name="departmentUserId"></param>
        /// <returns></returns>
        [HttpPost]
        public dynamic PostDepartment(DepartmentVM d)
        {
            return DepartmentManager.Instance.PostDepartment(d);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="departmentId"></param>
        /// <param name="departmentBranchId"></param>
        /// <param name="departmentAName"></param>
        /// <param name="departmentEName"></param>
        /// <param name="departmentDescription"></param>
        /// <param name="departmentManagerId"></param>
        /// <param name="departmentUserId"></param>
        /// <returns></returns>
        [HttpPut]
        [AcceptVerbs("GET", "POST")]
        public dynamic PutDepartment(DepartmentVM d)
        {
            return DepartmentManager.Instance.PutDepartment(d);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="departmentId"></param>
        /// <returns></returns>

        [HttpDelete]
        [AcceptVerbs("GET", "POST")]
        public dynamic DeleteDepartment(int departmentId)
        {
            return DepartmentManager.Instance.DeleteDepartment(departmentId);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="departmentId"></param>
        /// <returns></returns>
        [HttpGet]
        private dynamic departmentExists(int departmentId)
        {
            return DepartmentManager.Instance.departmentExists(departmentId);
        }

    }
}

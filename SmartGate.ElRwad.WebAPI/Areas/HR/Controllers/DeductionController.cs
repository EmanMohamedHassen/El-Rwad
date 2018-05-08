using SmartGate.ElRwad.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SmartGate.ElRwad.BLL.HR;
using SmartGate.ElRwad.ViewModel.HR;

namespace SmartGate.ElRwad.WebAPI.Areas.HR.Controllers
{
    public class DeductionController : ApiController
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public dynamic GetAllDeductions()
        {
            return DeductionManager.Instance.GetAllDeductions();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="monthID"></param>
        /// <param name="yearID"></param>
        /// <returns></returns>
        [HttpGet]
        public dynamic GetDeductionsForHr(byte monthID, int yearID)
        {
            return DeductionManager.Instance.GetDeductionsForHr(monthID, yearID);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public dynamic GetDeductionsForHr()
        {
            return DeductionManager.Instance.GetDeductionsForHr();
        }

        [HttpGet]
        public dynamic GetDeductions(byte monthID, int yearID)
        {
            return DeductionManager.Instance.GetDeductions(monthID, yearID);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="deductionId"></param>
        /// <returns></returns>
        [HttpGet]

        public dynamic GetDeductionById(int deductionId)
        {
            return DeductionManager.Instance.GetDeductionById(deductionId);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="fromDate"></param>
        /// <param name="toDate"></param>
        /// <returns></returns>
        [HttpGet]

        public dynamic GetDeductionByDate(DateTime fromDate, DateTime toDate)
        {
            return DeductionManager.Instance.GetDeductionByDate(fromDate, toDate);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="empId"></param>
        /// <param name="fromDate"></param>
        /// <param name="toDate"></param>
        /// <returns></returns>
        [HttpGet]

        public dynamic GetDeductionByDateAndEmpId(int empId, DateTime fromDate, DateTime toDate)
        {
            return DeductionManager.Instance.GetDeductionByDateAndCategory(empId, fromDate, toDate);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="depId"></param>
        /// <param name="fromDate"></param>
        /// <param name="toDate"></param>
        /// <returns></returns>
        [HttpGet]

        public dynamic GetDeductionByDateAndDepartmentId(int depId, DateTime fromDate, DateTime toDate)
        {
            return DeductionManager.Instance.GetDeductionByDateAndDepartmentId(depId, fromDate, toDate);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="depId"></param>
        /// <param name="fromDate"></param>
        /// <param name="toDate"></param>
        /// <returns></returns>
        [HttpGet]

        public dynamic GetDeductionByDateAndCategory(int depId, DateTime fromDate, DateTime toDate)
        {
            return DeductionManager.Instance.GetDeductionByDateAndCategory(depId, fromDate, toDate);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="deductionDate"></param>
        /// <param name="month"></param>
        /// <param name="year"></param>
        /// <param name="managerId"></param>
        /// <param name="employeeId"></param>
        /// <param name="deducDayCount"></param>
        /// <param name="reason"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpPost]
        public dynamic PostDeduction(DeductionPostVM d)
        {
            return DeductionManager.Instance.PostDeduction(d);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="deductionId"></param>
        /// <param name="deductionDate"></param>
        /// <param name="month"></param>
        /// <param name="year"></param>
        /// <param name="managerId"></param>
        /// <param name="employeeId"></param>
        /// <param name="deducDayCount"></param>
        /// <param name="reason"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpPut]
        [AcceptVerbs("GET", "POST")]
        public dynamic PutDeduction(DeductionPostVM d)
        {
            return DeductionManager.Instance.PutDeduction(d);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="deductionId"></param>
        /// <param name="hrApprov"></param>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpPut]
        [AcceptVerbs("GET", "POST")]
        public dynamic PutDeductionForApprov(int deductionId,
            bool hrApprov,
            int userId
            )
        {
            return DeductionManager.Instance.PutDeductionForApprov(deductionId, hrApprov, userId);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="deductionId"></param>
        /// <returns></returns>
        [HttpDelete]
        [AcceptVerbs("GET", "POST")]
        public dynamic DeleteDeduction(int deductionId)
        {
            return DeductionManager.Instance.DeleteDeduction(deductionId);
        }
        [HttpGet]
        private dynamic DeductionExists(int deductionId)
        {
            return DeductionManager.Instance.DeductionExists(deductionId);
        }



    }
}


using SmartGate.ElRwad.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SmartGate.ElRwad.ViewModel.HR;
using SmartGate.ElRwad.BLL.HR;

namespace SmartGate.ElRwad.WebAPI.Areas.HR.Controllers
{
    public class PermAbsentController : ApiController
    {
        enum OrderStatus { Order, AcceptedByManager, RefusedByManager, AcceptedByHr, RefusedByHr };
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public dynamic GetAllPermAbs()
        {
            return PermAbsentManager.Instance.GetAllPermAbs();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="monthID"></param>
        /// <param name="yearID"></param>
        /// <returns></returns>
        [HttpGet]
        public dynamic GetAllPermAbs(byte monthID, int yearID)
        {
            return PermAbsentManager.Instance.GetAllPermAbs(monthID, yearID);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="permAbsId"></param>
        /// <returns></returns>
        [HttpGet]
        public dynamic GetPermAbsById(int permAbsId)
        {
            return PermAbsentManager.Instance.GetPermAbsById(permAbsId);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="fromDate"></param>
        /// <param name="toDate"></param>
        /// <param name="orderStatusId"></param>
        /// <returns></returns>
        [HttpGet]
        public dynamic GetPermAbsByDate(DateTime fromDate, DateTime toDate, int orderStatusId)
        {
            return PermAbsentManager.Instance.GetPermAbsByDate(fromDate, toDate, orderStatusId);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="listPermAbs"></param>
        /// <returns></returns>
        [HttpGet]
        public dynamic getPermAbs(List<Perm_Absent> listPermAbs)
        {
            return PermAbsentManager.Instance.getPermAbs(listPermAbs);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="fromDate"></param>
        /// <param name="toDate"></param>
        /// <param name="departmentId"></param>
        /// <param name="orderStatusId"></param>
        /// <returns></returns>
        [HttpGet]
        public dynamic GetPermAbsByDateAndDept(DateTime fromDate, DateTime toDate, int departmentId, int orderStatusId)
        {
            return PermAbsentManager.Instance.GetPermAbsByDateAndDept(fromDate, toDate, departmentId, orderStatusId);
        }/// <summary>
        /// 
        /// </summary>
        /// <param name="empId"></param>
        /// <param name="fromDate"></param>
        /// <param name="toDate"></param>
        /// <returns></returns>
        [HttpGet]

        public dynamic GetPermAbsByDateAndEmpId(int empId, DateTime fromDate, DateTime toDate)
        {
            return PermAbsentManager.Instance.GetPermAbsByDateAndEmpId(empId, fromDate, toDate);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="empId"></param>
        /// <param name="monthID"></param>
        /// <param name="yearID"></param>
        /// <returns></returns>
        [HttpGet]

        public dynamic GetPermAbsEmpId(int empId, byte monthID, int yearID)
        {
            return PermAbsentManager.Instance.GetPermAbsEmpId(empId, monthID, yearID);
        }
       


        /// <summary>
        /// 
        /// </summary>
        /// <param name="managerId"></param>
        /// <param name="month"></param>
        /// <param name="year"></param>
        /// <returns></returns>
        [HttpGet]

        public dynamic GetPermAbsForManager(PermAbsentForManagerVM p)
        {
            return PermAbsentManager.Instance.GetPermAbsForManager(p);
        }
        [HttpGet]

        public dynamic GetPermAbsForHr(PermAbsentForHrVM p)
        {
            return PermAbsentManager.Instance.GetPermAbsForHr(p);
        }


        [HttpPost]
        public dynamic PostPermAbsent(PermAbsentPVM p)
        {
            return PermAbsentManager.Instance.PostPermAbsent(p);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        [HttpPut]
        [AcceptVerbs("GET", "POST")]
        public dynamic PutPermAbs(PermAbsentPVM p)
        {
            return PermAbsentManager.Instance.PutPermAbs(p);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        [HttpPut]
        [AcceptVerbs("GET", "POST")]
        public dynamic putPermAbsByManager(PermAbsByVM p)
        {
            return PermAbsentManager.Instance.putPermAbsByManager(p);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        [HttpPut]
        [AcceptVerbs("GET", "POST")]
        public dynamic putPermAbsByHr(PermAbsByVM p)
        {
            return PermAbsentManager.Instance.putPermAbsByHr(p);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="permAbsId"></param>
        /// <returns></returns>
        [HttpDelete]
        [AcceptVerbs("GET", "POST")]
        public dynamic DeletePermAbs(int permAbsId)
        {
            return PermAbsentManager.Instance.DeletePermAbs(permAbsId);
        }




    }
}

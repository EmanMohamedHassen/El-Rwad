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
    public class MissionController : ApiController
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public dynamic GetAllMissions()
        {
            return MissionManager.Instance.GetAllMissions();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="monthID"></param>
        /// <param name="yearID"></param>
        /// <returns></returns>
        [HttpGet]
        public dynamic GetMissionsForHr(byte monthID, int yearID)
        {
            return MissionManager.Instance.GetMissionsForHr(monthID, yearID);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="monthID"></param>
        /// <param name="yearID"></param>
        /// <returns></returns>
        [HttpGet]
        public dynamic GetMissions(byte monthID, int yearID)
        {
            return MissionManager.Instance.GetMissions(monthID, yearID);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="missionId"></param>
        /// <returns></returns>
        [HttpGet]

        public dynamic GetMissionById(int missionId)
        {
            return MissionManager.Instance.GetMissionById(missionId);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="fromDate"></param>
        /// <param name="toDate"></param>
        /// <returns></returns>
        [HttpGet]

        public dynamic GetMissionByDate(DateTime fromDate, DateTime toDate)
        {
            return MissionManager.Instance.GetMissionByDate(fromDate, toDate);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="empId"></param>
        /// <param name="fromDate"></param>
        /// <param name="toDate"></param>
        /// <returns></returns>
        [HttpGet]

        public dynamic GetMissionByDateAndEmpId(int empId, DateTime fromDate, DateTime toDate)
        {
            return MissionManager.Instance.GetMissionByDateAndEmpId(empId, fromDate, toDate);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="categoryId"></param>
        /// <param name="fromDate"></param>
        /// <param name="toDate"></param>
        /// <returns></returns>
        [HttpGet]

        public dynamic GetMissionByDateAndCategory(int categoryId, DateTime fromDate, DateTime toDate)
        {
            return MissionManager.Instance.GetMissionByDateAndCategory(categoryId, fromDate, toDate);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="departmentId"></param>
        /// <param name="fromDate"></param>
        /// <param name="toDate"></param>
        /// <returns></returns>
        [HttpGet]

        public dynamic GetMissionByDateAndDepartment(int departmentId, DateTime fromDate, DateTime toDate)
        {
            return MissionManager.Instance.GetMissionByDateAndDepartment(departmentId, fromDate, toDate);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="empId"></param>
        /// <param name="departmentId"></param>
        /// <param name="fromDate"></param>
        /// <param name="toDate"></param>
        /// <returns></returns>
        [HttpGet]

        public dynamic GetMissionByDateAndEmpIdAndDept(int empId, int departmentId, DateTime fromDate, DateTime toDate)
        {
            return MissionManager.Instance.GetMissionByDateAndEmpIdAndDept(empId, departmentId, fromDate, toDate);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        [HttpPost]
        public dynamic PostMission(MissionPVM m)
        {
            return MissionManager.Instance.PostMission(m);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="m"></param>
        /// <returns></returns>
        [HttpPut]
        [AcceptVerbs("GET", "POST")]
        public dynamic PutMission(MissionPVM m)
        {
            return MissionManager.Instance.PutMission(m);
        }

        [HttpPut]
        [AcceptVerbs("GET", "POST")]
        public dynamic PutForApprov(MissionAVM m)
        {
            return MissionManager.Instance.PutForApprov(m);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="missionId"></param>
        /// <returns></returns>
        [HttpDelete]
        [AcceptVerbs("GET", "POST")]
        public dynamic DeleteMission(int missionId)
        {
            return MissionManager.Instance.DeleteMission(missionId);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="missionDate"></param>
        /// <param name="empId"></param>
        /// <returns></returns>
        [HttpGet]
        private dynamic MissionExists(DateTime missionDate, int empId)
        {
            return MissionManager.Instance.MissionExists(missionDate, empId);
        }



    }
}

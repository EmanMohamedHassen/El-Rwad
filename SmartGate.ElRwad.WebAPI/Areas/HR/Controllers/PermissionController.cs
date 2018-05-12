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
    public class PermissionController : ApiController
    {
        private elRwadEntities db = new elRwadEntities();

        enum OrderStatus { Order, AcceptedByManager, RefusedByManager, AcceptedByHr, RefusedByHr };
        /// <summary>
        /// get permission properties
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public dynamic GetPermission()
        {
            return PermissionManager.Instance.GetPermission();
            
        }


        /// <summary>
        /// get permission by month id and year id 
        /// </summary>
        /// <param name="monthID"></param>
        /// <param name="yearID"></param>
        /// <returns></returns>
        [HttpGet]
        public dynamic GetPermission(byte monthID, int yearID)
        {
            return PermissionManager.Instance.GetPermission(monthID, yearID);
        }
        /// <summary>
        /// get permission by id 
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        [HttpGet]
        public dynamic GetPermissionById(int orderId)
        {
            return PermissionManager.Instance.GetPermissionById(orderId);
        }


        /// <summary>
        /// get permission by date 
        /// </summary>
        /// <param name="fromDate"></param>
        /// <param name="toDate"></param>
        /// <param name="orderStatusId"></param>
        /// <returns></returns>
        [HttpGet]
        public dynamic GetPermissionByDate(DateTime fromDate, DateTime toDate, int orderStatusId)
        {
            return PermissionManager.Instance.GetPermissionByDate(fromDate, toDate, orderStatusId);
        }

      /*  public dynamic getPerm(List<HR_Leave_Order> listPerm)
        {
            var returnPerm = listPerm.Select(s => new
            {
                orderId = s.Order_ID,
                orderDate = s.Order_Date.Value.Year.ToString() + "-" + s.Order_Date.Value.Month.ToString() + "-" + s.Order_Date.Value.Day.ToString(),
                leaveTypeId = s.LeaveType_ID,
                employeeId = s.Employee_ID,
                empCode = s.Employee.Employee_Code,
                leaveTypeName = s.PermissionType.PermissionType_Name,
                employeeName = s.Employee.FullName,
                leaveHours = s.Leave_Hours,
                acceptedById = s.AccpetedBy_ID,
                fromHour = s.From_Hour,
                fromMinute = s.From_Minute,
                toHour = s.To_Hour,
                toMinute = s.To_Minute,
                permissionCause = s.Permission_Causes,
                dayOrNight = s.DayOrNight.ToString(),
                orderStatusId = s.OrderStatu.Id,
                orderStatusName = s.OrderStatu.StatusAr,
                approveDate = s.Approv_Date.Value.Year.ToString() + "-" + s.Approv_Date.Value.Month.ToString() + "-" + s.Approv_Date.Value.Day.ToString(),
                userId = s.User_ID,
                lastUpdate = s.Last_Update.Value.Year.ToString() + "-" + s.Last_Update.Value.Month.ToString() + "-" + s.Last_Update.Value.Day.ToString()

            }).ToList();
            return returnPerm;
        }*/
        /// <summary>
        /// get permission by date and department
        /// </summary>
        /// <param name="fromDate"></param>
        /// <param name="toDate"></param>
        /// <param name="departmentId"></param>
        /// <param name="orderStatusId"></param>
        /// <returns></returns>
        [HttpGet]
        public dynamic GetPermissionByDateAndDept(DateTime fromDate, DateTime toDate, int departmentId, int orderStatusId)
        {
            return PermissionManager.Instance.GetPermissionByDateAndDept(fromDate, toDate, departmentId, orderStatusId);
        }
        /// <summary>
        /// get permission by date and employee id
        /// </summary>
        /// <param name="empId"></param>
        /// <param name="fromDate"></param>
        /// <param name="toDate"></param>
        /// <returns></returns>
        [HttpGet]
        public dynamic GetPermissionByDateAndEmpId(int empId, DateTime fromDate, DateTime toDate)
        {
            return PermissionManager.Instance.GetPermissionByDateAndEmpId(empId, fromDate, toDate);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="empId"></param>
        /// <param name="year"></param>
        /// <param name="monthID"></param>
        /// <returns></returns>
        [HttpGet]
        public dynamic GetPermissionByEmpId(int empId, int year, byte monthID)
        {
            return PermissionManager.Instance.GetPermissionByEmpId(empId, year, monthID);
        }

       /// <summary>
       /// get permission 
       /// </summary>
       /// <param name="managerId"></param>
       /// <param name="year"></param>
       /// <param name="monthId"></param>
       /// <returns></returns>
        [HttpGet]
        public dynamic GetPermForManager(int managerId, int year, int monthId)
        {
            return PermissionManager.Instance.GetPermForManager(managerId, year, monthId);
        }
        /// <summary>
        /// get permission for hr 
        /// </summary>
        /// <param name="year"></param>
        /// <param name="monthId"></param>
        /// <returns></returns>
        [HttpGet]
        public dynamic GetPermForHr(int year, int monthId)
        {
            return PermissionManager.Instance.GetPermForHr(year, monthId);
        }


        /// <summary>
        /// post permission
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>

        [HttpPost]
        public dynamic PostPermission(PermissionPVM p)
        {
            return PermissionManager.Instance.PostPermission(p);
        }
        /// <summary>
        /// put permission
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        [HttpPut]
        [AcceptVerbs("GET", "POST")]
        public dynamic PutPermission(PermissionPVM p )
        {
            return PermissionManager.Instance.PutPermission(p);
        }

        /// <summary>
        /// put permission by manager
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        [HttpPut]
        [AcceptVerbs("GET", "POST")]
        public dynamic PutPermissionbymanager(putPermission p)
        {
            return PermissionManager.Instance.PutPermissionbymanager(p);
        }
        /// <summary>
        /// put permission by hr
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        //for Hr to accept and refuse
        [HttpPut]
        [AcceptVerbs("GET", "POST")]
        public dynamic PutPermissionbyHr(putPermission p)
        {
            return PermissionManager.Instance.PutPermissionbyHr(p);
        }


        [HttpDelete]
        [AcceptVerbs("GET", "POST")]
        public dynamic DeletePermission(int permissionId)
        {
            return PermissionManager.Instance.DeletePermission(permissionId);

        }
        [HttpGet]

        private dynamic PermissionExists(DateTime orderDate, int empId)
        {
            return PermissionManager.Instance.PermissionExists(orderDate, empId);
        }



    }
}

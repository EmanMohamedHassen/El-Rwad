using SmartGate.ElRwad.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using SmartGate.ElRwad.BLL.HR;
using SmartGate.ElRwad.ViewModel.HR;
namespace SmartGate.ElRwad.WebAPI.Areas.HR.Controllers
{
    //[EnableCors(origins: "*", headers: "*", methods: "*", exposedHeaders: "X-My-Header")]
    public class EmployeesController : ApiController
    {
       /// <summary>
       /// 
       /// </summary>
       /// <returns></returns>
        [HttpGet]
        public object GetEmployees()
        {
            return EmployeeManager.Instance.GetEmployees();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="isActive"></param>
        /// <returns></returns>
        // public dynamic Get all Employees by is acative
        [HttpGet]
        public dynamic GetEmployeesByIsActive(bool isActive)
        {
            return EmployeeManager.Instance.GetEmployeesByIsActive(isActive);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        // public dynamic Get all active  Employees
        [HttpGet]
        public dynamic GetActiveEmployees()
        {
            return EmployeeManager.Instance.GetActiveEmployees();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="empId"></param>
        /// <returns></returns>
        [HttpGet]
        public dynamic GetEmployeeById(int empId)
        {
            return EmployeeManager.Instance.GetEmployeeById(empId);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="empName"></param>
        /// <returns></returns>
        [HttpGet]

        public dynamic GetEmployeeByEmpName(string empName)
        {
            return EmployeeManager.Instance.GetEmployeeByEmpName(empName);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="empPrintCode"></param>
        /// <returns></returns>
        [HttpGet]

        public dynamic GetEmployeeByEmpPrintCode(string empPrintCode)
        {
            return EmployeeManager.Instance.GetEmployeeByEmpPrintCode(empPrintCode);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="jobId"></param>
        /// <returns></returns>
        [HttpGet]

        public object GetEmployeesByJobId(int jobId)
        {
            return EmployeeManager.Instance.GetEmployeesByJobId(jobId);
        }
        [HttpGet]


        public object GetEmployeesByDepartmentId(int departmentId)
        {
            return EmployeeManager.Instance.GetEmployeesByDepartmentId(departmentId);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="BranchId"></param>
        /// <returns></returns>
        [HttpGet]

        public object GetEmployeesByBranchId(int BranchId)
        {
            return EmployeeManager.Instance.GetEmployeesByBranchId(BranchId);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="CategoryId"></param>
        /// <returns></returns>
        [HttpGet]

        public object GetEmployeesByCategoryId(int CategoryId)
        {
            return EmployeeManager.Instance.GetEmployeesByCategoryId(CategoryId);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="DeputationId"></param>
        /// <returns></returns>
        [HttpGet]

        public object GetEmployeesByDeputationId(int DeputationId)
        {
            return EmployeeManager.Instance.GetEmployeesByDeputationId(DeputationId);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ShiftId"></param>
        /// <returns></returns>
        [HttpGet]

        public object GetEmployeesByShiftId(int ShiftId)
        {
            return EmployeeManager.Instance.GetEmployeesByShiftId(ShiftId);
        }

        [HttpPost]
        public dynamic PostEmployee(EmployeePostVM e)
        {
            return EmployeeManager.Instance.PostEmployee(e);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [AcceptVerbs("GET", "POST")]
        public dynamic PutEmployee(EmployeePutVM e)
        {
            return EmployeeManager.Instance.PutEmployee(e);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="empId"></param>
        /// <returns></returns>
        [HttpDelete]
        [AcceptVerbs("GET", "POST")]
        public dynamic DeleteEmployee(int empId)
        {
            return EmployeeManager.Instance.DeleteEmployee(empId);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="empId"></param>
        /// <returns></returns>
        [HttpGet]
        private dynamic EmployeeExists(int empId)
        {
            return EmployeeManager.Instance.EmployeeExists(empId);
        }


    }
}

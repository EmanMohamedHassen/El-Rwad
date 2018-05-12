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
    public class VacationOrdersController : ApiController
    {

        enum OrderStatus { Order, AcceptedByManager, RefusedByManager, AcceptedByHr, RefusedByHr };
        [HttpGet]
        public dynamic GetVacation()
        {
            return VacationOrdersManager.Instance.GetVacation();

        }
        //Get all
        [HttpGet]
        public dynamic GetVacation(byte monthID, int yearID)
        {

            return VacationOrdersManager.Instance.GetVacation(monthID, yearID);

        }

        [HttpGet]
        public dynamic GetVacationById(int vacationId)
        {
            return VacationOrdersManager.Instance.GetVacationById(vacationId);
        }

        [HttpGet]
        public dynamic GetVacationByDate(DateTime fromDate, DateTime toDate, int statusId)
        {
            return VacationOrdersManager.Instance.GetVacationByDate(fromDate, toDate, statusId);
        }
        [HttpGet]
      
        public dynamic GetVacationsByDateAndDept(DateTime fromDate, DateTime toDate, int departmentId, int statusId)
        {
            return VacationOrdersManager.Instance.GetVacationsByDateAndDept(fromDate, toDate, departmentId, statusId);

        }

        [HttpGet]
        public dynamic GetVacationByDateAndEmpId(int empId, DateTime fromDate, DateTime toDate)
        {
            return VacationOrdersManager.Instance.GetVacationByDateAndEmpId(empId, fromDate, toDate);
        }

        [HttpGet]
        public dynamic GetVacationByEmpId(int empId, int year, byte monthID)
        {
            return VacationOrdersManager.Instance.GetVacationByEmpId(empId, year, monthID);

        }

        //public dynamic GetTest(int empId, DateTime fromDate, DateTime toDate)
        //{
        //    List<Vacations_Orders> listVacationOrder = db.Vacations_Orders.Where(e => e.Employee_ID == empId &&
        //       ((e.From_Date >= fromDate.Date && e.From_Date <= toDate.Date) || (e.To_Date >= fromDate.Date && e.To_Date <= toDate.Date))).ToList();

        //    List<Vacations_Orders> list_Results = new List<Vacations_Orders>();

        //    list_Results.AddRange(getReturnVacations(listVacationOrder, (int)OrderStatus.AcceptedByManager));
        //    list_Results.AddRange(getReturnVacations(listVacationOrder, (int)OrderStatus.AcceptedByHr));
        //    list_Results.AddRange(getReturnVacations(listVacationOrder, (int)OrderStatus.RefusedByHr));

        //    List<Vacations_Orders> distinct = list_Results.Distinct().ToList();

        //    return distinct;

        //}

        //لتقرير رصيد الاجازات  
        //By Eng.Eman
        [HttpGet]
        public dynamic GetVacationForEmp(int empId, int year)
        {
            return VacationOrdersManager.Instance.GetVacationForEmp(empId, year);

        }


        //return vacations with status id 
        [HttpGet]
        

        //To Get vacation orders for manager to take actions in it
        public dynamic GetForManager(int managerId, int year, byte monthID)
        {
            return VacationOrdersManager.Instance.GetForManager(managerId, year, monthID);
        }
        //To Get vacation orders which manager accepted for Hr to take actions in it
        [HttpGet]
        public dynamic GetForHr(int year, byte monthID)
        {
            return VacationOrdersManager.Instance.GetForHr(year, monthID);
        }




        [HttpPost]
        public dynamic PostVacation(VacationOrderPVM p)
        {
            return VacationOrdersManager.Instance.PostVacation(p);
        }

        [HttpPut]
        [AcceptVerbs("GET", "POST")]
        public dynamic PutVacation(VacationOrderPVM p)
        {
            return VacationOrdersManager.Instance.PutVacation(p);
        }

        //for manager to accept and refuse 
        [HttpPut]
        [AcceptVerbs("GET", "POST")]
        public dynamic PutVacationbyManager(putVacationVM p)
        {
            return VacationOrdersManager.Instance.PutVacationbyManager(p);
        }
        [HttpPut]
        [AcceptVerbs("GET", "POST")]
        public dynamic PutVacationbyHr(putVacationVM p)
        {
            return VacationOrdersManager.Instance.PutVacationbyHr(p);
        }
        [HttpDelete]
        [AcceptVerbs("GET", "POST")]
        public dynamic DeleteVacation(int vacationId)
        {
            return VacationOrdersManager.Instance.DeleteVacation(vacationId);
        }
        [HttpGet]
        private dynamic VacationExists(DateTime fromDate, DateTime toDate, int empId)
        {
            return VacationOrdersManager.Instance.VacationExists(fromDate, toDate, empId);
        }

    }

 
}


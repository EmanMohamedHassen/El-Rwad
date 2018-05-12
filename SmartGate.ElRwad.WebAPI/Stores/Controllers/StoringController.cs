using SmartGate.ElRwad.BLL.Stores;
using SmartGate.ElRwad.DAL;
using SmartGate.ElRwad.ViewModel.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SmartGate.ElRwad.WebAPI.Areas.Stores.Controllers
{
    public class StoringController : ApiController
    {
        private elRwadEntities db = new elRwadEntities();

        [HttpGet]
        public dynamic GetAllAddingPermission()
        {
            
            return StoringManager.Instance.GetAllAddingPermission();
        }

        [HttpGet]
        public dynamic GetAllAddingPermissionDetails()
        {
            return StoringManager.Instance.GetAllAddingPermission();
        }

        [HttpGet]
        public dynamic GetAddingPermissionById(int id)
        {
            return StoringManager.Instance.GetAddingPermissionById(id);
        }

        [HttpGet]
        public dynamic GetAddingPermissionDetailsById(int id)
        {
            return StoringManager.Instance.GetAddingPermissionDetailsById(id);
        }

        //تقرير اذن اضافة
        [HttpGet]
        public dynamic GetAddingPermissionByDate(DateTime fromDate, DateTime toDate)
        {
            return StoringManager.Instance.GetAddingPermissionByDate(fromDate, toDate);
        }
        //تفاصيل اذن الاضافة
        [HttpGet]
        public dynamic GetAddingPermissionReport(int id)
        {
            return StoringManager.Instance.GetAddingPermissionReport(id);
        }

        //بيان جرد تفصيلى 
        [HttpGet]
        public dynamic GetDetailedInventoryReport(Storing_DetailsVM d)
        {
            return StoringManager.Instance.GetDetailedInventoryReport(d);
        }

        //بيان جرد اجمالى
        [HttpGet]
        public dynamic GetTotalInventoryReport(Storing_DetailsVM d)
        {
            return StoringManager.Instance.GetTotalInventoryReport(d);
        }



        [HttpPost]
        public dynamic PostAddingPermission(PermissionVM p)
        {
            return StoringManager.Instance.PostAddingPermission(p);
        }

        [HttpPost]
        public dynamic PostAddingPermissionDetails(PermissionDetailsVM p)
        {
            return StoringManager.Instance.PostAddingPermissionDetails(p);
        }

        [HttpPut]
        [AcceptVerbs("GET", "POST")]
        public dynamic PutAddingPermission(PermissionVM p)
        {
            return StoringManager.Instance.PutAddingPermission(p);
        }

        [HttpPut]
        [AcceptVerbs("GET", "POST")]
        public dynamic PutAddingPermissionDetails(PermissionDetailsVM p)
        {
            return StoringManager.Instance.PutAddingPermissionDetails(p);
        }

        [HttpDelete]
        [AcceptVerbs("GET", "POST")]
        public dynamic DeleteAddingPermission(int id)
        {
            return StoringManager.Instance.DeleteAddingPermission(id);
        }

        [HttpDelete]
        [AcceptVerbs("GET", "POST")]
        public dynamic DeleteAddingPermissionDetails(int id)
        {
            return StoringManager.Instance.DeleteAddingPermissionDetails(id);
        }




    }
}
